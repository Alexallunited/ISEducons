using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace ISEducons
{
    /// <summary>
    /// Interaction logic for Ucionica26.xaml
    /// </summary>
    public partial class Ucionica26 : UserControl
    {
        List<Ucionica26Data> lista = new List<Ucionica26Data>();

        public Ucionica26()
        {
            InitializeComponent();



            UcitajDatotekuResursa();

        }

        // SERIJALIZACIJA/DESERIJALIZACIJA IZ DATOTEKE
        private readonly string _ucionica26 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ucionica26.bin");


        public void UcitajDatotekuResursa()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {

                stream = File.Open(_ucionica26, FileMode.OpenOrCreate);
                lista = null;
                lista = (List<Ucionica26Data>)formatter.Deserialize(stream);

                this.DataGridPeople.ItemsSource = lista;


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

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            //Add26 addWin = new Add26();
            ////this.Controls.Add(addWin);
            //addWin.Visibility = Visibility.Visible;
            PocetniProzor pocetniProzor = Window.GetWindow(this) as PocetniProzor;
            if (pocetniProzor != null)
            {
                pocetniProzor.Add26.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;
                UcitajDatotekuResursa();
            }
            

            UcitajDatotekuResursa();

        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {


            Update26 updWindow = new Update26(
                lista[DataGridPeople.SelectedIndex].Id,
                lista[DataGridPeople.SelectedIndex].Cpu,
                lista[DataGridPeople.SelectedIndex].Gpu,
                lista[DataGridPeople.SelectedIndex].Ram,
                lista[DataGridPeople.SelectedIndex].Mobo,
                lista[DataGridPeople.SelectedIndex].Psu,
                lista[DataGridPeople.SelectedIndex].Monitor,
                lista[DataGridPeople.SelectedIndex].Mis,
                lista[DataGridPeople.SelectedIndex].Tastatura,
                lista[DataGridPeople.SelectedIndex].Komentar);



            UcitajDatotekuResursa();
            //updWindow.Show();      <-- Ovo ce da radi, medjutim UserControl ne moze da se prikaze na ovaj nacin


            updWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;
            UcitajDatotekuResursa();

            

            PocetniProzor pocetniProzor = Window.GetWindow(this) as PocetniProzor;  //Ovo nam omogucava da koristimo Properties od drugog UserControl-a
            if (pocetniProzor != null)
            {
                //pocetniProzor = updWindow; 
                pocetniProzor.Update26.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;
                UcitajDatotekuResursa();
            }

        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            
                lista.RemoveAt(DataGridPeople.SelectedIndex);

                MemorisiDatotekuResursa();

                UcitajDatotekuResursa();
            
            
        }
    }
}
