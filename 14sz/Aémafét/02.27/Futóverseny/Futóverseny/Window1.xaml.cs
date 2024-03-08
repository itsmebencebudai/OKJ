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
using System.Windows.Shapes;
using Microsoft.Win32;


namespace Futóverseny
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private string filePath;

        public Window1(string filePath)
        {
            InitializeComponent();
            this.filePath = filePath;
        }
        private void LoadSortedLines(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                var sortedLines = lines.OrderBy(line => TimeSpan.ParseExact(line.Split(';')[4], @"mm\:ss\.ff", null));

                foreach (var line in sortedLines)
                {
                    string[] data = line.Split(';');
                    listBox2.Items.Add($"{data[1]} - {data[4]}");
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

        private void SaveToFile(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "(*.txt)|*.txt";
            saveFileDialog.FileName = "EREDMENY.txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (var sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (var item in listBox2.Items)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }

                    MessageBox.Show("Data saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while saving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
