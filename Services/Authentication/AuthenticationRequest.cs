using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using RequestApi.LoadObjects;

namespace RequestApi.Services.Authentication
{
    public class AuthenticationRequest
    {
        readonly HttpClient _client;

        //Instancio http client en el constructor
        public AuthenticationRequest(HttpClient client)
        {
            _client = client;
        }
        public AuthenticationRequest(string urlService)
        {
            _client = LoadHttpClient.GetHttpClient(urlService);
        }

        public async Task<string> GetToken(string username, string password, string endPoint = "api/account/login")
        {
            try
            {
                //Creo un objeto usuario con el usuario u contraseña
                var user = new { username, password };
                //serializo el usuario en un string
                string userSerilize = JsonSerializer.Serialize(user);
                //agrego el usuario en el http content
                HttpContent httpContent = new StringContent(userSerilize, Encoding.UTF8, "application/json");
                //Realizo el post
                HttpResponseMessage response = await _client.PostAsync(endPoint, httpContent);
                //Leo el resultado
                string jsonResponseResult = response.Content.ReadAsStringAsync().Result;
                //Obtengo el token
                JsonDocument document = JsonDocument.Parse(jsonResponseResult);
                JsonElement root = document.RootElement;
                JsonElement tokenElement = root.GetProperty("token");
                //Devuelvo el token
                return tokenElement.GetString() ;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
