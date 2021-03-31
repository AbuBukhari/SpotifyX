using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Web;
using System.Text.RegularExpressions;
using Colorful;
using System.Drawing;
using Console = Colorful.Console;

namespace SpotifyX_Console.LocalHost
{

    class LocalHost
    {
        static HttpListener _httpListener = new HttpListener();
        public static void host()
        {
            Logger.Logger.Logg("Started a localhost server");
            _httpListener.Prefixes.Add("http://localhost:8080/");
            _httpListener.Start();
            Thread _responseThread = new Thread(ResponseThread);
            _responseThread.Start(); // start the response thread



        }

        public static string Splitter(string orignal, string left, string right)
        {
            return orignal.Split(new string[]
            {
                left
            }, StringSplitOptions.None)[1].Split(new string[]
            {
                right
            }, StringSplitOptions.None)[0];
        }

        public static HttpListenerContext context;
        public static string Context = "";
        static void ResponseThread()
        {
            while (true)
            {
                context = _httpListener.GetContext();
                var request = context.Request;
                Context = request.Url.PathAndQuery;
                if (Context.Contains("/?code"))
                {
                    Program.Token_user = Splitter(Context, "/?code=", "&state");
                    Program.result = true;
                }
                byte[] _responseArray = Encoding.UTF8.GetBytes("<html><head><title>SpotifyX</title></head>" +
                "<body style='background-color=#65000b'> Please hold this on the background. You can exit this when your in the main menu - <strong>SpotifyX</strong></body></html>"); 
                context.Response.OutputStream.Write(_responseArray, 0, _responseArray.Length); 
                context.Response.KeepAlive = false; 
                context.Response.Close(); 
            }
        }
    }
}
