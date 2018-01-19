using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace TurtleWallet.Views
{
    public partial class WalletPage : ContentPage
    {
        ObservableCollection<TransactionItem> transactions = new ObservableCollection<TransactionItem>();

        public WalletPage()
        {
            InitializeComponent();
            TransactionList.ItemsSource = transactions;
            transactions.Add(new TransactionItem{ PublicKey="TRTLaaaa...aaaa", Date="1day ago", Type=TransactionItem.TransactionType.Outgoing, Amount=300 });
            transactions.Add(new TransactionItem { PublicKey = "TRTLbbbb...bbbb", Date = "2days ago", Type = TransactionItem.TransactionType.Outgoing, Amount = 210 });
            transactions.Add(new TransactionItem { PublicKey = "TRTLcccc...cccc", Date = "2weeks ago", Type = TransactionItem.TransactionType.Outgoing, Amount = 180 });

        }

        async void SendOnClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SendCoinModal());

        }

        async void ReceiveOnClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ReceiveCoinModal());
        }
    }

    public class TransactionItem
    {
        public string PublicKey { get; set; }
        public TransactionType Type { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; }
        public string TransactionArrow 
        {
            get
            {
                if (Type == TransactionType.Incoming)
                    return "←";
                if (Type == TransactionType.Outgoing)
                    return "→";

                return "";
            }
        }

        public string AmountDisplay
        {
            get
            {
                return Amount + "TRTL";
            }
        }

        public string TransactionTypeDisplay
        {
            get
            {
                if (Type == TransactionType.Incoming)
                    return "Received from";
                if (Type == TransactionType.Outgoing)
                    return "Sent to";

                return "";
            }
        }

        public enum TransactionType { Incoming, Outgoing };
    }
}
