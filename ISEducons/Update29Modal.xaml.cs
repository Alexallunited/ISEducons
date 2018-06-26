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
    /// Interaction logic for Update29.xaml
    /// </summary>
    public partial class Update29Modal : Window
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

        public Update29Modal()
        {
            InitializeComponent();
        }

        List<Ucionica29Data> lista = new List<Ucionica29Data>();


        public Update29Modal(string id, string cpu, string gpu, string ram, string mobo, string psu, string monitor, string mis, string tastatura, string komentar)
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
        private readonly string _ucionica29 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ucionica29.bin");


        private void UcitajDatotekuResursa()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            // TREBA IF ELSE, PROVERI DA LI RADI BEZ LISTA != NULL




            try
            {
                // obsCol ima ugradjen konstuktor samo ubacim listu u njega
                stream = File.Open(_ucionica29, FileMode.OpenOrCreate);
                lista = (List<Ucionica29Data>)formatter.Deserialize(stream);

                Console.WriteLine(lista);

                foreach (Ucionica29Data item in lista)
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



            foreach (Ucionica29Data data29 in lista)
            {
                if (data29.Id == this.id)
                {
                    data29.Id = boxID.Text;
                    data29.Cpu = boxCPU.Text;
                    data29.Gpu = boxGPU.Text;
                    data29.Ram = boxRAM.Text;
                    data29.Mobo = boxMaticna.Text;
                    data29.Psu = boxPSU.Text;
                    data29.Monitor = boxMonitor.Text;
                    data29.Mis = boxMis.Text;
                    data29.Tastatura = boxTastatura.Text;
                    data29.Komentar = boxKomentar.Text;

                }
            }

            try
            {

                //lista ima ugradjen konstuktor za obsCol

                stream = File.Open(_ucionica29, FileMode.OpenOrCreate);
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
                pocetniProzor.ucionica29.Visibility = Visibility.Visible;
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
                pocetniProzor.ucionica29.Visibility = Visibility.Visible;
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
