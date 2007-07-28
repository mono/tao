using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace FFmpegExamples
{
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
            this.audio.LivtUpdateEvent += new LiveUpdateCallback(audio_LivtUpdateEvent);
            
        }

        void audio_LivtUpdateEvent(object update)
        {
            if (InvokeRequired) {
                BeginInvoke(new TimerCallback(audio_LivtUpdateEvent), update);
                return;
            }
            if (this.label1.Text != update.ToString())
                this.label1.Text = update.ToString();
        }

        AudioStream audio = new AudioStream();
        bool canPlay;

        private void button2_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.openFileDialog1.ShowDialog()) {
                string path = this.openFileDialog1.FileName;
                audio.Open(path);
                canPlay = true;
            }
        }

        Thread thread;
        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(RunMusic));
            thread.IsBackground = true;
            thread.Start();
        }

        private void RunMusic()
        {
            if (canPlay) {
                audio.Play();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            audio.Stop();
        }
    }
}