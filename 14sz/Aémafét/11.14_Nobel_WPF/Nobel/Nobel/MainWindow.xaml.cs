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
                            Eredmeny.Text = string.Empty;
                            Feladat3();
                            break;
                        case "4. feladat":
                            DescriptionText.Text = "Határozza meg és írja ki a képernyőre a minta szerint, hogy ki kapott 2017-ben irodalmi Nobel-díjat!";
                            Eredmeny.Text = string.Empty;
                            Feladat4();
                            break;
                        case "5. feladat":
                            DescriptionText.Text = "Határozza meg és írja ki a képernyőre a minta szerint, hogy mely szervezetek kaptak béke Nobel-díjat 1990-től napjainkig!";
                            Eredmeny.Text = string.Empty;
                            Feladat5();
                            break;
                        case "6. feladat":
                            DescriptionText.Text = "A Curie család több tagja is kapott díjat. Határozza meg és írja ki a képernyőre a minta szerint, hogy melyik évben a család melyik tagja milyen díjat kapott!";
                            Eredmeny.Text = string.Empty;
                            Feladat6();
                            break;
                        case "7. feladat":
                            DescriptionText.Text = "Határozza meg és írja ki a képernyőre a minta szerint, hogy melyik típusú díjból hány darabot osztottak ki a Nobel-díj történelme folyamán!";
                            Eredmeny.Text = string.Empty;
                            Feladat7();
                            break;
                        case "8. feladat":
                            DescriptionText.Text = "Hozzon létre orvosi.txt néven egy UTF-8 kódolású szöveges állományt, amely tartalmazza az összes kioszott orvosi Nobel-díj adatait!";
                            Eredmeny.Text = string.Empty;
                            Feladat8();
                            break;
                        default:
                            DescriptionText.Text = "Nincsen feladat kiválasztva";
                            Eredmeny.Text = string.Empty;
                            break;
                    }
                }
            }
        }


        private void Feladat3()
        {
            List<DataItem> data = ReadCsvFile(csvFilePath);

            Feladat.Text = "3. feladat:";

            var result = data.FirstOrDefault(item => item.KeresztNev.Equals("Arthur B.") && item.VezetekNev.Equals("McDonald"));

            if (result != null)
            {
                Eredmeny.Text = $"{result.Tipus}";
            }
        }

        private void Feladat4()
        {
            List<DataItem> data = ReadCsvFile(csvFilePath);

            Feladat.Text = "4. feladat:";

            var result = data.FirstOrDefault(item => item.Evszam.Equals("2017") && item.Tipus.Equals("irodalmi"));

            if (result != null)
            {
                Eredmeny.Text = $"{result.KeresztNev} {result.VezetekNev}";
            }
        }
        private void Feladat5()
        {
            List<DataItem> data = ReadCsvFile(csvFilePath);

            Feladat.Text = "5. feladat:";

            var results = data
                .Where(item => int.Parse(item.Evszam) >= 1990 && string.IsNullOrEmpty(item.VezetekNev))
                .ToList();

            foreach (var result in results)
            {
                Eredmeny.Text += $"{result.Evszam}: {result.KeresztNev}\n";
            }
        }

        private void Feladat6()
        {
            List<DataItem> data = ReadCsvFile(csvFilePath);

            Feladat.Text = "6. feladat:";

            var results = data
                .Where(item => item.VezetekNev.Contains("Curie"))
                .ToList();

            foreach (var result in results)
            {
                Eredmeny.Text += $"{result.Evszam}: {result.KeresztNev} {result.VezetekNev}({result.Tipus})\n";
            }
        }

        private void Feladat7()
        {
            List<DataItem> data = ReadCsvFile(csvFilePath);

            Feladat.Text = "7. feladat:";

            var fizikai_db = 0;
            var irodalomi_db = 0;
            var kemiai_db = 0;
            var orvosi_db = 0;
            var beke_db = 0;
            var kozgazdasagtani_db = 0;

            foreach (var result in data)
            {
                if (result.Tipus.Equals("fizikai"))
                    fizikai_db++;
                else if (result.Tipus.Equals("kémiai"))
                    kemiai_db++;
                else if (result.Tipus.Equals("orvosi"))
                    orvosi_db++;
                else if (result.Tipus.Equals("irodalmi"))
                    irodalomi_db++;
                else if (result.Tipus.Equals("béke"))
                    beke_db++;
                else if (result.Tipus.Equals("közgazdaságtani"))
                    kozgazdasagtani_db++;
            }

            Eredmeny.Text =
                    $"fizikai \t {fizikai_db}\n" +
                    $"kémiai \t {kemiai_db}\n" +
                    $"orvosi \t {orvosi_db}\n" +
                    $"irodalmi \t {irodalomi_db}\n" +
                    $"béke \t {beke_db}\n" +
                    $"közgazdaságtani \t {kozgazdasagtani_db}\n";
        }

        private void Feladat8()
        {
            Feladat.Text = "8. feladat:";

            StreamWriter writer = new StreamWriter("orvosi.txt");

            List<DataItem> data = ReadCsvFile(csvFilePath);

            foreach (var item in from item in data
                                 where item.Tipus.Equals("orvosi")
                                 select item)
            {
                writer.WriteLine($"{item.Evszam}: {item.KeresztNev} {item.VezetekNev}");
            }

            Eredmeny.Text = File.Exists("orvosi.txt") ? "Az orvosi.txt sikeresen létrehozva" : "Az orvosi.txt nem sikerült létrehozni";

        }









    }
}
