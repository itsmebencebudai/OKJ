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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int melyiksz = 0;
        private static int melyikk = 0;
        public MainWindow()
        {
            InitializeComponent();
            cserek.Click += képcsere; //csak képet cserél 
            cseresz.Click += szövegcsere; //csak szöveget cserél
            cserem.Click += képcsere; //delegált függvény 
            cserem.Click += szövegcsere; //második delegált
            //kattintásra mindkettő végrehajtódik
        }

        private void képcsere(object sender, RoutedEventArgs e)
        {
            if (melyikk == 0)
                image.Source = new BitmapImage(new Uri("lednice.jpg",UriKind.RelativeOrAbsolute)); 
            else
                image.Source = new BitmapImage(new Uri("tatra.jpg", UriKind.RelativeOrAbsolute));
            melyikk=(++melyikk) % 2;
        }
        private void szövegcsere(object sender, RoutedEventArgs e)
        {
            if (melyiksz == 0)
                textBox.Text = "Lednice";
            else
                textBox.Text = "Ótátrafüred";
            melyiksz=(++melyiksz)%2;
        }
    }
}
