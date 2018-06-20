using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ISEducons
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            itSektorScreen.Visibility = Visibility.Collapsed;
            //Thread.Sleep(1500);    //Usporava paljenje programa zbog SplashScreen-a
            

        }

        private void Home_Copy12_Click(object sender, RoutedEventArgs e)
        {
            exitScreen exit = new exitScreen();
            exit.ShowDialog();





            //if (MessageBox.Show("Da li želite da izađete iz programa?", "Izlaz",
            //             MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            //{
            //    Environment.Exit(1);   //Izlaz iz programa
            //}
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            SidePanel.Margin = new Thickness(0, 48, 0, 0);
            homeScreen.Visibility = Visibility.Visible;
            itSektorScreen.Visibility = Visibility.Collapsed;

        }

        private void rektorat_Click(object sender, RoutedEventArgs e)
        {
            SidePanel.Margin = new Thickness(0, 92, 0, 0);  //Klikom na

        }

        private void pravnaSluzba_Click(object sender, RoutedEventArgs e)
        {
            SidePanel.Margin = new Thickness(0, 136, 0, 0);
        }

        private void itSektor_Click(object sender, RoutedEventArgs e)
        {
            SidePanel.Margin = new Thickness(0, 180, 0, 0);

            homeScreen.Visibility = Visibility.Collapsed;
            itSektorScreen.Visibility = Visibility.Visible;
        }

        private void finansijskaSluzba_Click(object sender, RoutedEventArgs e)
        {
            SidePanel.Margin = new Thickness(0, 224, 0, 0);
        }

        private void studentskaSluzba_Click(object sender, RoutedEventArgs e)
        {
            SidePanel.Margin = new Thickness(0, 268, 0, 0);
        }

        private void biblioteka_Click(object sender, RoutedEventArgs e)
        {
            SidePanel.Margin = new Thickness(0, 312, 0, 0);
        }

        private void obezbedjenje_Click(object sender, RoutedEventArgs e)
        {
            SidePanel.Margin = new Thickness(0, 356, 0, 0);
        }

        private void odrzavanje_Click(object sender, RoutedEventArgs e)
        {
            SidePanel.Margin = new Thickness(0, 400, 0, 0);
        }

        private void nabavka_Click(object sender, RoutedEventArgs e)
        {
            SidePanel.Margin = new Thickness(0, 444, 0, 0);
            PocetniProzor pocetniProzor = new PocetniProzor();
            pocetniProzor.ShowDialog();
        }

        private void options_Click(object sender, RoutedEventArgs e)
        {
            SidePanel.Margin = new Thickness(0, 488, 0, 0);
        }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            SidePanel.Margin = new Thickness(0, 532, 0, 0);
        }

        private void homeScreen_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}