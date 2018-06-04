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

using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net;
using System.Management;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using System.Windows.Threading;

namespace ISEducons
{
    /// <summary>
    /// Interaction logic for NetworkScanner.xaml
    /// </summary>
    public partial class NetworkScanner : Window
    {
        public NetworkScanner()
        {
            InitializeComponent();
            
            labelaStatus.Content = "";
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            stop.IsEnabled = false;
        }

        private void WindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove(); //omogucava da se prozor pomera tako sto se drzi levi klik na prozoru
        }

        Thread myThread = null;

        public void Scan(string subnet)
        {
            Ping myPing;
            PingReply reply;
            IPAddress addr;
            IPHostEntry host;

            Application.Current.Dispatcher.BeginInvoke(
            DispatcherPriority.Background,
            new Action(() => this.progressBar.Maximum = 254));
            //progressBar.Maximum = 254;

            Application.Current.Dispatcher.BeginInvoke(
            DispatcherPriority.Background,
            new Action(() => this.progressBar.Value = 0));
            //progressBar.Value = 0;

            Application.Current.Dispatcher.BeginInvoke(
            DispatcherPriority.Background,
            new Action(() => this.listView.Items.Clear()));
            //listView.Items.Clear();

            for (int i = 1; i < 255; i++)
            {
                string subnetn = "." + i.ToString();
                myPing = new Ping();
                reply = myPing.Send(subnet + subnetn, 900);

                Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Background,
                new Action(() => this.labelaStatus.Foreground = new SolidColorBrush(Colors.Green)));
                //labelaStatus.Foreground = new SolidColorBrush(Colors.Green);

                Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Background,
                new Action(() => this.labelaStatus.Content = "Skeniram " + subnet + subnetn));
                //labelaStatus.Content = "Skeniram: " +subnet + subnetn;

                if (reply.Status == IPStatus.Success)
                {
                    try
                    {

                        addr = IPAddress.Parse(subnet + subnetn);
                        host = Dns.GetHostEntry(addr);
                        //host = Dns.GetHostEntry(addr);



                        Application.Current.Dispatcher.BeginInvoke(
                         DispatcherPriority.Background,
                         new Action(() => this.listView.Items.Add(new ScanData { Ip = subnet + subnetn, Hostname = host.HostName, Status = "Aktivan" })));
                         //this.listView.Items.Add(new ScanData { Ip = subnet + subnetn, Hostmame = host.HostName, Status = "Aktivan" });

                        //listView.Items.Add(new ListViewItem(new String[] { subnet + subnetn, host.HostName, "Up" }));
                        //listView.Items.Add(new System.Windows.Forms.ListViewItem(new String[] { subnet + subnetn, host.HostName, "Up" }));
                        //listView.Items.Add(new ListViewItem());
                    }
                    catch
                    {

                        // MessageBox.Show("Couldnt retrieve hostname for "+subnet+subnetn, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Background,
                new Action(() => this.progressBar.Value += 1));
                //progressBar.Value += 1;
            }

            Application.Current.Dispatcher.BeginInvoke(
            DispatcherPriority.Background,
            new Action(() => this.start.IsEnabled = true));
            //start.IsEnabled = true;

            Application.Current.Dispatcher.BeginInvoke(
            DispatcherPriority.Background,
            new Action(() => this.stop.IsEnabled = false));
            //stop.IsEnabled = false;

            Application.Current.Dispatcher.BeginInvoke(
            DispatcherPriority.Background,
            new Action(() => this.boxIP.IsEnabled = true));
            //boxIP.IsEnabled = true;

            Application.Current.Dispatcher.BeginInvoke(
            DispatcherPriority.Background,
            new Action(() => this.labelaStatus.Content = "Skeniranje završeno"));
            //labelaStatus.Content = "Završeno skeniranje";


            int count = listView.Items.Count;
            MessageBox.Show("Scanning done!\nFound " + count.ToString() + " hosts.", "Done");
        }



        private void cmdScan_Click(object sender, EventArgs e)
        {
            //this.Dispatcher.Invoke(() =>
            // {
            if (boxIP.Text == string.Empty)
            {
                MessageBox.Show("No IP address entered.", "Error");
            }
            else
            {
                string a = "192.168.1";

                myThread = new Thread(() => Scan(a));

                //Application.Current.Dispatcher.BeginInvoke(
                //DispatcherPriority.Background,
                //new Action(() => this.myThread = new Thread(() => Scan(boxIP.Text))));
               
                //myThread = new Thread(() => Scan(boxIP.Text));

                //Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                //{
                //    myThread = new Thread(() => 
                //    Scan(boxIP.Text));
                //} 
                //));
                myThread.IsBackground = true;

                myThread.Start();  //Invoke
                
                if (myThread.IsAlive == true)
                {
                    stop.IsEnabled = true;
                    start.IsEnabled = false;
                    boxIP.IsEnabled = false;
                }
                
            }
            // });




        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            myThread.Suspend();
            start.IsEnabled = true;
            stop.IsEnabled = false;
            boxIP.IsEnabled = true;
            labelaStatus.Foreground = new SolidColorBrush(Colors.Red);
            labelaStatus.Content = "Skeniranje zaustavljeno";
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            if (myThread.IsAlive == true)
            {
                myThread.Suspend();
            }

            this.Close();
        }
    }
}
