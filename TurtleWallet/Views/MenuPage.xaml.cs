using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace TurtleWallet.Views
{
    public partial class MenuPage : ContentPage
    {
        ObservableCollection<MenuItem> menus = new ObservableCollection<MenuItem>();
        MenuItem dashboard = new MenuItem { ItemTitle = "Dashboard", Destination = new DashboardPage() };
        MenuItem logout = new MenuItem { ItemTitle = "Log Out", Destination = new LandingPage() };

        public MenuPage()
        {
            InitializeComponent();

            MenuListView.ItemsSource = menus;
            menus.Add(dashboard);
            menus.Add(new MenuItem { ItemTitle = "Network Info", Destination = new NetworkInfoPage() });
            menus.Add(logout);

        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as MenuItem;
            if (item == null)
                return;

            if (item.Equals(logout))
            {
                Application.Current.MainPage = new LandingPage();
            }
            else
            {
                ((RootPage)Application.Current.MainPage).IsPresented = false;
                ((RootPage)Application.Current.MainPage).Detail = new NavigationPage(item.Destination);
            }

            // Manually deselect item
            MenuListView.SelectedItem = null;
        }
    }

    public class MenuItem
    {
        public string ItemTitle { get; set; }
        public ContentPage Destination { get; set; }
    }
}
