using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Colorful;
using Console = Colorful.Console;
using System.Drawing;
using SpotifyAPI.Web;
using SpotifyX_Console.Spotify;
using System.IO;
using System.Threading;
using System.Web;



namespace SpotifyX_Console
{
    class Program
    {
        public static string Token = "";
        public static string Token_user = "";
        public static string auth = "";
        public static string refreshToken = "";
        public static string Parse(string orignal, string left, string right)
        {
            return orignal.Split(new string[]
            {
                left
            }, StringSplitOptions.None)[1].Split(new string[]
            {
                right
            }, StringSplitOptions.None)[0];
        }


        static void Main(string[] args)
        {
            Logger.Logger.Logg("Trying to logg in....");
            LocalHost.LocalHost.host();
            Console.WriteLine("Auth....");
            System.Diagnostics.Process.Start("https://accounts.spotify.com/authorize?client_id=   &response_type=code&redirect_uri=http%3A%2F%2Flocalhost%3A8080%2F&callback&scope=user-read-private%20user-read-email&state=34fFs29kd09");
            Console.ReadLine();
            Auth_Spotify.Access();
            Console.ReadLine();

        }
    }
}
