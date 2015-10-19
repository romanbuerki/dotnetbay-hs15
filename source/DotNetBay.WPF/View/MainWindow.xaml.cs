using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DotNetBay.Core;
using DotNetBay.Model;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Auction> auctions = new ObservableCollection<Auction>();

        public ObservableCollection<Auction> Auctions { get { return auctions; } }

        public MainWindow()
        {
            if ((Application.Current as App) != null)
            {
                var service = new AuctionService(((App)Application.Current).MainRepository, new SimpleMemberService(((App)Application.Current).MainRepository));
              
                foreach (var auction in service.GetAll())
                {
                    this.Auctions.Add(auction);
                }
            }
            DataContext = this;
            InitializeComponent();
            
          
        }

       

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

            new SellView().ShowDialog();

        }

        private void ButtonBuy_OnClick(object sender, RoutedEventArgs e)
        {
            Auction auction = ((FrameworkElement)sender).DataContext as Auction;
            BidView bidView = new BidView(auction);
            bidView.ShowDialog();

        }


    }
}
