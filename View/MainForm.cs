namespace Knv.MRLY240314
{
    using System.Windows.Forms;
    using Controls;
    using System;
    using System.Drawing;

    public interface IMainForm
    {
        event EventHandler Shown;
        event FormClosedEventHandler FormClosed;
        event FormClosingEventHandler FormClosing;
        event EventHandler Disposed;
        KnvTracingControl Tracing { get; }

        event EventHandler ReadFpgaRegisters;
        event EventHandler RunChainCheck;
        event EventHandler SetChain;

        bool AlwaysOnTop { get; set; }

        object DataSource { get; set; } 

        string Text { get; set; }
        ToolStripItem[] MenuBar { set; }
        ToolStripItem[] StatusBar { set; }

        void GridRefresh();
    }

    public partial class MainForm : Form , IMainForm
    {
        public event EventHandler ReadFpgaRegisters;
        public event EventHandler RunChainCheck;
        public event EventHandler SetChain;

        public ToolStripItem[] MenuBar
        {
            set { menuStrip1.Items.AddRange(value); }
        }

        public KnvTracingControl Tracing
        {
            get { return knvTracingControl1; }
        }

        public bool AlwaysOnTop
        {
            get { return this.TopMost; }
            set { this.TopMost = value; }
        }

        public object DataSource
        {
            get { return knvDataGridView1.DataSource; }
            set { knvDataGridView1.DataSource = value; }
        }

        public ToolStripItem[] StatusBar
        {
            set { statusStrip1.Items.AddRange(value); }
        }

        public MainForm()
        {
            InitializeComponent();

            knvDataGridView1.KnvDoubleBuffered(true);
        }

        public void GridRefresh()
        { 
            knvDataGridView1.Refresh();
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

        private void knvDataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (knvDataGridView1.Rows[e.RowIndex].Cells[2].Value == null) return;

            var result = knvDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString().ToUpper().Trim();

            if (result == "FAILED")
                knvDataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            else
            if (result == "PASSED")
                knvDataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            else
                knvDataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;

        }
    }
}
