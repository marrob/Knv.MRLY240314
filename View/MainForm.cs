namespace Knv.MRLY240314
{
    using System.Windows.Forms;
    using Controls;
    using System;

    public interface IMainForm
    {
        event EventHandler Shown;
        event FormClosedEventHandler FormClosed;
        event FormClosingEventHandler FormClosing;
        event EventHandler Disposed;
        KnvTracingControl Tracing { get; }

        event EventHandler<bool> FpgaBypassChanged;
        event EventHandler ReadFpgaRegisters;
        event EventHandler RunChainCheck;
        event EventHandler SetChain;

        string Vout { get; set; }
        string Iout { get; set; }
        string MeasureTemperatureCelsius { get; set; }

        string Text { get; set; }
        ToolStripItem[] MenuBar { set; }
        ToolStripItem[] StatusBar { set; }
    }

    public partial class MainForm : Form , IMainForm
    {

        
        public event EventHandler ReadFpgaRegisters;
        public event EventHandler RunChainCheck;
        public event EventHandler SetChain;
        public event EventHandler<bool> FpgaBypassChanged;

        public ToolStripItem[] MenuBar
        {
            set { menuStrip1.Items.AddRange(value); }
        }

        public string Iout
        {
            get;
            set;
        }

        public string Vout 
        {
            get;
            set;
        }

        public KnvTracingControl Tracing
        {
            get { return knvTracingControl1; }
        }



        public string MeasureTemperatureCelsius
        {
            get;
            set;
        }

        public ToolStripItem[] StatusBar
        {
            set { statusStrip1.Items.AddRange(value); }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void ReadRegisters_Click(object sender, EventArgs e)
        {
            ReadFpgaRegisters.Invoke(this, EventArgs.Empty);
        }

        private void ChainCheck_Click(object sender, EventArgs e)
        {
            RunChainCheck.Invoke(this, EventArgs.Empty);
        }

        private void buttonSetChain_Click(object sender, EventArgs e)
        {
            SetChain.Invoke(this, EventArgs.Empty);
        }

        private void checkBoxFpgaBypass_CheckedChanged(object sender, EventArgs e)
        {
            FpgaBypassChanged?.Invoke(this, checkBoxFpgaBypass.Checked);
        }
    }
}
