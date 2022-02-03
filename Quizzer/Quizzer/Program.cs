using NAudio.Wave;
using System.Net;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;
using CsvHelper;

namespace Quizzer
{


    public class ImageQuestion
    {
        public string ID { get; set; }
        public string Question { get; set; }
        public string Media { get; set; }
        public string Answer { get; set; }

    }

    internal class Program
    {

        public static string img;
        public static string answer;
        public static string qText;

        static string[] id = new string[50];
        static string[] questions = new string[50];
        static string[] answers = new string[50];
        static string[] media = new string[50];

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            parseCSV();
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

        public static void parseCSV()
        {
            using var streamReader = File.OpenText("D:/Documents/Code Projects/Quizzer/Quizzer/Quizzer/imagequestions.csv");
            using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);



            var quests = csvReader.GetRecords<ImageQuestion>().ToList();
            int i = 0;

            foreach (var question in quests)
            {
                id[i] = question.ID;
                questions[i] = question.Question;
                media[i] = question.Media;
                answers[i] = question.Answer;

                i++;

                System.Diagnostics.Debug.WriteLine(questions[2]);
                System.Diagnostics.Debug.WriteLine(media[2]);
                System.Diagnostics.Debug.WriteLine(answers[2]);

            }




        }

        public static void newQuestion()
        {
            Random rnd = new Random();

            int rndValue = rnd.Next(0, 2);


            qText = questions[rndValue];
            img = media[rndValue];
            answer = answers[rndValue];
        }

        
    }

    
}