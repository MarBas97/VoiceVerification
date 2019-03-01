using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using SpeakerRecognitionClient.MyServiceReference;
using System.Net.Sockets;
using System.IO;
using NAudio.Wave;

namespace SpeakerRecognitionClient
{
    public partial class ClientForm : Form
    {
        private readonly DataWaveOperation _operation = null;
        
        private string decision;
        private int timeleft = 0;
        private const string PathToFile = @"temp.wav";
        private Bitmap MyImage;
        private int xSize = 250;
        private int ySize = 250;
        private double connectionTime;

        public ClientForm()
        {
            InitializeComponent();

            _operation = new DataWaveOperation();
           
            bSend.Enabled = false;
            button1.Enabled = false;
            bPlay.Enabled = false;
           
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void bStart_Click(object sender, EventArgs e)
        {

            bSend.Enabled = false;
            button1.Enabled = false;
            bPlay.Enabled = false;
            bStart.Enabled = false;
            _operation.StartRecording();
            timer.Start();
            timer.Interval = 2000;
            timer.Tick += Timer_Tick;            
            pictureBox1.Image = null;
            label1.Visible = false;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {            
                 timer.Stop();
                _operation.StopRecording();
                 bSend.Enabled = true;
                 button1.Enabled = true;
                 bPlay.Enabled = true;
                 bStart.Enabled = true;
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            bSend.Enabled = false;
            button1.Enabled = false;
            bPlay.Enabled = false;
            bStart.Enabled = false;
            decision = _operation.SendDataAndReceiveAnswer();       
            
            watch.Stop();
            connectionTime = (double)(watch.ElapsedMilliseconds)/1000.0;
            ShowDecision();
            bStart.Enabled = true;
        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
            
        }

        private void bPlay_Click(object sender, EventArgs e)
        {
            if (File.Exists(PathToFile))
            {
                var player = new WaveOutEvent();
                var waveFile = new WaveFileReader(PathToFile);
                _operation.PlayWaveFile(player, waveFile);
                Thread.Sleep(2000);
                waveFile.Flush();
                waveFile.Close();
            }
                

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void ShowDecision()
        {
            if (decision == "true")
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                MyImage = new Bitmap("access.png");
                pictureBox1.ClientSize = new Size(xSize, ySize);
                pictureBox1.Image = (Image)MyImage;                
                label1.Visible = true;
                label1.Text = String.Format("Conection Time: " + connectionTime + " sec");
            }
            else if(decision == "false")
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                MyImage = new Bitmap("no_access.png");
                pictureBox1.ClientSize = new Size(xSize, ySize);
                pictureBox1.Image = (Image)MyImage;                
                label1.Visible = true;
                label1.Text = String.Format("Conection Time: "+connectionTime + " sec");
            }
          


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.Delete(PathToFile);
            bSend.Enabled = false;
            bPlay.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
