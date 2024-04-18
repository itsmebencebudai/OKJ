using System;
using System.Collections.Generic;
using System.IO;

namespace biobolt
{
    internal class Program
    {

        class Feladatok
        {
            public int Darab { get; set; }
            public string Név { get; set; }
            public int Összeg { get; set; }

            public static List<Feladatok> Beolvasas(string FileName)
            {
                using (var reader = new StreamReader(FileName))
                {
                    List<Feladatok> list = new List<Feladatok>();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        Feladatok feladatok = new Feladatok();

                        feladatok.Darab = int.Parse(values[0]);
                        feladatok.Név = values[1].ToString();
                        feladatok.Összeg = int.Parse(values[2]);

                        list.Add(feladatok);
                    }

                    return list;
                }
            }
        }


        static void Main(string[] args)
        {

            Console.WriteLine("1.) feladat:");
            Termekek_Szama();
            Legtobb_termek();
            Termek_Osszerteke();
            Console.ReadKey();
        }
        public static void Termekek_Szama()
        {
            var darabtermek = 0;
            List<Feladatok> feladatok = Feladatok.Beolvasas("magvak.txt");
            foreach (var item in feladatok)
            {
                darabtermek++;
            }
            Console.WriteLine("A boltban: " + darabtermek + " féle termék van.");
        }

        public static void Legtobb_termek()
        {
            var maxsuj = 0;
            string teremkneve = null;
            List<Feladatok> feladatok = Feladatok.Beolvasas("magvak.txt");
            foreach (var item in feladatok)
            {
                if (item.Darab >= maxsuj)
                {
                    maxsuj = item.Darab;
                    teremkneve = item.Név;
                }
            }
            Console.WriteLine("A legtöbb termék: " + maxsuj + " kb " + teremkneve);
        }

        public static void Termek_Osszerteke()
        {
            var osszertek = 0;
            List<Feladatok> feladatok = Feladatok.Beolvasas("magvak.txt");
            foreach (var item in feladatok)
            {
                osszertek += (item.Darab * item.Összeg);
            }
            Console.WriteLine("A termékek összértéke: " + osszertek + " Ft");
        }

    }
}
