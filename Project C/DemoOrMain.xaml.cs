using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace Project_C
{
    /// <summary>
    /// Interaction logic for DemoOrMain.xaml
    /// </summary>
    public partial class DemoOrMain : Window
    {
        private DispatcherTimer dispatcherTimer;

        public DemoOrMain()
        {
            InitializeComponent();

            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }
        public static bool button_is_clicked = false;
        public static bool button_is_clickedM = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            button_is_clickedM = true;
            var show_main = new MainWindow();
            show_main.Show();
            this.Close();
            
        }
        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            button_is_clicked = true;
            var show_new = new Create_monument.Create_dialog();
            show_new.ShowDialog();

        }

    }
}
