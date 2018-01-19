using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TurtleWallet.Views
{
    public partial class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;
            //NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
