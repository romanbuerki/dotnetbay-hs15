using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DotNetBay.Model;

namespace DotNetBay.WPF.ViewModel
{
    class AuctionViewModel : ViewModelBase
    {
        private Auction _auction;

        public ICommand BuyButtonCommand { get; set; }
        
        public AuctionViewModel(Auction auction) : base()
        {
            _auction = auction;
            BuyButtonCommand = new RelayCommand(this.BuyButtonCommandContent);
          
        
        }

        public void BuyButtonCommandContent()
        {
            
                new BidView(_auction).ShowDialog();
                this.OnPropertyChanged(null);
                
        }

        public String Title
        {
            get { return _auction.Title; }
        }

        public String Description
        {
            get { return _auction.Description; }
        }

        public Boolean IsClosed
        {
            get { return _auction.IsClosed; }
        }

        public double StartPrice
        {
            get { return _auction.StartPrice; }
        }

        public double CurrentPrice
        {
            get
            {
                if (_auction.ActiveBid != null)
                {
                    return _auction.ActiveBid.Amount;
                }
                return 0;
            }
        }

        public DateTime StartDateTimeUtc
        {
            get { return _auction.StartDateTimeUtc; }
        }

        public DateTime EndDateTimeUtc
        {
            get { return _auction.EndDateTimeUtc; }
        }

        public String Seller
        {
            get { return _auction.Seller.DisplayName; }
        }

        public DateTime CloseDateTimeUtc
        {
            get { return _auction.CloseDateTimeUtc; }
        }

        public int Bids
        {
            get { return _auction.Bids.Count; }
        }

        public Boolean IsRunning
        {
            get { return _auction.IsRunning; }
        }


    }
}
