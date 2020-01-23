using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace Project_C.Create_monument
{
    /// <summary>
    /// Interaction logic for Tip_spomenika.xaml
    /// </summary>
    [Serializable]
    public partial class Tip_spomenika : Window, INotifyPropertyChanged
    {
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(System.Windows.Application.Current.Windows[1]);
            if (focusedControl is DependencyObject)
            {
                string str = Help.HelpDavac.GetHelpKey((DependencyObject)focusedControl);
                Help.HelpDavac.ShowHelp(str, this);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        //obs collection i selektovani tip
        public static ObservableCollection<Tip> Tipovi
        {
            get;
            set;
        }
        public static List<Tip> lista = new List<Tip>(); // brisati
        public static Tip selektovani = null;

        public Tip_spomenika()
        {
            InitializeComponent();

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

            this.DataContext = this;
            tipoviDataGrid.ItemsSource = Tipovi;
            txtOznaka.IsEnabled = false;
        }

        private void novi_tip_btn_Click(object sender, RoutedEventArgs e)
        {
            novi_tip_btn.IsEnabled = false;
            txtOznaka.IsEnabled = true;
            novi_tip_btn.IsEnabled = false;
            txtOznaka.Text = string.Empty;
            txtIme.Text = string.Empty;
            txtOpis.Text = string.Empty;
            Tipovi.Add(new Tip() { });
        }
        private void cuvanje_tipa_btn_Click(object sender, RoutedEventArgs e)
        {
            Tipovi.Add(new Tip() { Oznaka_Tipa = txtOznaka.Text, Ime_Tipa = txtIme.Text, Opis_Tipa = txtOpis.Text, Slika = imgPreview.Source.ToString() });
            txtOznaka.Text = string.Empty;
            txtIme.Text = string.Empty;
            txtOpis.Text = string.Empty;
            System.Windows.Forms.MessageBox.Show("Tip je uspješno kreiran.");
            novi_tip_btn.IsEnabled = true;
            txtOznaka.IsEnabled = false;
        }
        private void izmjena_tipa_btn_Click(object sender, RoutedEventArgs e)
        {
            selektovani = (Tip)tipoviDataGrid.SelectedItem;
            Tip temp = selektovani;
            int i = Tipovi.IndexOf(temp);
            
            selektovani.Oznaka_Tipa = txtOznaka.Text;
            selektovani.Ime_Tipa = txtIme.Text;
            selektovani.Opis_Tipa = txtOpis.Text;
            
            selektovani.Slika = imgPreview.Source.ToString();
            if (Create_dialog.Spomen != null)
            {
                foreach (Spomenik sp_tip in Create_dialog.Spomen.ToList()) //kopija reference kolekcije sa ToList()
                {
                    if (sp_tip.Tip_return_string.Equals(selektovani.Ime_Tipa))
                    {
                        sp_tip.Ikonica = selektovani.Slika;
                    }
                }
            }
            
            Tipovi.Remove(temp);
            Tipovi.Insert(i, selektovani);

            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Spomenik>));
            using (StreamWriter wr = new StreamWriter(@"spomenici.xml"))
            {
                xs.Serialize(wr, Create_dialog.Spomen);
            }

            System.Windows.Forms.MessageBox.Show("Tip je uspješno izmjenjen.");

        } 
        private void brisanje_tipa_btn_Click(object sender, RoutedEventArgs e)
        {
            //brisanje selektovanog tipa
            selektovani = (Tip)tipoviDataGrid.SelectedItem;

            DialogResult dr = System.Windows.Forms.MessageBox.Show("Da li želite da obrišete " + selektovani.Ime_Tipa + " ?", "Warrning", MessageBoxButtons.YesNoCancel);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                if (Create_dialog.Spomen != null)
                {
                    foreach (Spomenik sp_tip in Create_dialog.Spomen.ToList()) //kopija reference kolekcije sa ToList()
                    {
                        if (sp_tip.Tip_return_string.Equals(selektovani.Ime_Tipa))
                        {
                            Create_dialog.Spomen.Remove(sp_tip);
                        }
                    }
                }
                Tipovi.Remove(selektovani);
                System.Windows.Forms.MessageBox.Show("Tip je uspješno obrisan.");
            } else
            {
                //nista ne radi
            }            
        }
        private void izaberi_ikonicu_tipa_btn_Click(object sender, RoutedEventArgs e)
        {
            //biranje slike za odredjeni tip
            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            op.Title = "Odaberi sliku";
            op.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (op.ShowDialog() == true)
            {
                imgPreview.Source = new BitmapImage(new Uri(op.FileName));
            }
        }
        //----------------------------------------------------------------------------
        public void dodaj_tip_btn_Click(object sender, RoutedEventArgs e)
        {
            //dodavanje tipova u spomenike
            selektovani = (Tip)tipoviDataGrid.SelectedItem;
            this.Close();
        }
        public void izlaz_btn_Click(object sender, RoutedEventArgs e)
        {
            //izlazak iz prozora za dodavanje tipova u spomenike
            this.Close();
        }

        private void sacuvaj_btn_Click(object sender, RoutedEventArgs e)
        {
            
                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Tip>));
                using (StreamWriter wr = new StreamWriter("tipovi.xml"))
                {
                    xs.Serialize(wr, Tipovi);
                } // cuvanje u XML datoteku 
                System.Windows.Forms.MessageBox.Show("Tipovi su uspješno sačuvani u datoteku <tipovi.xml>.");

        }

        private void ucitaj_btn_Click(object sender, RoutedEventArgs e)
        {

            tipoviDataGrid.ItemsSource = null; // brisanje trenutnog DataGrid-a

            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Tip>)); //ucitavanje iz datoteke
            using (StreamReader rd = new StreamReader(@"tipovi.xml"))
                {
                    Tipovi = xs.Deserialize(rd) as ObservableCollection<Tip>;
                }

            tipoviDataGrid.ItemsSource = Tipovi; //ubacivanje ucitanih Tipova u DataGrid
            System.Windows.Forms.MessageBox.Show("Tipovi su uspješno učitani iz datoteke <tipovi.xml>.");
        }

        
    }
}
