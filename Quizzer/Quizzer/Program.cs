using NAudio.Wave;
using System.Net;
using System.Threading;
using System.ComponentModel;

namespace Quizzer
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            Thread.Sleep(100);
        }


        public static void NewThread()
        {
            var url = "https://sounds-mp3.com/mp3/0010834.mp3";
            PlayMp3FromUrl(url);
        }

        public static void PlayMp3FromUrl(string url)
        {
            using (var mf = new MediaFoundationReader(url))
            using (var wo = new WaveOutEvent())
            {
                wo.Init(mf);
                wo.Play();
                while (wo.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                }
            }

        }

        
    }

    
}