using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Kalapacsvetes
{
    class Program
    {
        class Sportolo
        {
            public int Helyezés { get; set; }
            public double Eredmény { get; set; }
            public string Nev { get; set; }
            public string OrszágKód { get; set; }
            public string Helyszín { get; set; }
            public DateTime Dátum { get; set; }
            public Sportolo(int helyezes, double eredmeny, string nev, string orszagkod, string helyszin, DateTime datum)
            {
                Helyezés = helyezes;
                Eredmény = eredmeny;
                Nev = nev;
                OrszágKód = orszagkod;
                Helyszín = helyszin;
                Dátum = datum;
            }
        }
        class OrszagDobasok
        {
            public string OrszagKód { get; set; }
            public int Dobasok { get; set; }
        }
        private static List<Sportolo> sportolok = new List<Sportolo>();
        static void Main(string[] args)
        {
            StreamReader sr = new("kalapacsvetes.txt");
            sr.ReadLine(); //elso sor
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                var adatok = line.Split(';');
                int helyezes = int.Parse(adatok[0]);
                double eredmeny = double.Parse(adatok[1]);
                string nev = adatok[2];
                string orszag = adatok[3];
                string helyszin = adatok[4];
                DateTime datum = DateTime.Parse(adatok[5]);
                Sportolo sportolo = new Sportolo(helyezes, eredmeny, nev, orszag, helyszin, datum);
                sportolok.Add(sportolo);
            }
            feladat4();
            feladat5();
            feladat6();
            feladat7();
            feladat8();
            Console.ReadKey();
        }
        private static void feladat8()
        {
            StreamWriter sw = new StreamWriter("magyarok.txt");
            var HUNok = sportolok.Where(a => a.OrszágKód.Equals("HUN"));
            foreach ( var hunok in HUNok)
                sw.WriteLine($"{hunok.Helyezés} - {hunok.Nev} - {hunok.Eredmény} - {hunok.Dátum} - {hunok.Helyszín}");
            sw.Close();
        }
        private static void feladat7()
        {
            Console.WriteLine($"7. feladat: Statisztika");
            List<OrszagDobasok> orszagDobasoklist = new List<OrszagDobasok>();
            foreach (var dobasok in sportolok)
            {
                var orszagDobassort = orszagDobasoklist.FirstOrDefault(a => a.OrszagKód == dobasok.OrszágKód);
                if (orszagDobassort != null)
                    orszagDobassort.Dobasok++;
                else
                    orszagDobasoklist.Add(new OrszagDobasok { OrszagKód = dobasok.OrszágKód, Dobasok = 1 });
            }
            foreach (var orszagDobas in orszagDobasoklist)
                Console.WriteLine($"\t{orszagDobas.OrszagKód} - {orszagDobas.Dobasok}");
        }
        private static void feladat6()
        {
            Console.Write($"6. feladat: Kerek egy evszamot: ");
            string bekertevszam = Console.ReadLine();
            var adottEvDobasok = sportolok.Where(d => d.Dátum.Year == int.Parse(bekertevszam)).ToList();
            if (adottEvDobasok.Count.Equals(0))
                Console.WriteLine($"\tEgy dobás sem kerult be ebben az evben.");
            else 
                Console.WriteLine($"\t{adottEvDobasok.Count}db dobás került be ebben az evben:");
            var legjobb3 = adottEvDobasok.OrderByDescending(d=> d.Eredmény).ToList();
            var legjobbak = legjobb3.Take(adottEvDobasok.Count);
            foreach (var jatekos in legjobbak)
                Console.WriteLine($"\t{jatekos.Nev}");
        }

        private static void feladat5()
        {
            double atlageredmeny = 0;
            var HUNsporolok = sportolok.Where(a => a.OrszágKód.Equals("HUN")).ToList();
            if (HUNsporolok.Any())
                atlageredmeny = HUNsporolok.Average(a => a.Eredmény);
            Console.WriteLine($"5. feladat: A magyar sporolok atlagosan {atlageredmeny} metert dobtak.");
        }

        private static void feladat4()
        {
            Console.WriteLine($"4. feladat: {sportolok.Count} dobás eredménye található.");
        }
    }
}
