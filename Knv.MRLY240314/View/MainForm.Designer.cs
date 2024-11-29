namespace Knv.MRLY240314
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.knvDataGridView1 = new Knv.MRLY240314.Controls.KnvDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonReadRegisters = new System.Windows.Forms.Button();
            this.buttonSetChain = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.knvTracingControl1 = new Knv.MRLY240314.Controls.KnvTracingControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.knvDataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1094, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 671);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1094, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.knvTracingControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1094, 647);
            this.splitContainer1.SplitterDistance = 448;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1094, 448);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1094, 448);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.knvDataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1086, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Steps";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // knvDataGridView1
            // 
            this.knvDataGridView1.BackgroundText = "Itt lesz a tesztek listája miután azonosítottam a kártyát";
            this.knvDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.knvDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knvDataGridView1.FirstZebraColor = System.Drawing.Color.Bisque;
            this.knvDataGridView1.Location = new System.Drawing.Point(3, 3);
            this.knvDataGridView1.Name = "knvDataGridView1";
            this.knvDataGridView1.ReadOnly = true;
            this.knvDataGridView1.SecondZebraColor = System.Drawing.Color.White;
            this.knvDataGridView1.Size = new System.Drawing.Size(1080, 416);
            this.knvDataGridView1.TabIndex = 0;
            this.knvDataGridView1.ZebraRow = true;
            this.knvDataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.knvDataGridView1_RowPrePaint);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonReadRegisters);
            this.tabPage2.Controls.Add(this.buttonSetChain);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1086, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Functions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonReadRegisters
            // 
            this.buttonReadRegisters.Location = new System.Drawing.Point(6, 6);
            this.buttonReadRegisters.Name = "buttonReadRegisters";
            this.buttonReadRegisters.Size = new System.Drawing.Size(190, 23);
            this.buttonReadRegisters.TabIndex = 0;
            this.buttonReadRegisters.Text = "Read FPGA Register";
            this.buttonReadRegisters.UseVisualStyleBackColor = true;
            this.buttonReadRegisters.Click += new System.EventHandler(this.ReadRegisters_Click);
            // 
            // buttonSetChain
            // 
            this.buttonSetChain.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSetChain.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonSetChain.Location = new System.Drawing.Point(6, 64);
            this.buttonSetChain.Name = "buttonSetChain";
            this.buttonSetChain.Size = new System.Drawing.Size(190, 23);
            this.buttonSetChain.TabIndex = 2;
            this.buttonSetChain.Text = "Set Chain";
            this.buttonSetChain.UseVisualStyleBackColor = false;
            this.buttonSetChain.Click += new System.EventHandler(this.buttonSetChain_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Run Chain Check";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ChainCheck_Click);
            // 
            // knvTracingControl1
            // 
            this.knvTracingControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knvTracingControl1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knvTracingControl1.Location = new System.Drawing.Point(0, 0);
            this.knvTracingControl1.Name = "knvTracingControl1";
            this.knvTracingControl1.Size = new System.Drawing.Size(1094, 195);
            this.knvTracingControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 693);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.knvDataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonReadRegisters;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonSetChain;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Controls.KnvDataGridView knvDataGridView1;
        Knv.MRLY240314.Controls.KnvTracingControl knvTracingControl1;
    }
}

