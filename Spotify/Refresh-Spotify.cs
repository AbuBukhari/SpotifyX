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
            public string clientID = "dcf7c38d3cb0434fb4fdb6ac3f736f04";
            public string clientSecret = "e44267b0951a4cceb370ac97fc3ec8ef";
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
            }
        }
    }
}
