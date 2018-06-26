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
using System.IO;
using ISEducons.HelpProzor;

namespace ISEducons.HelpWindow
{
    /// <summary>
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        private JSHelper ch;
        public HelpWindow(string key, MainWindow originator)
        {
            InitializeComponent();

            string curDir = Directory.GetCurrentDirectory();
            string path = String.Format("{0}/Help/{1}.html", curDir, key);
            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                key = "error";
            }
            Uri u = new Uri(String.Format("file:///{0}/Help/{1}.html", curDir, key));
            Console.WriteLine(u);
            //ch = new JSHelper(originator);

            //wbHelp.ObjectForScripting = ch;
            //wbHelp.Navigate(u);

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove(); //omogucava da se prozor pomera tako sto se drzi levi klik na prozoru
        }
    }
}
