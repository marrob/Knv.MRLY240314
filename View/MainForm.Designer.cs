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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonReadRegisters = new System.Windows.Forms.Button();
            this.knvTracingControl1 = new Knv.MRLY240314.Controls.KnvTracingControl();
            this.buttonSetChain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(983, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 479);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(983, 22);
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
            this.splitContainer1.Size = new System.Drawing.Size(983, 455);
            this.splitContainer1.SplitterDistance = 157;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSetChain);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.buttonReadRegisters);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(983, 157);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Run Chain Check";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ChainCheck_Click);
            // 
            // buttonReadRegisters
            // 
            this.buttonReadRegisters.Location = new System.Drawing.Point(12, 14);
            this.buttonReadRegisters.Name = "buttonReadRegisters";
            this.buttonReadRegisters.Size = new System.Drawing.Size(190, 23);
            this.buttonReadRegisters.TabIndex = 0;
            this.buttonReadRegisters.Text = "Read FPGA Register";
            this.buttonReadRegisters.UseVisualStyleBackColor = true;
            this.buttonReadRegisters.Click += new System.EventHandler(this.ReadRegisters_Click);
            // 
            // knvTracingControl1
            // 
            this.knvTracingControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knvTracingControl1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knvTracingControl1.Location = new System.Drawing.Point(0, 0);
            this.knvTracingControl1.Name = "knvTracingControl1";
            this.knvTracingControl1.Size = new System.Drawing.Size(983, 294);
            this.knvTracingControl1.TabIndex = 0;
            // 
            // buttonSetChain
            // 
            this.buttonSetChain.Location = new System.Drawing.Point(12, 72);
            this.buttonSetChain.Name = "buttonSetChain";
            this.buttonSetChain.Size = new System.Drawing.Size(190, 23);
            this.buttonSetChain.TabIndex = 2;
            this.buttonSetChain.Text = "Set Chain";
            this.buttonSetChain.UseVisualStyleBackColor = true;
            this.buttonSetChain.Click += new System.EventHandler(this.buttonSetChain_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 501);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonReadRegisters;
        private Controls.KnvTracingControl knvTracingControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonSetChain;
    }
}

