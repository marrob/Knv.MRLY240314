namespace Knv.MRLY240314.View
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxUpTimeCounterPolling = new System.Windows.Forms.CheckBox();
            this.checkBoxConnectOnStart = new System.Windows.Forms.CheckBox();
            this.numericUpDownMeasurementDelayTime = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCloseLowLimit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCloseHighLimit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxOpenLowLimit = new System.Windows.Forms.TextBox();
            this.textBoxOpenHighLimit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxBypassResistorLowLimit = new System.Windows.Forms.TextBox();
            this.textBoxBypassResistorHighLimit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMeasurementDelayTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(256, 254);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(337, 254);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // checkBoxUpTimeCounterPolling
            // 
            this.checkBoxUpTimeCounterPolling.AutoSize = true;
            this.checkBoxUpTimeCounterPolling.Location = new System.Drawing.Point(12, 12);
            this.checkBoxUpTimeCounterPolling.Name = "checkBoxUpTimeCounterPolling";
            this.checkBoxUpTimeCounterPolling.Size = new System.Drawing.Size(137, 17);
            this.checkBoxUpTimeCounterPolling.TabIndex = 3;
            this.checkBoxUpTimeCounterPolling.Text = "UpTime Counter Polling";
            this.checkBoxUpTimeCounterPolling.UseVisualStyleBackColor = true;
            // 
            // checkBoxConnectOnStart
            // 
            this.checkBoxConnectOnStart.AutoSize = true;
            this.checkBoxConnectOnStart.Location = new System.Drawing.Point(12, 35);
            this.checkBoxConnectOnStart.Name = "checkBoxConnectOnStart";
            this.checkBoxConnectOnStart.Size = new System.Drawing.Size(108, 17);
            this.checkBoxConnectOnStart.TabIndex = 4;
            this.checkBoxConnectOnStart.Text = "Connect On Start";
            this.checkBoxConnectOnStart.UseVisualStyleBackColor = true;
            // 
            // numericUpDownMeasurementDelayTime
            // 
            this.numericUpDownMeasurementDelayTime.Location = new System.Drawing.Point(175, 68);
            this.numericUpDownMeasurementDelayTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownMeasurementDelayTime.Name = "numericUpDownMeasurementDelayTime";
            this.numericUpDownMeasurementDelayTime.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMeasurementDelayTime.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Measurement Delay Time in ms:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "IM02PNS Relay Close";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "High Limit";
            // 
            // textBoxCloseLowLimit
            // 
            this.textBoxCloseLowLimit.Location = new System.Drawing.Point(121, 37);
            this.textBoxCloseLowLimit.Name = "textBoxCloseLowLimit";
            this.textBoxCloseLowLimit.Size = new System.Drawing.Size(100, 20);
            this.textBoxCloseLowLimit.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Low Limit";
            // 
            // textBoxCloseHighLimit
            // 
            this.textBoxCloseHighLimit.Location = new System.Drawing.Point(242, 37);
            this.textBoxCloseHighLimit.Name = "textBoxCloseHighLimit";
            this.textBoxCloseHighLimit.Size = new System.Drawing.Size(100, 20);
            this.textBoxCloseHighLimit.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "IM02PNS Relay Open";
            // 
            // textBoxOpenLowLimit
            // 
            this.textBoxOpenLowLimit.Location = new System.Drawing.Point(121, 63);
            this.textBoxOpenLowLimit.Name = "textBoxOpenLowLimit";
            this.textBoxOpenLowLimit.Size = new System.Drawing.Size(100, 20);
            this.textBoxOpenLowLimit.TabIndex = 13;
            // 
            // textBoxOpenHighLimit
            // 
            this.textBoxOpenHighLimit.Location = new System.Drawing.Point(242, 63);
            this.textBoxOpenHighLimit.Name = "textBoxOpenHighLimit";
            this.textBoxOpenHighLimit.Size = new System.Drawing.Size(100, 20);
            this.textBoxOpenHighLimit.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Bypass Resistor";
            // 
            // textBoxBypassResistorLowLimit
            // 
            this.textBoxBypassResistorLowLimit.Location = new System.Drawing.Point(121, 89);
            this.textBoxBypassResistorLowLimit.Name = "textBoxBypassResistorLowLimit";
            this.textBoxBypassResistorLowLimit.Size = new System.Drawing.Size(100, 20);
            this.textBoxBypassResistorLowLimit.TabIndex = 16;
            // 
            // textBoxBypassResistorHighLimit
            // 
            this.textBoxBypassResistorHighLimit.Location = new System.Drawing.Point(242, 89);
            this.textBoxBypassResistorHighLimit.Name = "textBoxBypassResistorHighLimit";
            this.textBoxBypassResistorHighLimit.Size = new System.Drawing.Size(100, 20);
            this.textBoxBypassResistorHighLimit.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(348, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Ohms";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(348, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Ohms";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(348, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Ohms";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxBypassResistorHighLimit);
            this.groupBox1.Controls.Add(this.textBoxBypassResistorLowLimit);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxOpenHighLimit);
            this.groupBox1.Controls.Add(this.textBoxOpenLowLimit);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxCloseHighLimit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxCloseLowLimit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(10, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 156);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Limits";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(131, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(180, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "After modofication please reconnect!";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(429, 300);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownMeasurementDelayTime);
            this.Controls.Add(this.checkBoxConnectOnStart);
            this.Controls.Add(this.checkBoxUpTimeCounterPolling);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMeasurementDelayTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxUpTimeCounterPolling;
        private System.Windows.Forms.CheckBox checkBoxConnectOnStart;
        private System.Windows.Forms.NumericUpDown numericUpDownMeasurementDelayTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCloseLowLimit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCloseHighLimit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxOpenLowLimit;
        private System.Windows.Forms.TextBox textBoxOpenHighLimit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxBypassResistorLowLimit;
        private System.Windows.Forms.TextBox textBoxBypassResistorHighLimit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
    }
}