

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
                _cardTester.MakeTestSteps();
                _stopwatch = new Stopwatch();
               
               

                _mainForm.FpgaBypassChanged += (o, enabled) => Connection.Instance?.SetFpgaBypass(enabled);
                Connection.Instance.TracingEnable = true;
                Connection.Instance.ConnectionChanged += (o, e) => EventAggregator.Instance.Publish(new ConnectionChangedAppEvent(Connection.Instance.IsOpen));
                _mainForm.ReadFpgaRegisters += (o, e) => Connection.Instance.ReadRegisters();
                _mainForm.RunChainCheck += (o, e) => Connection.Instance?.RunChainCheck();

                //*** Main Menu ***
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

                //*** StatusBar ***
                #region StatusBar
                _mainForm.StatusBar = new ToolStripItem[]
                {
                    new StatusBar.WhoIs(),
                    new StatusBar.FwVersion(),
                    new StatusBar.UpTime(),
                    new StatusBar.EmptyStatus(),
                    new StatusBar.Version(),
                    new StatusBar.Logo(),
                };
                #endregion


                //*** Fuctions ****
                long startUpdateRateTick = DateTime.Now.Ticks;
                int responseCnt = 0;
                int temp;
                _worker.DoWork += (o, e) =>
                {
                    do
                    {
                        try
                        {
                            if (Connection.Instance.IsOpen)
                            {
                                if (DateTime.Now.Ticks - startUpdateRateTick >= 1000 * 10000)
                                {
                                    temp = responseCnt;
                                    _uiContext.Post(UiUpdate, null);
                                    responseCnt = 0;
                                    startUpdateRateTick = DateTime.Now.Ticks;
                                }
                                else
                                {
                                    responseCnt++;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Read Error: {ex.Message}");
                        }


                        Thread.Sleep(100);

                    } while (_worker.CancellationPending != true);

                    if (_worker.CancellationPending)
                    {
                        e.Cancel = true;
                        _autoResetEvent.Set();
                    }
                };

                _worker.RunWorkerAsync();

                //*** Run ***
                Application.Run((MainForm)_mainForm);
            }

            public void Run()
            {
                _mainForm.Tracing?.AppendText("User:Run");
                _startTimestamp = DateTime.Now;
                _cardTester.Reset();
                Action action = () => { ExecuteTheCaseItems(); };
                action.BeginInvoke( new AsyncCallback(OnTestCompleted), null );
                _stopwatch.Start();

            }

            void OnTestCompleted(IAsyncResult result)
            {
                _stopwatch.Stop();

                double sec = _stopwatch.Elapsed.TotalSeconds;

                var parameterLines = new List<string>()
                {
                    $"Start Timestamp:{_startTimestamp}",
                    $"Elapased Time: {sec:F3}",
                 //   $"FW Version: {Connection.Instance.GetVersion()}",
                 //   $"UID:{Connection.Instance.UniqeId()}" 
                };

                _logFilePath = _cardTester.MakeCsvReport(AppConstants.LogDirectory, _startTimestamp, "card_id", parameterLines);
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
                stepItem caseItem = null;
                try
                {
                    while ((caseItem = _cardTester.NextStep()) != null)
                    {
                        if (Connection.Instance.IsOpen)
                        {
                            Connection.Instance.SetChain(caseItem.GetStringOfRelayChain());
                            Thread.Sleep(Settings.Default.MeasurementDelayTimeMs);
                            caseItem.Measured = Connection.Instance.MeasureResistance();
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
                //*** Tracing Update ***
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
                //*** Auto connect ***
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
