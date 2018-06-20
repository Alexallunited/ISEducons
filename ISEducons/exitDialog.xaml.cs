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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;

namespace ISEducons
{
    /// <summary>
    /// Interaction logic for exitDialog.xaml
    /// </summary>
    public partial class exitDialog : UserControl
    {
        public exitDialog()
        {
            InitializeComponent();
        }
        private void yes_Click(object sender, RoutedEventArgs e)
        {
            

            Environment.Exit(1);   //Izlaz iz programa


        }
        
    }
}
