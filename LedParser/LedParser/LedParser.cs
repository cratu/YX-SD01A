using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LedParser
{
	public partial class LedParser : Form
	{
		Thread t;
		public delegate void DrawOnPanelDelegate(Bitmap bmp);
		public DrawOnPanelDelegate dopDelegate;
		const int pixelWidth = 15;
		private FileParser currentData;
		ManualResetEvent mrse = new ManualResetEvent(true);
        private int diodeNumber = -1;

		public LedParser()
		{
			InitializeComponent();
			dopDelegate = new DrawOnPanelDelegate(DrawOnPanel);
			pbPlayer.Width = 0;
            this.Text += " v " + ApplicationInfo.Version;
		}

		private void btnOpenFile_Click(object sender, EventArgs e)
		{
			
		}

		private void PlayFile(object data)
		{

			if (!(data is FileParser))
				throw new Exception("Wrong type");

			FileParser fp = (FileParser)(data as FileParser).Clone();
			Bitmap bmp = new Bitmap(fp.FrameLength * pixelWidth, 15);

			int pb = 0;
			foreach (var frame in fp)
			{
				pb++;
				UpdateProgressBar(pb);
				mrse.WaitOne();
				FillBitmap(pixelWidth, bmp, frame);
				DrawBitmapOnPanel(bmp);

				Pause();
			}
		}

		private void DrawBitmapOnPanel(Bitmap bmp)
		{
			if (pbPlayer.InvokeRequired)
				pbPlayer.Invoke(dopDelegate, new object[] { bmp });
			else
				DrawOnPanel(bmp);
		}

		private void UpdateProgressBar(int value)
		{
			if (progressBar.InvokeRequired)
				progressBar.Invoke((MethodInvoker)(() =>
				{
					progressBar.Value = value;
				}));
			else
			{
				progressBar.Value = value;
			}
		}

		/// <summary>
		/// Inits progress bar or reset it.
		/// </summary>
		/// <param name="fp"></param>
		private void InitProgressBar(FileParser fp)
		{
			if (progressBar.InvokeRequired)
				progressBar.Invoke((MethodInvoker)(() =>
				{
					progressBar.Maximum = fp.NumberOfFrames;
					progressBar.Value = 0;
				}));
			else
			{
				progressBar.Maximum = fp.NumberOfFrames;
				progressBar.Value = 0;
			}
		}

		/// <summary>
		/// pause thread depends on tbSpeed control value
		/// </summary>
		private void Pause()
		{

			int speed = 10;
			if (tbSpeed.InvokeRequired)
			{
				tbSpeed.Invoke((MethodInvoker)(() => { speed *= tbSpeed.Value; }));
			}
			else
				speed *= tbSpeed.Value;
			Thread.Sleep(speed);
		}

		/// <summary>
		/// Fills bitmap with specified frame.
		/// </summary>
		/// <param name="pixelWidth">Circle radius</param>
		/// <param name="bmp">Bitmap</param>
		/// <param name="frame">Frame</param>
		private static void FillBitmap(int pixelWidth, Bitmap bmp, IList<Color> frame)
		{
			using (Graphics g = Graphics.FromImage(bmp))
			{
				using (var sb = new SolidBrush(Color.Red))
				{
					for (int k = 0; k < frame.Count; k++)
					{
						sb.Color = frame[k];
						g.FillEllipse(sb, new Rectangle(k * pixelWidth, 0, pixelWidth, 15));
					}
				}
			}
		}


		private void DrawOnPanel(Bitmap bmp)
		{
			pbPlayer.Width = bmp.Width;
			pbPlayer.Image = (Bitmap)bmp.Clone();
		}

		private void LedParser_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (t != null) t.Abort();
		}

		private void btnPlayPause_Click(object sender, EventArgs e)
		{
			if (t != null)
			{
				if (mrse.WaitOne(0))
				{
					mrse.Reset();
					numericUpDown1.Value = progressBar.Value - 1;
				}
				else
					mrse.Set();
				ClearEditZone();
			}
		}

		private void btnRestart_Click(object sender, EventArgs e)
		{
			numericUpDown1.Value = 0;
			if (t != null)
			{
				ClearEditZone();
				t.Abort();
				mrse.Reset();
				mrse.Set();
				if (currentData != null)
				{
					t = new Thread(new ParameterizedThreadStart(this.PlayFile));
					t.Start(currentData);
				}
			}
		}

		/// <summary>
		/// Change current frame.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			if (currentData != null)
			{
				mrse.Reset();

				Bitmap bmp = new Bitmap(currentData.FrameLength * pixelWidth, 15);
				FillBitmap(pixelWidth, bmp, currentData[(int)numericUpDown1.Value]);
				DrawBitmapOnPanel(bmp);
				UpdateProgressBar((int)numericUpDown1.Value + 1);
				ClearEditZone();
			}
		}

		private void pbPlayer_MouseClick(object sender, MouseEventArgs e)
		{
			if (currentData != null)
			{
				//pauses playback if run
				if (t != null)
				{
					if (mrse.WaitOne(0))
					{
						mrse.Reset();
						numericUpDown1.Value = progressBar.Value - 1;
					}
				}
                diodeNumber = e.X / 15;
                lblDiodeNumber.Text = diodeNumber.ToString();
				/*using (Graphics g = Graphics.FromImage(pbPlayer.Image))
				{
					using (var p = new Pen(Color.White))
					{
						g.DrawEllipse(p, new Rectangle(diodeNumber * pixelWidth, 0, pixelWidth, 15));
					}
				}*/

                UpdateOneDiodeView(currentData[(int)numericUpDown1.Value][diodeNumber]);
                btnChangeColor.Enabled = true;
			}
		}

        /// <summary>
        /// fills onediode view by diode color.
        /// </summary>
        /// <param name="color">color</param>
        private void UpdateOneDiodeView(Color color)
        {
            Bitmap bmp = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (var sb = new SolidBrush(Color.Red))
                {
                    colorDialog1.Color = sb.Color = color;
                    lblBlue.Text = color.B.ToString();
                    lblGreen.Text = color.G.ToString();
                    lblRed.Text = color.R.ToString();
                    g.FillEllipse(sb, new Rectangle(0, 0, 100, 100));
                    using (var p = new Pen(Color.White))
                    {
                        g.DrawEllipse(p, new Rectangle(0, 0, 100, 100));
                    }

                }
            }
            pbOneDiode.Image = (Image)bmp;
        }

		private void ClearEditZone()
		{
			pbOneDiode.Image = null;
			lblBlue.Text =
			lblGreen.Text =
			lblRed.Text = "?";
            lblDiodeNumber.Text = "?";
            btnChangeColor.Enabled = false;
            diodeNumber = -1;
		}

		private void LedParser_Load(object sender, EventArgs e)
		{

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mrse.Reset();
                numericUpDown1.Value = 0;
                var file = openFileDialog1.OpenFile();
                byte[] data = new byte[file.Length];
                file.Read(data, 0, (int)file.Length);

                currentData = new FileParser(data);

                StartPlay();
                mrse.Set();
            }
        }

        private void StartPlay()
        {
            InitProgressBar(currentData);
            lblFramesTotal.Text = currentData.NumberOfFrames.ToString();
            numericUpDown1.Maximum = currentData.NumberOfFrames - 1;
            if (t != null) t.Abort();

            t = new Thread(new ParameterizedThreadStart(this.PlayFile));

            t.Start(currentData);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProgramm npForm = new NewProgramm(currentData);
            if (npForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mrse.Reset();
                currentData = npForm.FileParser;
                StartPlay();
                mrse.Set();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentData != null)
            {
                Stream myStream;
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        myStream.Write(currentData.GetBinarySource(), 0, currentData.GetBinarySource().Length);
                        myStream.Close();
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (diodeNumber >= 0 && colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                currentData.SetDiodeColor((int)numericUpDown1.Value, diodeNumber, colorDialog1.Color);
                UpdateOneDiodeView(colorDialog1.Color);
                Bitmap bmp = new Bitmap(currentData.FrameLength * pixelWidth, 15);
                FillBitmap(pixelWidth, bmp, currentData[(int)numericUpDown1.Value]);
                DrawBitmapOnPanel(bmp);
            }
        }

	}
}
