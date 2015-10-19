using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DotNetBay.WPF.Annotations;

namespace DotNetBay.WPF.ViewModel
{
    abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected abstract void OnPropertyChanged([CallerMemberName] string propertyName = null);

    }
}
