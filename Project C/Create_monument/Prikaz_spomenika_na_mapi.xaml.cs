using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project_C.Create_monument
{
    /// <summary>
    /// Interaction logic for Prikaz_spomenika_na_mapi.xaml
    /// </summary>
    public partial class Prikaz_spomenika_na_mapi : Window
    {
        private ObservableCollection<Spomenik> Prikaz_na_mapi
        {
            get;
            set;
        }
        private ObservableCollection<Tip> Prikaz_tipa
        {
            get;
            set;
        }
        public Prikaz_spomenika_na_mapi(TextBlock element)
        {
            InitializeComponent();

            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

            this.DataContext = this;

            Prikaz_na_mapi = new ObservableCollection<Spomenik>();

            
            if(element.GetType() == typeof(TextBlock))
            {
                
                
                    foreach(Spomenik sp in MainWindow.Elementi)
                    {
                        if ((String)element.Tag == sp.Naziv)
                    {
                        Prikaz_na_mapi.Add(sp);
                        spomeniciMapaDataGrid.Items.Refresh();
                        spomeniciMapaDataGrid.ItemsSource = Prikaz_na_mapi;
                        Prikaz_tipa = new ObservableCollection<Tip>();
                        Prikaz_tipa.Add(sp.Tip_s);
                        prikazTipovaDataGrid.ItemsSource = Prikaz_tipa;
                        prikazDataGrid.ItemsSource = sp.Listica;
                    }
                    }
                    
                
                
            } else
            {
                return;
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
