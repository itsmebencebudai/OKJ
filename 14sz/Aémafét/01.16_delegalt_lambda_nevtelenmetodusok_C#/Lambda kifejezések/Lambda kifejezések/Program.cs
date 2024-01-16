using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_kifejezések
{
    internal class Program
    {
        public delegate T Func<T>();                                                                            // paraméter nélküli delegált
        public delegate T Func<P1, T>(P1 p1);                                                                   // 1 paraméteres delegált
        public delegate T Func<P1, P2, T>(P1 p1, P2 p2);                                                        // 2 paraméteres delegált
        public delegate T Func<P1, P2, P3, T>(P1 p1, P2 p2, P3 p3);                                             // 3 paraméteres delegált
        public delegate T Func<P1, P2, P3, P4, T>(P1 p1, P2 p2, P3 p3, P4 p4);                                  // 4 paraméteres delegált
        public delegate T Almafa<T, P, P1>(P p, P1 p1);                                                         // Két paraméteres delegált (P, P1), T az eredmény típusa 
                                                                                                                // delegált nem lehet függvényen belül!!!
        private static void Main(string[] args)
        {
            /*   
                                                                // Konkrétan megadott típusok a baloldalon,
                                                                // teljes blokk a jobbon!

            (int x) => { return x * x; }                        // egy paraméteres kifejezés

            (int a, int b) => { return a + b; }                 // két paraméteres kifejezés

                                                                // Implicit típusok a baloldalon, a fordító kitalálja a konkrét 
                                                                // használati típusokból a és b típusát.
                                                                // Ha a jobboldali kifejezés egyszerű, akkor elhagyható a return
                                                                // és a {} blokkhatárolók is.

            (a, b) => a + b                                     // ugyanaz mint az első példa
            x => db += x                                        // egy paraméternél elhagyható a baloldalról 
                                                                // a zárójel

            () => db + 1                                        // paraméter nélküli kifejezés

            */

            // „Gyári” 1 paraméteres delegált használat
            int i;
            Func<int, int> f1 = (x) => {
                return x * x;
            };
            i = f1(3); // 9  

            Almafa<int, string, bool> fa = (x, y) => {
                if (y) return x.Length;
                else return 0;
            };

            int starking = fa("starking", true);
            Console.WriteLine(starking);
        }
    }
}
