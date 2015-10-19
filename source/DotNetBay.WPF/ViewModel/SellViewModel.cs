using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DotNetBay.Core;
using DotNetBay.Model;

namespace DotNetBay.WPF.ViewModel
{
    class SellViewModel : ViewModelBase
    {
        private Auction _auction = new Auction();

        public String Title
        {
            get { return _auction.Title; }
            set { _auction.Title = value; }
        }
        public String Description
        {
            get { return _auction.Description; }
            set { _auction.Description = value; }
        }
        public double StartPrice
        {
            get { return _auction.StartPrice; }
            set { _auction.StartPrice = value; }
        }

        public DateTime StartDateTimeUtc
        {
            get { return _auction.StartDateTimeUtc; }
            set { _auction.StartDateTimeUtc = value; }
        }

        public DateTime EndDateTimeUtc
        {
            get { return _auction.EndDateTimeUtc; }
            set { _auction.EndDateTimeUtc = value; }
        }

        public SellViewModel()
        {
            SaveAuctionCommand = new RelayCommand<Window>(this.SaveAuctionContent);
        }

     
        protected override void OnPropertyChanged(string propertyName = null)
        {
            throw new NotImplementedException();
        }

        public ICommand SaveAuctionCommand { get; private set; }

        public ICommand CloseWindowCommand { get; private set; }

        private void SaveAuctionContent(Window window)
        {
            var memberService = new SimpleMemberService(((App) Application.Current).MainRepository);
            var service = new AuctionService(((App) Application.Current).MainRepository, memberService);

            this._auction.Seller = memberService.GetCurrentMember();
            service.Save(this._auction);
            window.Close();
        }
    }
}
