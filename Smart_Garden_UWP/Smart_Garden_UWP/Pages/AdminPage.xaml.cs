using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Smart_Garden_UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminPage : Page
    {
        public AdminPage()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            adminSplitView.IsPaneOpen = !adminSplitView.IsPaneOpen;

            String currentState = VisualStateManager.GetVisualStateGroups(pageGrid)[0].CurrentState.Name;

            if (adminSplitView.IsPaneOpen)
            {
                if (currentState.Equals("Compact"))
                {
                    logOutCompactButton.Visibility = Visibility.Collapsed;
                    loggedInUser.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (currentState.Equals("Compact"))
                {
                    logOutCompactButton.Visibility = Visibility.Visible;
                    loggedInUser.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
