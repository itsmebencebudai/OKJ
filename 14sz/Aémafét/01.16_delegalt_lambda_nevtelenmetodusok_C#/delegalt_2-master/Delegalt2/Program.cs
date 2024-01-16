using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegalt2
{
    class Program
    {

        static bool Eldöntés(List<int> lista, Func<int, bool> T) //előre definiált Func, saját delegált helyett
        {
            int i = 0;
            while (i < lista.Count && !T(lista[i]))
                i++;
            return i < lista.Count;
        }
        static bool Kettővelosztható(int x)
        {
            return x % 2 == 0;
        }
        static void Main(string[] args)
        {
            List<int> lista = new List<int>() { 2, 4, 5, 10, 34, 35, 20, 25 };

            if (Eldöntés(lista, Kettővelosztható)) //hagyományos függvény
                Console.WriteLine("Van köztük kettővel osztható");
            else
                Console.WriteLine("Nincs kettővel osztható");

            if (Eldöntés(lista, delegate (int x) { return x % 3 == 0; })) //névtelen függvény
                Console.WriteLine("Van köztük hárommal osztható");
            else
                Console.WriteLine("Nincs hárommal osztható");

            if (Eldöntés(lista, x => x % 5 == 0)) //lambda kifejezés
                Console.WriteLine("Van köztük öttel osztható");
            else
                Console.WriteLine("Nincs öttel osztható");

        }
    }
}