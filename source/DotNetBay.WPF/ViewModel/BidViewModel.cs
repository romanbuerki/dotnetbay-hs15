using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DotNetBay.Core;
using DotNetBay.Model;

namespace DotNetBay.WPF.ViewModel
{
    class BidViewModel : ViewModelBase
    {
        private Auction _auction;
        public ICommand BidCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public BidViewModel(Auction auction) 
        {
            _auction = auction;
            BidCommand = new RelayCommand<Window>(this.BidCommandContent);
            CloseCommand = new RelayCommand<Window>(this.CloseCommandContent);
        }
        

        public String Title
        {
            get { return _auction.Title; }
            
        }

        public String Description
        {
            get { return _auction.Description; }
        }

        public double StartPrice
        {
            get { return _auction.StartPrice; }
        }

        public double CurrentPrice
        {
            get { return _auction.CurrentPrice; }
        }

      
        public double BidBox { get; set; }

        private void BidCommandContent(Window window)
        {
            if (_auction.ActiveBid == null || BidBox > _auction.ActiveBid.Amount)
            {
                Service.PlaceBid(_auction, BidBox);
                window.Close();
            }
            
        }

        private void CloseCommandContent(Window window)
        {
            window.Close();
        }

    }
}
