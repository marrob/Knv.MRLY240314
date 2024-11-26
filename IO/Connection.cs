
namespace Knv.MRLY240314.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO.Ports;
    using System.Globalization;
    public class Status
    {
        public UInt32 StatusCode { get; set; }
        public UInt32 UpTimeSec { get; set; }
    };

    public class Connection
    {
        public static Connection Instance { get; } = new Connection();
        const string GenericTimestampFormat = "yyyy.MM.dd HH:mm:ss";
        public event EventHandler ConnectionChanged;
        public event EventHandler ErrorHappened;
        public bool TracingEnable { get; set; } = false;


        public Queue<string> TraceQueue = new Queue<string>();
        public int TraceLines { get; private set; }

        SerialPort _sp;
        public bool IsOpen
        {
            get
            {
                if (_sp == null)
                    return false;
                else
                    return _sp.IsOpen;
            }
        }

        public int ReadTimeout
        {
            get { return _sp.ReadTimeout; }
            set { _sp.ReadTimeout = value; }
        }

        public static string[] GetPortNames()
        {
            return (SerialPort.GetPortNames());
        }
        static readonly object _syncObject = new object();

        /// <summary>
        /// Srosport Nyitása
        /// </summary>
        /// <param name="port">Port:COMx</param>
        public void Open(string port)
        {
            try
            {
                _sp = new SerialPort(port)
                {
                    ReadTimeout = 1000,
                    BaudRate = 19200,
                    NewLine = "\r"
                };
                _sp.Open();
                _sp.DiscardInBuffer();
                Trace("Serial Port: " + port + " is Open.");
                Test();
                OnConnectionChanged();
            }
            catch (Exception ex)
            {
                _sp.Close();
                Trace("IO ERROR Serial Port is: " + port + " Open fail... beacuse:" + ex.Message);
                OnConnectionChanged();
            }
        }

        public void Test()
        {
            if (_sp == null || !_sp.IsOpen)
            {
                Trace("IO ERROR: port is closed.");
            }

            try
            {
                var resp = WriteRead("*OPC?");
                if (resp == null || !(resp == "*OPC" || resp == "*OPC? OK"))
                    Trace("Connection TEST ERROR");
            }
            catch (Exception ex)
            {
                Trace("IO-ERROR:" + ex.Message);
            }
        }

        public void ExitDfuMode()
        {
            WriteRead("RST");
        }

        public void EnterDfuMode()
        {

            WriteRead("RST");
            System.Threading.Thread.Sleep(1000);


            int temp = _sp.ReadTimeout;
            _sp.ReadTimeout = 20;
            string response = string.Empty;

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    response = WriteRead("DFU");
                    if (response == "OK")
                        break;
                }
                catch (Exception)
                {

                }
            }
            _sp.ReadTimeout = temp;

            if (response != "OK")
                throw new ApplicationException("");
        }


        internal string WriteRead(string request)
        {
            string response = string.Empty;
            Exception exception = null;
            int rxErrors = 0;
            int txErrors = 0;

            do
            {
                if (_sp == null || !_sp.IsOpen)
                {
                    var msg = $"The {_sp.PortName} Serial Port is closed. Please open it.";
                    Trace(msg);
                    OnConnectionChanged();
                    throw new ApplicationException(msg);
                }
                try
                {
                    Trace("Tx: " + request);
                    _sp.WriteLine(request);

                    try
                    {
                        response = _sp.ReadLine().Trim(new char[] { '\0', '\r', '\n' }); ;
                        Trace("Rx: " + response);
                        return response;
                    }
                    catch (Exception ex) //TODO: Nem jol van kezelve a TIMOUT
                    {
                        Trace("Rx ERROR Serial Port is:" + ex.Message);
                        exception = new TimeoutException($"Last Request: {request}", ex);
                        rxErrors++;
                        OnErrorHappened();
                    }
                }
                catch (Exception ex)
                {
                    Trace("Tx ERROR Serial Port is:" + ex.Message);
                    exception = ex;
                    txErrors++;
                    OnErrorHappened();
                }

            } while (rxErrors < 3 && txErrors < 3);

            Trace("There were three consecutive io error. I close the connection.");
            Close();
            throw exception;
        }

        internal string WriteReadWoTracing(string request)
        {
            string response = string.Empty;
            Exception exception = null;
            int rxErrors = 0;
            int txErrors = 0;

            do
            {
                if (_sp == null || !_sp.IsOpen)
                {
                    var msg = $"The {_sp.PortName} Serial Port is closed. Please open it.";
                    Trace(msg);
                    OnConnectionChanged();
                    throw new ApplicationException(msg);
                }
                try
                {
                    _sp.WriteLine(request);
                    try
                    {
                        response = _sp.ReadLine().Trim(new char[] { '\0', '\r', '\n' }); ;
                        return response;
                    }
                    catch (Exception ex)
                    {
                        exception = new TimeoutException($"Last Request: {request}", ex);
                        rxErrors++;
                        OnErrorHappened();
                    }
                }
                catch (Exception ex)
                {
                    Trace("Tx ERROR Serial Port is:" + ex.Message);
                    exception = ex;
                    txErrors++;
                    OnErrorHappened();
                }

            } while (rxErrors < 3 && txErrors < 3);

            Trace("There were three consecutive io error. I close the connection.");
            Close();
            throw exception;
        }

        public void Close()
        {
            TraceQueue.Enqueue(DateTime.Now.ToString(GenericTimestampFormat) + " " + "Serial Port is: " + "Close");
            _sp?.Close();
            OnConnectionChanged();
        }

        internal void Trace(string msg)
        {
            if (!TracingEnable)
                return;
            TraceLines++;
            TraceQueue.Enqueue(DateTime.Now.ToString(GenericTimestampFormat) + " " + msg);
        }

        public void TraceClear()
        {
            TraceQueue.Clear();
            TraceLines = 0;
        }
        protected virtual void OnConnectionChanged()
        {
            EventHandler handler = ConnectionChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnErrorHappened()
        {
            EventHandler handler = ErrorHappened;
            handler?.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        /// Firmware Verziószáma
        /// </summary>
        /// <returns>pl. 1.0.0.0</returns>
        public string GetVersion()
        {
            var resp = WriteRead("VER?");
            if (resp == null)
                return "n/a";
            else
                return resp;
        }
        /// <summary>
        /// Processzor egyedi azonsítója, hosza nem változik
        /// </summary>
        /// <returns>pl:20001E354D501320383252</returns>
        public string UniqeId()
        {
            var resp = WriteRead("UID?");
            if (resp == null)
                return "n/a";
            else
                return resp;
        }
        /// <summary>
        /// Bekapcsolás óta eltelt idő másodpercben
        /// </summary>
        /// <returns>másodperc</returns>
        public int GetUpTime()
        {
            if (int.TryParse(WriteRead("UPTIME?"), NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"), out int retval))
                return retval;
            else
                return 0;
        }

        /// <summary>
        /// A panel varáció neve pl: MGUI201222V00-PCREF
        /// </summary>
        /// <returns></returns>
        public string WhoIs()
        {
            var resp = WriteRead("*IDN?");
            if (resp == null)
                return "n/a";
            else
                return resp;
        }

        /// <summary>
        /// Az FPGA regiszterei olvashatóak. 
        /// FIGYLEM: Olvasás előtt az FPGA bypass-t OFF-ra kell kapcsolni!
        /// ToDo: ismert probléma, hogy az első olvasás rossz értéket ad...
        /// Akkor jó az érték, ha 43-al kezdődik E8782A esetén 
        /// pl: 430F8055F0AA0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
        /// </summary>
        /// <returns></returns>
        public string ReadRegisters()
        {
            return WriteRead("REG?");
        }

        public string RunChainCheck()
        {
            return WriteRead("CHAIN:CHECK?");
        }


        public string SetChain(string hexastring)
        {
            return WriteRead($"CHAIN:SET {hexastring}");
        }

        /// <summary>
        /// Ha true, akkor az FPGA transzparens így közvetlenül írahtó a relélánc a uC-val
        /// Ha false, akkor az FPGA regiszterei _csak_ olvashatóak (egyelőre)
        /// </summary>
        /// <param name="enable"></param>
        public void SetFpgaBypass(bool enable)
        {

            if (enable)
                WriteRead("BYPASS:ON");
            else
                WriteRead("BYPASS:OFF");
        
        }

        public Status GetStatus()
        {
            string response = WriteRead("STA?");
            var values = response.Split(' ');
            UInt32 upTimeSec = UInt32.Parse(values[0], NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
            UInt32 statusCode = UInt32.Parse(values[1], NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
            return new Status() 
            { 
                StatusCode = statusCode, 
                UpTimeSec = upTimeSec
            };
        }

        public double MeasureResistance()
        { 
            var ohmsStr = WriteRead("OHMS?");
            var ohms = double.Parse(ohmsStr, CultureInfo.GetCultureInfo("en-US"));
            return ohms;
        }
    }
}
