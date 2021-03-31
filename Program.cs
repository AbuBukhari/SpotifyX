﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Colorful;
using Console = Colorful.Console;
using System.Drawing;
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
        public static string name = Guid.NewGuid().ToString();
        public static bool result;

        static void Main(string[] args)
        {
            // Color.FromArgb(30, 215, 96)  =  Spotify Green color
            // Color.FromArgb(25, 20, 20) =  Spotify Black color
            Console.BackgroundColor = Color.FromArgb(25, 20, 20);
            Console.Clear();
            Console.ForegroundColor = Color.FromArgb(30, 215, 96);
            Console.Title = "SpotifyX - Waiting for user | Created by Vanix";
            if(!Directory.Exists("Temp"))
            {
               Directory.CreateDirectory("Temp");     
            }
            if(!File.Exists($"Temp\\{name}.txt"))
            {
                var k = File.Create($"Temp\\{name}.txt");
                k.Close();
            }
            Logger.Logger.Logg("Trying to logg in....");
            LocalHost.LocalHost.host();
            Console.WriteLine("Auth....");
            Logger.Logger.Logg("Started a process");
            System.Diagnostics.Process.Start("https://accounts.spotify.com/authorize?client_id=dcf7c38d3cb0434fb4fdb6ac3f736f04&response_type=code&redirect_uri=http%3A%2F%2Flocalhost%3A8080%2F&callback&scope=user-read-private%20user-read-email%20user-top-read&state=34fFs29kd09");
            Console.WriteLine("Press enter if there is /?key in the url");
            Console.ReadLine();

                Auth_Spotify.Access();
                Thread.Sleep(500);
                Logger.Logger.Logg("Talking to spotify api...");
                Task.Factory.StartNew(delegate ()
                {
                    for (; ; )
                    {
                        Refresh_Spotify.Refresh();
                        Thread.Sleep(1500);
                    }
                });
                Console.Clear();
                Logo.Design.Logo();
                UserInfo.access();
                Favorite_Artist.access();
                Logger.Logger.Logg("----------------------------------------------------------");
                Console.ReadLine();
        }
    }
}
