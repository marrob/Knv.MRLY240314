

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

    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new App();
        }

        class App
        {
            readonly IMainForm _mainForm;
            readonly SynchronizationContext _uiContext;
            readonly BackgroundWorker _worker;
            readonly AutoResetEvent _autoResetEvent;

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
                _mainForm.ReadFpgaRegisters += (o, e) =>
                {
                    Connection.Instance.ReadRegisters();
                };
                _mainForm.RunChainCheck += (o, e) =>
                {
                    Connection.Instance?.RunChainCheck();
                };
                _mainForm.SetChain += (o, e) =>
                {
                    Connection.Instance?.SetChain(new byte[0]);
                };

        

                Connection.Instance.TracingEnable = true;
                Connection.Instance.ConnectionChanged += (o, e) =>
                {
                    EventAggregator.Instance.Publish(new ConnectionChangedAppEvent(Connection.Instance.IsOpen));
                };


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


                        Thread.Sleep(100 );

                    } while (_worker.CancellationPending != true);

                    if (_worker.CancellationPending)
                    {
                        e.Cancel = true;
                        _autoResetEvent.Set();
                    }
                };

                _worker.RunWorkerAsync();

                //*** Main Menu ***
                #region Main Menu
                _mainForm.MenuBar = new ToolStripItem[]
                {
                    new Commands.ComPortSelectCommand(),
                    new Commands.ConnectCommand(),
                    new Commands.HowIsWorkingCommand(),
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

                //*** Run ***
                Application.Run((MainForm)_mainForm);
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
                    if (/*Settings.Default.ConnectOnStart*/ true)
                    {
                        if (SerialPort.GetPortNames().Contains(Settings.Default.SeriaPortName))
                        { 
                            Connection.Instance.Open(Settings.Default.SeriaPortName);
                      //      if (Settings.Default.RecordingEnabled)
                      //          LogStart();
                        }
                    }
                }
            }
        }
    }
}
