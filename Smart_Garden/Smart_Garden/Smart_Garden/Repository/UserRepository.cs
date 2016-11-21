using Newtonsoft.Json;
using Smart_Garden.Models;
using Smart_Garden.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden.Repository
{
    public class UserRepository : IUserRepository
    {
        #region Helper methods
        public string val(String userName, String userPassword)
        {
            string authInfo = userName + ":" + userPassword;
            authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(authInfo));
            return authInfo;
        }
        #endregion
        public async Task<List<User>> getAllUsers()
        {
            List<User> users = null;
            var baseUri = "http://192.168.43.38:9999/user";

            String json = await JsonApiClientGetRequest(baseUri);
            if (json != null)
            {
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }

            return users;
        }
        public async Task<bool> updateUser(User user)
        {
            var baseUri = "user/update";

            if (await JsonApiClientPutRequestWithUserObj(baseUri, user))
            {
                return true;
            }

            return false;
        }

        public async Task<User> getUserByUsername(String username)
        {
            User user = null;
            var baseUri = "http://192.168.43.38:9999/user/getByUsername/" + username;

            String json = await JsonApiClientGetRequest(baseUri);
            if (json != null)
            {
                user = JsonConvert.DeserializeObject<User>(json);
            }

            return user;
        }

        private async Task<String> JsonApiClientGetRequest(String baseUri)
        {
            String json = null;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = (new AuthenticationHeaderValue("Basic", val("admin", "admin")));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.GetAsync(baseUri);
                    if (response.IsSuccessStatusCode)
                    {
                        json = await response.Content.ReadAsStringAsync();
                    }

                    return json;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }

        private async Task<Boolean> JsonApiClientPutRequestWithUserObj(String baseUri, User user)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://192.168.43.38:9999/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = (new AuthenticationHeaderValue("Basic", val("admin", "admin")));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    StringContent stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync(baseUri, stringContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return false;
        }
    }
}

