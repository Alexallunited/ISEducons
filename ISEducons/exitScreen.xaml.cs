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

namespace ISEducons
{
    /// <summary>
    /// Interaction logic for exitScreen.xaml
    /// </summary>
    public partial class exitScreen : Window
    {
        public exitScreen()
        {
            InitializeComponent();
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);   //Izlaz iz programa
        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
