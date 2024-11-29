namespace Knv.MRLY240314
{
    using System;
    using System.Windows.Forms;
    using Events;
    using IO;
    using System.ComponentModel;
    using System.Threading;
    using Knv.MRLY240314.Properties;
    using System.IO.Ports;
    using System.Linq;
    using System.Diagnostics;
    using System.Collections.Generic;
    using NUnit.Framework.Internal;

    public interface IApp
    {
        void Run();
        void Stop();
    }

    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new App();
        }

        class App:IApp
        {
            readonly IMainForm _mainForm;
            readonly SynchronizationContext _uiContext;
            readonly AutoResetEvent _autoResetEvent;
            readonly E8782A_CardTester _cardTester;
            readonly BackgroundWorker _worker;         
            readonly Stopwatch _stopwatch;
            bool _stopFlag = false;
            bool _pauseFlag = false;
            DateTime _startTimestamp;
            string _logFilePath;
            StepsView _stepsView;

            public App()
            {
                try
                {
                    _mainForm = new MainForm();
                    _mainForm.Text = AppConstants.SoftwareTitle;
                    _mainForm.Shown += MainForm_Shown;
                    _mainForm.FormClosed += MainForm_FormClosed;
                    _uiContext = SynchronizationContext.Current;
                    _worker = new BackgroundWorker();
                    _worker.WorkerSupportsCancellation = true;
                    _autoResetEvent = new AutoResetEvent(false);
                    _cardTester = new E8782A_CardTester();
                    _stopwatch = new Stopwatch();
                    _stepsView = new StepsView();

                    if (string.IsNullOrEmpty(Settings.Default.ReportDirectory))
                        Settings.Default.ReportDirectory = AppConstants.ReportDirectory;

                    Connection.Instance.TracingEnable = true;
                    Connection.Instance.ConnectionChanged += (o, e) =>
                    {
                        bool isOpen = Connection.Instance.IsOpen;
                        EventAggregator.Instance.Publish(new ConnectionChangedAppEvent(isOpen));
                        //--- ha sikerül a csatlakozás, akkor az FPGA transzparensé tesszük igy közvetlenül elérhető a relélánc ---
                        if (isOpen)
                        {
                            Connection.Instance.SetFpgaBypass(true);
                            //--- itt már él a kapcsolat és valószínüleg be tudjuk azonosítani a kártyát ---
                            //--- Létrehozom a tesztek listáját ---
                            _cardTester.MakeSteps();
                            //--- Átmásolom a teszteket a View osztályba...---
                            foreach (var step in _cardTester.Steps)
                            {
                                _stepsView.Add(new StepViewItem()
                                {
                                    StepItem = step,
                                    Name = $"{step.RelayName}__{step.CaseName}",
                                    Measured = "?",
                                    LowLimit = $"{step.LowLimit}",
                                    HighLimit = $"{step.HighLimit}",
                                });
                            }
                        }
                        else
                        {
                            Action syncMethod = () =>
                            {  
                                _stepsView.Clear();
                            };

                            if (_uiContext != null)
                                _uiContext.Post((e1) => { syncMethod(); }, null);
                            else
                                syncMethod();
                        }
                          
                    };

                    _mainForm.ReadFpgaRegisters += (o, e) =>
                    {
                        Connection.Instance.SetFpgaBypass(false);
                        Connection.Instance.ReadRegisters();
                        Connection.Instance.SetFpgaBypass(true);
                    };
                    _mainForm.RunChainCheck += (o, e) => Connection.Instance?.RunChainCheck();

                    //--- Main Menu ---
                    #region Main Menu
                    _mainForm.MenuBar = new ToolStripItem[]
                    {
                    new Commands.ComPortSelectCommand(),
                    new Commands.ConnectCommand(),
                    new Commands.RunCommand(this),
                    new Commands.StopCommand(this),
                    new Commands.OpenLastReport(),

                    new Commands.SettingsCommand(_mainForm),
                    new Commands.AlwaysOnTopCommand(_mainForm),
                    new Commands.HowIsWorkingCommand(),

                    };
                    #endregion

                    //--- StatusBar ---
                    #region StatusBar
                    _mainForm.StatusBar = new ToolStripItem[]
                    {
                    new StatusBar.WhoIs(),
                    new StatusBar.FwVersion(),
                    new StatusBar.UpTime(),
                    new StatusBar.Uid(),
                    new StatusBar.TestProgressStatus(),
                    new StatusBar.TestResultStatus(),
                    new StatusBar.ElapsedTimeStatus(),
                    new StatusBar.EmptyStatus(),
                    new StatusBar.Version(),
                    new StatusBar.Logo(),
                    };
                    #endregion


                    //--- A logolás Queue-ba történik, majd itt frissítem az UI-ra ---
                    _worker.DoWork += (o, e) =>
                    {
                        do
                        {
                            _uiContext.Post(UiUpdate, null);
                            Thread.Sleep(100);

                        } while (_worker.CancellationPending != true);

                        if (_worker.CancellationPending)
                        {
                            e.Cancel = true;
                            _autoResetEvent.Set();
                        }
                    };

                    _worker.RunWorkerAsync();

                    //--- Run ---
                    Application.Run((MainForm)_mainForm);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}\r\n{ex.StackTrace}", AppConstants.SoftwareTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            /// <summary>
            /// A teszt indítása
            /// </summary>
            public void Run()
            {

                _mainForm.Tracing?.AppendText("User:Run");
                _startTimestamp = DateTime.Now;
                _cardTester.Reset();
                _stopFlag = false;

                foreach (var step in _stepsView)
                {
                    step.Result = "-";
                    step.Measured = "-";
                }

                _mainForm.GridRefresh();

                Action action = () => { ExecuteTheCaseItems(); };
                action.BeginInvoke( new AsyncCallback(OnTestCompleted), null );
                _stopwatch.Start();

                EventAggregator.Instance.Publish(new TestCompletedAppEvent()
                {
                    TestResult = "RUNNING",
                });

            }

            /// <summary>
            /// A teszt végén lefut bármi is történik.
            /// </summary>
            /// <param name="result">nem használom...</param>
            void OnTestCompleted(IAsyncResult result)
            {
                _stopwatch.Stop();

                double sec = _stopwatch.Elapsed.TotalSeconds;
                string version = Connection.Instance.GetVersion();
                string uid = Connection.Instance.UniqeId();
                var totalPassed = _cardTester.Steps.Count(i => i.Result == "PASSED");
                var totalFailed = _cardTester.Steps.Count(i => i.Result == "FAILED");

                //--- Ha nem szakitotta meg a tesztet a User és tesztek száma egyezik a PASSED számával, akkor PASSED a teszt eredménye ---
                string testResult = "-";
                if (!_stopFlag)
                    testResult = (totalPassed == _cardTester.Steps.Count()) ? "PASSED" : "FAILED";
                else
                    testResult = "ABORT";

                var parameterLines = new List<string>()
                {
                    $"Test Result: { testResult }",
                    $"Total Steps: { _cardTester.Steps.Count() }",
                    $"Total Passed: { totalPassed }",
                    $"Total Failed: { totalFailed }",
                    $"Start Timestamp: {_startTimestamp}",
                    $"Elapased Time: {sec:F3}",
                    $"Measurement Delay Time:{Settings.Default.MeasurementDelayTimeMs}ms",
                    $"FW Version: {version}",
                    $"UID:{uid}"
                };

                _logFilePath = _cardTester.MakeCsvReport(Settings.Default.ReportDirectory, _startTimestamp, uid, testResult, parameterLines);
                _stopwatch.Restart();

                Connection.Instance.Trace($"Log Path: {_logFilePath}");

                Action syncMethod = () =>
                {
                    EventAggregator.Instance.Publish(new TestCompletedAppEvent()
                    {
                        TestResult = testResult,
                        ElapsedTime = $"{sec:F3}",
                        TotalSteps = $"{_cardTester.Steps.Count()}",
                        TotalPassed = $"{totalPassed}",
                        TotalFailed = $"{totalFailed}",
                    });
                };

                if (_uiContext != null)
                    _uiContext.Post((e1) => { syncMethod(); }, null);
                else
                    syncMethod();

            }

            public void Stop()
            {
                _mainForm.Tracing?.AppendText("User:Stop");
                _stopFlag = true;
            }

            void ExecuteTheCaseItems()
            {
                StepItem step = null;
                try
                {
                    //--- amig van teszt, addig nem null ---
                    while ((step = _cardTester.NextStep()) != null)
                    {
                        if (Connection.Instance.IsOpen)
                        {
                            Connection.Instance.SetChain(step.GetStringOfRelayChain());
                            Thread.Sleep(Settings.Default.MeasurementDelayTimeMs);
                            step.Measured = Connection.Instance.MeasureResistance();

                            //--- Ez a rész CSAK a grid-es megjeleíntésért felelős... a riport külön értékel ---
                            var stepView = _stepsView.FirstOrDefault(i => i.StepItem == step);
                            if (stepView != null)
                            {
                                stepView.Measured = $"{step.Measured:F3}";
                                stepView.Result = step.Result;
                            }
                        }
                        //--- User megszakította a tesztet ---
                        if (_stopFlag)
                            break;
                    }
                }
                catch (Exception ex) 
                {  
                    Connection.Instance.Trace($"Program.cs.ExecuteTheCaseItems().Error: {ex.Message}");
                } 
            }

            /// <summary>
            /// Az Ui frissjtés már az Ui szálon
            /// </summary>
            void UiUpdate(object something)
            {
                //--- időközönként ráfrisssitek a Grid-re hogy látszódjanak a beírt értékek... biztos van jobb megoldás is ---
                _mainForm.GridRefresh();

                //--- időközönként elküldöm az ui-ra hogy hol jár a teszt ---
                EventAggregator.Instance.Publish(new TestProgressAppEvent()
                {
                    TotalSteps = $"{_cardTester.Steps.Count}",
                    CurrentStepIndex = $"{_cardTester.GetCurrentTestPointer}"
                });

                //--- Tracing Update ---
                for (int i = 0; Connection.Instance.TraceQueue.Count != 0; i++)
                {
                    string str = Connection.Instance.TraceQueue.Dequeue();
                    _mainForm.Tracing?.AppendText(str);
                   
                }
            }

            private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
            {
                Settings.Default.Save();
            }

            private void MainForm_Shown(object sender, EventArgs e)
            {
                EventAggregator.Instance.Publish(new ShowAppEvent());

                _mainForm.DataSource = _stepsView;

                //--- Auto connect ---
                if (Settings.Default.SeriaPortName != null)
                {
                    if (Settings.Default.ConnectOnStart)
                    {
                        if (SerialPort.GetPortNames().Contains(Settings.Default.SeriaPortName))
                        { 
                            Connection.Instance.Open(Settings.Default.SeriaPortName);
                        }
                    }
                }
            }
        }
    }

    
}
