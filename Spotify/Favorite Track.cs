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

namespace SpotifyX_Console.Spotify
{
    class Favorite_Artist
    {
        public static Match match;
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
                    Console.WriteLine("Your favorite artists ->", Color.FromArgb(30, 215, 96));
                    foreach (Match match in regex.Matches(responseFromServer))
                    {
                        Console.WriteLine(match.Value.Replace("\"", "").Replace("name", "").Replace(":", ""), Color.FromArgb(30, 215, 96));
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
