using System;
using System.Collections.Generic;
using System.IO;

namespace AnalyzeMusicPlaylist
{
    //create a class to load the data from the text file and put it into a list
    public static class MusicLoader
    {
        //specifies that there are 7 'fields' in the list
        private static int NumItemsInRow = 8;

        //make a new list and load the data file path (input by user)
        public static List<Music> Load(string musicDataFilePath){
            List<Music> musicList = new List<Music>();

            //iterate throught the StreamReader for each index, but skips the first line with all the headers
            try
            {
                using (var reader = new StreamReader(musicDataFilePath))
                {
                    int lineNumber = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        lineNumber++;
                        if (lineNumber == 1) continue;

                        var values = line.Split("\t"); //splits into tabs, not commas

                        if (values.Length != NumItemsInRow)
                        {
                            throw new Exception($"Row {lineNumber} contains {values.Length} values. It should contain {NumItemsInRow}.");
                        }
                        try
                        {
                            string name = (values[0]);
                            string artist = (values[1]);
                            string album = (values[2]);
                            string genre = (values[3]);
                            int size = Int32.Parse(values[4]);
                            int time = Int32.Parse(values[5]);
                            int year = Int32.Parse(values[6]);
                            int plays = Int32.Parse(values[7]);
                            Music music = new Music(name, artist, album, genre, size, time, year, plays);
                            musicList.Add(music);
                        }
                        catch (FormatException e)
                        {
                            throw new Exception($"Row {lineNumber} contains invalid data. ({e.Message})");
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception($"Unable to open {musicDataFilePath} ({e.Message}).");
            }

            return musicList;
        }

    }
}
