using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Web;
using System.Text.RegularExpressions;

namespace SpotifyX_Console.LocalHost
{

    class LocalHost
    {
        static HttpListener _httpListener = new HttpListener();
        public static void host()
        {
            Console.WriteLine("Starting server...");
            _httpListener.Prefixes.Add("http://localhost:8080/");
            _httpListener.Start();
            Thread _responseThread = new Thread(ResponseThread);
            _responseThread.Start(); // start the response thread

 

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
                Program.Token_user = Program.Parse(Context, "/?code=", "&");
                byte[] _responseArray = Encoding.UTF8.GetBytes("<html><head><title>Localhost server -- port 5000</title></head>" +
                "<body>Welcome to the <strong>Localhost server</strong> -- <em> Please dont close the website for spotifyX</em></body></html>"); 
                context.Response.OutputStream.Write(_responseArray, 0, _responseArray.Length); 
                context.Response.KeepAlive = false; 
                context.Response.Close(); 
            }
        }
    }
}
