using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Diakok
{
    internal class Program
    {
        class Diak
        {
            public string Nev { get; set; }
            public int Pontszam { get; set; }

            public Diak(string nev, int pontszam)
            {
                Nev = nev;
                Pontszam = pontszam;
            }
        }

        private static List<Diak> diakokList = new List<Diak>();

        static void Main(string[] args)
        {
            BeolvasAdatokat("adatok.txt");

            SzamitsDiakokSzamat();
            SzamitsAtlagot();
            SzamitsMinimumMaximum();
            MentsEredmenyeket("eredmenyek.txt");

            Console.ReadKey();
        }

        private static void BeolvasAdatokat(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    var adatok = line.Split(',');

                    string nev = adatok[0];
                    int pontszam = int.Parse(adatok[1]);

                    Diak diak = new Diak(nev, pontszam);
                    diakokList.Add(diak);
                }
            }
        }

        private static void SzamitsDiakokSzamat()
        {
            Console.WriteLine($"3. feladat: {diakokList.Count} van összesen a feladatban");
        }

        private static void SzamitsAtlagot()
        {
            double atlag = diakokList.Average(a => a.Pontszam);
            Console.WriteLine($"4. feladat: {atlag} a diákok átlag pontszáma");
        }

        private static void SzamitsMinimumMaximum()
        {
            int max = diakokList.Max(a => a.Pontszam);
            int min = diakokList.Min(a => a.Pontszam);

            Console.WriteLine($"5. feladat: A minimum pontszám: {min} és a maximum: {max}");
        }

        private static void MentsEredmenyeket(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                double atlag = diakokList.Average(a => a.Pontszam);
                int max = diakokList.Max(a => a.Pontszam);
                int min = diakokList.Min(a => a.Pontszam);
                string maxNev = diakokList.First(a => a.Pontszam == max).Nev;
                string minNev = diakokList.First(a => a.Pontszam == min).Nev;

                sw.WriteLine($"Átlag pontszám: {atlag}");
                sw.WriteLine($"Legmagasabb pontszám: {maxNev} - {max}");
                sw.WriteLine($"Legalacsonyabb pontszám: {minNev} - {min}");
            }

            Console.WriteLine("Eredmények mentve az eredmenyek.txt fájlba.");
        }
    }
}
