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

namespace Smart_Garden_UWP_Repo.Repository
{
    public class UserRepository : IUserRepository
    {
        public string val(String userName, String userPassword)
        {
            string authInfo = userName + ":" + userPassword;
            authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(authInfo));
            return authInfo;
        }

        public void addUser()
        {
            throw new NotImplementedException();
        }

        public void deleteUser()
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> getAllUsers()
        {
            List<User> users = null;
            var baseUri = "http://localhost:9999/user";

            String json = await DBClient(baseUri);
            if (json != null)
            {
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }

            return users;
        }

        public async Task<User> getUserByUsername(String username)
        {
            User user = null;
            var baseUri = "http://localhost:9999/user/getByUsername/" + username;

            String json = await DBClient(baseUri);
            if (json != null)
            {
                user = JsonConvert.DeserializeObject<User>(json);
            }

            return user;
        }

        //TODO FIX PROBLEM
        public async Task<String> getUserRole(User user)
        {
            String role = null;
            var baseUri = "http//localhost:9999/user/getRole/" + user.Username;

            String json = await DBClient(baseUri);
            if(json != null)
            {
                role = JsonConvert.DeserializeObject<String>(json);
            }

            return role;
        }

        private async Task<String> DBClient(String baseUri)
        {
            String json = null;

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
    }
}