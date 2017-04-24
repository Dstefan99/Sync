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
    /// Interaktionslogik für Lesezeichen.xaml
    /// </summary>
    public partial class Lesezeichen : Window
    {
        MainWindow Main;
        public Lesezeichen(MainWindow mane)
        {
            Main = mane;
            InitializeComponent();
        }

        List<string> removals = new List<string>();

       
        public Lesezeichen(ItemCollection l, MainWindow mane) : this(mane)
        {
            foreach (var item in l)
            {
                listBox_Lesezeichen.Items.Add(item);
            }
        }

        // Schliest das Fenster
        private void button_OK_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }


        // Löscht die markierte URL aus der ListBox raus
        private void button_loeschen_Click(object sender, RoutedEventArgs e)
        {
            foreach (string item in listBox_Lesezeichen.SelectedItems)
            {
                removals.Add(item);
            }

            foreach (string s in removals)
            {
                listBox_Lesezeichen.Items.Remove(s);
            }
        }

     
        // Naviegiert zu der gewünschten Webseite die man eingespeichert hat.
        private void listBox_Lesezeichen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
            Main.Sync_Browser.Navigate(listBox_Lesezeichen.SelectedItem.ToString());
            System.Diagnostics.Debug.WriteLine(listBox_Lesezeichen.SelectedItem.ToString());
        }
    }
}
