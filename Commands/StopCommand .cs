
namespace Knv.MRLY240314.Commands
{
    using Properties;
    using System;
    using System.Windows.Forms;
    using View;

    class StopCommand : ToolStripMenuItem
    {
        readonly IApp _app;
        public StopCommand(IApp app)
        {
        //    Image = Resources.Settings_outline_48;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Text = "Stop";
            _app = app;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _app.Stop();
        }
    }
}
