using System;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Speaker
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer synth;

        bool flag = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            synth = new SpeechSynthesizer();

            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                return;
            }
            else
            {
                if (radioButton1.Checked)
                {
                    synth.SelectVoice("Microsoft Irina Desktop"); // russian
                }
                else
                {
                    synth.SelectVoice("Microsoft Zira Desktop");  // english
                }
            }

            flag = true;

            synth.SetOutputToDefaultAudioDevice();

            synth.Rate = (int)numericUpDown1.Value;

            synth.SpeakAsync(textBox1.Text);

            //SaveFileDialog sf = new SaveFileDialog();
            //sf.Filter = "Audio files (*.wav)|*.wav|All files (*.*)|*.*";
            //if (sf.ShowDialog() == DialogResult.OK)
            //{
            //    synth.SetOutputToWaveFile(sf.FileName);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            synth.SpeakAsyncCancelAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                synth.Pause();
                flag = false;
            }
            else
            {
                synth.Resume();
                flag = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (synth != null)
            {
                synth.Dispose();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            synth.SpeakAsyncCancelAll();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (synth != null)
            {
                synth.SpeakAsyncCancelAll();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (synth != null)
            {
                synth.SpeakAsyncCancelAll();
            }
        }
    }
}
