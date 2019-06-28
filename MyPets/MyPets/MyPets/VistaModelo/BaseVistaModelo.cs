using System;
using System.Collections.Generic;

using System.Text;

namespace MyPets.VistaModelo
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
   public class BaseVistaModelo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void SetValue<T>(ref T backingfield, T value, [CallerMemberName] string propertyName=null)
        {
            if (EqualityComparer<T>.Default.Equals(backingfield,value))
            {
                return;
            }
            backingfield = value;
            OnPropertyChanged(propertyName);
        }
    }
}
