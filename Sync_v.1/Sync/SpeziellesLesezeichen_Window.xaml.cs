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

namespace Sync
{
    /// <summary>
    /// Interaktionslogik für SpeziellesLesezeichen_Window.xaml
    /// </summary>
    public partial class SpeziellesLesezeichen_Window : Window
    {
        MainWindow Main_Lese;

        List<string> removals = new List<string>();

        public SpeziellesLesezeichen_Window(MainWindow mane_Lese)
        {
            Main_Lese = mane_Lese;
            InitializeComponent();
        }

        public SpeziellesLesezeichen_Window(ItemCollection l, MainWindow mane_Lese) : this(mane_Lese)
        {
            foreach (var item in l)
            {
                listBox_Spezielles_Lesezeichen.Items.Add(item);
            }
        }

        //Schließt das fenster
        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Man sucht einen eintrag aus den man rauslöschen will von unserer Listbox.
        private void button_Loeschen_Click(object sender, RoutedEventArgs e)
        {
            foreach (string item in listBox_Spezielles_Lesezeichen.SelectedItems)
            {
                removals.Add(item);
            }

            foreach (string s in removals)
            {
                listBox_Spezielles_Lesezeichen.Items.Remove(s);
            }
        }

        
        //Soll mit einem Doppelklick zu der jeweiligen Webseite die man haben will, navigiert.
        private void listBox_Spezielles_Lesezeichen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            System.Diagnostics.Debug.WriteLine(listBox_Spezielles_Lesezeichen.SelectedItem.ToString());
           // Main_Lese.Sync_Browser.Navigate(listBox_Spezielles_Lesezeichen.SelectedItem.ToString());
        }
    }
}
