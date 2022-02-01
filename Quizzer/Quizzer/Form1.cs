namespace Quizzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "https://www.google.com/images/branding/googlelogo/2x/googlelogo_light_color_92x30dp.png";
            Program.PlayMp3FromUrl("https://www.soundhelix.com/examples/mp3/SoundHelix-Song-1.mp3");

        }
    }
}