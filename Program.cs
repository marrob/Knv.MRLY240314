

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

            StepsView _stepViews;

            public App()
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
                _stepViews = new StepsView();
              
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
                            var stepView = new StepViewItem();
                            stepView.StepItem = step;
                            stepView.Name = $"{step.RelayName}__{step.CaseName}";
                            stepView.Measured = "?";
                            stepView.LowLimit = $"{step.LowLimit}";
                            stepView.HighLimit = $"{step.HighLimit}";
                            _stepViews.Add(stepView);
                        }
                    }
                    else
                    {
                        _stepViews.Clear();
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
                    new Commands.HowIsWorkingCommand(),
                    new Commands.AlwaysOnTopCommand(_mainForm),
                    new Commands.SettingsCommand(_mainForm),
                    new Commands.RunCommand(this),
                    new Commands.StopCommand(this)
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

            public void Run()
            {
                _mainForm.Tracing?.AppendText("User:Run");
                _startTimestamp = DateTime.Now;
                _cardTester.Reset();

                foreach (var step in _stepViews)
                {
                    step.Result = "-";
                    step.Measured = "-";
                }


                Action action = () => { ExecuteTheCaseItems(); };
                action.BeginInvoke( new AsyncCallback(OnTestCompleted), null );
                _stopwatch.Start();
            }

            void OnTestCompleted(IAsyncResult result)
            {
                _stopwatch.Stop();

                double sec = _stopwatch.Elapsed.TotalSeconds;
                string version = Connection.Instance.GetVersion();
                string uid = Connection.Instance.UniqeId();

                var parameterLines = new List<string>()
                {
                    $"Start Timestamp:{_startTimestamp}",
                    $"Elapased Time: {sec:F3}",
                    $"FW Version: {version}",
                    $"UID:{uid}" 
                };

                _logFilePath = _cardTester.MakeCsvReport(AppConstants.LogDirectory, _startTimestamp, uid, parameterLines);
                _stopwatch.Restart();

                Connection.Instance.Trace($"Log Path: {_logFilePath}");
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
                            var viewItem = _stepViews.FirstOrDefault(i => i.StepItem == step);
                            if (viewItem != null)
                            {
                                viewItem.Measured = $"{step.Measured:F3}";
                                if (step.LowLimit <= step.Measured && step.Measured <= step.HighLimit)
                                    viewItem.Result = "PASSED";
                                else
                                    viewItem.Result = "FAILED";
                            }
                        }

                        if (_stopFlag)
                        {
                            _stopFlag = false;
                            break;
                        }
                    }
                }
                catch (Exception ex) 
                {  
                    Connection.Instance.Trace($"Program.cs.ExecuteTheCaseItems().Error: {ex.Message}");
                } 
            }

            void UiUpdate(object response)
            {
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

                _mainForm.DataSource = _stepViews;

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
