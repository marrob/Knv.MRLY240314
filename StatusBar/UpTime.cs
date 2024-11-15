

namespace Knv.MRLY240314.StatusBar
{
    using System;
    using System.Windows.Forms;
    using Properties;
    using IO;

    class UpTime : ToolStripStatusLabel
    { 
        public UpTime()
        {
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new System.Drawing.Size(58, 19);
            Text = "UpTime Counter: " + AppConstants.ValueNotAvailable2;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Start();

            timer.Tick += (s, e) =>
            {
                if (Connection.Instance.IsOpen)
                {
                    //Text = "UpTime Counter: " + Connection.Instance.GetUpTime();
                }
            };
        }
    }
}
