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
    class UserInfo
    {
        public static void access()
        {
            try
            {
                WebRequest request = WebRequest.Create("https://api.spotify.com/v1/me");
                request.Method = "GET";
                request.Headers.Add("Authorization", "Bearer " + Program.auth);
                request.ContentType = "application/json; charset=utf-8";


                WebResponse response = request.GetResponse();
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    string name = Regex.Match(responseFromServer, "\"display_name\" : \"(.*?)\",").Groups[1].Value.ToString();
                    string country = Regex.Match(responseFromServer, "\"country\" : \"(.*?)\",").Groups[1].Value.ToString();
                    bool premium = Regex.Match(responseFromServer, "\"product\" : \"premium\",").Success;
                    Console.WriteLine("--------------------------", Color.FromArgb(30, 215, 96));
                    Console.WriteLine("Spotify Name: " + name, Color.FromArgb(30, 215, 96));
                    Console.WriteLine("Country: " + country, Color.FromArgb(30, 215, 96));
                    Console.WriteLine("spotify Premium: " + premium, Color.FromArgb(30, 215, 96));
                    Console.WriteLine("--------------------------", Color.FromArgb(30, 215, 96));
                }
             }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
