using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leaf.xNet;


namespace SpotifyX_Console.Spotify
{
    class UserTrack
    {
        public static void track()
        {
            string playing = "";
            try
            {
                var req = new HttpRequest();
                req.AddHeader("Content-Type", "application/json");
                req.AddHeader("Accept", "application/json");
                req.AddHeader("Authorization: Bearer ", Program.auth);
                playing = req.Get("https://api.spotify.com/v1/me", null).ToString();
                Console.WriteLine(playing);
            }
            catch
            {
                Console.WriteLine("Failed");
            }


        }
    }
}
