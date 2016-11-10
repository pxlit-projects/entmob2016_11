using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart_Garden_UWP_Models;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Diagnostics;
using SmarT_Garden_UWP_Models.Models;

namespace Smart_Garden_UWP_Repo.Repository
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

        #region Repository implementation
        public async Task<Boolean> addUser(User user)
        {
            var baseUri = "user/add";
            
            if(await JsonApiClientPostRequestWithUserObj(baseUri, user))
            {
                return true;
            }

            return false;
        }

        public async Task<Boolean> deleteUser(User user)
        {
            var baseUri = "user/delete";

            if(await JsonApiClientDeleteRequestWithUserObj(baseUri, user))
            {
                return true;
            }

            return false;
        }

        public async Task<List<User>> getAllUsers()
        {
            List<User> users = null;
            var baseUri = "http://localhost:9999/user";

            String json = await JsonApiClientGetRequest(baseUri);
            if (json != null)
            {
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }

            return users;
        }

        public async Task<User> getUserByUsername(String username)
        {
            User user = null;
            var baseUri = "http://10.0.2.2:9999/user/getByUsername/" + username;

            String json = await JsonApiClientGetRequest(baseUri);
            if (json != null)
            {
                user = JsonConvert.DeserializeObject<User>(json);
            }

            return user;
        }
        #endregion

        #region JsonApiClient Section
        private async Task<String> JsonApiClientGetRequest(String baseUri)
        {
            String json = null;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = (new AuthenticationHeaderValue("Basic", val("mkyong", "123456")));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.GetAsync(baseUri);
                    if (response.IsSuccessStatusCode)
                    {
                        json = await response.Content.ReadAsStringAsync();
                    }

                    return json;
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }

        private async Task<Boolean> JsonApiClientPostRequestWithUserObj(String baseUri, User user)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:9999/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = (new AuthenticationHeaderValue("Basic", val("mkyong", "123456")));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    StringContent stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(baseUri, stringContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return false;
        }

        private async Task<Boolean> JsonApiClientDeleteRequestWithUserObj(String baseUri, User user)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:9999/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = (new AuthenticationHeaderValue("Basic", val("mkyong", "123456")));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                
                    HttpResponseMessage response = await client.DeleteAsync(baseUri + "/" + user.Id);

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
        #endregion
    }
}