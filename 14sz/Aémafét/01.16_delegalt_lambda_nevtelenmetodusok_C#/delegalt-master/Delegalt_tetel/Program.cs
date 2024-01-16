using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegalt_tetel
{
    internal class Program
    {
        private delegate bool Ttul(int x);

        private static int Megszamol(List<int> lista, Ttul T)
        {
            int db = 0;
            foreach (int elem in lista)
                if (T(elem)) db++;
            return db;
        }

        private static bool Kettoveloszthato(int x)
        {
            return x % 2 == 0;
        }

        private static bool Otteloszthato(int x)
        {
            return x % 5 == 0;
        }

        private static bool Harommaloszthato(int x)
        {
            return x % 3 == 0;
        }

        private static bool Eldontes(List<int> lista, Func<int, bool> T)
        //előre definiált Func, saját delegált helyett
        {
            int i = 0;
            while (i < lista.Count && !T(lista[i]))
                i++;
            return i < lista.Count;
        }

        private static void Main(string[] args)
        {
            List<int> lista = new List<int>() { 2, 4, 5, 10, 34, 35, 20, 25 };
            Console.WriteLine("5-tel oszthatóak száma: {0}", Megszamol(lista, Otteloszthato));
            Console.WriteLine("2-vel oszthatóak száma: {0}", Megszamol(lista, Kettoveloszthato));
            Console.WriteLine("3-mal oszthatóak száma: {0}", Megszamol(lista, Harommaloszthato));

            if (Eldontes(lista, Kettoveloszthato)) //hagyományos függvény
                Console.WriteLine("Van köztük kettővel osztható");
            else
                Console.WriteLine("Nincs kettővel osztható");


            if (Eldontes(lista, delegate (int x) { return x % 3 == 0; }))
                //névtelen függvény
                Console.WriteLine("Van köztük hárommal osztható");
            else
                Console.WriteLine("Nincs hárommal osztható");

            if (Eldontes(lista, x => x % 5 == 0)) //lambda kifejezés
                Console.WriteLine("Van köztük öttel osztható");
            else
                Console.WriteLine("Nincs öttel osztható");
        }
    }
}

