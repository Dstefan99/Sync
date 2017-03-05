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

        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            Sync_Browser.Navigate(textBox_suchbox.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Sync_Browser.Navigate("http://www.google.com");
        }

        private void button_Back(object sender, RoutedEventArgs e)
        {
            Sync_Browser.GoBack();
        }

        private void button_Click_Vor(object sender, RoutedEventArgs e)
        {
            Sync_Browser.GoForward();
        }

        private void Sync_Browser_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            textBox_suchbox.Text = e.Uri.OriginalString;

        }
    }
}
