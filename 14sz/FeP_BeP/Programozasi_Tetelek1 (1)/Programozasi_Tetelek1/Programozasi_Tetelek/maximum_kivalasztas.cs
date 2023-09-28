/*
Feladat: Adott egy „n” elem: „s” számsorozat. Adjuk meg a sorozat legnagyobb elemét!
Megoldás: Tegyük fel, hogy a sorozat legnagyobb eleme a 0. elem. Ezt tároljuk egy változóban, pl.
„max”. Ezt a változót hasonlítsuk össze a sorozat a többi elemével. Ha találunk a feltételezett
legnagyobb elemnél nagyobbat, akkor jegyezzük meg, hogy az új elem a legnagyobb. Mire a
sorozat végére érünk, a „max” változó a sorozat legnagyobb elemét fogja tartalmazni.

Eljárás Megszámolás(s,n,T,db)
    Változó: i,db:egész
    db:=0
    Ciklus i:=0-tól n-ig 1-sével
        Ha s[i] T tul akkor
            db:=db+1
        Elágazás vége
    Ciklus vége
Eljárás vége

 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programozasi_Tetelek
{
    class Maximum_Kivalasztas_C //Maximum kiválasztás osztály definiálása
    {
        const int N = 10;       //Konstans definició
        //adatag definició
        int[] s = new int[N];   //Tömb definiálása példányosítás
        //konstruktor definició
        public Maximum_Kivalasztas_C(int[] p_s) //paraméterrel ellátott konstruktor a példányosításkor kötelező megadni paraméterként egy tömböt aminek az érttékeit átadja az 's' tombnek 
        {
            s= p_s; //értékadás
        }
        //metodus definició
        public int maximum()    //maximumkiválasztás tételének megvalósítása
        {
            int max = s[0];     //Kezdetben a legnagyobb érték legyen a tömb első eleme, ehhez viszonyítunk elösször
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] > max) //Feltétreles utasítás. Megvizsgáljuk hogy a tömb i-dik eleme az nagyobb e mint a jelenlegi legnagyobb érték,
                    max = s[i]; //ha igen, akkor az lesz majd a maximum. 
            }
            return max;         //Visszatérési érték megadása, a legnagyobb értéket adjuk vissza
        }
    }
}
