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
            File.AppendAllText($"Loggs\\{Program.name}.txt", $"[SpotifyX Date: {DateTime.Now.ToString("H.mm.ss")}] {text}" + Environment.NewLine);
            return text;
        }
    }
}
