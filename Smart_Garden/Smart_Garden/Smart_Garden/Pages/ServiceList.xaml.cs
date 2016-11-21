using Robotics.Mobile.Core.Bluetooth.LE;
using Smart_Garden.Models;
using Smart_Garden.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Smart_Garden.Pages
{
    public partial class ServiceList : ContentPage
    {
        public ServiceList(User user)
        {
            InitializeComponent();
            BindingContext = new ServiceListViewModel(user);
            

        }


    }
}
