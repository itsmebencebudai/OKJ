using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Névtelen__anonymous___metódusok
{
    class Program
    {
        public delegate int módosít(int x);
        public delegate string üdv();
        public int Dupláz(int mit)
        {
            return 2 * mit;
        }
        public void Paraméter_minta(módosít m)
        {
            Console.WriteLine("A paraméterül kapott delegált hívása!");
            Console.WriteLine(m(6));
        }

        static void Main(string[] args)
        {

            Program p = new Program();
            //Klasszikus delegált definíció
            módosít mf = new módosít(p.Dupláz);
            //
            //Névtelen metódussal inicializált delegált
            üdv d1 = delegate { return "Hajrá Fradi!"; };
            //Névtelen paraméteres metódussal inicializálva
            módosít mf1 = delegate (int x) { return x * x; };
            Console.WriteLine("Hívások eredménye {0}, {1}.", mf(5), mf1(5));
            Console.WriteLine(d1());
            p.Paraméter_minta(delegate (int x) { return 3 * x; });
            // Közvetlen, névtelen metódus a paraméter.
        }
    }
}
