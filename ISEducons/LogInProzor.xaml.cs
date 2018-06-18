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
using ISEducons.Properties;
using System.Resources;

using MaterialDesignColors;
using MaterialDesignThemes.Wpf;

namespace ISEducons
{
    /// <summary>
    /// Interaction logic for LogInProzor.xaml
    /// </summary>
    public partial class LogInProzor : Window
    {
        public LogInProzor()
        {
            InitializeComponent();
        }

        public void LogIn_Click(object sender, RoutedEventArgs e)
        {


            this.Hide();
            PocetniProzor test = new PocetniProzor();
            test.ShowDialog();





            //if (UsernameBox.Text == ISEducons.Properties.Resources.UsernameA && PasswordBox.Password == ISEducons.Properties.Resources.PasswordA) //ovo bas i nije najsigurniji nacin da se cuva passworda al ajd sad
            //{
            //    this.Hide();
            //    PocetniProzor test = new PocetniProzor();
            //    test.ShowDialog();
            //}
            //else
            //{
            //    if (UsernameBox.Text == ISEducons.Properties.Resources.UsernameU && PasswordBox.Password == ISEducons.Properties.Resources.PasswordU)
            //    {


            //        MainWindowDialogHost.DialogContent = new KorisnikPostojiDialog(); //otvara UserControl exitDialog kao dialog
            //        MainWindowDialogHost.IsOpen = true;

            //    }


            //    else
            //    {
            //        if ((UsernameBox.Text != ISEducons.Properties.Resources.UsernameA || UsernameBox.Text != ISEducons.Properties.Resources.UsernameU)
            //            &&
            //           (PasswordBox.Password != ISEducons.Properties.Resources.PasswordA || PasswordBox.Password != ISEducons.Properties.Resources.PasswordU))

            //            MainWindowDialogHost.DialogContent = new KorisnikNePostojiDialog(); //otvara UserControl exitDialog kao dialog
            //            MainWindowDialogHost.IsOpen = true;

            //    }
            //}

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Test for Enter key.
            if (e.Key == Key.Enter)
            {
                this.Hide();
                PocetniProzor test = new PocetniProzor();
                test.ShowDialog();
            }
        }
    }
}
