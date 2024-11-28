
namespace Knv.MRLY240314.Commands
{
    using Properties;
    using System;
    using System.Windows.Forms;
    using View;
    using System.IO;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    using Knv.MRLY240314.Events;

    class OpenLastReport : ToolStripMenuItem
    {
        string _lastReportPath;
        
        public OpenLastReport()
        {
            Image = Resources.Settings_outline_48;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Text = "Report by Npp";
            _lastReportPath = LastReportPath();
            ToolTipText = _lastReportPath;
            AutoToolTip = true;

            EventAggregator.Instance.Subscribe((Action<TestCompletedAppEvent>)
                (e => {
                        _lastReportPath = LastReportPath();
                        ToolTipText = _lastReportPath;
                } ));
           
        }


        class PathWithDateTime
        {
            public DateTime DateTime { get; set; }
            public string Path { get; set; }
        }

        public string LastReportPath()
        {
            var pathWithDateTimes = new List<PathWithDateTime>();

            //A könyvtárban található összes fájl bejárása
            string[] files = Directory.GetFiles(Settings.Default.ReportDirectory);
            string format = "yyyyMMdd_HHmmss";

            //Formátuma: 666FF39384B513043112640_20241128_135318_FAILED.csv
            foreach (string file in files)
            {
                string[] items = file.Split(new char[] { '_' });

                if (items.Count() == 4 && !string.IsNullOrEmpty(items[1]) && !string.IsNullOrEmpty(items[2]))
                {
                    var dateTimeString = $"{items[1]}_{items[2]}";
                    if (DateTime.TryParseExact(dateTimeString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDateTime))
                    {
                        pathWithDateTimes.Add(new PathWithDateTime
                        {
                            DateTime = parsedDateTime,
                            Path = file
                        });
                    }
                }
            }
            return pathWithDateTimes.OrderByDescending(x => x.DateTime).FirstOrDefault().Path;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            var myProcess = new Process();
            myProcess.StartInfo.Arguments = "\"" + _lastReportPath + "\"";
            myProcess.StartInfo.FileName = "Notepad++";
            try
            {
                myProcess.Start();
            }
            catch (Exception)
            {
                myProcess.StartInfo.FileName = "Notepad";
                myProcess.Start();
            }
        }
    }
}
