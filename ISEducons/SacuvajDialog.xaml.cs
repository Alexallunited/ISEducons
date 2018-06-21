using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ISEducons
{
    /// <summary>
    /// Interaction logic for SacuvajDialog.xaml
    /// </summary>
    public partial class SacuvajDialog : UserControl 
    {
        Izvestaj Izvestaj = new Izvestaj();
        Plan Plan = new Plan();
        
        public SacuvajDialog()
        {
            InitializeComponent();
            //izvestaj = new izvestaj();
            //plan = new plan();
            //SacuvajDialog sacuvajDialog = new SacuvajDialog();
            //sacuvajDialog.Izvestaj = this;
            
            //PocetniProzor PocetniProzor;

        }


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

        public void yes_Click(object sender, RoutedEventArgs e)
        {
            
        }
       


    }
}
