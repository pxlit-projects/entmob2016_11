using Plugin.BLE.Abstractions.Contracts;
using Smart_Garden.Models;
using Smart_Garden.ViewModels;
using Xamarin.Forms;

namespace Smart_Garden.Pages
{
    public partial class Login : ContentPage
    {

        public Login(IAdapter adapter, IBluetoothLE ble)
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(adapter, ble, Navigation);

        }
    }
}
