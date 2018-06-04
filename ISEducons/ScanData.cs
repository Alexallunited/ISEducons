using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISEducons
{
    class ScanData : INotifyPropertyChanged
    {
        string ip;
        string hostname;
        string status;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

        public ScanData()
        {
            ip = "";
            hostname = "";
            status = "";
        }

        public ScanData(string Ip, string Age, string IsStudent)
        {
            this.Ip = Ip;
            this.Hostmame = Age;
            this.Status = IsStudent;
        }

        public string Ip { get => ip; set { ip = value; OnNotifyPropertyChanged("Name"); } }
        public string Hostmame { get => hostname; set { hostname = value; OnNotifyPropertyChanged("Age"); } }
        public string Status { get => status; set { status = value; OnNotifyPropertyChanged("IsStudent"); } }




    }
}
