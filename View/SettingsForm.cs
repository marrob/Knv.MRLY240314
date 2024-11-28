

namespace Knv.MRLY240314.View
{
    using Knv.MRLY240314.Properties;
    using System;
    using System.Windows.Forms;

    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            numericUpDownMeasurementDelayTime.Value = Settings.Default.MeasurementDelayTimeMs;

            checkBoxConnectOnStart.Checked = Settings.Default.ConnectOnStart;

            textBoxReportDirectory.Text = Settings.Default.ReportDirectory;


            textBoxCloseLowLimit.Text = Settings.Default.CloseLowLimit.ToString();
            textBoxCloseLowLimit.TextChanged += (tb_sender, value) =>
            {
                TextBox tb = (TextBox)tb_sender;
                if (float.TryParse(tb.Text, out float temp))
                    tb.BackColor = System.Drawing.Color.White;
                else
                    tb.BackColor = System.Drawing.Color.Red;
            };

            textBoxCloseHighLimit.Text = Settings.Default.CloseHighLimit.ToString();
            textBoxCloseHighLimit.TextChanged += (tb_sender, value) =>
            {
                TextBox tb = (TextBox)tb_sender;
                if (float.TryParse(tb.Text, out float temp))
                    tb.BackColor = System.Drawing.Color.White;
                else
                    tb.BackColor = System.Drawing.Color.Red;
            };

            textBoxOpenLowLimit.Text = Settings.Default.OpenLowLimit.ToString();
            textBoxOpenLowLimit.TextChanged += (tb_sender, value) =>
            {
                TextBox tb = (TextBox)tb_sender;
                if (float.TryParse(tb.Text, out float temp))
                    tb.BackColor = System.Drawing.Color.White;
                else
                    tb.BackColor = System.Drawing.Color.Red;
            };

            textBoxOpenHighLimit.Text = Settings.Default.OpenHighLimit.ToString();
            textBoxOpenHighLimit.TextChanged += (tb_sender, value) =>
            {
                TextBox tb = (TextBox)tb_sender;
                if (float.TryParse(tb.Text, out float temp))
                    tb.BackColor = System.Drawing.Color.White;
                else
                    tb.BackColor = System.Drawing.Color.Red;
            };

            textBoxBypassResistorLowLimit.Text = Settings.Default.BypassResistorLowLimit.ToString();
            textBoxBypassResistorLowLimit.TextChanged += (tb_sender, value) =>
            {
                TextBox tb = (TextBox)tb_sender;
                if (float.TryParse(tb.Text, out float temp))
                    tb.BackColor = System.Drawing.Color.White;
                else
                    tb.BackColor = System.Drawing.Color.Red;
            };

            textBoxBypassResistorHighLimit.Text = Settings.Default.BypassResistorHighLimit.ToString();
            textBoxBypassResistorHighLimit.TextChanged += (tb_sender, value) =>
            {
                TextBox tb = (TextBox)tb_sender;
                if (float.TryParse(tb.Text, out float temp))
                    tb.BackColor = System.Drawing.Color.White;
                else
                    tb.BackColor = System.Drawing.Color.Red;
            };

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

            Settings.Default.MeasurementDelayTimeMs = (int)numericUpDownMeasurementDelayTime.Value;
            Settings.Default.ConnectOnStart = checkBoxConnectOnStart.Checked;
            Settings.Default.ReportDirectory = textBoxReportDirectory.Text;

            float temp;

            if (float.TryParse(textBoxCloseLowLimit.Text, out temp))
                Settings.Default.CloseLowLimit = temp;

            if (float.TryParse(textBoxCloseHighLimit.Text, out temp))
                Settings.Default.CloseHighLimit = temp;

            if (float.TryParse(textBoxOpenLowLimit.Text, out temp))
                Settings.Default.OpenLowLimit = temp;

            if (float.TryParse(textBoxOpenHighLimit.Text, out temp))
                Settings.Default.OpenHighLimit = temp;

            if (float.TryParse(textBoxBypassResistorLowLimit.Text, out temp))
                Settings.Default.BypassResistorLowLimit = temp;

            if (float.TryParse(textBoxBypassResistorHighLimit.Text, out temp))
                Settings.Default.BypassResistorHighLimit = temp;

            DialogResult = DialogResult.OK;
        }

        private void buttonReportDirectory_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                { textBoxReportDirectory.Text = folderBrowserDialog.SelectedPath; }

            }
        }
    }
}
