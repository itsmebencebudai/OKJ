/*
 Feladat: Adott egy „n” elem: „s” sorozat, és a sorozat elemein értelmezett „T” tulajdonság. Tudjuk,
hogy van a sorozatban legalább 1 db „T” tulajdonságú elem. Adjuk meg az els) „T” tulajdonságú
elem indexét, sorszámát!
Megoldás: Hasonlóan az eldöntés tételéhez vizsgálnunk kell egyesével az elemeket. Meddig kell a
vizsgálatot végeznünk? Addig, amíg meg nem találjuk az els) „T” tulajdonságú elemet. Mivel
biztosan van a sorozatban 1 db „T” tulajdonságú elem, így felesleges azt vizsgálnunk, hogy a
sorozat végére értünk-e.

Eljárás Kiválasztás(s,n,T,sorsz)
    Változó: i,sorsz:egész
    i:=0
    Ciklus amíg s[i] nem T tul.
        i:=i+1
    Ciklus vége
    sorsz:=i
Eljárás vége

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programozasi_Tetelek
{
    class Kivalaszt_C
    {
        const int N = 10;
        //adatag
        int[] tomb = new int[N];
        //metodusok
        public Kivalaszt_C(int[] i_tomb) //construktor int[] paraméterrel 
        {
            tomb = i_tomb;
        }
        public int kivalaszt() //Kiválasztás tételét megvalósító metodus a sorszámot adja vissza
        {
            int i = 0;

            Console.WriteLine("Kérem adja meg az értéket: ");
            int Ttul = Convert.ToInt32(Console.ReadLine());
            while (tomb[i] != Ttul)
            {
                i++; //egyenértékű i=i+1
            }
            return i ;
        }
    }
}
