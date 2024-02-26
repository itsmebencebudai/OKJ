using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Feladat1
{
    class Versenyzo
    {
        public string Csapat { get; set; }
        public string VersenyzoNeve { get; set; }
        public int Eletkor { get; set; }
        public string Palya { get; set; }
        public string Korido { get; set; }
        public int Kor { get; set; }

        public Versenyzo(string csapat, string versenyzoNeve, int eletkor, string palya, string korido, int kor)
        {
            Csapat = csapat;
            VersenyzoNeve = versenyzoNeve;
            Eletkor = eletkor;
            Palya = palya;
            Korido = korido;
            Kor = kor;
        }

        public override string ToString()
        {
            return $"Csapat: {Csapat}, Versenyző neve: {VersenyzoNeve}, Életkor: {Eletkor}, Pálya: {Palya}, Kör idő: {Korido}, Kör: {Kor}";
        }
    }

    class Program
    {
        static List<Versenyzo> versenyzok = new List<Versenyzo>();
        static Versenyzo keresettVersenyzo = null;
        public static string keresettNev = "";
        static void Main(string[] args)
        {
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Console.ReadKey();
        }

        private static void Feladat6()
        {
            if (keresettVersenyzo != null)
            {
                string leggyorsabbKorido = versenyzok
                    .Where(v => v.VersenyzoNeve == keresettNev)
                    .Min(v => v.Korido);

                string leggyorsabbPalya = versenyzok
                    .Where(v => v.VersenyzoNeve == keresettNev && v.Korido == leggyorsabbKorido)
                    .Select(v => v.Palya)
                    .FirstOrDefault();

                Console.WriteLine($"6. feladat:  {leggyorsabbPalya}, {leggyorsabbKorido}");
            }
            else
            {
                Console.WriteLine("6. feladat: Nincs ilyen versenyző az állományban!");
            }
        }

        private static void Feladat5()
        {
            Console.WriteLine("Kérem adja meg a versenyző nevét:");
            keresettNev = Console.ReadLine();
            
            foreach (var versenyzo in versenyzok)
            {
                if (versenyzo.VersenyzoNeve == keresettNev)
                {
                    keresettVersenyzo = versenyzo;
                    break;
                }
            }
        }

        private static void Feladat4()
        {
            foreach (var versenyzo in versenyzok)
            {
                if (versenyzo.VersenyzoNeve == "Fürge Ferenc" && versenyzo.Palya == "Gran Prix Circuit")
                {
                    //Console.WriteLine($"Versenyző: {versenyzo.VersenyzoNeve}");
                    //Console.WriteLine($"Pálya: {versenyzo.Palya}");
                    //Console.WriteLine($"Kör idő: {versenyzo.Korido}");
                    Console.WriteLine($"4. feladat: {KoridoMásodperc(versenyzo.Korido)} másodperc");
                    break;
                }
            }
        }
        private static int KoridoMásodperc(string korido)
        {
            string[] ido = korido.Split(':');
            int ora = Convert.ToInt32(ido[0]);
            int perc = Convert.ToInt32(ido[1]);
            int masodperc = Convert.ToInt32(ido[2]);

            return ora * 3600 + perc * 60 + masodperc;
        }

        private static void Feladat3()
        {
            Console.WriteLine("3. feladat: " + versenyzok.Count);
        }
        private static void Feladat2()
        {

            string filePath = "autoverseny.csv";

            StreamReader reader = null;

            try
            {
                reader = new StreamReader(filePath);

                string line;

                // elso sor
                line = reader.ReadLine();

                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(';');

                    if (fields.Length == 6)
                    {
                        string csapat = fields[0];
                        string versenyzoNeve = fields[1];
                        int eletkor = Convert.ToInt32(fields[2]);
                        string palya = fields[3];
                        string korido = fields[4];
                        int kor = Convert.ToInt32(fields[5]);

                        Versenyzo versenyzo = new Versenyzo(csapat, versenyzoNeve, eletkor, palya, korido, kor);
                        versenyzok.Add(versenyzo);
                    }
                    else
                    {
                        Console.WriteLine("Hibás formátum a fájlban.");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("A fájl nem található: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt: " + ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            //foreach (var versenyzo in versenyzok)
            //{
            //    Console.WriteLine(versenyzo);
            //}
        }
    }
}
