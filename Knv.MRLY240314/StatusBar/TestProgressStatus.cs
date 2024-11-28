namespace Knv.MRLY240314.StatusBar
{
    using Knv.MRLY240314.Events;
    using System;
    using System.Windows.Forms;

    class TestProgressStatus : ToolStripStatusLabel
    {
        public TestProgressStatus()
        {
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new System.Drawing.Size(103, 19);
            Text = "-";

            EventAggregator.Instance.Subscribe((Action<TestProgressAppEvent>)(e =>
            {
                Text = $"{e.TotalSteps} / {e.CurrentStepIndex}";
            }));
        }
    }
}
