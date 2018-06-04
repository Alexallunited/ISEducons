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


using MaterialDesignColors;
using MaterialDesignThemes.Wpf;

namespace ISEducons
{
    /// <summary>
    /// Interaction logic for Izgled.xaml
    /// </summary>
    public partial class Izgled : UserControl
    {
        public Izgled()
        {
            InitializeComponent();
        }
        
        private void Light_Click(object sender, RoutedEventArgs e)
        {
            new PaletteHelper().SetLightDark(false); //podesavanje na Light temu
        }

        private void Dark_Click(object sender, RoutedEventArgs e)
        {
            new PaletteHelper().SetLightDark(true);  //podesavanje na Dark temu
        }
    }
}
