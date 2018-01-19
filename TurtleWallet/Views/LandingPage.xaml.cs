using System;
using Xamarin.Forms;

namespace TurtleWallet.Views
{
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        public RootPage GetRootPage()
        {
            Page menuPage = new MenuPage();
            var NavigationPage = new NavigationPage(new DashboardPage());
            var RootPage = new RootPage();
            menuPage.Title = "Menu";
            RootPage.Master = menuPage;
            RootPage.Detail = NavigationPage;

            return RootPage;
        }

        void SignInOnClick(object sender, EventArgs e)
        {
            Application.Current.MainPage = GetRootPage();
        }
    }
}
