using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;


namespace Project_C.Create_monument
{
    /// <summary>
    /// Interaction logic for Etikete.xaml
    /// </summary>
    [Serializable]
    public partial class Etikete : Window
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
        public static ObservableCollection<Etiketa> Etikete_oc
        {
            get;
            set;
        }
        public static Etiketa selected_etiketa = null;
        public static List<Etiketa> lista_selektovanih = new List<Etiketa>();


        public Etikete()
        {
            InitializeComponent();

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

            this.DataContext = this;
            etiketeDataGrid.ItemsSource = Etikete_oc;
            txtOznaka.IsEnabled = true;
        }

        private void izaberi_boju_btn_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog clr = new ColorDialog();
            clr.ShowDialog();

            List<Byte> b = new List<byte>();
            b.Add(clr.Color.A);
            b.Add(clr.Color.R);
            b.Add(clr.Color.G);
            b.Add(clr.Color.B);
            
            txtColor.Background = new SolidColorBrush(Color.FromArgb(clr.Color.A, clr.Color.R, clr.Color.G, clr.Color.B));
        }
        private void nova_etiketa_btn_Click(object sender, RoutedEventArgs e)
        {
            nova_etiketa_btn.IsEnabled = false;
            txtOznaka.Text = string.Empty;
            txtOpis.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtOznaka.IsEnabled = true;
        }
        private void sacuvaj_etiketu_btn_Click(object sender, RoutedEventArgs e)
        {
            Etikete_oc.Add(new Etiketa() { Oznaka_etiketa = txtOznaka.Text, Opis_etiketa = txtOpis.Text, Boja_etiketa = txtColor.Background });
            txtOznaka.Text = string.Empty;
            txtOpis.Text = string.Empty;
            txtColor.Text = string.Empty;
            System.Windows.Forms.MessageBox.Show("Etiketa je uspješno kreirana.");
            nova_etiketa_btn.IsEnabled = true;
            txtOznaka.IsEnabled = false;
        }

        private void izmjeni_etiketu_btn_Click(object sender, RoutedEventArgs e)
        {
            selected_etiketa = (Etiketa)etiketeDataGrid.SelectedItem;
            Etiketa temp = selected_etiketa;
            int i = Etikete_oc.IndexOf(temp);

            selected_etiketa.Oznaka_etiketa = txtOznaka.Text;
            selected_etiketa.Opis_etiketa = txtOpis.Text;
            selected_etiketa.Boja_etiketa = txtColor.Background;

            Etikete_oc.Remove(temp);
            Etikete_oc.Insert(i, selected_etiketa);

            System.Windows.Forms.MessageBox.Show("Etiketa je uspješno izmjenjena.");
        }

        private void obrisi_etiketu_btn_Click(object sender, RoutedEventArgs e)
        {
            selected_etiketa = (Etiketa)etiketeDataGrid.SelectedItem;

            DialogResult dr = System.Windows.Forms.MessageBox.Show("Da li želite da obrišete " + selected_etiketa.Boja_etiketa + " ?", "Warrning", MessageBoxButtons.YesNoCancel);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                Etikete_oc.Remove(selected_etiketa);
                System.Windows.Forms.MessageBox.Show("Etiketa je uspješno obrisana.");
            } else
            {
                return;
            }
        }

        public void dodaj_etiketu_btn_Click(object sender, RoutedEventArgs e)
        {
            selected_etiketa = (Etiketa)etiketeDataGrid.SelectedItem;
            bool etiketa_postoji = false;

            if(lista_selektovanih.Count == 0 && Create_dialog.selected_spomenik.Listica == null)
            {
                lista_selektovanih.Add(selected_etiketa);
                //System.Windows.Forms.MessageBox.Show("Etiketa je uspješno dodata.");
            } else
            {
                lista_selektovanih = Create_dialog.selected_spomenik.Listica;
                foreach (Etiketa etiketa in lista_selektovanih.ToArray())
                {
                    if (selected_etiketa.Oznaka_etiketa.ToUpper().Equals(etiketa.Oznaka_etiketa.ToUpper()))
                    {
                        etiketa_postoji = true;
                        break;
                    }
                }
                if(!etiketa_postoji)
                {
                    lista_selektovanih.Add(selected_etiketa);
                    //System.Windows.Forms.MessageBox.Show("Etiketa je uspješno dodata.");
                } else
                {
                    System.Windows.Forms.MessageBox.Show("Etiketa sa oznakom " + selected_etiketa.Oznaka_etiketa + " već postoji!");
                }
                
            }
        }

        private void izadji_etikete_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sacuvaj_etikete_btn_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Etiketa>));
            using (StreamWriter wr = new StreamWriter(@"etikete.xml"))
            {
                xs.Serialize(wr, Etikete_oc);
            }
            System.Windows.Forms.MessageBox.Show("Etikete su uspješno sačuvane u datoteku <etikete.xml>.");
        }

        private void ucitaj_etikete_btn_Click(object sender, RoutedEventArgs e)
        {
            etiketeDataGrid.ItemsSource = null;
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Etiketa>));
            using (StreamReader rd = new StreamReader("etikete.xml"))
            {
                Etikete_oc = xs.Deserialize(rd) as ObservableCollection<Etiketa>;
            }
            etiketeDataGrid.ItemsSource = Etikete_oc;
            System.Windows.Forms.MessageBox.Show("Etikete su uspješno učitane iz datoteke <etikete.xml>.");
        }

        
    }
}
