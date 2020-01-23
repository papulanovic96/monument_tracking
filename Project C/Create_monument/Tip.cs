using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_C.Create_monument
{
    [Serializable]
    public class Tip : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private string _oznaka;
        private string _ime;
        private string _opis;
        private string _slika;

        public string Oznaka_Tipa
        {
            get
            {
                return _oznaka;
            }

            set
            {
                _oznaka = value;
                OnPropertyChanged("Oznaka");
            }
        }

        public string Ime_Tipa
        {
            get
            {
                return _ime;
            }

            set
            {
                _ime = value;
                OnPropertyChanged("Ime");
            }
        }

        public string Opis_Tipa
        {
            get
            {
                return _opis;
            }

            set
            {
                _opis = value;
                OnPropertyChanged("Opis");
            }
        }

        public string Slika
        {
            get
            {
                return _slika;
            }

            set
            {
                _slika = value;
                OnPropertyChanged("Slika");
            }
        }
    }
}
