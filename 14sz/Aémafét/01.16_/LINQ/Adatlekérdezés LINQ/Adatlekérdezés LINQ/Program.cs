using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adatlekérdezés_LINQ
{
    internal class Program
    {
        private static void Main()
        {
            int[] halszám = new int[] { 4, 5, 7, 6, 3 };            // 1. adatforrás megadása. Ez legegyszerűbb esetben
                                                                    // egy tömb, jelen esetben egész tömb

            IEnumerable<int> halszámok =                            // 2. Lekérdező kifejezés megadása.
            from hal in halszám
            where hal > 4
            select hal;
            foreach (int i in halszámok)                            // 3. A lekérdezés végrehajtása. A kapott felsorolható
            {                                                       // adatsoron (IEnumerable<int>) a foreach végiglépdel.
                Console.WriteLine(i);
            }
            // Eredmény: 5, 7, 6


            // eredmény = from név in forrás
            //      [kiegészítő feltételek]
            //   select elem vagy group elem;

            // eredmény = forrás.
            //      [kiegészítő feltételek.]
            //    Select( Lambda kifejezés);

            //int[] halszám = new int[] { 4, 5, 7, 6, 3 };          // egy tömb a forrás
            // a legegyszerűbb lekérdezés, nincs feltétel, minden
            // elemet megkapunk
            //IEnumerable<int> halszámok =
            //from hal in halszám                                   // nem hagyható el lekérdezésből
            //select hal;
            // Lekérdező kifejezés megadása. Eredmény típusát 
            // konkrétan megadjuk
            IEnumerable<int> halszámok1 =
            from hal in halszám
            where hal > 4                                           // elhagyható ha nem kell feltétel
            select hal;
            // A lekérdezés végrehajtása. 
            foreach (int i in halszámok1)
            {
                Console.WriteLine(i);
            }
            // Eredmény: 5, 7, 6


            var hsz = halszám.                                      // A fenti kifejezés forma metódus (extension) hívásos
            Where(x => x > 4).                                      // alakja
            Select(x => x);                                         // Eredmény típusát ráhagyjuk a fordítóra, hadd találja ki!

            foreach (int i in hsz)
            {
                Console.WriteLine(i);
            }
        }

        private class Program2
        {
            static public List<int> adatok = new List<int>();
            static public void Generál(int méret)
            {   //adatbeolvasás helyett egy véletlenszámokat generálunk
                Random r = new Random();
                for (int i = 0; i < méret; i++)
                {
                    adatok.Add(r.Next(100));
                }
            }
            static public int Összegzés_hagyományosan()
            {
                int s = 0;
                for (int i = 0; i < adatok.Count; i++)
                    s += adatok[i];
                return s;
            }
            static public int Összegzés_LINQ()
            {
                return adatok.Sum();
            }
            static public bool Eldöntés_hagyományosan(Func<int, bool> T) //delegált használat
            {
                int i = 0;
                while (i < adatok.Count && !T(adatok[i]))
                    i++;
                return i < adatok.Count();
            }
            static public bool Eldöntés_LINQ(Func<int, bool> T)
            {
                return adatok.FindIndex(x => T(x) == true) >= 0; //-1, ha nincs
            }

            private static int Megszámolás_hagyományosan(Func<int, bool> T)
            {
                int db = 0;
                for (int i = 0; i < adatok.Count; i++)
                {
                    if (T(adatok[i])) db++;
                }
                return db;
            }

            private static int Megszámolás_LINQ(Func<int, bool> T)
            {
                return adatok.Where(x => T(x) == true).Count();
            }

            private static int Kiválasztás_hagyományosan(Func<int, bool> T)
            {
                int i = 0;
                while (!T(adatok[i]))
                    i++;
                return adatok[i];
            }

            private static int Kiválasztás_LINQ(Func<int, bool> T) //értéket adunk vissza
            {
                return adatok.Where(x => T(x) == true).First();
            }

            private static int Maximumkiválasztás_hagyományosan(Func<int, bool> T)
            {
                int maxérték = adatok[0];
                for (int i = 1; i < adatok.Count(); i++)
                {
                    if (maxérték < adatok[i]) maxérték = adatok[i];
                }
                return maxérték;
            }

            private static int Maximumkiválasztás_LINQ(Func<int, bool> T)
            {
                return adatok.Max();
            }

            private static (bool, int) Keresés_hagyományosan(Func<int, bool> T)
            {
                int i = 0;
                while (i < adatok.Count && !T(adatok[i]))
                    i++;
                return (i < adatok.Count, adatok[i]);
            }

            private static (bool, int) Keresés_LINQ(Func<int, bool> T) //tuple
            {
                return adatok.Where(x => T(x) == true).Select(x => (adatok.IndexOf(x) > -1, x)).First();
            }

            private static List<int> Kiválogatás_hagyományosan(Func<int, bool> T)
            {
                List<int> eredmény = new List<int>();
                for (int i = 0; i < adatok.Count(); i++)
                {
                    if (T(adatok[i]))
                        eredmény.Add(adatok[i]);
                }
                return eredmény;
            }

            private static void Kiírás(List<int> lista)
            {
                foreach (int elem in adatok)
                {
                    Console.Write(elem + ",");
                }
                Console.WriteLine();
            }

            private static List<int> Kiválogatás_LINQ(Func<int, bool> T)
            {
                return adatok.Where(x => T(x) == true).ToList();
            }

            private static void Main(string[] args)
            {
                Generál(10);

                Kiírás(adatok);

                Console.WriteLine("Hagyományos, Az elemek összege: {0}", Összegzés_hagyományosan());

                Console.WriteLine("LINQ-s, Az elemek összege: {0}", Összegzés_LINQ());

                if (Eldöntés_hagyományosan(x => x > 5))
                {
                    Console.WriteLine("Hagyományosan, Eldöntés:  Van");
                }
                else
                {
                    Console.WriteLine("Hagyományosan, Eldöntés: Nincs");
                }

                if (Eldöntés_LINQ(x => x > 5))
                {
                    Console.WriteLine("LINQ-val, Eldöntés:  Van");
                }
                else
                {
                    Console.WriteLine("LINQ-val, Eldöntés: Nincs");
                }

                Console.WriteLine("Hagyományos, megszámolás 5-nél nagyobb: {0}", Megszámolás_hagyományosan((x => x > 5)));
                Console.WriteLine("LINQ-s, megszámolás 5-nél nagyobb: {0}", Megszámolás_LINQ((x => x > 5)));
                Console.WriteLine("Hagyományos, kiválasztás első 5-nél nagyobb: {0}", Kiválasztás_hagyományosan((x => x > 5)));
                Console.WriteLine("LINQ-s, kiválasztás első 5-nél nagyobb: {0}", Kiválasztás_LINQ((x => x > 5)));
                Console.WriteLine("Hagyományos, maximumkiválasztás: {0}", Maximumkiválasztás_hagyományosan((x => x > 5)));
                Console.WriteLine("LINQ-s, maximumkiválasztás: {0}", Maximumkiválasztás_LINQ((x => x > 5)));

                (bool van, int elem) = Keresés_hagyományosan((x => x > 5));
                Console.Write("Hagyományosan, keresés van-e 5-nél nagyobb és melyik: ");
                if (van)
                {
                    Console.WriteLine(" Van és {0}", elem);
                }
                else
                {
                    Console.WriteLine("Nincs");
                }

                (van, elem) = Keresés_LINQ((x => x > 5));
                Console.Write("LINQ-val, keresés van-e 5-nél nagyobb és melyik: ");
                if (van)
                {
                    Console.WriteLine(" Van és {0}", elem);
                }
                else
                {
                    Console.WriteLine("Nincs");
                }

                List<int> eredmény = Kiválogatás_hagyományosan(x => x > 5);
                Console.WriteLine("Hagyományos, kiválogatás 5-nél nagyobbak: ");
                Kiírás(eredmény);
                eredmény = Kiválogatás_LINQ(x => x > 5);
                Console.WriteLine("LINQ-val, kiválogatás 5-nél nagyobbak: ");
                Kiírás(eredmény);

            }
        }

    }
}
