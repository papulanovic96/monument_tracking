using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace Project_C.Create_monument
{
    /// <summary>
    /// Interaction logic for Create_dialog.xaml
    /// </summary>

    [Serializable]
    public partial class Create_dialog : Window, INotifyPropertyChanged
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
        public static ObservableCollection<Spomenik> Spomen
        {
            get;
            set;
        }

        public static List<Spomenik> lista = new List<Spomenik>();
        public static Spomenik selected_spomenik = new Spomenik();

        public Create_dialog()
        {
            InitializeComponent();

            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

            this.DataContext = this;

            if (DemoOrMain.button_is_clicked == true)
            {
                DemoOrMain.button_is_clicked = false;
                spomeniciDataGrid.IsEnabled = false;
                txtEtik.IsEnabled = false;
                txtEtik.Foreground = new SolidColorBrush(Colors.Black);
                txtNaziv.IsEnabled = false;
                txtNaziv.Foreground = new SolidColorBrush(Colors.Black);
                txtOpis.IsEnabled = false;
                txtOpis.Foreground = new SolidColorBrush(Colors.Black);
                txtOznaka.IsEnabled = false;
                txtOznaka.Foreground = new SolidColorBrush(Colors.Black);
                txtPrihod.IsEnabled = false;
                txtPrihod.Foreground = new SolidColorBrush(Colors.Black);
                txtTip.IsEnabled = false;
                txtTip.Foreground = new SolidColorBrush(Colors.Black);
                comboEra.IsEnabled = false;
                comboEra.Foreground = new SolidColorBrush(Colors.Black);
                comboStatus.IsEnabled = false;
                comboStatus.Foreground = new SolidColorBrush(Colors.Black);
                checkArh.IsEnabled = false;
                checkNaselje.IsEnabled = false;
                checkUNESCO.IsEnabled = false;
                dateDatum.IsEnabled = false;
                dateDatum.Foreground = new SolidColorBrush(Colors.Black);
                dodaj_spomenik_btn.IsEnabled = false;
                izaberi_etikete_btn.IsEnabled = false;
                izaberi_ikonicu_btn.IsEnabled = false;
                izaberi_tip_btn.IsEnabled = false;
                izmjeni_spomenik_btn.IsEnabled = false;
                obrisi_spomenik_btn.IsEnabled = false;
                prikazi_etikete_btn.IsEnabled = false;
                prikazi_tip_btn.IsEnabled = false;
                sacuvaj_spomenik_btn.IsEnabled = false;
                sacuvaj.IsEnabled = false;
                ucitaj.IsEnabled = false;
                txtPronadjiNaziv.IsEnabled = false;
                

                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();

            }
            if(DemoOrMain.button_is_clickedM)
            {
                DemoOrMain.button_is_clicked = false;
                try
                {
                    dispatcherTimer.Stop();
                } catch
                {

                }
            }
            spomeniciDataGrid.ItemsSource = Spomen;
            
            txtOznaka.IsEnabled = false;
        }

        
        private void myFilter(object sender, FilterEventArgs e)
        {
            try
            {
                var obj = e.Item as Spomenik;

                if (obj != null && txtPronadjiNaziv.Text.Length > 0)
                {
                    if (obj.Naziv.StartsWith(txtPronadjiNaziv.Text.ToString()))
                        e.Accepted = true;
                    else
                        e.Accepted = false;
                }
            }
            catch { }
            
        }

        ICollectionView filterSpomenikaa;

        private void txtPronadjiNaziv_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!DemoOrMain.button_is_clicked)
            {
                var filterSpomenika = new CollectionViewSource() { Source = Spomen };
                filterSpomenika.Filter += new FilterEventHandler(myFilter);

                filterSpomenikaa = filterSpomenika.View;
                filterSpomenikaa.Refresh();

                spomeniciDataGrid.ItemsSource = filterSpomenikaa;
            }
            
        }
        private bool input_KeyDown()
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                return true;
            }
            return false;
        }

        private bool dodat_je = false;
        private bool dodat_tip = false;
        private bool dodat_etiketa = false;
        private bool serial = false;
        private bool cuvanje = false;
        public void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (input_KeyDown())
            {
                dispatcherTimer.Stop();
                this.Close();
            } else
            {
                if (!serial)
                {
                    serial = true;
                    XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Spomenik>));
                    using (StreamReader rd = new StreamReader("spomenici.xml"))
                    {
                        Spomen = xs.Deserialize(rd) as ObservableCollection<Spomenik>;
                    }
                    spomeniciDataGrid.ItemsSource = Spomen;
                    return;
                }

                if (!dodat_je)
                {
                    dodaj_spomenik_btn_Click(null, null);
                    dodat_je = true;
                    spomeniciDataGrid.Items.Refresh();
                    return;
                }

                if (txtOznaka.Text == "")
                {
                    txtOznaka.Text = "SP_7";
                    txtOznaka.IsEnabled = false;
                    return;
                }
                if (txtNaziv.Text == "")
                {
                    txtNaziv.Text = "Pyramid of Zoser";
                    return;
                }

                XmlSerializer xs3 = new XmlSerializer(typeof(ObservableCollection<Tip>));
                using (StreamReader rd = new StreamReader("tipovi.xml"))
                {
                    Tip_spomenika.Tipovi = xs3.Deserialize(rd) as ObservableCollection<Tip>;
                }

                var type_dialog = new Tip_spomenika();
                if (!dodat_tip)
                {

                    type_dialog.Show();
                    type_dialog.dodaj_tip_btn_Click(null, null);
                    dodat_tip = true;

                    return;
                }
                

                if (comboEra.Text == "")
                {
                    comboEra.Text = "stari vijek";
                    return;
                }
                if (checkUNESCO.IsChecked == false)
                {
                    checkUNESCO.IsChecked = true;
                    return;
                }
                //izaberi_ikonicu_btn_Click(null, null);

                if (comboStatus.Text == "")
                {
                    comboStatus.Text = "dostupan";
                    return;
                }
                if (txtPrihod.Text == "")
                {
                    txtPrihod.Text = "10000";
                    return;
                }
                if (dateDatum.Text == "")
                {
                    dateDatum.Text = "1.2.1910";
                    return;
                }
                if (txtOpis.Text == "")
                {
                    txtOpis.Text = "Neki opis.";
                    return;
                }

                XmlSerializer xs2 = new XmlSerializer(typeof(ObservableCollection<Etiketa>));
                using (StreamReader rd = new StreamReader("etikete.xml"))
                {
                    Etikete.Etikete_oc = xs2.Deserialize(rd) as ObservableCollection<Etiketa>;
                }

                var etik_dialog = new Etikete();

                if (!dodat_etiketa)
                {

                    etik_dialog.Show();
                    etik_dialog.dodaj_etiketu_btn_Click(null, null);
                    dodat_etiketa = true;
                    etik_dialog.Close();
                    return;
                }

                if(!cuvanje)
                {
                    sacuvaj_spomenik_btn_Click(null, null);
                    dodat_je = false;
                    dodat_tip = false;
                    serial = false;
                    return;
                }

                // Forcing the CommandManager to raise the RequerySuggested event
                CommandManager.InvalidateRequerySuggested();
                
            }
            
        }
        private bool postoji_slika = true;
        private String slicica = null;
        private DispatcherTimer dispatcherTimer;

        private Spomenik new_sp = new Spomenik();
        private void dodaj_spomenik_btn_Click(object sender, RoutedEventArgs e)
        {
            txtOznaka.IsEnabled = true;
            dodaj_spomenik_btn.IsEnabled = false;
            txtOznaka.Text = string.Empty;
            txtNaziv.Text = string.Empty;
            txtOpis.Text = string.Empty;
            txtPrihod.Text = string.Empty;
            comboStatus.Text = string.Empty;
            comboEra.Text = string.Empty;
            txtTip.Text = string.Empty;
            dateDatum.Text = string.Empty;
            txtEtik.Text = string.Empty;
            Spomen.Add(new_sp);
            selected_spomenik = new_sp;
        }
        private void sacuvaj_spomenik_btn_Click(object sender, RoutedEventArgs e)
        {
            List<Etiketa> temp_list = new List<Etiketa>();
            Brush temp_boja = null;
            try
            {
                if (txtOznaka.Text == string.Empty)
                {
                    System.Windows.Forms.MessageBox.Show("Niste unijeli oznaku!");
                    return;
                }
            }catch { }
            /*try
            {
                foreach(Spomenik sw in Spomen.ToArray())
                {
                    if(txtOznaka.Text == sw.Oznaka)
                    {
                        System.Windows.Forms.MessageBox.Show("Unijeli ste postojeću oznaku!");
                        return;
                    }
                }
            }
            catch { }*/
           
            if (Tip_spomenika.selektovani == null)
            {
                System.Windows.Forms.MessageBox.Show("Niste dodali tip!");
                return;
            }
            else
            {
                    try
                    {
                        temp_list = Etikete.lista_selektovanih;
                        temp_boja = Etikete.selected_etiketa.Boja_etiketa;
                    }
                    catch
                    {
                        //
                    }
                    finally
                    {
                        //
                    }

                try
                {
                    slicica = imgIkonica.Source.ToString();
                }
                catch
                {
                    if(DemoOrMain.button_is_clicked)
                    {
                        postoji_slika = false;
                    } else
                    {
                        postoji_slika = false;
                    }
                }
                finally
                {
                    try
                    {
                        if (!postoji_slika)
                        {
                            slicica = Tip_spomenika.selektovani.Slika.ToString();
                        }

                    }
                    catch (Exception)
                    {
                        //sta uraditi?
                        System.Windows.Forms.MessageBox.Show("Ikonica nije uspješno učitana.");
                    }

                }
                
                Spomen.Add(new Spomenik() { Oznaka = txtOznaka.Text, Naziv = txtNaziv.Text, Tip_s = Tip_spomenika.selektovani, Tip_return_string = Tip_spomenika.selektovani.Ime_Tipa, Era = comboEra.Text, Ikonica = slicica, Arheoloski_obradjen = (bool)checkArh.IsChecked, UNESCO = (bool)checkUNESCO.IsChecked, Naseljeni_region = (bool)checkNaselje.IsChecked, Turisticki_status = comboStatus.Text, Turisticki_prihod = txtPrihod.Text + "$", Datum_otkrivanja = dateDatum.Text, Opis = txtOpis.Text, Etiketa_return_string = temp_boja, Listica = temp_list });
                Spomen.RemoveAt(Spomen.Count - 2);
                txtOznaka.Text = string.Empty;
                txtNaziv.Text = string.Empty;
                txtOpis.Text = string.Empty;
                txtPrihod.Text = string.Empty;
                comboStatus.Text = string.Empty;
                comboEra.Text = string.Empty;
                txtTip.Text = string.Empty;
                dateDatum.Text = string.Empty;
                txtEtik.Text = string.Empty;
                Tip_spomenika.selektovani = null;
                dodaj_spomenik_btn.IsEnabled = true;
                txtOznaka.IsEnabled = false;
                //System.Windows.Forms.MessageBox.Show("Uspješno ste kreirali spomenik");
            }
        }
        private void izmjeni_spomenik_btn_Click(object sender, RoutedEventArgs e)
        {
            selected_spomenik = (Spomenik)spomeniciDataGrid.SelectedItem;
            Spomenik temp = selected_spomenik;
            int i = Spomen.IndexOf(temp);

            try
            {
                selected_spomenik.Tip_s = Tip_spomenika.selektovani;
                selected_spomenik.Tip_return_string = Tip_spomenika.selektovani.Ime_Tipa;
            } catch(Exception)
            {
                //
            }

            try
            {
                selected_spomenik.Ikonica = imgIkonica.Source.ToString();
                postoji_slika = true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Niste odabrali ikonicu.\nZa ovaj spomenik je učitana ikonica tipa.");
                postoji_slika = false;
            }
            finally
            {
                try
                {
                    if (!postoji_slika)
                    {
                        selected_spomenik.Ikonica = Tip_spomenika.selektovani.Slika.ToString();
                    }

                }
                catch
                {
                    //sta uraditi?
                    System.Windows.Forms.MessageBox.Show("Ikonica nije uspješno učitana.");
                }

            }
            if (selected_spomenik.Listica == null)
            {
                try
                {
                    selected_spomenik.Listica = Etikete.lista_selektovanih;
                    selected_spomenik.Etiketa_return_string = Etikete.selected_etiketa.Boja_etiketa;
                }
                catch
                {
                    //
                }
                finally
                {
                    //
                }
            }

            selected_spomenik.Naziv = txtNaziv.Text;
            selected_spomenik.Era = comboEra.Text;
            selected_spomenik.Arheoloski_obradjen = (bool)checkArh.IsChecked;
            selected_spomenik.UNESCO = (bool)checkUNESCO.IsChecked;
            selected_spomenik.Naseljeni_region = (bool)checkNaselje.IsChecked;
            selected_spomenik.Turisticki_status = comboStatus.Text;
            selected_spomenik.Turisticki_prihod = txtPrihod.Text + "$";
            selected_spomenik.Opis = txtOpis.Text;

            Spomen.Remove(temp);
            Spomen.Insert(i, selected_spomenik);
            spomeniciDataGrid.ItemsSource = Spomen;
            Tip_spomenika.selektovani = null;
            System.Windows.Forms.MessageBox.Show("Spomenik je uspješno izmjenjen.");
        }
        private void obrisi_spomenik_btn_Click(object sender, RoutedEventArgs e)
        {
            selected_spomenik = (Spomenik)spomeniciDataGrid.SelectedItem;

            DialogResult dr =  System.Windows.Forms.MessageBox.Show("Da li želite da obrišete " + selected_spomenik.Naziv +" ?", "Warrning", MessageBoxButtons.YesNoCancel);
            if(dr == System.Windows.Forms.DialogResult.Yes)
            {
                Spomen.Remove(selected_spomenik);
                System.Windows.Forms.MessageBox.Show("Spomenik je uspješno obrisan.");
            } else
            {
                return;
            }
        }
        private void izaberi_etikete_btn_Click(object sender, RoutedEventArgs e)
        {
            selected_spomenik = (Spomenik)spomeniciDataGrid.SelectedItem;
            var etiketa = new Create_monument.Etikete();
            etiketa.Show();
        }

        private void izaberi_tip_btn_Click(object sender, RoutedEventArgs e)
        {
            var type_dialog = new Create_monument.Tip_spomenika();
            type_dialog.Show();
        }
        private void izaberi_ikonicu_btn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            op.Title = "Odaberite sliku";
            op.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (op.ShowDialog() == true)
            {
                imgIkonica.Source = new BitmapImage(new Uri(op.FileName));
            }
        }
        private void sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Spomenik>));
            using (StreamWriter wr = new StreamWriter(@"spomenici.xml"))
            {
                xs.Serialize(wr, Spomen);
            }
            System.Windows.Forms.MessageBox.Show("Spomenici su uspješno sačuvani u datoteku <spomenici.xml>.");
        }
        private void ucitaj_Click(object sender, RoutedEventArgs e)
        {

            spomeniciDataGrid.ItemsSource = null;

            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Spomenik>));
            using (StreamReader rd = new StreamReader("spomenici.xml"))
            {
                Spomen = xs.Deserialize(rd) as ObservableCollection<Spomenik>;
            }
            spomeniciDataGrid.ItemsSource = Spomen;
            System.Windows.Forms.MessageBox.Show("Spomenici su uspješno učitani iz datoteke <spomenici.xml>.");
        }

        private void prikazi_etikete_btn_Click(object sender, RoutedEventArgs e)
        {
            selected_spomenik = (Spomenik)spomeniciDataGrid.SelectedItem;
            
            var etiketa = new Prikaz_etiketa();
            etiketa.Show();
        }

        private void prikazi_tip_btn_Click(object sender, RoutedEventArgs e)
        {
            selected_spomenik = (Spomenik)spomeniciDataGrid.SelectedItem;

            var tipics = new Prikaz_tipova();
            tipics.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(DemoOrMain.button_is_clickedM)
            {
                btn_stop.IsEnabled = false;
            } else
            {
                dispatcherTimer.Stop();
                this.Close();
            }
               

            
            /*
            var sss = new Create_dialog();
            sss.Show();*/
        }
    }

    public partial class StringToDoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                double r;
                if (double.TryParse(s, out r))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Please enter a valid double value.");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }



}
