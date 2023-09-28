/*
 Feladat: Adott egy „n” elem: „s” számsorozat, és a sorozat elemein értelmezett „f” függvény.
Adjuk meg a sorozat elemeinek „f” függvény által képzett értékét.
Megoldás: Legyen egy változó „a”, melynek kezd)értéke „f0” („nullelem”) az adott feladattól függ.
Legyen egy „f” függvény, amely a sorozat elemein értelmezett függvény. (Pl. +, -, *, , ). A
megoldás során a sorozat elemin végighaladva vesszük az „a” változó és a sorozat aktuális
elemének „f” függvényét.

Eljárás Sorozatszámítás(s,n,f,a)
    Változó: i:egész
    a:elemtípus
    a:=f0
    Ciklus i:=0-tól n-ig 1-sével
        a:=f(a,s[i])
    Ciklus vége
Eljárás vége

Összegzés tétele egy konkrét megvalósítás

Eljárás Összegzés(s,n,összeg)
    Változó: i:egész
    összeg:elemtípus
    összeg:=0
    Ciklus i:=0-tól n-ig 1-sével
        összeg:=összeg+s[i]
    Ciklus vége
Eljárás vége
 */
using System;

public class Osszegzes_C
{
    const int N = 10;
    int[] s = new int[N]; 
    public Osszegzes_C(int[] s_p)
    {
        s = s_p;
    }
    public int osszegzes()
    {
        int osszeg = 0;
        for (int i = 0; i < s.Length; i++)
        {
            osszeg = osszeg + s[i];
        }
        return osszeg;
    }
}
