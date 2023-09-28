/* unióképzés tételét megvalósító osztály
 Feladat: Adott egy „n” elemű „s” és egy „m” elemű „z” sorozat. Határozzuk meg a két sorozat
unióját!

Eljárás Unioképzés(s,n,z,m,unio,db)
    Változó: i,j,db:egész
    unio:=s
    db:=n-1
    Ciklus j:=0-t/l m-ig 1-sével
        i:=0
        Ciklus amíg i<n és s[i]z[j]
            i:=i+1
        Ciklus vége
        Ha i=n akkor 
            db:=db+1
            unio[db]:=z[j]
        Elágazás vége
    Ciklus vége
Eljárás vége
 */
using System;

class Unio_C
{
    const int N = 10; //konstans definició a tömb méretére
    const int M = 15; //konstans definició a tömb méretére (n,m elemű sorozatt)
    int[] unio = new int[N + M]; // az unió tömb definiciója az elemeinek száma maximálisan N+M

    public int[] unio_tetel(int[] s, int[] z) //uniót megvalósító metodus 
    {
        for (int k = 0; k < s.Length; k++)  // Az egyik tömb tartalmát (s) egy az egyben betöltjük a az unió tömbe
        {
            unio[k] = s[k];
        }

        int db = N, i; //inicializáljuk az unió tömb indexét (db), és a i ciklus változót

        for (int j = 0; j < z.Length; j++) // a 'z' tömbön végighaladunk és megnézzük, hogy szerepel az értéke az 's' tömben  
        {
            i = 0;
            while (i < s.Length && s[i] != z[j]) // eldöntés tétele van-e benne
            {
                i++;
            }
            if (i == s.Length) //Ha nincs benne (ezért egyenlőséget vizsgálunk) akkor beletesszük az unió tömbe a 'z' tömb j-dik indexű elemét
            {
                unio[db] = z[j];
                db++;
            }
        }
        return unio; //visszaadjuk a fügvény értékeként az unio tömböt
    }
}
