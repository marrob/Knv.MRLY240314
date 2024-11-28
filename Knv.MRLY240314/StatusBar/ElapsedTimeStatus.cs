

namespace Knv.MRLY240314.StatusBar
{
    using Knv.MRLY240314.Events;
    using System;
    using System.Windows.Forms;
    using System.Drawing;

    class ElapsedTimeStatus : ToolStripStatusLabel
    {
        public ElapsedTimeStatus()
        {
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new Size(58, 19);
            Text = "-s";

            EventAggregator.Instance.Subscribe((Action<TestCompletedAppEvent>)(e =>
            {
                if (string.IsNullOrEmpty(e.ElapsedTime))
                    Text = "-s";
                else
                    Text = $"{e.ElapsedTime}s";

            }));
        }
    }
}
