using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpotifyX_Console.Logger
{
    class Logger
    {
        public static string Logg(string text)
        {
            File.AppendAllText("LoggSystem.txt", text + " - Spotify X Logg System. Date: "+ DateTime.Now.ToString("H.mm.ss - dddd, dd") + Environment.NewLine);
            return text;
        }
    }
}
