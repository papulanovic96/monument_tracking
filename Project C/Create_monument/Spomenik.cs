using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Project_C.Create_monument
{
    [Serializable, XmlRoot("Spomenik")]
    public class Spomenik 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string info)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private string _oznaka;
        private string _naziv;
        private string _tip;
        private string _era;
        private string _ikonica;
        private bool _arh_obradjen;
        private bool _unesco;
        private bool _naseljen_region;
        private string _tur_stat;
        private string _tur_prihod;
        private string _datum_oktrivanja;
        private string _opis;
        private Brush _etiketa;
        private List<Etiketa> listica = new List<Etiketa>();
        private Tip tipic = new Tip();

        public string Oznaka
        {
            get
            {
                return _oznaka;
            }
            set
            {
                if (value != _oznaka)
                {
                    _oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }
        public string Naziv
        {
            get
            {
                return _naziv;
            }
            set
            {
                if (value != _naziv)
                {
                    _naziv = value;
                    OnPropertyChanged("Naziv");
                }
            }
        }
        public Tip Tip_s
        {
            get
            {
                return tipic;
            }
            set
            {
                tipic = value;
            }
        }
        public string Tip_return_string
        {
            get
            {
                return _tip;
            }
            set
            {
                if (value != _tip)
                {
                    _tip = value;
                     OnPropertyChanged("Tip");
                }
            }
        }
        public string Era
        {
            get
            {
                return _era;
            }
            set
            {
                if (value != _era)
                {
                    _era = value;
                    OnPropertyChanged("Era");
                }
            }
        }
        public string Ikonica
        {
            get
            {
                return _ikonica;
            }
            set
            {
                if (value != _ikonica)
                {
                    _ikonica = value;
                   OnPropertyChanged("Ikonica");
                }
            }
        }
        public string Turisticki_status
        {
            get
            {
                return _tur_stat;
            }
            set
            {
                if (value != _tur_stat)
                {
                    _tur_stat = value;
                    OnPropertyChanged("Turisticki status");
                }
            }
        }
        public string Turisticki_prihod
        {
            get
            {
                return _tur_prihod;
            }
            set
            {
                if (value != _tur_prihod)
                {
                    _tur_prihod = value;
                    OnPropertyChanged("Turisticki prihod");
                }
            }
        }
        public string Datum_otkrivanja
        {
            get
            {
                return _datum_oktrivanja;
            }
            set
            {
                if (value != _datum_oktrivanja)
                {
                    _datum_oktrivanja = value;
                    OnPropertyChanged("Datum otkrivanja");
                }
            }
        }
        public string Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (value != _opis)
                {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }
        public bool Arheoloski_obradjen
        {
            get
            {
                return _arh_obradjen;
            }
            set
            {
                if(_arh_obradjen != value)
                {
                    _arh_obradjen = value;
                    OnPropertyChanged("Arheoloski obradjen");
                }
            }
        }
        public bool UNESCO
        {
            get
            {
                return _unesco;
            }
            set
            {
                if (_unesco != value)
                {
                    _unesco = value;
                    OnPropertyChanged("UNESCO");
                }
            }
        }
        public bool Naseljeni_region
        {
            get
            {
                return _naseljen_region;
            }
            set
            {
                if (_naseljen_region != value)
                {
                    _naseljen_region = value;
                    OnPropertyChanged("Naseljeni region");
                }
            }
        }
        
        public Brush Etiketa_return_string
        {
            get
            {
                return _etiketa;
            }
            set
            {
                if (value != _etiketa)
                {
                    _etiketa = value;
                     OnPropertyChanged("Tip");
                }
            }
        }

        public List<Etiketa> Listica { get => listica; set => listica = value; }

        double _X;
        public double X
        {
            get
            {
                return _X;
            }
            set
            {
                if (_X != value)
                {
                    _X = value;
                    OnPropertyChanged("X");
                }
            }
        }

        double _Y;
        public double Y
        {
            get
            {
                return _Y;
            }
            set
            {
                if (_Y != value)
                {
                    _Y = value;
                    OnPropertyChanged("Y");
                }
            }
        }
    }
}
