using System;
using System.Collections.Generic;

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

using TurtleWallet.Services;

namespace TurtleWallet.Views
{
    public partial class NetworkInfoPage : ContentPage
    {
        public NetworkInfoPage()
        {
            InitializeComponent();

            var str = GetHeight();
            str = GetHashRate();
            str = GetSupply();
            str = GetDifficulty();
        }

        async Task<String> GetHeight()
        {
            string hashrate = await DaemonModule.CurrentHeight();
            Height.Text = hashrate;
            return hashrate;
        }

        async Task<String> GetHashRate()
        {
            string hashrate = await DaemonModule.CurrentHashrate();
            HashRate.Text = hashrate;
            return hashrate;
        }

        async Task<String> GetSupply()
        {
            string hashrate = await DaemonModule.CurrentSupply();
            Supply.Text = hashrate;
            return hashrate;
        }

        async Task<String> GetDifficulty()
        {
            string hashrate = await DaemonModule.CurrentDifficulty();
            Difficulty.Text = hashrate;
            return hashrate;
        }
    }
}
