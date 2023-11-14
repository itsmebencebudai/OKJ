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
using System.IO;

namespace Nobel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string csvFilePath = "nobel.csv";
        public MainWindow()
        {
            InitializeComponent();
            LoadCSVFile();
        }
        private void LoadCSVFile()
        {
            if (!File.Exists(csvFilePath))
            {
                MessageBox.Show("CSV file is does not exists");
                return;
            }

            List<DataItem> data = ReadCsvFile(csvFilePath);

            //dataGrid.ItemsSource = data;
        }

        private List<DataItem> ReadCsvFile(string filePath)
        {
            List<DataItem> data = new();

            StreamReader reader = new StreamReader(filePath);
            reader.ReadLine();

            //string[] lines = File.ReadAllLines(filePath);

            string line = "";

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                string[] subs = line.Split(';');

                DataItem item = new()
                {
                    Evszam = subs[0],
                    Tipus = subs[1],
                    KeresztNev = subs[2],
                    VezetekNev = subs[3]
                };
                data.Add(item);

            }

            return data;
        }

        public class DataItem
        {
            public string Evszam { get; set; }
            public string Tipus { get; set; }
            public string KeresztNev { get; set; }
            public string VezetekNev { get; set; }
        }

        private void FeladatValtozas(object sender, SelectionChangedEventArgs e)
        {
            // Assuming you have a TextBlock named DescriptionText
            if (DescriptionText != null)
            {
                ComboBox comboBox = (ComboBox)sender;
                ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

                // Check if an item is selected
                if (selectedItem != null)
                {
                    // Get the content of the selected ComboBoxItem
                    string selectedText = selectedItem.Content.ToString();

                    // Set the description text based on the selected item
                    switch (selectedText)
                    {
                        case "-- Feladatok --":
                            DescriptionText.Text = "Nincsen feladat kiválasztva";
                            break;
                        case "3. feladat":
                            DescriptionText.Text = "Határozza meg és írja ki a képernyőre a minta szerint, hogy Arthur B. McDonald milyen típusú díjat kapott! Feltételezheti, hogy életében csak egyszer kapott Nobel-díjat";
                            Feladat3();
                            break;
                        case "4. feladat":
                            DescriptionText.Text = "Határozza meg és írja ki a képernyőre a minta szerint, hogy ki kapott 2017-ben irodalmi Nobel-díjat!";
                            Feladat4();
                            break;
                        case "5. feladat":
                            DescriptionText.Text = "Határozza meg és írja ki a képernyőre a minta szerint, hogy mely szervezetek kaptak béke Nobel-díjat 1990-től napjainkig!";
                            break;
                        case "6. feladat":
                            DescriptionText.Text = "A Curie család több tagja is kapott díjat. Határozza meg és írja ki a képernyőre a minta szerint, hogy melyik évben a család melyik tagja milyen díjat kapott!";
                            break;
                        case "7. feladat":
                            DescriptionText.Text = "Határozza meg és írja ki a képernyőre a minta szerint, hogy melyik típusú díjból hány darabot osztottak ki a Nobel-díj történelme folyamán!";
                            break;
                        case "8. feladat":
                            DescriptionText.Text = "Hozzon létre orvosi.txt néven egy UTF-8 kódolású szöveges állományt, amely tartalmazza az összes kioszott orvosi Nobel-díj adatait!";
                            break;
                        default:
                            DescriptionText.Text = "Nincsen feladat kiválasztva";
                            break;
                    }
                }
            }
        }

        //private void Feladat3()
        //{
        //    List<DataItem> data = ReadCsvFile(csvFilePath);

        //    foreach (DataItem item in data)
        //    {
        //        if (item.KeresztNev.Equals("Arthur B.") && item.VezetekNev.Equals("McDonald"))
        //        {
        //            DataGrid_Eredmeny.ItemsSource = item.Evszam;
        //        }
        //    }
        //}

        private void Feladat3()
        {
            List<DataItem> data = ReadCsvFile(csvFilePath);

            var result = data.FirstOrDefault(item => item.KeresztNev.Equals("Arthur B.") && item.VezetekNev.Equals("McDonald"));

            if (result != null)
            {
                List<DataItem> resultList = new List<DataItem> { result };
                DataGrid_Eredmeny.ItemsSource = resultList;
            }
        }

        private void Feladat4()
        {
            List<DataItem> data = ReadCsvFile(csvFilePath);

            var result = data.FirstOrDefault(item => item.Evszam.Equals("2017") && item.Tipus.Equals("irodalmi"));

            if (result != null)
            {
                List<DataItem> resultList = new List<DataItem> { result };
                DataGrid_Eredmeny.ItemsSource = resultList;
            }
        }




    }
}
