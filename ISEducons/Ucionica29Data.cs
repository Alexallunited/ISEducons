using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISEducons
{
    [Serializable]
    public class Ucionica29Data : INotifyPropertyChanged
    {
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

        public Ucionica29Data()
        {
            id = "";
            cpu = "";
            gpu = "";
            ram = "";
            mobo = "";
            psu = "";
            monitor = "";
            mis = "";
            tastatura = "";
            komentar = "";
        }


        public Ucionica29Data(string Id, string Cpu, string Gpu, string Ram, string Mobo, string Psu, string Monitor, string Mis, string Tastatura, string Komentar)
        {
            this.Id = Id;
            this.Cpu = Cpu;
            this.Gpu = Gpu;
            this.Ram = Ram;
            this.Mobo = Mobo;
            this.Psu = Psu;
            this.Monitor = Monitor;
            this.Mis = Mis;
            this.Tastatura = Tastatura;
            this.Komentar = Komentar;
        }

        public string Id { get => id; set { id = value; OnNotifyPropertyChanged("Id"); } }
        public string Cpu { get => cpu; set { cpu = value; OnNotifyPropertyChanged("Cpu"); } }
        public string Gpu { get => gpu; set { gpu = value; OnNotifyPropertyChanged("Gpu"); } }
        public string Ram { get => ram; set { ram = value; OnNotifyPropertyChanged("Ram"); } }
        public string Mobo { get => mobo; set { mobo = value; OnNotifyPropertyChanged("Mobo"); } }
        public string Psu { get => psu; set { psu = value; OnNotifyPropertyChanged("Psu"); } }
        public string Monitor { get => monitor; set { monitor = value; OnNotifyPropertyChanged("Ip"); } }
        public string Mis { get => mis; set { mis = value; OnNotifyPropertyChanged("Mis"); } }
        public string Tastatura { get => tastatura; set { tastatura = value; OnNotifyPropertyChanged("Tastatura"); } }
        public string Komentar { get => komentar; set { komentar = value; OnNotifyPropertyChanged("Komentar"); } }





    }



}
