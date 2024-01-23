using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nepesseg
{
    internal class Orszag
    {
        public string Orszagnev { get; private set; }
        public int Terulet { get; private set; }
        public int Nepesseg { get; private set; }
        public string Fovaros { get; private set; }
        public int FovarosNepesseg { get; private set; }

        /*
        public Orszag(string orszagnev, int terulet, int nepesseg, string fovaros, int fovarosNepesseg)
        {
            Orszagnev = orszagnev;
            Terulet = terulet;
            Nepesseg = nepesseg;
            Fovaros = fovaros;
            FovarosNepesseg = fovarosNepesseg;
        }
        */

        public Orszag(string sor)
        {
            // Ebben a konstruktorban is elvégezheti az adatsor felbontását!
            // Ha nem ezt választja, akkor törölje ezt a konstruktort!


            // 3 perc
            string[] data = sor.Split(';');

            if (data.Length >= 5)
            {
                Orszagnev = data[0].Trim();

                Terulet = int.Parse(data[1].Trim());

                string nepessegData = data[2].Trim();
                Nepesseg = ParseNepesseg(nepessegData);

                Fovaros = data[3].Trim();

                string fovarosnepessegData = data[4].Trim();
                FovarosNepesseg = ParseNepesseg(fovarosnepessegData);
            }
            else
            {
                Console.WriteLine("Nem jó adat forma: " + sor);
            }

        }

        private int ParseNepesseg(string nepessegString)
        {

            // 4 perc
            if (nepessegString.EndsWith("g"))
            {
                double numerikusResz = double.Parse(nepessegString.Substring(0, nepessegString.Length - 1).Trim());
                numerikusResz *= 1000000000;
                return (int)Math.Round(numerikusResz);
            }
            else
            {
                return int.Parse(nepessegString.Trim());
            }
        }

        public override string ToString()
        {
            return "";
        }
        public int NepSurduseg
        {
            // 5 perc
            get
            {
                if (Terulet != 0)
                {
                    double nepSurdusegDouble = (double)Nepesseg / Terulet;
                    return (int)Math.Round(nepSurdusegDouble);
                }
                else
                {
                    Console.WriteLine("Hiba: A terület 0, a népsűrűség nem számolható.");
                    return 0;
                }
            }
        }
        public bool FovarosLakossagTobbMint30Szazalek()
        {
            // 6 perc
            double persentige = Nepesseg / 100 * 30;
            if (FovarosNepesseg * 1000 > persentige)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            // 1 perc
            List<Orszag> orszagList = new List<Orszag>();
            string filePath = "adatok-utf8.txt";

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string sor = reader.ReadLine();
                        Orszag orszag = new Orszag(sor);
                        orszagList.Add(orszag);
                    }
                }
            }
            else
            {
                Console.WriteLine("Fájl nem található: " + filePath);
            }

            Feladat3(orszagList);
            Feladat4(orszagList);
            Feladat5(orszagList);
            Feladat6(orszagList);
            Feladat7(orszagList);

            Console.ReadKey();
        }

        private static void Feladat7(List<Orszag> orszagList)
        {
            // 5 perc
            Console.WriteLine("7. feladat - A következő országok lakosságának több mint 30%-a a fővárosban lakik:");

            foreach (Orszag orszag in orszagList)
            {
                if (orszag.FovarosLakossagTobbMint30Szazalek())
                {
                    Console.WriteLine($"\t{orszag.Orszagnev} ({orszag.Fovaros})");
                }
            }
        }

        private static void Feladat6(List<Orszag> orszagList)
        {
            // 4 perc
            Console.WriteLine("6. feladat");
            List<Orszag> rendezettOrszagok = orszagList.OrderByDescending(orszag => orszag.Nepesseg).ToList();

            if (rendezettOrszagok.Count >= 3)
            {
                Orszag harmadikLegnepesebb = rendezettOrszagok[2];
                Console.WriteLine($"A harmadik legnépesebb ország: {harmadikLegnepesebb.Orszagnev},a lakosság {harmadikLegnepesebb.Nepesseg} fő.");
            }
            else
            {
                Console.WriteLine("Nem áll rendelkezésre elegendő adat a harmadik legnépesebb ország meghatározásához.");
            }
            Console.WriteLine();
        }
        private static void Feladat5(List<Orszag> orszagList)
        {
            // 4 perc
            Console.WriteLine("5. feladat");
            Orszag kina_feladat5 = orszagList.Find(orszag => orszag.Orszagnev == "Kína");
            Orszag india_feladat5 = orszagList.Find(orszag => orszag.Orszagnev == "India");
            if (kina_feladat5 != null && india_feladat5 != null)
            {
                int kulonbseg = kina_feladat5.Nepesseg - india_feladat5.Nepesseg;
                Console.WriteLine($"Kínában a lakosság {kulonbseg} volt több.");
            }
            else
            {
                Console.WriteLine("Kína vagy India nem található az országok között.");
            }
            Console.WriteLine();
        }
        private static void Feladat4(List<Orszag> orszagList)
        {
            // 4 perc
            Console.WriteLine("4. feladat");
            Orszag kina_feladat4 = orszagList.Find(orszag => orszag.Orszagnev == "Kína");
            if (kina_feladat4 != null)
            {
                int kinaNepSurduseg = kina_feladat4.NepSurduseg;
                Console.WriteLine($"Kína népsűrűsége: {kinaNepSurduseg} fő/km²");
            }
            else
            {
                Console.WriteLine("Kína nem található az országok között.");
            }
            Console.WriteLine();
        }
        private static void Feladat3(List<Orszag> orszagList)
        {
            // 1 perc
            Console.WriteLine("3. feladat");
            Console.WriteLine($"A beolvasott orszagok száma {orszagList.Count}.");
            Console.WriteLine();
        }
    }
}
