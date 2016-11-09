using Smart_Garden_UWP.Pages;
using Smart_Garden_UWP.Services.Interfaces;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Smart_Garden_UWP.Services
{
    public class NavigationService : INavigationService
    {
        public void NavigateTo(string key)
        {
            if (key == "Admin")
            {
                AdminPage page = new AdminPage();
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(AdminPage));
            }

            if(key == "User")
            {
                StatisticsPage page = new StatisticsPage();
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(StatisticsPage));
            }

            if(key == "Logout")
            {
                LoginPage page = new LoginPage();
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(LoginPage));
            }

            if(key == "UserManagement")
            {
                UserManagementPage page = new UserManagementPage();
                Frame rootFrame = Window.Current.Content as Frame;

                if(rootFrame.Content as AdminPage != null)
                {
                    AdminPage adminPage = rootFrame.Content as AdminPage;
                    // get the grid of the adminPage
                    Grid adminPageGrid = VisualTreeHelper.GetChild(adminPage, 0) as Grid;
                    // get the splitview from within that grid
                    SplitView adminPageSplitView = VisualTreeHelper.GetChild(adminPageGrid, 0) as SplitView;
                    // Eventually access the content of the splitview (this is our frame we need to navigate)
                    Frame mySplitViewFrame = adminPageSplitView.Content as Frame;
                    // change the frame which is shown in here
                    mySplitViewFrame.Navigate(typeof(UserManagementPage));
                }
            }

            if(key == "CropManagement")
            {
                CropSettingsPage page = new CropSettingsPage();
                Frame rootFrame = Window.Current.Content as Frame;

                if (rootFrame.Content as AdminPage != null)
                {
                    AdminPage adminPage = rootFrame.Content as AdminPage;
                    // get the grid of the adminPage
                    Grid adminPageGrid = VisualTreeHelper.GetChild(adminPage, 0) as Grid;
                    // get the splitview from within that grid
                    SplitView adminPageSplitView = VisualTreeHelper.GetChild(adminPageGrid, 0) as SplitView;
                    // Eventually access the content of the splitview (this is our frame we need to navigate)
                    Frame mySplitViewFrame = adminPageSplitView.Content as Frame;
                    // change the frame which is shown in here
                    mySplitViewFrame.Navigate(typeof(CropSettingsPage));
                }
            }
        }

    }
}
