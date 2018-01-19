using System;

using Xamarin.Forms;

namespace TurtleWallet.Views
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        async void WalletOnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WalletPage());
        }
    }
}
