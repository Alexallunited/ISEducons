using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Update26Modal.xaml
    /// </summary>
    public partial class Update26Modal : Window
    {


        private string id;
        string cpu;
        string gpu;
        string ram;
        string mobo;
        string psu;
        string monitor;
        string mis;
        string tastatura;
        string komentar;

        public Update26Modal()
        {
            InitializeComponent();
        }

        List<Ucionica26Data> lista = new List<Ucionica26Data>();


        public Update26Modal(string id, string cpu, string gpu, string ram, string mobo, string psu, string monitor, string mis, string tastatura, string komentar)
        {

            InitializeComponent();

            this.id = id;
            this.cpu = cpu;
            this.gpu = gpu;
            this.ram = ram;
            this.mobo = mobo;
            this.psu = psu;
            this.monitor = monitor;
            this.mis = mis;
            this.tastatura = tastatura;
            this.komentar = komentar;

            boxID.Text = id;
            boxCPU.Text = cpu;
            boxGPU.Text = gpu;
            boxRAM.Text = ram;
            boxMaticna.Text = mobo;
            boxPSU.Text = psu;
            boxMonitor.Text = monitor;
            boxMis.Text = mis;
            boxTastatura.Text = tastatura;
            boxKomentar.Text = komentar;

            UcitajDatotekuResursa();
        }



        // SERIJALIZACIJA/DESERIJALIZACIJA IZ DATOTEKE
        private readonly string _ucionica26 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ucionica26.bin");


        private void UcitajDatotekuResursa()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            // TREBA IF ELSE, PROVERI DA LI RADI BEZ LISTA != NULL




            try
            {
                // obsCol ima ugradjen konstuktor samo ubacim listu u njega
                stream = File.Open(_ucionica26, FileMode.OpenOrCreate);
                lista = (List<Ucionica26Data>)formatter.Deserialize(stream);

                Console.WriteLine(lista);

                foreach (Ucionica26Data item in lista)
                {
                    Console.WriteLine(item.Id);
                }

            }
            catch
            {
                // 
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }


        }


        private void MemorisiDatotekuResursa()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;



            foreach (Ucionica26Data data26 in lista)
            {
                if (data26.Id == this.id)
                {
                    data26.Id = boxID.Text;
                    data26.Cpu = boxCPU.Text;
                    data26.Gpu = boxGPU.Text;
                    data26.Ram = boxRAM.Text;
                    data26.Mobo = boxMaticna.Text;
                    data26.Psu = boxPSU.Text;
                    data26.Monitor = boxMonitor.Text;
                    data26.Mis = boxMis.Text;
                    data26.Tastatura = boxTastatura.Text;
                    data26.Komentar = boxKomentar.Text;

                }
            }

            try
            {

                //lista ima ugradjen konstuktor za obsCol

                stream = File.Open(_ucionica26, FileMode.OpenOrCreate);
                formatter.Serialize(stream, lista);
            }
            catch
            {
                // 
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            MemorisiDatotekuResursa();
            UcitajDatotekuResursa();
            PocetniProzor pocetniProzor = Window.GetWindow(this) as PocetniProzor;
            if (pocetniProzor != null)
            {
                UcitajDatotekuResursa();
                pocetniProzor.ucionica26.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;
                UcitajDatotekuResursa();
            }

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            UcitajDatotekuResursa();
            PocetniProzor pocetniProzor = Window.GetWindow(this) as PocetniProzor;
            if (pocetniProzor != null)
            {
                UcitajDatotekuResursa();
                pocetniProzor.ucionica26.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;
                UcitajDatotekuResursa();
            }
        }


        private void WindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove(); //omogucava da se prozor pomera tako sto se drzi levi klik na prozoru
        }

        //private void boxIP_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    e.Handled = Regex.IsMatch(e.Text, "[^0-9.a-Z- ]+");
        //}
    }
}
