using NAudio.Wave;
using System.Net;
using System.Threading;
using System.ComponentModel;

namespace Quizzer
{
    public partial class Form1 : Form
    {
        
        string answer;

      

        public Form1()
        {
            InitializeComponent();





        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == answer)
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) { 
        

            pictureBox1.ImageLocation = "https://www.google.com/images/branding/googlelogo/2x/googlelogo_light_color_92x30dp.png";
            Thread t = new Thread(Program.NewThread);
            t.Start();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.newQuestion();
            label1.Text = Program.qText;
            answer = Program.answer;
            pictureBox1.ImageLocation = Program.img;

        }
    }
}