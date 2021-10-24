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
    class tracks
    {
        public static string artist_id = "";
        public static int counter = 0;
        public static void access()
        {

            try
            {
                WebRequest request = WebRequest.Create("https://api.spotify.com/v1/me/top/tracks");
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
                    Console.WriteLine("Your favorite Tracks ->", Color.FromArgb(30, 215, 96));
                    Logger.Logger.Logg($"Writing {UserInfo.k}'s favorite Tracks on console.");
                    int number = 1;
                    Console.WriteLine(responseFromServer);
                    foreach (Match match in regex.Matches(responseFromServer))
                    {
                        Console.Write(match.Value.Replace("\"", "").Replace("name", "").Replace(":", ""), Color.FromArgb(30, 215, 96));
                        Console.WriteLine();
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
