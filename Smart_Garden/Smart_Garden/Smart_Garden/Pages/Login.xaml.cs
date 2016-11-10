using Robotics.Mobile.Core.Bluetooth.LE;
using Smart_Garden.Models;
using Smart_Garden.ViewModels;
using Xamarin.Forms;

namespace Smart_Garden.Pages
{
    public partial class Login : ContentPage
    {
        IAdapter adapter;
        public Login(IAdapter adapter)
        {
            InitializeComponent();
            this.adapter = adapter;
            MessagingCenter.Subscribe<Login>(this, "adapter", (padapter) =>
            {
                
            });
            MessagingCenter.Subscribe<Login>(this, "user", (puser) =>
            {
                
            });
            MessagingCenter.Send(adapter, "adapter");
        }
    }
}
