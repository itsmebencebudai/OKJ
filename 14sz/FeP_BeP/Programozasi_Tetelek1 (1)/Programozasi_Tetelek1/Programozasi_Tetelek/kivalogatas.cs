/*
 Feladat: Adott egy „n” elem: „s” sorozat, és a sorozat elemein értelmezett „T” tulajdonság.
Válogassuk ki egy külön sorozatba („d”) az „s” sorozat „T” tulajdonságú elemeit!
Megoldás: Végig kell vizsgálnunk a sorozat összes elemét. A „T” tulajdonságú elemeket egy külön
sorozatba kiírjuk.

 Eljárás Kiválogatás(s,n,d,db,T)
    Változó: i,db:egész
    db:=0
    Ciklus i:=0-t/l n-ig 1-sével
        Ha s[i] T tul. akkor 
            db:=db+1; 
            d[db]:=s[i]
        Elágazás vége
    Ciklus vége
Eljárás vége
 */
using System;

public class Kivalogat_C
{
    const int N = 10;
    int[] s = new int[N];
    public Kivalogat_C(int[] p_s)
    {
        s = p_s;
    }
    public int[] kivalogatas()
    {
        int[] d = new int[N];
        int db = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] % 2 == 0) { d[db] = s[i]; db++; }

        }
        return d;
    }
}
