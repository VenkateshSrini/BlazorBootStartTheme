using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MyComp.KPortal.Client.Services
{
    public class ViewBagServices : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanges([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string userName;
        public string UserName
        {
            get => userName;
            set{
                userName = value;
                OnPropertyChanges();
            }
        }
    }
}
