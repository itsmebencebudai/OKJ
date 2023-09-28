/*
 Feladat: Adott egy „n” elem: „s” sorozat, és a sorozat elemein értelmezett „T” tulajdonság. Adjuk
meg a „T” tulajdonságú elemek darabszámát!
Megoldás: A megoldás során végig kell haladnunk az egész sorozaton, és megszámolnunk, hogy
hány db. „T” tulajdonságú elemet találunk. Célszerűen egy változót, melynek a kezdőértéke 0
növelünk mindig.
       
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

class Megszamlal_C          //megszámlás tétel osztályának definiciója
{
    const int N = 10;       // konstans definició
    //adatag definició
    int[] s = new int[N];   //tömb létrehozása példányosítás
    //konstruktor definició
    public Megszamlal_C(int[] p_s)      //paraméterrel ellátott konstruktor. A példányosításkor kötelező megadni paraméterként egy tömböt, aminek az érttékeit átadja az 's' tombnek 
    {
        s = p_s;                //értékdás
    }
    //metodus definició
    public int megszamlal()             //megszámlálás tételének megvalósítása
    {
        int db = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] % 2 == 0) db++;    //T tuladonság: páros számok darabszáma
        }
        return db;                      // metodus visszatérési értékének megadása
    }
}
