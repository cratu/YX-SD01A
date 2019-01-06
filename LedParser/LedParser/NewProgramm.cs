using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LedParser
{
    public partial class NewProgramm : Form
    {
        FileParser _fp;
        public FileParser FileParser
        {
            get { return _fp; }
        }
        public NewProgramm(FileParser fp)
        {
            InitializeComponent();
            _fp = fp;
        }

        private void btnSelectInitialColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.FromArgb(int.Parse(lblR.Text),int.Parse(lblR.Text),int.Parse(lblR.Text));
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                lblR.Text = colorDialog1.Color.R.ToString();
                lblG.Text = colorDialog1.Color.G.ToString();
                lblB.Text = colorDialog1.Color.B.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Format f = rbSD01A.Checked ? Format.SD01A : Format.SD01B;
            _fp = new FileParser((int)numericUpDown1.Value, Color.FromArgb(int.Parse(lblR.Text), int.Parse(lblG.Text), int.Parse(lblB.Text)), f:f);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
