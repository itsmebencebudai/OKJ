using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System;

namespace Futóverseny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] lines = Array.Empty<string>();
        private string filePath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1(filePath);
            window1.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Close();

            App.Current.Shutdown();
        }

        private void LoadDataFromFile(object sender, RoutedEventArgs e)
        {
            string debugPath = AppDomain.CurrentDomain.BaseDirectory;
            filePath = System.IO.Path.Combine(debugPath, "futok.txt");

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] data = line.Split(';');
                    string name = data[1];
                    listbox1.Items.Add(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a fájl olvasása során: {ex.Message}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ListBox1_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found: " + filePath);
                    return;
                }

                string[] lines = File.ReadAllLines(filePath);

                if (listbox1.SelectedItem == null)
                {
                    Console.WriteLine("No item selected in ListBox");
                    return;
                }

                int selectedIndex = listbox1.SelectedIndex;
                if (selectedIndex >= 0 && selectedIndex < lines.Length)
                {
                    string[] data = lines[selectedIndex].Split(';');
                    Console.WriteLine("Selected data: " + string.Join(", ", data));
                    textBox2.Text = data[0];
                    textBox3.Text = data[3];
                    textBox4.Text = data[4];
                    textBox5.Text = data[2];
                }
                else
                {
                    Console.WriteLine("Invalid selected index: " + selectedIndex);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }


    }
}