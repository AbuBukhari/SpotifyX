using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace SpotifyX_Console.Spotify
{
    class Refresh_Spotify
    {
        class SpotifyAuthentication
        {
            public string clientID = "";
            public string clientSecret = "";
            public string redirectURL = "http://localhost:8080/";
        }
        public static void Refresh()
        {
            SpotifyAuthentication sAuth = new SpotifyAuthentication();
            using (HttpClient client = new HttpClient())
            {
               
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(sAuth.clientID + ":" + sAuth.clientSecret)));

                FormUrlEncodedContent formContent = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("refresh_token", Program.refreshToken),
                        new KeyValuePair<string, string>("grant_type", "refresh_token"),
                    });

                var response = client.PostAsync("https://accounts.spotify.com/api/token", formContent).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;
                Program.auth = Regex.Match(responseString, "{\"access_token\":\"(.*?)\",").Groups[1].Value.ToString();
                Logger.Logger.Logg("Getting Some stuff..");
            }
        }
    }
}
