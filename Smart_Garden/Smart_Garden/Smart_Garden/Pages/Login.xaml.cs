using Robotics.Mobile.Core.Bluetooth.LE;
using Smart_Garden.Connection;
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
        IAdapter adapter;
        ConnectionMaker connection;
        List<User> users;
        static string userConnection = "";
        public Login(IAdapter adapter)
        {
            InitializeComponent();
            this.adapter = adapter;
            connection = new ConnectionMaker();
            HttpResponseMessage response = ConnectionMaker.GetAllUsers();
            users = response.Content.ReadAsAsync<List<User>>().Result;
           
        }

        

    }
}
