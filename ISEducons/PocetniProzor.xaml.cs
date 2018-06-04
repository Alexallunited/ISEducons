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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using MaterialDesignColors;
using MaterialDesignThemes.Wpf;


namespace ISEducons
{
    /// <summary>
    /// Interaction logic for PocetniProzor.xaml
    /// </summary>
    public partial class PocetniProzor : Window
    {
        public PocetniProzor()
        {
            InitializeComponent();

          
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1500);
            }).ContinueWith(t =>
            {
                //note you can use the message queue from any thread, but just for this here we 
                //need to get the message queue from the snackbar, so need to be on the dispatcher
                MainSnackbar.MessageQueue.Enqueue("                   Dobrodošli admin");
            }, TaskScheduler.FromCurrentSynchronizationContext());

            


        }

        private void WindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove(); //omogucava da se prozor pomera tako sto se drzi levi klik na prozoru
        }

        private void izgled_Click(object sender, RoutedEventArgs e)
        {
           
            MainWindowDialogHost.DialogContent = new Izgled(); //otvara UserControl Izgled kao dialog
            MainWindowDialogHost.IsOpen = true;

        }

        private void nalog_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ova mogućnost će biti dostupna tek u sledećoj verziji");
        }

        private void dokumentacija_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("U izradi");
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("U izradi");
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindowDialogHost.DialogContent = new exitDialog(); //otvara UserControl exitDialog kao dialog
            MainWindowDialogHost.IsOpen = true;
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); //zatvaranje pocetnog prozora
            LogInProzor login = new LogInProzor();
            login.ShowDialog();
        }

        private void TestDugme_Click(object sender, RoutedEventArgs e)
        {
            NetworkScanner scan = new NetworkScanner();
            scan.ShowDialog();
        }
    }
}
