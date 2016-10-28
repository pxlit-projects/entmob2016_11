using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden.Connection
{
    public class ConnectionMaker
    {
        public static string EncodeCredentials(String userName, String userPassword)
        {
            string authInfo = userName + ":" + userPassword;
            authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(authInfo));

            return authInfo;
        }

        static public HttpResponseMessage GetAllUsers()
        {
            using (var client = new HttpClient())
            {

                // Make our request and request the results
                var baseUri = "http://localhost:3306/user";
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = (new System.Net.Http.Headers.AuthenticationHeaderValue("Basic ", EncodeCredentials("mkyong", "123456")));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                

                HttpResponseMessage response = client.GetAsync(baseUri).Result;
                // Throw an exception if an error occurs
                response.EnsureSuccessStatusCode();
                return response;
            }
        }
    
}
}
