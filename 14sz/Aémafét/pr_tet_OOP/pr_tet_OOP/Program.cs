using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pr_tet_OOP
{
    class Program
    {

        
        public static int[] l = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 34, -52, 56, };
        public static int[] t = {10, 15, -19, 34, -52, 56, 9, -7, 31, -14, -93, 12, 16, 17, 18, 19, };
        public static int[] k = {10, 15, 19, 34, 52};


        static void Main(string[] args)
        {
            //txtfile();
            menu();

            /*
            feladat1();
            Console.WriteLine();
            feladat2();
            Console.WriteLine();
            feladat3();
            Console.WriteLine();
            feladat4();
            Console.WriteLine();
            feladat5();
            Console.WriteLine();
            //feladat6();
            Console.WriteLine();
            feladat7();
            Console.WriteLine();
            feladat8();
            Console.WriteLine();
            feladat12();
            Console.WriteLine();
            feladat9();
            Console.WriteLine();
            feladat10();
            Console.WriteLine();
            feladat11();
            visszamenu();
            menu();
            txtfile();*/

            Console.ReadKey();
        }

        /*public static Txtfile()
        {
            StreamWriter sw = new StreamWriter("input.txt");
            Random rd = new Random();
            for (int i = 0; i < 12; i++)
            {
                int number = rd.Next(1, 99);
                sw.WriteLine($"{number},{number},{number},{number},{number},{number},{number}");
            }
            Console.WriteLine("A file létre lett hozva");
            
        }*/

        public static StreamReader sr = new StreamReader("input.txt");
        public static List<int> szamok = new List<int>();
        public static void beolv()
        {
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var values = line.Split(',');
                szamok.Add(Convert.ToInt32(values));
            }
        }
        public static void menu()
        {
            //Console.WriteLine("0.) File generálása");
            Console.WriteLine("1.) Összegzés");
            Console.WriteLine("2.) Megszámolás");
            Console.WriteLine("3.) Eldöntés");
            Console.WriteLine("4.) Kiválasztás");
            Console.WriteLine("5.) Keresés");
            Console.WriteLine("6.) Másolás");
            Console.WriteLine("8.) Szétválogatás");
            Console.WriteLine("9.) Unió");
            Console.WriteLine("10.) Maximum kiválasztás");
            Console.WriteLine("11.) Minimum kiválasztás");
            Console.WriteLine("12.) Metszet");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Válasszon számot: ");
            double szam = double.Parse(Console.ReadLine());

            switch (szam.ToString())
            {
                case "0":
                    Console.Clear();
                    txtfile();
                    break;
                case "1":
                    Console.Clear();
                    feladat1();
                    break;
                case "2":
                    Console.Clear();
                    feladat2();
                    break;
                case "3":
                    Console.Clear();
                    feladat3();
                    break;
                case "4":
                    Console.Clear();
                    feladat4();
                    break;
                case "5":
                    Console.Clear();
                    feladat5();
                    break;
                case "6":
                    Console.Clear();
                    feladat6();
                    break;
                case "7":
                    Console.Clear();
                    feladat7();
                    break;
                case "8":
                    Console.Clear();
                    feladat8();
                    break;
                case "9":
                    Console.Clear();
                    feladat9();
                    break;
                case "10":
                    Console.Clear();
                    feladat10();
                    break;
                case "11":
                    Console.Clear();
                    feladat11();
                    break;
                case "12":
                    Console.Clear();
                    feladat12();
                    break;
                default:
                    break;
            }
        }

        private static void visszamenu()
        {
            
            Console.WriteLine();
            Console.Write("Visszakar menni a menübe? (i / n ): ");
            string menube = Console.ReadLine();
            switch (menube)
            {
                case "i":
                    Console.Clear();
                    menu();
                    break;
                case "n":
                    Environment.Exit(1);
                    break;
                default:
                    break;
            }
        }

        private static void feladat11()
        {
            //min
            Console.WriteLine(11);
            int n = t.Length;  //Az t a tömb mérete
            int min;

            min = t[0];
            for (int i = 1; i < n; i++)
                if (t[i] < min)
                    min = t[i];

            Console.WriteLine($"A legkisebb elem: {min}");
            Console.WriteLine();
            Console.WriteLine();
            visszamenu();
            
        }

        private static void feladat10()
        {
            //max
            Console.WriteLine(10);
            int n = t.Length;  //Az t a tömb mérete
            int max;

            max = t[0];
            for (int i = 0; i < n; i++)
                if (t[i] > max)
                    max = t[i];

            Console.WriteLine($"A legnagyobb elem: {max}");
            Console.WriteLine();
            Console.WriteLine();
            visszamenu();
        }

        private static void feladat9()
        {
            //unió
            Console.WriteLine(9);
            Console.WriteLine("Unió tétel");
            int[] c = new int[100];

            int i, j, k;
            int n = t.Length, m = l.Length;

            for (i = 0; i < n; i++)
                c[i] = t[i];
            k = n;
            for (j = 0; j < m; j++)
            {
                i = 0;
                while (i < n && l[j] != t[i])
                    i++;
                if (i >= n)
                {
                    c[k] = l[j];
                    k++;    
                }
            }


            //Az t tömb kiíratása
            Console.WriteLine("t tömb");
            for (i = 0; i < n; i++)
                Console.Write(t[i] + " ");
            Console.WriteLine();

            //A l tömb kiíratása
            Console.WriteLine("l tömb");
            for (i = 0; i < m; i++)
                Console.Write(l[i] + " ");
            Console.WriteLine();

            //Az uniós eredménytömb kiíratása
            Console.WriteLine("únió");
            for (i = 0; i < k; i++)
                Console.Write(c[i] + " ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            visszamenu();
        }

        private static void feladat12()
        {
            //metszet
            Console.WriteLine(8.2);
            int[] c = new int[10];
            int n = 5, m = 6, o; //Tömbök mérete
            int i, j, k; //Ciklusváltozók, illetve tömbindexek

            k = 0;
            for (i = 0; i < n; i++)
            {
                j = 0;
                while (j < m && l[j] != t[i])
                    j++;
                if (j < m)
                {
                    c[k] = t[i];
                    k++;
                }
            }

            o = k; //c tömb mérete

            //kiiratás
            for (i = 0; i < n; i++)
                Console.Write(t[i] + " ");
            Console.WriteLine();
            for (j = 0; j < m; j++)
                Console.Write(l[j] + " ");
            Console.WriteLine();
            for (k = 0; k < o; k++)
                Console.Write(c[k] + " ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            visszamenu();

        }
        private static void feladat8()
        {
            //kiválotgatás
            Console.WriteLine(8.1);
            int n = l.Length;
            int[] b = new int[n];
            int[] c = new int[n];

            int j = 0;
            int k = 0;
            for (int i = 0; i < n; i++)
                if (l[i] < 16)  
                {
                    b[j] = l[i];
                    j++;
                }
                else
                {
                    c[k] = l[i];
                    k++;
                }

            //kiiratás
            Console.WriteLine("Volt:");
            for (int i = 0; i < n; i++)
                Console.Write("{0} ", l[i]);
            Console.WriteLine();

            Console.WriteLine("16-nál kisebb:");
            for (int i = 0; i < j; i++)
                Console.Write(" {0} ", b[i]);
            Console.WriteLine();

            Console.WriteLine("16-nál nagyobb:");
            for (int i = 0; i < k; i++)
                Console.Write(" {0} ", c[i]);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            visszamenu();
        }

        private static void feladat7()
        {
            //feltételes másolás
            Console.WriteLine(7);
            Console.WriteLine("Másolja át (false/true)?");
            bool másol = bool.Parse(Console.ReadLine());
            //Console.WriteLine("Teszt: "+másol);
            int[] x = new int[100];
            int i, j, y;
            int n = t.Length, m = k.Length;
            for (i = 0; i < n; i++)
                x[i] = t[i];
            y = n;
            if (másol.Equals(true))
            {
                for (j = 0; j < m; j++)
                {
                    i = 0;
                    while (i < n && l[j] != t[i])
                        i++;
                    if (i >= n)
                    {
                        x[y] = l[j];
                        y++;
                    }
                }
                // kiiratás
                Console.Write("C tömb : ");
                for (i = 0; i < y; i++)
                    Console.Write(x[i] + " ");
            }else
                //ha nem
                Console.WriteLine("Nem másolta át");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            visszamenu();
        }

        private static void feladat6()
        {
            
            Console.WriteLine(6);
            //másolás
            var c = k.Concat(l);

            //  Tömbök kiíratása
            Console.WriteLine("A másolt tömb tartalma");
            foreach (var item in c)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            visszamenu();

        }

        private static void feladat5()
        {
            //l listában hanyadik helyen van
            Console.WriteLine(5);

            Console.Write("Kérem a számot:");
            int kert = int.Parse(Console.ReadLine());
            int n = t.Length;
            int i = 0;
            while (i < n && t[i] != kert)
                i++;

            if (i < n)
                Console.WriteLine("Indexe: {0}", i);
            else
                Console.WriteLine("Nincs benne");
            Console.WriteLine();
            Console.WriteLine();
            visszamenu();
        }

        private static void feladat4()
        {
            // keresett érték
            Console.WriteLine(4);
            int n = t.Length;
            int ker = 56; 

            int i = 0;
            while (t[i] != ker)
                i++;

            Console.WriteLine($"Az 56-os indexe: {i}");
            Console.WriteLine();
            Console.WriteLine();
            visszamenu();
        }

        private static void feladat3()
        {
            //k listában megtalálható-e
            Console.WriteLine(3);

            Console.Write("Kérem a számot:");
            int kert = int.Parse(Console.ReadLine());
            bool van = false;
            foreach (var item in k)
            {
                if (item.Equals(kert))
                {
                    van = true;
                }
                break;

            }
            if (van)
            {
                Console.WriteLine($"Van ilyen szám! {kert}");
            }else
                Console.WriteLine("Nincsen ilyen szám!");
            Console.WriteLine();
            Console.WriteLine();
            visszamenu();

        }

        private static void feladat2()
        {
            //t listában a negatív számok
            Console.WriteLine(2);
            int neg = 0;
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] < 0)
                {
                    neg++;
                }
            }
            Console.WriteLine($"Negatív számok {neg}");
            Console.WriteLine();
            Console.WriteLine();
            visszamenu();
        }

        private static void feladat1()
        {
            // l lista összege
            Console.WriteLine(1);
            int oszeg = 0;
            for (int i = 0; i < l.Length; i++)
            {
                oszeg += l[i];
            }
            Console.WriteLine($"Az l lista összege: {oszeg}");
            Console.WriteLine();
            Console.WriteLine();
            visszamenu();
        }
    }
}

