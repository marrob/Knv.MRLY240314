

namespace Knv.MRLY240314.StatusBar
{
    using Knv.MRLY240314.Events;
    using System;
    using System.Windows.Forms;
    using System.Drawing;

    class TestResultStatus : ToolStripStatusLabel
    {
        public TestResultStatus()
        {
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new System.Drawing.Size(58, 19);
            Text = "-";

            EventAggregator.Instance.Subscribe((Action<TestCompletedAppEvent>)(e =>
            {
                Text = e.TestResult;

                if (e.TestResult == "PASSED")
                    BackColor = Color.LightGreen;
                else if (e.TestResult == "FAILED")
                    BackColor = Color.Red;
                else if (e.TestResult == "RUNNING")
                    BackColor = Color.Yellow;
                else if(e.TestResult == "ABORT")
                    BackColor = Color.Orange;
                else
                    BackColor = SystemColors.Control;

            }));
        }
    }
}
