using System;

namespace AnalyzeMusicPlaylist
{
    //create a class to initiate with all the headers inside the txt file
    public class Music
    {
        public string Name;
        public string Artist;
        public string Album;
        public string Genre;
        public int Size;
        public int Time;
        public int Year;
        public int Plays;

    //create constructor that takes in all attributes of the 'Music' class
        public Music(string name, string artist, string album, string genre, int size, int time, int year, int plays)
        {
            Name = name;
            Artist = artist; 
            Album = album;
            Genre = genre;
            Size = size;
            Time = time;
            Year = year;
            Plays = plays;
        }
    }
}