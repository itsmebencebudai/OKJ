using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Delegált_függvények
{
    internal class proba
    {
        public static int negyzet(int i)
        {
            return i * i;
        }
        public int dupla(int i)
        {
            return 2 * i;
        }
        public int tripla(int i)
        {
            return 3 * i;
        }
        public void egy(int i)
        {
            Console.WriteLine(i);
        }
        public void ketto(int i)
        {
            Console.WriteLine(2 * i);
        }
        public double maximum(double x, double y)
        {
            if (x > y)
                return x;
            else
                return y;
        }
    }

    internal class Program
    {
        private delegate int emel(int k);                                   // az emel delegált definiálása

        private delegate void meghiv(int j);

        private delegate double vmut(double b, double n);                   // vmut olyan delegált amelyik egy valós értéket visszaadó, 
                                                                            // és két valós paramétert váró függvényt jelent

        private delegate int emut(int i, int j);                            // emut olyan delegált, amelyik egy egész értéket visszaadó 
                                                                            // , és két egész paramétert váró függvényt jelent

        private static void Main(string[] args)
        {
            emel f = new emel(proba.negyzet);                               // statikus függvény lesz a delegált
            Console.WriteLine(f(5));
            proba p = new proba();
            emel g = new emel(p.dupla);                                     // normál példafüggvény lesz  delegált
            Console.WriteLine(g(5));
            emel h = new emel(p.tripla);
            g += h;                                                         // g single cast, g a tripla lesz
            Console.WriteLine(g(5));                                        // eredmény: 15
            meghiv m = new meghiv(p.egy);                                   // multicast delegált
            m += new meghiv(p.ketto);
            m(5);                                                           // delegált hívás, eredmény 5,10
            vmut mut = new vmut(p.maximum);                                 // valós hívás
            Console.WriteLine(mut(3, 5));
        }


    }
}
