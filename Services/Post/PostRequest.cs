using RequestApi.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using RequestApi.LoadObjects;

namespace RequestApi.Services.Post
{
    public class PostRequest
    {
        public static async Task<T> PostApiWithAuthentication<T>(string urlService, string endpoint, string contentRequest, string username, string password)
        {
            try
            {
                //Create and Load Http Client
                HttpClient client = await LoadHttpClient.GetHttpClientWithToken(urlService: urlService,username: username, password: password);
                //Post Request
                return await PostApiRequest<T>(client, endpoint, contentRequest);
            }
            catch (Exception ex)
            {
                throw ex;//return error
            }
        }
        public static async Task<T> PostApiWithAuthentication<T>(string urlService, string endpoint, string contentRequest,string token)
        {
            try
            {
                //Create and Load Http Client
                HttpClient client = await LoadHttpClient.GetHttpClientWithToken(urlService:urlService, token: token);
                //Post Request
                return await PostApiRequest<T>(client, endpoint, contentRequest);
            }
            catch (Exception ex)
            {
                throw ex;//return error
            }
        }
        public static async Task<T> PostApiWithoutAuthentication<T>(string urlService, string endpoint, string contentRequest)
        {
            try
            {
                //Create and Load Http Client
                HttpClient client = LoadHttpClient.GetHttpClient(urlService:urlService);
                //Post Request
                return await PostApiRequest<T>(client, endpoint, contentRequest);
            }
            catch (Exception ex)
            {
                throw ex;//return error
            }
        }
        private static async Task<T> PostApiRequest<T>(HttpClient client, string endpoint, string contentRequest)
        {
            try
            {
                //Load Http Content
                HttpContent httpContent = new StringContent(contentRequest, Encoding.UTF8, "application/json");
                //Do Request
                HttpResponseMessage responseMessage = await client.PostAsync(endpoint, httpContent);
                /**/
                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    //Get json result
                    string jsonResult = responseMessage.Content.ReadAsStringAsync().Result;
                    T result;
                    try
                    {
                        //Deserialize result to Object
                        result = JsonSerializer.Deserialize<T>(jsonResult);
                    }
                    catch
                    {
                        try
                        {
                            //Try deserialize result when the type is primitive
                            result = (T)Convert.ChangeType(jsonResult, typeof(T));
                        }
                        catch (Exception ex)
                        {
                            throw ex;//Return error
                        }
                    }
                    return result;//Reurn result
                }
                else
                {
                    //Get error
                    string error = await responseMessage.Content.ReadAsStringAsync();
                    //Create a exception with this error message
                    Exception ex = new Exception(error);
                    throw ex;//return error
                }
            }
            catch (Exception ex)
            {
                throw ex;//return error
            }
        }

    }
}
