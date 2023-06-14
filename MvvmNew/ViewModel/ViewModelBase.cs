using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MvvmNew.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public static MainWindowViewModel MainWindowViewModel { get; set; } = new MainWindowViewModel();
        public static OneCatPageViewModel OneCatPageViewModel { get; set; } = new OneCatPageViewModel();



        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void Set<T>(ref T field, T value, [CallerMemberName] string propName = "")
        {
            if (field != null)
            {
                if (!field.Equals(value))
                {
                    field = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
        }
    }
}
