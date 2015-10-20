using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DotNetBay.Model;

namespace DotNetBay.WPF.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<AuctionViewModel> AuctionsList { get; set; }
        public ICommand AddNewAuctionCommand { get; set; }


    
        public MainViewModel()
        {
            AuctionsList = new ObservableCollection<AuctionViewModel>();
            AddNewAuctionCommand = new RelayCommand(this.AddNewAuctionContent);
            foreach (var auction in Service.GetAll())
            {
              AuctionsList.Add(new AuctionViewModel(auction));  
            }
           
        }

        public void AddNewAuctionContent()
        {
            new SellView().ShowDialog();
        }
    }

    
}
