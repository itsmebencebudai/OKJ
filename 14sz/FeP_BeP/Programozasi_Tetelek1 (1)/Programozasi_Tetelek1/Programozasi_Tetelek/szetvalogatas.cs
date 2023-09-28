/*
Szétválogatás tételét megvalósító osztály
Feladat: Adott egy „n” elemű „s” sorozat, és a sorozat elemein értelmezett „T” tulajdonság.
Válogassuk ki külön-külön két sorozatba az „s” sorozat „T”, illetve nem „T” tulajdonságú elemeit!
A tételt a páros és nem páros elemek szétválogatásán keresztül valósítjuk meg.

Megoldás: Végig kell vizsgálnunk a sorozat összes elemét. A „T” tulajdonságú elemeket egy „dt”
(elemszáma „dbt”), a nem „T” tulajdonságú elemeket, pedig egy „dnt” nev: sorozatba (elemszáma
„dbnt”) helyezzük el.

Eljárás Szétválogatás(s,n,dt,dbt,dnt,dbnt,T)
    Változó: i,dbt,dbnt:egész
    dbt:=0; dbnt:=0
    Ciklus i:=0-t/l n-ig 1-sével
        Ha s[i] T tul.
            akkor 
                dbt:=dbt+1
                dt[dbt]:=s[i]
            különben 
                dbnt:=dbnt+1
                dnt[dbnt]:=s[i]
        Elágazás vége
    Ciklus vége
Eljárás vége
 */
using System;

public class Szetvalogat_C
{
    const int N = 10; // Konstans definició
    int[] s = new int[N];
    int[] d = new int[N]; //A "T" tulajdonságú elemeket tartalmazó tömb 
    int[] dn = new int[N];  //A nem "T" tulajdonságú elemeket tartalmazó tömb 

    public Szetvalogat_C(int[] p_s) //paraméterezett konstruktor tömböt vár paraméterként, hogy mit válogasson szét
    {
        s = p_s;
    }
    
    public void szetvalogat() //szétválogatás tételét megvalósító osztály
    {
        int db = 0, dbn = 0; // "T ulajdonságú (d) és a nem T ulajdonságú (dn)" tömbök indexének inicializálása

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] % 2 == 0) { d[db] = s[i]; db++; } 
            else { dn[dbn] = s[i]; dbn++; }
        }
    }
    public int[] D { get { return d; } } //getter metodus
    public int[] Dn { get { return dn; } } //getter metodus
}
