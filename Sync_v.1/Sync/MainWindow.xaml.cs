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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sync
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Lesezeichen lese;
        SpeziellesLesezeichen_Window sp_lese;
        List<string> removals = new List<string>();

        public MainWindow()
        {
            lese = new Lesezeichen(this);
            sp_lese = new SpeziellesLesezeichen_Window(this);
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
          
            
        }

        //Navigiert zu der gewünschten Webseite
        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            Sync_Browser.Navigate("http://"+textBox_suchbox.Text);
          
        }

        //Wenn sich das Programm startet, navigiert der Webbrowser nach wie in dem Beispiel "www.google.com"
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Sync_Browser.Navigate("http://www.google.com");
        }

        //geht eine Seite zurück
        private void button_Back(object sender, RoutedEventArgs e)
        {
            //Wird abgefragt ob man noch zurück gehen kann. Wenn nicht bekommt man eine Nachricht das man nicht mehr zurück kann.
            if (Sync_Browser.CanGoBack)
            {
                Sync_Browser.GoBack();
            }
            else
            {
                MessageBox.Show("du kannst nicht mehr zurück!");
            }
            
        }

        //geht eine Seite vor
        private void button_Click_Vor(object sender, RoutedEventArgs e)
        {
            //Wird abgefragt ob man noch vorgehen kann. Wenn nicht bekommt man eine Nachricht das man nicht mehr vorgehen kann.
            if (Sync_Browser.CanGoForward)
            {
                Sync_Browser.GoForward();
            }
            else
            {
                MessageBox.Show("du kannst nicht mehr vor!");
            }
        }

      
        
        // Hier werden die Url's in einen MenuItem gespeichert
        private void Sync_Browser_Navigating_1(object sender, NavigatingCancelEventArgs e)
        {
            
            textBox_suchbox.Text = e.Uri.OriginalString;

            Chronik chr = new Chronik(textBox_suchbox.Text);

            var temp = new MenuItem();
            temp.Header = chr.Url;
            temp.Click += Chronik_anzeigen_Click;
            Chronik_zeigen.Items.Add(temp);
            
        }

       // Neue Tabs erstellen
        private void button_Click_New_Tab(object sender, RoutedEventArgs e)
        {
            TabItem tab = new TabItem();
            tab.Header = "New Tab";
            Grid grid_web = new Grid();
            WebBrowser web = new WebBrowser();
            web.Navigate("http://www.google.com");
            grid_web.Children.Add(web);
            tab.Content = grid_web;

            tabControl.Items.Add(tab);



        }

         // Werden die Tabs geschlossen
        private void button_delete_Tabs_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                tabControl.Items.RemoveAt(tabControl.SelectedIndex);
            }
            catch (Exception)
            {

                Application.Current.Shutdown();

            }

        }

    
        

       

       

      
        // Fügt es in einer listBox hinzu
        private void Lesezeichen_hinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            
           
            lese.listBox_Lesezeichen.Items.Add(textBox_suchbox.Text);
        }

        // Öffnet sich ein neues Fenster wo man seine Lesezeichen sieht
        private void Lesezeichen_zeigen_Click(object sender, RoutedEventArgs e)
        {
            if (!lese.IsActive)
            {
                lese = new Lesezeichen( lese.listBox_Lesezeichen.Items,this);
                lese.ShowDialog();
            }
        }
       
        // Chronik wird angezeigt und wenn man auf eine der Url's draufklickt wird man zu der Webseite geschickt
        private void Chronik_anzeigen_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Sync_Browser.Navigate(((MenuItem)sender).Header.ToString());
            }
            catch (Exception)
            {

                MessageBox.Show("");
            }
          

        }


        
        // Hier wird das spezielle Lesezeichen hinzugefügt
        private void Spezielles_Lesezeichen_hinzufuegen(object sender, RoutedEventArgs e)

        {
            

            var doc = Sync_Browser.Document as mshtml.HTMLDocument;

            

            if (doc != null)
            {
                var currentSelection = doc.selection;
                if (currentSelection != null)
                {
                    var selectionRange = currentSelection.createRange();
                    if (selectionRange != null)
                    {
                        SpeziellesLesezeichen spezi_lesezeichen = new SpeziellesLesezeichen(selectionRange.Text, textBox_suchbox.Text);

                        sp_lese.listBox_Spezielles_Lesezeichen.Items.Add(spezi_lesezeichen.Text + "\r\nURL: " + spezi_lesezeichen.Url );
                       
                    }
                }
            }
        }

        // Hier wird dann ein Fenster geöffnet wo man seine Texte und Urls die man gespeichert hat, sehen kann.
        private void Spezielles_Lesezeichen_anzeigen_Click(object sender, RoutedEventArgs e)
        {
            // Hier wird abgefragt ob das Dialog nicht mehr aktiv
            if (!sp_lese.IsActive)
            {
                sp_lese = new SpeziellesLesezeichen_Window(sp_lese.listBox_Spezielles_Lesezeichen.Items, this);
                sp_lese.ShowDialog();
            }
        }
    }
}
