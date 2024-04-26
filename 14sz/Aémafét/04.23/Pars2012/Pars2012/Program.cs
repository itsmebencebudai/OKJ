using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static Pars2012.Program;

namespace Pars2012
{
    internal class Program
    {
        public class Versenyzok
        {
            public string Név { get; set; }
            public char Csoport { get; set; }
            public string NemzetEsKod { get; set; }
            public string Sorozat { get; set; }
            public double[] Dobasok { get; private set; }

            public Versenyzok(string line)
            {
                string[] strings = line.Split(';');

                Név = strings[0];
                Csoport = char.Parse(strings[1]);
                NemzetEsKod = strings[2];
                Sorozat = $"{strings[3]}; {strings[4]}; {strings[5]}";
                Dobasok = new double[3];
                for (int i = 0; i < Dobasok.Length; i++)
                {
                    if (strings[i + 3] == "X")
                        Dobasok[i] = -1.0;
                    else if (strings[i + 3] == "-")
                        Dobasok[i] = -2.0;
                    else
                        Dobasok[i] = Convert.ToDouble(strings[i + 3]);
                }
            }

            public double Eredmeny
            {
                get
                {
                    double maximum = Dobasok[0];
                    foreach (var i in Dobasok.Skip(1))
                        if (i > maximum)
                            maximum = i;
                    return maximum;
                }
            }

            public string Nemzet
            {
                get
                {
                    string[] splited = NemzetEsKod.Split(' ');
                    return String.Join(" ", splited.Take(splited.Length - 1));
                }
            }

            public string Kod
            {
                get
                {
                    string[] splited = NemzetEsKod.Split(' ');
                    string kod = splited.Last().Replace("(", "").Replace(")", "");
                    return kod;
                }
            }

        }
        public static List<Versenyzok> versenyzok = new List<Versenyzok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("Selejtezo2012.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                versenyzok.Add(new Versenyzok(line));
            }
            feladat5();
            feladat6();
            feladat9();
            feladat10();
            Console.ReadKey();
        }

        private static void feladat10()
        {
            List<string> ListOut = new List<string>();
            ListOut.Add($"Helyezés;Név;Csoport;Nemzet;NemzetKód;Sorozat;Eredmény");

            for (int i = 1; i <= 12; i++)
            {
                Versenyzok legjobb = versenyzok.OrderByDescending(v => v.Eredmeny).First();
                ListOut.Add($"{i};{legjobb.Név};{legjobb.Csoport};{legjobb.Nemzet};{legjobb.Kod};{legjobb.Sorozat};{legjobb.Eredmeny}");
                versenyzok.Remove(legjobb);
            }
            File.WriteAllLines("Dontos2012.txt", ListOut, Encoding.UTF8);
        }

        private static void feladat9()
        {
            Versenyzok winner = versenyzok.First();
            foreach (var item in versenyzok.Skip(1))
                if (item.Eredmeny > winner.Eredmeny) winner = item;
            Console.WriteLine($"\tNév: {winner.Név}");
            Console.WriteLine($"\tCsoport: {winner.Csoport}");
            Console.WriteLine($"\tNemzet: {winner.Nemzet}");
            Console.WriteLine($"\tNemzet kód: {winner.Kod}");
            Console.WriteLine($"\tSorozat: {winner.Sorozat}");
            Console.WriteLine($"\tEredmény: {winner.Eredmeny}");
        }

        private static void feladat6()
        {
            var tovabbjutottak = versenyzok.Where(versenyzo => versenyzo.Dobasok.Any(dobas => dobas > 78.00)).ToList();
            Console.WriteLine($"6. feladat: 78,00 méter feletti eredménnyel továbbjutott: {tovabbjutottak.Count} fő");
        }

        private static void feladat5()
        {
            Console.WriteLine($"5. feladat: Versenyzok szama a selejtezoben: {versenyzok.Count()} fo");
        }
    }
}
