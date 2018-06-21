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
    /// Interaction logic for Update26.xaml
    /// </summary>
    public partial class Update26 : UserControl
    {
        public Update26()
        {
            InitializeComponent();
        }

        string id;
        string cpu;
        string gpu;
        string ram;
        string mobo;
        string psu;
        string monitor;
        string mis;
        string tastatura;
        string komentar;

        List<Ucionica26Data> lista = new List<Ucionica26Data>();

        
            public Update26(string Id, string Cpu, string Gpu, string Ram, string Mobo, string Psu, string Monitor, string Mis, string Tastatura, string Komentar)
        {
            this.id = Id;
            this.cpu = Cpu;
            this.gpu = Gpu;
            this.ram = Ram;
            this.mobo = Mobo;
            this.psu = Psu;
            this.monitor = Monitor;
            this.mis = Mis;
            this.tastatura = Tastatura;
            this.komentar = Komentar;
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
                    Console.WriteLine(item.Cpu);
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
            this.Visibility = Visibility.Collapsed;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
        private void boxIP_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9.]+");
        }
    }
}
