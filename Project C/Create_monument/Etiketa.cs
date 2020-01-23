using System;
using System.ComponentModel;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Project_C.Create_monument
{
    [XmlInclude(typeof(SolidColorBrush))]
    [XmlInclude(typeof(MatrixTransform))]
    [Serializable]
    public class Etiketa : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private string _oznaka_etiketa;
        private Brush _boja_etiketa;
        private string _opis_etiketa;
        

        public string Oznaka_etiketa
        {
            get
            {
                return _oznaka_etiketa;
            }
            set
            {
                if (value != _oznaka_etiketa)
                {
                    _oznaka_etiketa = value;
                    OnPropertyChanged("Oznaka_etiketa");
                }
            }
        }
        
        public Brush Boja_etiketa
        {
            get
            {
                return _boja_etiketa;
            }
            set
            {
                if (value != _boja_etiketa)
                {
                    _boja_etiketa = value;
                    OnPropertyChanged("Boja_etiketa");
                }
            }
        }
        public string Opis_etiketa
        {
            get
            {
                return _opis_etiketa;
            }
            set
            {
                if (value != _opis_etiketa)
                {
                    _opis_etiketa = value;
                    OnPropertyChanged("Opis_etiketa");
                }
            }
        }
    }
}
