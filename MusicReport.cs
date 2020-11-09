using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnalyzeMusicPlaylist
{
    public static class MusicReport
    {
        public static string GenerateText(List<Music> musicList)
        {
            string report = "Music Playlist Report\n\n";

            if (musicList.Count() < 1)
            {
                report += "No data is available. \n";

                return report;
            }

            //How many songs received 200 or more plays?
            report += "Songs that reveived 200 or more plays:";
            var songsPlayed = from music in musicList where music.Plays > 200 select music;
            if(songsPlayed.Count() > 0)
            {
                foreach (var songs in songsPlayed)
                {
                    report += "\nName: " + songs.Name + "," + "  Artist: " + songs.Artist + "," + "  Album: " + songs.Album + "," + "  Genre: " + songs.Genre
                    + "," + "  Size: " + songs.Size + "," + "  Time: " + songs.Time + "," + "  Year: " + songs.Year + "," + "  Plays: " + songs.Plays;
                }
                report.TrimEnd(',');
                report += "\n";
            }
            else{
                report += "not available\n";
            }

            //How many songs are in the playlist with the Genre of “Alternative”?
            var alternativeSongs = from music in musicList where music.Genre == "Alternative" select music;
            var countAlternative = 0;
            if(alternativeSongs.Count() > 0)
            {
                foreach (var songs in alternativeSongs)
                {
                    countAlternative ++;
                }
                report += "\n\nNumber of Alternative songs: " + countAlternative;
                report.TrimEnd(',');
                report += "\n";
            }
            else{
                report += "not available\n";
            }


            //How many songs are in the playlist with the Genre of “Hip-Hop/Rap”?
            var hippieHop = from music in musicList where music.Genre == "Hip-Hop/Rap" select music;
            var countHippie = 0;
            if(hippieHop.Count() > 0)
            {
                foreach (var songs in hippieHop)
                {
                    countHippie ++;
                }
                report += "\n\nNumber of Hip-Hop/Rap songs: " + countHippie;
                report.TrimEnd(',');
                report += "\n";
            }
            else{
                report += "not available\n";
            }

            //What songs are in the playlist from the album “Welcome to the Fishbowl?”
            report += "\n\nSongs from album 'Welcome to the Fishbowl'";
            var songFish = from music in musicList where music.Album == "Welcome to the Fishbowl" select music;
            if(songFish.Count() > 0)
            {
                foreach (var songs in songFish)
                {
                    report += "\nName: " + songs.Name + "," + "  Artist: " + songs.Artist + "," + "  Album: " + songs.Album + "," + "  Genre: " + songs.Genre
                    + "," + "  Size: " + songs.Size + "," + "  Time: " + songs.Time + "," + "  Year: " + songs.Year + "," + "  Plays: " + songs.Plays;
                }
                report.TrimEnd(',');
                report += "\n";
            }
            else{
                report += "not available\n";
            }

            //What are the songs in the playlist from before 1970?
            report += "\n\nSongs older than 1970:";
            var oldies = from music in musicList where music.Year < 1970 select music;
            if(oldies.Count() > 0)
            {
                foreach (var songs in oldies)
                {
                    report += "\nName: " + songs.Name + "," + "  Artist: " + songs.Artist + "," + "  Album: " + songs.Album + "," + "  Genre: " + songs.Genre
                    + "," + "  Size: " + songs.Size + "," + "  Time: " + songs.Time + "," + "  Year: " + songs.Year + "," + "  Plays: " + songs.Plays;
                }
                report.TrimEnd(',');
                report += "\n";
            }
            else{
                report += "not available\n";
            }

            //What are the song names that are more than 85 characters long?
            report += "\n\nSongs names greater than 85 characters long:";
            var longies = from music in musicList where music.Name.Length > 85 select music;
            if(longies.Count() > 0)
            {
                foreach (var songs in longies)
                {
                    report += "\nName: " + songs.Name + "," + "  Artist: " + songs.Artist + "," + "  Album: " + songs.Album + "," + "  Genre: " + songs.Genre
                    + "," + "  Size: " + songs.Size + "," + "  Time: " + songs.Time + "," + "  Year: " + songs.Year + "," + "  Plays: " + songs.Plays;
                }
                report.TrimEnd(',');
                report += "\n";
            }
            else{
                report += "not available\n";
            }


            //What is the longest song? (longest in Time)
            report += "\n\nLongest song (in time):";
            var longestSongEver = from music in musicList where music.Time > 0 orderby music.Time descending select music;
            var longNum = 0;
            if(longestSongEver.Count() > 0)
            {
                foreach (var songs in longestSongEver)
                {
                    longNum += 1;
                    if (longNum == 1){
                        report += "\nName: " + songs.Name + "," + "  Artist: " + songs.Artist + "," + "  Album: " + songs.Album + "," + "  Genre: " + songs.Genre
                    + "," + "  Size: " + songs.Size + "," + "  Time: " + songs.Time + "," + "  Year: " + songs.Year + "," + "  Plays: " + songs.Plays;
                    }
                    else{
                        break;
                    }
                }
                report.TrimEnd(',');
                report += "\n";
            }
            else{
                report += "not available\n";
            }
            return report;
        }
    }
}
