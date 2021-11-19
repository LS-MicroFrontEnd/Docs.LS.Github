using RequestApi.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RequestApi.LoadObjects
{
    public class LoadHttpClient
    {
        public static async Task<HttpClient> GetHttpClientWithToken(string urlService, string username=null, string password=null,string token=null)
        {
            //Create and Load Http Client
            HttpClient client = GetHttpClient(urlService: urlService);
            //Get Token
            if(string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                AuthenticationRequest authenticationRequest = new AuthenticationRequest(client);
                token = await authenticationRequest.GetToken(username, password);
            }
            //Load Token to Http header
            if(!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }
            return client;
        }
        public static HttpClient GetHttpClient(string urlService, int TimeOut = 50000)
        {
            //Create and Load Http Client
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(urlService);
            client.DefaultRequestHeaders.Accept.Clear();
            client.Timeout = TimeSpan.FromSeconds(TimeOut);
            return client;
        }
    }
}
