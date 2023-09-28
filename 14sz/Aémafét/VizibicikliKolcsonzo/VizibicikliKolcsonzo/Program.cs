using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VizibicikliKolcsonzo
{
    class Program
    {
        // 2. feladat
        class Kolcsonzes
        {
            public string Nev;
            public string JAzon;
            public int EÓra;
            public int Eperc;
            public int Vóra;
            public int Vperc;

            public Kolcsonzes(string sor)
            {
                string[] k = sor.Split(';');
                Nev = k[0];
                JAzon = k[1];
                EÓra = Convert.ToInt32(k[2]);
                Eperc = Convert.ToInt32(k[3]);
                Vóra = Convert.ToInt32(k[4]);
                Vperc = Convert.ToInt32(k[5]);
            }
        }
        static void Main(string[] args)
        {
            // 3. feladat
            List<Kolcsonzes> kolcsonzes = new List<Kolcsonzes>();
            //4. feladat
            foreach (var item in File.ReadAllLines("kolcsonzesek.txt").Skip(1))
            {
                kolcsonzes.Add(new Kolcsonzes(item));
            }
            // 5. feladat
            Console.WriteLine($"5. feladat: Napi kölcsönzések száma: {kolcsonzes.Count}");
            // 6. feladat
            Console.Write($"6. feladat: Kérek egy nevet: ");
            string kertnev = Console.ReadLine();
            bool talal = false;
            Console.WriteLine($"\t\t{kertnev} kölcsönzései:");
            foreach (var item in kolcsonzes)
            {
                if (kertnev == item.Nev)
                {
                    Console.WriteLine($"\t\t{item.EÓra}:{item.Eperc}-{item.Vóra}:{item.Vperc}");
                    talal = true;
                }
            }
            if(!talal)
            {
                Console.WriteLine("Nem volt ilyen nevű kölcsönző!");
            }
            
            // 7. feladat
            Console.Write($"7. feladat:  Adjon meg egy időpontot óra:perc alakban: ");
            string idopont = Console.ReadLine();
            byte óra = byte.Parse(idopont.Split(':')[0]);
            byte perc = byte.Parse(idopont.Split(':')[1]);
            //TimeSpan ts = new TimeSpan();
            TimeSpan Idopont = new TimeSpan(óra, perc, 0);
            Console.WriteLine("\tA vízen lévő járművek: ");
            foreach (var item in kolcsonzes)
            {
                TimeSpan el = new TimeSpan(item.EÓra, item.Eperc, 0);
                TimeSpan vi = new TimeSpan(item.Vóra, item.Vperc, 0);
                if (((el.Hours <= Idopont.Hours) && (el.Minutes <= Idopont.Minutes)) && vi.Hours >= Idopont.Hours) /*&& (vi.Minutes >= Idopont.Minutes)*/
                {
                    Console.WriteLine($"\t{el.Hours}:{el.Minutes}-{vi.Hours}:{vi.Minutes} : {item.Nev}");
                }

                /*if (((el.Hours <= Idopont.Hours) && (el.Minutes <= Idopont.Minutes)) && vi.Hours >= Idopont.Hours)      //Módisítani kell
                    Console.WriteLine($"\t{el.Hours}:{el.Minutes}-{vi.Hours}:{vi.Minutes} : {item.Nev}");*/
            }
            // ha nincsen / rossz időpont
            if(perc < 0 || perc > 59)
            {
                Console.WriteLine("\tNem volt megfelelő az időpont (perc)!");
            }
            if(óra < 0 ||óra > 24){
                Console.WriteLine("\tNem volt megfelelő az időpont (óra)!");
            }


            // 8 .feladat
            int díj = 2400;
            double oszperc = 0;
            foreach (var item in kolcsonzes)
            {
                TimeSpan el = new TimeSpan(item.EÓra, item.Eperc, 0);
                TimeSpan vi = new TimeSpan(item.Vóra, item.Vperc, 0);

                oszperc += ((vi - el).Minutes);

            }
            oszperc = oszperc / 30;
            double osszbev = oszperc * díj;
            Console.WriteLine($"8. feladat: A napi betétel: {osszbev} ft");

            // 9. feladat
            StreamWriter streamWriter = new StreamWriter("F.txt");
            foreach (var item in kolcsonzes)
            {
                if (item.JAzon.Equals("F"))
                {
                    streamWriter.WriteLine(item.EÓra + ":" + item.Eperc + "-" + item.Vóra+":" + item.Vperc+ " : "+item.Nev);
                }
            }
            streamWriter.Close();

            // 10. feladat
            Console.WriteLine("10. feladat: Statisztika");
            int a = 0, b=0, c=0, d=0, e=0, f=0, g=0;
            foreach (var item in kolcsonzes)
            {
                switch (item.JAzon)
                {
                    case "A":
                        a++;
                        break;

                    case "B":
                        b++;
                        break;

                    case "C":
                        c++;
                        break;

                    case "D":
                        d++;
                        break;

                    case "E":
                        e++;
                        break;

                    case "F":
                        f++;
                        break;

                    case "G":
                        g++;
                        break;

                    default:
                        break;
                }

            }

            Console.WriteLine($"\t\tA - {a}");
            Console.WriteLine($"\t\tB - {b}");
            Console.WriteLine($"\t\tC - {c}");
            Console.WriteLine($"\t\tD - {d}");
            Console.WriteLine($"\t\tE - {e}");
            Console.WriteLine($"\t\tF - {f}");
            Console.WriteLine($"\t\tG - {g}");

            Console.ReadKey();
        }
    }
}
