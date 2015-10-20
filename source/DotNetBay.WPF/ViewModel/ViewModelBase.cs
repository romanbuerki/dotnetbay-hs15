using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DotNetBay.Core;
using DotNetBay.WPF.Annotations;

namespace DotNetBay.WPF.ViewModel
{
    abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected SimpleMemberService MemberService { get; set; }
        protected AuctionService Service { get; set; }

        public ViewModelBase()
        {
            MemberService = new SimpleMemberService(((App)Application.Current).MainRepository);
            Service = new AuctionService(((App)Application.Current).MainRepository, MemberService);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
