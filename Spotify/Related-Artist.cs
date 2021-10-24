using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Colorful;
using System.Drawing;
using Console = Colorful.Console;

namespace SpotifyX_Console.Spotify
{
    class Favorite_Track
    {
        public static void access()
        {
            string url = "https://api.spotify.com/v1/artists/" + Favorite_Artist.artist_id + "/related-artists";
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                request.Headers.Add("Authorization", "Bearer " + Program.auth);
                request.ContentType = "application/json; charset=utf-8";


                WebResponse response = request.GetResponse();
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    Regex regex = new Regex("\"name\" : \"(.*?)\"");
                    foreach (Match match in regex.Matches(responseFromServer))
                    {
                        Console.WriteLine(match.Value.Replace("\"", "").Replace("name", "").Replace(":", ""), Color.FromArgb(30, 215, 96));
                        Favorite_Artist.counter++;
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
