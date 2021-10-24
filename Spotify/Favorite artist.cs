using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpotifyX_Console.LocalHost;
using System.Drawing;
using Colorful;
using Console = Colorful.Console;
using System.Threading;

namespace SpotifyX_Console.Spotify
{
    class Favorite_Artist
    {
        public static string artist_id = "";
        public static int counter = 0;
        public static void access()
        {
            
            try
            {
                WebRequest request = WebRequest.Create("https://api.spotify.com/v1/me/top/artists");
                request.Method = "GET";
                request.Headers.Add("Authorization", "Bearer " + Program.auth);
                request.ContentType = "application/json; charset=utf-8";


                WebResponse response = request.GetResponse();
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    Regex regex = new Regex("\"name\" : \"(.*?)\"");
                    Regex regex_id = new Regex("\"id\" : \"(.*?)\",");
                    Console.WriteLine("Your favorite artists ->", Color.FromArgb(30, 215, 96));
                    Logger.Logger.Logg($"Writing {UserInfo.k}'s favorite artists on console.");
                    int number = 1;
                    foreach (Match match in regex.Matches(responseFromServer))
                    {
                        Console.WriteLine(number + " - " + match.Value.Replace("\"", "").Replace("name", "").Replace(":", ""), Color.FromArgb(30, 215, 96));
                        number++;
                    }
                    Thread.Sleep(1000);
                    Console.WriteLine("Wanna see your related artists?", Color.FromArgb(30, 215, 96));
                    Console.ReadLine();
                    Logger.Logger.Logg($"Writing {UserInfo.k}'s related artists on console.");
                    Console.WriteLine("Your related artists ->", Color.FromArgb(30, 215, 96));
                    foreach (Match match in regex_id.Matches(responseFromServer))
                    {

                        artist_id = match.Value.Replace("\"", "").Replace("id", "").Replace(":", "").Replace(",", "").Replace("  ", "");
                        Favorite_Track.access();
                    }
                    Console.WriteLine($"I found {counter} related artists!", Color.FromArgb(30, 215, 96));

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
