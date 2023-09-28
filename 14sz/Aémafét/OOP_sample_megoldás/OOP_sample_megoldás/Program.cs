using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Collections;


namespace OOP_sample_megoldás
{
    class Task
    {
        List<string> Data = new List<string>();

        public void Read_In(string path)
        {
            StreamReader reader = new StreamReader(File.OpenRead(path));

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                for (int i = 0; i < values.Length; i++)
                {
                    Data.Add(values[i]);
                }
            }
        }
        List<string> Data2 = new List<string>();
        public void Read_In2(string path)
        {
            StreamReader reader2 = new StreamReader(File.OpenRead(path));

            while (!reader2.EndOfStream)
            {
                var line = reader2.ReadLine();
                var values = line.Split(',');

                for (int i = 0; i < values.Length; i++)
                {
                    Data2.Add(values[i]);
                }
            }
        }

        public void Summary()
        {
            readin();

            List<int> data_int = new List<int>();
            int sum = 0;
            for (int i = 0; i < Data.Count; i++)
            {
                data_int.Add(Convert.ToInt32(Data[i]));
                sum = sum + data_int[i];
            }
            Console.WriteLine();
            Console.WriteLine("Total: " + sum);
        }

        public void Menu()
        {
            bool exit = false;
            int error = 0;
            int maxerror = 3;

            string[] data = new string[1000];
            do
            {
                Console.WriteLine();
                Console.WriteLine("Válassz az alábbi lehetőségek közül:");
                Console.WriteLine("1. Összegzés tétel");
                Console.WriteLine("2. Megszámlálás tétel");
                Console.WriteLine("3. Eldöntés tétel");
                Console.WriteLine("4. Kiválasztás tétel");
                Console.WriteLine("5. Keresés tétel");
                Console.WriteLine("6. Másolás tétel");
                Console.WriteLine("7. Kiválogatás tétel");
                Console.WriteLine("8. Szétválogatás tétel");
                Console.WriteLine("9. Metszet tétel");
                Console.WriteLine("10. Min tétel");
                Console.WriteLine("11. Max tétel");
                Console.WriteLine("12. Kilépés");
                Console.WriteLine();
                Console.Write("Válasszon menupontot: ");

                int choice;

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Summary();
                            break;
                        case 2:
                            Megszamalalas();
                            break;
                        case 3:
                            Eldontes();
                            break;
                        case 4:
                            Kivalasztas();
                            break;
                        case 5:
                            Kereses();
                            break;
                        case 6:
                            Masolas();
                            break;
                        case 7:
                            Kivalogatas();
                            break;
                        case 8:
                            Szetvalogatas();
                            break;
                        case 9:
                            Metszet();
                            break;
                        case 10:
                            Min();
                            break;
                        case 11:
                            MAx();
                            break;
                        case 12:
                            Environment.Exit(1);
                            //exit = true;
                            break;

                        default:
                            Console.WriteLine("Hibás választás! Kérlek válassz újra.");
                            error++;

                            if (error >= maxerror)
                            {
                                exit = true;
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Hibás választás! Kérlek válassz újra.");
                    error++;

                    if (error >= maxerror)
                    {
                        exit = true;
                    }
                }

            } while (!exit);
        }

        private void MAx()
        {
            readin();
            var tomb = Data.Select(s => int.Parse(s)).ToList();
            int[] tombint = tomb.ToArray();
            int n = tombint.Length;
            int min;

            min = tombint[0];
            for (int i = 0; i < n; i++)
                if (tombint[i] < min)
                    min = tombint[i];

            Console.WriteLine($"A legkisebb elem: {min}");
            Console.WriteLine();
        }

        private void Min()
        {
            readin();
            var tomb = Data.Select(s => int.Parse(s)).ToList();
            int[] tombint = tomb.ToArray();
            int n = tombint.Length;
            int max;

            max = tombint[0];
            for (int i = 0; i < n; i++)
                if (tombint[i] > max)
                    max = tombint[i];

            Console.WriteLine($"A legnagyobb elem: {max}");
            Console.WriteLine();

        }

        private void Metszet()
        {
            readin();
            readin2();
            var tomb = Data.Select(s => int.Parse(s)).ToList();
            int[] tombint = tomb.ToArray();
            var tomb2 = Data2.Select(s => int.Parse(s)).ToList();
            int[] tombint2 = tomb2.ToArray();

            int[] a = new int[tombint.Length];
            tombint.CopyTo(a, 0);
            int[] b = new int[tombint2.Length];
            tombint2.CopyTo(b, 0);
            int[] c = new int[a.Length+b.Length];
            int n = a.Length, m = b.Length, o; //Tömbök mérete
            int i, j, k; //Ciklusváltozók, illetve tömbindexek
            k = 0;
            for (i = 0; i < n; i++)
            {
                j = 0;
                while (j < m && b[j] != a[i])
                    j++;
                if (j < m)
                {
                    c[k] = a[i];
                    k++;
                }
            }
            o = k; //Harmadik azaz a "c" tömb mérete
            /* Tömbök kiíratása */
            Console.WriteLine("A tomb: ");
            for (i = 0; i < n; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();
            Console.WriteLine("B tomb: ");
            for (j = 0; j < m; j++)
                Console.Write(b[j] + " ");
            Console.WriteLine();
            Console.WriteLine("C tomb: ");
            for (k = 0; k < o; k++)
                Console.Write(c[k] + " ");
            Console.WriteLine();

        }

        private void readin2()
        {
            Read_In2("input2.txt");
        }

        private void Szetvalogatas()
        {
            readin();
            var tomb = Data.Select(s => int.Parse(s)).ToList();
            int[] tombint = tomb.ToArray();
            int n = tombint.Length;
            int[] b = new int[n];
            int[] c = new int[n];

            int j = 0;
            for (int i = 0; i < n; i++)
                if (tombint[i] < 10)
                {
                    b[j] = tombint[i];
                    j++;
                }
            //kiiratás
            Console.WriteLine("10-nál kisebb:");
            for (int i = 0; i < j; i++)
                Console.Write("{0} ", b[i]);
            Console.WriteLine();
        }

        private void Kivalogatas()
        {
            readin();
            var tomb = Data.Select(s => int.Parse(s)).ToList();
            int[] tombint = tomb.ToArray();
            int n = tombint.Length;
            int[] b = new int[n];
            int[] c = new int[n];

            int j = 0;
            int k = 0;
            for (int i = 0; i < n; i++)
                if (tombint[i] < 16)
                {
                    b[j] = tombint[i];
                    j++;
                }
                else
                {
                    c[k] = tombint[i];
                    k++;
                }

            //kiiratás
            Console.WriteLine("Volt:");
            for (int i = 0; i < n; i++)
                Console.Write("{0} ", tombint[i]);
            Console.WriteLine();

            Console.WriteLine("16-nál kisebb:");
            for (int i = 0; i < j; i++)
                Console.Write("{0} ", b[i]);
            Console.WriteLine();

            Console.WriteLine("16-nál nagyobb:");
            for (int i = 0; i < k; i++)
                Console.Write("{0} ", c[i]);
            Console.WriteLine();
        }

        private void Masolas()
        {
            readin();
            var tomb = Data.Select(s => int.Parse(s)).ToList();
            int[] tombint = tomb.ToArray();
            Console.Write($"A tomb: ");
            for (int i = 0; i < tombint.Length; i++)
            {
                Console.Write(tombint[i]+" ");
            }
            int[] b = new int[30];
            tombint.CopyTo(b, 0);
            Console.WriteLine();
            Console.WriteLine($"B tomb: ");
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write(b[i] + " ");
            }
        }

        private void Kereses()
        {
            readin();
            Console.Write("Kérem a számot:");
            int kert = int.Parse(Console.ReadLine());
            var tomb = Data.Select(s => int.Parse(s)).ToList();
            int[] tombint = tomb.ToArray();
            int n = tombint.Length;
            int i = 0;
            while (i < n && tombint[i] != kert)
                i++;

            if (i < n)
                Console.WriteLine("Indexe: {0}", i);
            else
                Console.WriteLine("Nincs benne");
            Console.WriteLine();
        }

        private void Kivalasztas()
        {
            readin();

            var tomb = Data.Select(s => int.Parse(s)).ToList();

            int[] tombint = tomb.ToArray();

            int n = tombint.Length;
            int ker = 5;

            int i = 0;
            while (tombint[i] != ker) 
                i++;
            
            Console.WriteLine($"Az 5-ös indexe: {i}");
            Console.WriteLine();

        }

        public void readin()
        {
            Read_In("input1.txt");
        }

        private void Eldontes()
        {
            readin();
            Console.WriteLine();
            Console.Write("Kérek egy értéket: ");
            var ker = Console.ReadLine();
            bool van = false;
            foreach (var item in Data)
            {
                if (ker == item)
                {
                    Console.WriteLine("Van benne ilyen érték: "+ker);
                    van = true;
                    break;
                }
            }
            if (van)
            {
                Console.WriteLine("Nincsen benne ilyen érték : "+ker);
            }
            Console.WriteLine();


        }

        private void Megszamalalas()
        {
            readin();
            Console.WriteLine();
            Console.WriteLine($"Megszámlálás: {Data.Count()}");
        }
    }
        

    internal class Program
    {
        static void Main(string[] args)
        {
            Task Task_call = new Task();
            Task_call.Menu();

            Console.ReadLine();
        }
    }
}
