using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace FutoVerseny
{
    public partial class MainWindow : Window
    {
        private List<Versenyzo> versenyzok = new List<Versenyzo>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void HozzaadasButton_Click(object sender, RoutedEventArgs e)
        {
            // Hozzáadás gomb eseménykezelője
            string nev = nevTextBox.Text;
            string szuletesiDatum = szuletesiDatumTextBox.Text;
            string orszag = orszagTextBox.Text;
            string ido = idoTextBox.Text;

            Versenyzo versenyzo = new Versenyzo(nev, szuletesiDatum, orszag, ido);
            versenyzok.Add(versenyzo);

            RefreshListBox();
            ClearTextBoxes();
        }

        private void EredmenylistaButton_Click(object sender, RoutedEventArgs e)
        {
            // Eredménylista gomb eseménykezelője
            var eredmenylista = versenyzok.OrderByDescending(v => v.Ido).ToList();
            string eredmenyText = string.Join(Environment.NewLine, eredmenylista.Select(v => $"{v.Nev}: {v.Ido}"));

            MessageBox.Show(eredmenyText, "Eredménylista");
        }

        private void MentesButton_Click(object sender, RoutedEventArgs e)
        {
            // Mentes gomb eseménykezelője
            var eredmenylista = versenyzok.OrderByDescending(v => v.Ido).ToList();
            string eredmenyText = string.Join(Environment.NewLine, eredmenylista.Select(v => $"{v.Nev}: {v.Ido}"));

            File.WriteAllText("EREDMENYEK.txt", eredmenyText);
            MessageBox.Show("Eredmények mentve az EREDMENYEK.txt fájlba.", "Mentés");
        }

        private void RefreshListBox()
        {
            // ListBox frissítése
            versenyzokListBox.ItemsSource = null;
            versenyzokListBox.ItemsSource = versenyzok.Select(v => v.Nev).ToList();
        }

        private void ClearTextBoxes()
        {
            // TextBox-ok ürítése
            nevTextBox.Clear();
            szuletesiDatumTextBox.Clear();
            orszagTextBox.Clear();
            idoTextBox.Clear();
        }
    }

    public class Versenyzo
    {
        public string Nev { get; set; }
        public string SzuletesiDatum { get; set; }
        public string Orszag { get; set; }
        public string Ido { get; set; }

        public Versenyzo(string nev, string szuletesiDatum, string orszag, string ido)
        {
            Nev = nev;
            SzuletesiDatum = szuletesiDatum;
            Orszag = orszag;
            Ido = ido;
        }
    }
}
