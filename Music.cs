using System;

namespace AnalyzeMusicPlaylist
{
    public class Music
    {
        public string Name;
        public string Artist;
        public string Genre;
        public int Size;
        public int Time;
        public int Year;
        public int Plays;

        public Music(string name, string artist, string genre, int size, int time, int year, int plays)
        {
            Name = name;
            Artist = artist; 
            Genre = genre;
            Size = size;
            Time = time;
            Year = year;
            Plays = plays;
        }
    }
}