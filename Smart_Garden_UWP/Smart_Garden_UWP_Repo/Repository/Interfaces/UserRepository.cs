using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart_Garden_UWP_Models;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace Smart_Garden_UWP_Repo.Repository
{
    public class UserRepository : IUserRepository
    {
        public string val(String userName, String userPassword)
        {
            string authInfo = userName + ":" + userPassword;
            authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(authInfo));
            var q = new HttpRequestHeader();
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

        public async Task<string> getAllUsers()
        {
            string str = "Nothing";
            using (var client = new HttpClient())
            {
                var baseUri = "http://localhost:9999/user";
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = (new AuthenticationHeaderValue("Basic", val("mkyong", "123456")));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(baseUri);
                if (response.IsSuccessStatusCode)
                {
                    str = await response.Content.ReadAsStringAsync();
                }

                return str;
            }
        }

        public User getUserByUsername()
        {
            throw new NotImplementedException();
        }
    }
}