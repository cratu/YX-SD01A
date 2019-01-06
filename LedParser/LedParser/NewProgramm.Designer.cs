namespace LedParser
{
    partial class NewProgramm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblR = new System.Windows.Forms.Label();
            this.lblG = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectInitialColor = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbSD01A = new System.Windows.Forms.RadioButton();
            this.rbSD01B = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Frames";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Red";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Green";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Blue";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(72, 14);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(97, 22);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(63, 20);
            this.lblR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(16, 17);
            this.lblR.TabIndex = 5;
            this.lblR.Text = "0";
            // 
            // lblG
            // 
            this.lblG.AutoSize = true;
            this.lblG.Location = new System.Drawing.Point(63, 41);
            this.lblG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(16, 17);
            this.lblG.TabIndex = 6;
            this.lblG.Text = "0";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(63, 62);
            this.lblB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(16, 17);
            this.lblB.TabIndex = 7;
            this.lblB.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectInitialColor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblG);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblR);
            this.groupBox1.Location = new System.Drawing.Point(21, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(148, 123);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Initial Color";
            // 
            // btnSelectInitialColor
            // 
            this.btnSelectInitialColor.Location = new System.Drawing.Point(9, 82);
            this.btnSelectInitialColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectInitialColor.Name = "btnSelectInitialColor";
            this.btnSelectInitialColor.Size = new System.Drawing.Size(100, 28);
            this.btnSelectInitialColor.TabIndex = 8;
            this.btnSelectInitialColor.Text = "Select";
            this.btnSelectInitialColor.UseVisualStyleBackColor = true;
            this.btnSelectInitialColor.Click += new System.EventHandler(this.btnSelectInitialColor_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(177, 10);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Location = new System.Drawing.Point(177, 47);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbSD01B);
            this.groupBox2.Controls.Add(this.rbSD01A);
            this.groupBox2.Location = new System.Drawing.Point(177, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(100, 80);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RX-SD01?";
            // 
            // rbSD01A
            // 
            this.rbSD01A.AutoSize = true;
            this.rbSD01A.Checked = true;
            this.rbSD01A.Location = new System.Drawing.Point(7, 21);
            this.rbSD01A.Name = "rbSD01A";
            this.rbSD01A.Size = new System.Drawing.Size(38, 21);
            this.rbSD01A.TabIndex = 0;
            this.rbSD01A.TabStop = true;
            this.rbSD01A.Text = "A";
            this.rbSD01A.UseVisualStyleBackColor = true;
            // 
            // rbSD01B
            // 
            this.rbSD01B.AutoSize = true;
            this.rbSD01B.Location = new System.Drawing.Point(7, 49);
            this.rbSD01B.Name = "rbSD01B";
            this.rbSD01B.Size = new System.Drawing.Size(38, 21);
            this.rbSD01B.TabIndex = 1;
            this.rbSD01B.Text = "B";
            this.rbSD01B.UseVisualStyleBackColor = true;
            // 
            // NewProgramm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 178);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NewProgramm";
            this.Text = "Create New Programm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelectInitialColor;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbSD01B;
        private System.Windows.Forms.RadioButton rbSD01A;
    }
}