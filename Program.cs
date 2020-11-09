using System;
using System.Collections.Generic;


namespace AnalyzeMusicPlaylist
{
    class Program
    {
        static void Main(string[] args)
        {
            //program takes in arguments and generates error if files are not found, etc.
            if(args.Length != 2) {
                Console.WriteLine("Music <music_text_file_path> <report_file_path");
                Environment.Exit(1);
            }

            string musicDataFilePath = args[0];
            string reportFilePath = args[1];

            List<Music> musicList = null;
            try
            {
                musicList = MusicLoader.Load(musicDataFilePath);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                Environment.Exit(2);
            }

            var report = MusicReport.GenerateText(musicList);

            try
            {
                System.IO.File.WriteAllText(reportFilePath, report);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                Environment.Exit(3);
            }

        }
    }
}
