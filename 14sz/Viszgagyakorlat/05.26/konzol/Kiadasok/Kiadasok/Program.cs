using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kiadasok
{
    internal class Program
    {
        class Kiadas
        {
            public string honap { get; set; }
            public int bevetel { get; set; }
            public int kiadas { get; set; }
            public double profit => bevetel - kiadas;

            public Kiadas(string honap, int bevetel, int kiadas)
            {
                this.honap = honap;
                this.bevetel = bevetel;
                this.kiadas = kiadas;
            }
        }
        private static List<Kiadas> kiadasList = new List<Kiadas>();
        static void Main(string[] args)
        {
            beolvasas("beolvas.txt");
            feladat1();
            feladat2();
            feladat3("eredmenyek.txt");

            Console.ReadKey();
        }

        private static void feladat3(string kiFile)
        {
            StreamWriter sw = new StreamWriter(kiFile);

            var maxprofit = kiadasList.Max(a => a.profit);
            var maxveszteseg = kiadasList.Where(a => a.profit < 0).Min(a => a.profit);
            int bevetel = kiadasList.Sum(a => a.bevetel);
            int kiadas = kiadasList.Sum(a => a.kiadas);
            double profit = kiadasList.Sum(a => a.profit);

            sw.WriteLine($"A max profit: {maxprofit}");
            sw.WriteLine($"A legnagyobb veszteseg: {maxveszteseg}");
            sw.WriteLine($"Az osszes bevetel: {bevetel}");
            sw.WriteLine($"Az osszes kiadas: {kiadas}");
            sw.WriteLine($"Az osszes profit: {profit}");

            sw.Close();
        }

        private static void feladat2()
        {
            var maxprofit = kiadasList.Max(a => a.profit);
            var maxveszteseg = kiadasList.Where(a => a.profit < 0).Min(a => a.profit);

            Console.WriteLine($"2. feladat:");
            Console.WriteLine($"\tA maximum profit {maxprofit} volt");
            Console.WriteLine($"\tA legnagyobb veszteseg {maxveszteseg} volt");
        }

        private static void feladat1()
        {
            int bevetel = kiadasList.Sum(a => a.bevetel);
            int kiadas = kiadasList.Sum(a => a.kiadas);
            int profit = bevetel - kiadas;

            Console.WriteLine($"1. feladat:");
            Console.WriteLine($"\tAz osszes bevetel: {bevetel}");
            Console.WriteLine($"\tAz osszes kiadas: {kiadas}");
            Console.WriteLine($"\tAz osszes profit: {profit}");
        }

        private static void beolvasas(string beFile)
        {
            StreamReader sr = new StreamReader(beFile);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                var adatok = line.Split(',');

                string honap = adatok[0];
                int bevetel = int.Parse(adatok[1]);
                int kiadas = int.Parse(adatok[2]);

                Kiadas kiadasClass = new Kiadas(honap, bevetel, kiadas);
                kiadasList.Add(kiadasClass);
            }
        }
    }
}
