using System;

using Xamarin.Forms;

namespace TurtleWallet.Services
{
    public class DaemonModule : ContentPage
    {
        public DaemonModule()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

