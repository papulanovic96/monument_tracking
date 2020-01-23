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
    /// Interaction logic for Prikaz_tipova.xaml
    /// </summary>
    public partial class Prikaz_tipova : Window
    {
        private ObservableCollection<Tip> Prikaz_tipa
        {
            get;
            set;
        }
        public Prikaz_tipova()
        {
            InitializeComponent();

            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

            this.DataContext = this;
            Prikaz_tipa = new ObservableCollection<Tip>();
            try
            {
                Prikaz_tipa.Add(Create_dialog.selected_spomenik.Tip_s);
                prikazTipovaDataGrid.ItemsSource = Prikaz_tipa;
            } catch
            {

            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
