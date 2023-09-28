/*
 Feladat: Adott egy „n” elem: „s” sorozat, és a sorozat elemein értelmezett „T” tulajdonság.
a) Döntsük el, hogy van-e „T” tulajdonságú elem a sorozatban!
b) Döntsük el, hogy minden elem „T” tulajdonságú-e!
a) Megoldás: Meg kell vizsgálnunk a sorozat elemeit, hogy „T” tulajdonságúak-e. Meg kell
néznünk az összes elemet? Felesleges, hiszen, ha találunk már 1 db „T” tulajdonságú elemet, akkor
tudunk válaszolni a kérdésre. A válasz egy logikai típusú válasz: „igaz” vagy „hamis”. El)l-tesztel)
ciklussal dolgozunk, vizsgáljuk az elemeket egymás után. Mikor léphetünk ki a vizsgálatból? Ha
találunk „T” tulajdonságú elemet, illetve, ha már megvizsgáltunk minden elemet, végigértünk a
sorozaton és azt tapasztaltuk, hogy egyik elem sem „T” tulajdonságú (i=n, a sorozatindex egyenl) a
sorozat elemeinek számával).
 
Eljárás Eldöntés(s,n,T,van)
    Változó: i:egész
    van:logikai
    i:=0
    Ciklus amíg s[i] nem T tul. és i<n
        i:=i+1
    Ciklus vége
    van:=(i<n)
Eljárás vége

b) Megoldás: Meg kell vizsgálnunk a sorozat elemeit, hogy mind „T” tulajdonságúak-e. Meg kell
néznünk az összes elemet? Felesleges, hiszen, ha találunk már 1 db nem „T” tulajdonságú elemet,
akkor választ tudunk adni a kérdésre. El)l-tesztel) ciklussal dolgozunk, vizsgáljuk az elemeket
egymás után. Mikor léphetünk ki a vizsgálatból? Ha találtunk nem „T” tulajdonságú elemet, illetve,
ha már megvizsgáltunk minden elemet, végigértünk a sorozaton és azt tapasztaltuk, hogy minden
elem „T” tulajdonságú (i=n, a sorozatindex egyenl) a sorozat elemeinek számával).
 
Eljárás Eldöntés(s,n,T,mind)
    Változó: i:egész
    mind:logikai
    i:=0
    Ciklus amíg s[i] T tul. és i<n
        i:=i+1
    Ciklus vége
    mind:=(i=n)
Eljárás vége
 */
using System;

class Eldont
{
    const int N = 10;
    //adatag
    int[] tomb = new int[N];
    //metodusok
    public Eldont(int[] i_tomb) //construktor int[] paraméterrel 
    {
        tomb = i_tomb;
    }
    public bool eldont_egy() //logikai visszatérési értékkel rendelkező metodus
    {
        int i = 0;

        Console.WriteLine("Kérem adja meg az értéket: ");
        int Ttul = Convert.ToInt32(Console.ReadLine());
        while (i < tomb.Length && tomb[i] != Ttul)
        {
            i++; //egyenértékű i=i+1
        }
        return i < tomb.Length;
    }
    public bool eldont_mind() //logikai visszatérési értékkel rendelkező metodus
    {
        int i = 0;
        while (i < tomb.Length && tomb[i] % 2 == 0)
        {
            i++; //egyenértékű i=i+1
        }
        return i == tomb.Length;
    }
}
