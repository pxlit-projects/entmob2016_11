using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Smart_Garden.Pages
{
    public partial class Login : ContentPage
    {
        HttpClient client;
        public Login()
        {
            InitializeComponent();
            client = new HttpClient();
            WebRequest wr = 
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(System.Net.Http.Headers.)
        }
        public string val(String userName, String userPassword)
        {
            string authInfo = userName + ":" + userPassword;
            authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(authInfo));
           var  q = new HttpRequestHeader();
            
            return authInfo
        }
        public async Task<string> getAllUsers()
        {
            string str = "Nothing";
            using (var client = new HttpClient())
            {
                var baseUri = "http://localhost:9999/user";
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add( new System.Net.Http.Headers.AuthenticationHeaderValue("Basic " + )
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(baseUri);
                if (response.IsSuccessStatusCode)
                {
                    str = await response.Content.ReadAsStringAsync();
                }

                return str;
            }
        }
    }
}
