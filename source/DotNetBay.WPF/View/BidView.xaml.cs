using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DotNetBay.Core;
using DotNetBay.Model;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for BidView.xaml
    /// </summary>
    public partial class BidView : Window
    {
        private Auction _auction;
        public BidView()
        {
            InitializeComponent();
        }

        public BidView(Auction auction) : this()
        {
            _auction = auction;
            this.DataContext = _auction;
        }

        private void ButtonBid_OnClick(object sender, RoutedEventArgs e)
        {
            int bidPrice = 0;
            Int32.TryParse(BidBox.Text, out bidPrice);
            if (bidPrice > _auction.CurrentPrice)
            {
                var memberService = new SimpleMemberService(((App)Application.Current).MainRepository);
                var service = new AuctionService(((App)Application.Current).MainRepository, memberService);
                Bid bid = new Bid();
                bid.Bidder = memberService.GetCurrentMember();
                bid.Accepted = true;
                bid.Amount = bidPrice;
                _auction.CurrentPrice = bidPrice;
                _auction.Bids.Add(bid);
                service.Save(_auction);
            }
                
            this.Close();
        }
        private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
