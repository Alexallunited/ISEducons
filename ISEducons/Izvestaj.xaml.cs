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
    /// Interaction logic for Izvestaj.xaml
    /// </summary>
    public partial class Izvestaj : UserControl
    {
        public Izvestaj()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //TextRange t = new TextRange(richTextBox1.Document.ContentStart,
            //                        richTextBox1.Document.ContentEnd);
            //FileStream file = new FileStream("Sample File.xaml", FileMode.Create);
            //t.Save(file, System.Windows.DataFormats.XamlPackage);
            //file.Close();

            //System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            //if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew)) 
            //    using (StreamWriter sw = new StreamWriter(s))
            //    {
            //        sw.Write(RichTextBox.Text);
            //    }
            //}


            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //if (saveFileDialog.ShowDialog() == true)
            //{

            //    File.WriteAllText(saveFileDialog.FileName, editor.Text);
            //}



        }
        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(editor.Document.ContentStart, editor.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(editor.Document.ContentStart, editor.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);
            }
        }


    }
}
