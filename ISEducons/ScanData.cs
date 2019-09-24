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

        public ScanData(string Ip, string Hostname, string Status)
        {
            this.Ip = Ip;
            this.Hostname = Hostname;
            this.Status = Status;
        }

        public string Ip { get { return ip; } set { ip = value; OnNotifyPropertyChanged("Ip"); } }
        public string Hostname { get { return hostname; } set { hostname = value; OnNotifyPropertyChanged("Hostname"); } }
        public string Status { get { return status; } set { status = value; OnNotifyPropertyChanged("Status"); } }




    }
}
