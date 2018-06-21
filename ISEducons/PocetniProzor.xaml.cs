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

//using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;

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
            Izvestaj.Visibility = Visibility.Collapsed;
            Plan.Visibility = Visibility.Collapsed;
            Racunari26.Visibility = Visibility.Collapsed;
            Racunari29.Visibility = Visibility.Collapsed;
            ucionica26.Visibility = Visibility.Collapsed;
            Update26.Visibility = Visibility.Collapsed;
            Add26.Visibility = Visibility.Collapsed;

            IzvestajSave.IsEnabled = false;
            IzvestajExit.IsEnabled = false;

            PlanSave.IsEnabled = false;
            PlanExit.IsEnabled = false;

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1500);
            }).ContinueWith(t =>
            {
                MainSnackbar.MessageQueue.Enqueue("                   Dobrodošli admin");
            }, TaskScheduler.FromCurrentSynchronizationContext());

            


        }

        private void WindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove(); //omogucava da se prozor pomera tako sto se drzi levi klik na prozoru
        }

        private void uizradi_Click(object sender, RoutedEventArgs e)
        {
            MainWindowDialogHost.DialogContent = new UIzradiDialog(); //otvara UserControl exitDialog kao dialog
            MainWindowDialogHost.IsOpen = true;

        }

        private void izgled_Click(object sender, RoutedEventArgs e)
        {
           
            MainWindowDialogHost.DialogContent = new Izgled(); //otvara UserControl Izgled kao dialog
            MainWindowDialogHost.IsOpen = true;

        }

        private void nalog_Click(object sender, RoutedEventArgs e)
        {
            MainWindowDialogHost.DialogContent = new UIzradiDialog(); //otvara UserControl exitDialog kao dialog
            MainWindowDialogHost.IsOpen = true;
            
        }

        private void dokumentacija_Click(object sender, RoutedEventArgs e)
        {
            MainWindowDialogHost.DialogContent = new UIzradiDialog(); //otvara UserControl exitDialog kao dialog
            MainWindowDialogHost.IsOpen = true;
            
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {

            MainWindowDialogHost.DialogContent = new UIzradiDialog(); //otvara UserControl exitDialog kao dialog
            MainWindowDialogHost.IsOpen = true;
            
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
            login.ShowDialog(); // Modalni prozor
            Izvestaj.editor.Document.Blocks.Clear();
            Plan.editor2.Document.Blocks.Clear();
        }
        
        private void Skener_Click(object sender, RoutedEventArgs e)
        {
            NetworkScanner scan = new NetworkScanner();
            scan.Show(); //Nemodalni prozor
        }



        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F11)
            {
                new PaletteHelper().SetLightDark(false); //podesavanje na Light temu
            }
            else if (e.Key == Key.F12)
            {
                new PaletteHelper().SetLightDark(true);  //podesavanje na Dark temu
            }
            else if (e.Key == Key.F1) //KeyPress za HELP tj. dokumentaciju
            {

            }
            else if (e.Key == Key.Escape) // Nisam siguran da mi je ovo potrebno al neka stoji za sada tu, mozda cu implementirati logout ili exit na ovo dugme
            {

            }
        }







        private void TestDugme_Click(object sender, RoutedEventArgs e)
        {
            NetworkScanner scan = new NetworkScanner();
            scan.Show(); //Nemodalni prozor
        }

        private void IzvestajExit_Click_1(object sender, RoutedEventArgs e)
        {
            Izvestaj.Visibility = Visibility.Collapsed;
            IzvestajSave.IsEnabled = false;
            IzvestajExit.IsEnabled = false;
            Izvestaj.editor.Document.Blocks.Clear();

            Izvestaj.Visibility = Visibility.Collapsed;
            Plan.Visibility = Visibility.Collapsed;
            Racunari26.Visibility = Visibility.Collapsed;
            Racunari29.Visibility = Visibility.Collapsed;
            ucionica26.Visibility = Visibility.Collapsed;
            Update26.Visibility = Visibility.Collapsed;
            Add26.Visibility = Visibility.Collapsed;
        }

        private void IzvestajOpen_Click(object sender, RoutedEventArgs e)
        {
            Izvestaj.Visibility = Visibility.Visible;
            IzvestajSave.IsEnabled = true;
            IzvestajExit.IsEnabled = true;

            
            Plan.Visibility = Visibility.Collapsed;
            Racunari26.Visibility = Visibility.Collapsed;
            Racunari29.Visibility = Visibility.Collapsed;
            ucionica26.Visibility = Visibility.Collapsed;
            Update26.Visibility = Visibility.Collapsed;
            Add26.Visibility = Visibility.Collapsed;
        }
        private void PlanExit_Click_1(object sender, RoutedEventArgs e)
        {
            Plan.Visibility = Visibility.Collapsed;
            PlanSave.IsEnabled = false;
            PlanExit.IsEnabled = false;
            Plan.editor2.Document.Blocks.Clear();

            Izvestaj.Visibility = Visibility.Collapsed;
            Racunari26.Visibility = Visibility.Collapsed;
            Racunari29.Visibility = Visibility.Collapsed;
            ucionica26.Visibility = Visibility.Collapsed;
            Update26.Visibility = Visibility.Collapsed;
            Add26.Visibility = Visibility.Collapsed;
        }

        private void PlanOpen_Click(object sender, RoutedEventArgs e)
        {
            Plan.Visibility = Visibility.Visible;
            PlanSave.IsEnabled = true;
            PlanExit.IsEnabled = true;

            Izvestaj.Visibility = Visibility.Collapsed;
            Racunari26.Visibility = Visibility.Collapsed;
            Racunari29.Visibility = Visibility.Collapsed;
            ucionica26.Visibility = Visibility.Collapsed;
            Update26.Visibility = Visibility.Collapsed;
            Add26.Visibility = Visibility.Collapsed;
        }

        public delegate void TempDelegate();
        public static event TempDelegate es;

        public void izvestaj_Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(Izvestaj.editor.Document.ContentStart, Izvestaj.editor.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }

        private void izvestaj_Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(Izvestaj.editor.Document.ContentStart, Izvestaj.editor.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);
            }
        }
        public void plan_Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(Plan.editor2.Document.ContentStart, Plan.editor2.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }

        private void plan_Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(Plan.editor2.Document.ContentStart, Plan.editor2.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);
            }
        }

        private void Ucionica26_Click(object sender, RoutedEventArgs e)
        {
            ucionica26.UcitajDatotekuResursa();
            ucionica26.Visibility = Visibility.Visible;

            Izvestaj.Visibility = Visibility.Collapsed;
            Plan.Visibility = Visibility.Collapsed;
            Racunari26.Visibility = Visibility.Collapsed;
            Racunari29.Visibility = Visibility.Collapsed;

            //Racunari26.Visibility = Visibility.Visible;

            //Izvestaj.Visibility = Visibility.Collapsed;
            //Plan.Visibility = Visibility.Collapsed;
            //Racunari29.Visibility = Visibility.Collapsed;
            ////Racunari10.Visibility = Visibility.Collapsed;
        }

        private void Ucionica29_Click(object sender, RoutedEventArgs e)
        {


            Izvestaj.Visibility = Visibility.Collapsed;
            Plan.Visibility = Visibility.Collapsed;
            Racunari26.Visibility = Visibility.Collapsed;
            Racunari29.Visibility = Visibility.Collapsed;

            //Racunari29.Visibility = Visibility.Visible;

            //Izvestaj.Visibility = Visibility.Collapsed;
            //Plan.Visibility = Visibility.Collapsed;
            //Racunari26.Visibility = Visibility.Collapsed;
            ////Racunari10.Visibility = Visibility.Collapsed;
        }

        private void Ucionica10_Click(object sender, RoutedEventArgs e)
        {
            //Racunari10.Visibility = Visibility.Visible;

            Izvestaj.Visibility = Visibility.Collapsed;
            Plan.Visibility = Visibility.Collapsed;
            Racunari26.Visibility = Visibility.Collapsed;
            Racunari29.Visibility = Visibility.Collapsed;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            //Racunari10.Visibility = Visibility.Visible;
            Izvestaj.Visibility = Visibility.Collapsed;
            Plan.Visibility = Visibility.Collapsed;
            Racunari26.Visibility = Visibility.Collapsed;
            Racunari29.Visibility = Visibility.Collapsed;
            ucionica26.Visibility = Visibility.Collapsed;
            Update26.Visibility = Visibility.Collapsed;
            Add26.Visibility = Visibility.Collapsed;

            //if (Izvestaj.editor.Document.Blocks.Count <= 1)
            //{
            //    MessageBox.Show("PRAZAN!!!!");
            //}else
            //{
            //    MessageBox.Show("IMA NESTO!!!!");
            //    MainWindowDialogHost.DialogContent = new SacuvajDialog(); 
            //    MainWindowDialogHost.IsOpen = true;
            //}

        }
    }
}
