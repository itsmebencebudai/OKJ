/*
Feladat: Adott egy „n” elemű „s” rendezett sorozat.Keressük azt az elemet, amelynek értéke „q”!
Megoldás: A megoldó algoritmus során kihasználjuk, hogy a sorozat rendezett. Első lépésben
vizsgáljuk meg a sorozat „középső” elemét! Ha ez a keresett elem(„q”), akkor készen vagyunk.Ha
a keresett elem ennél kisebb, akkor csak az ezt megelőzők között lehet, vagyis a keresést a
„középső” elem előtti részre alkalmazzuk. Ha a keresett elem nagyobb, akkor természetesen a
keresést a „középső” elem utáni részre alkalmazzuk.Részintervallumokat fogunk vizsgálni, a
részintervallumokat szűkítjük.

Eljárás BinárisKeresés(s,n,q,van,sorsz)
    Változó: e,u,k,sorsz:egész
    q:elemtípus
    van:logikai
    e:=0; u:=n-1
    Ciklus
        k:=egészrész((e+u)/2)
        Elágazás
            q<s[k] esetén u:=k-1
            q>s[k] esetén e:=k+1
        Elágazás vége
    amíg e<=u és s[k]q
    Ciklus vége
    van:=(e<=u)
    Ha van akkor 
        sorsz:=k
    Elágazás vége
Eljárás vége
 
   */
using System;

public class Bin_Ker_C
{
    const int N = 10;
    //adattagok
    int[] tomb = new int[N];
        //metodusok
        public Bin_Ker_C(int[] i_tomb) //construktor definiálása paraméterrel, tömböt kap paraméterként
        {
            tomb = i_tomb;
            Array.Sort(tomb);
        
        }
        public Nullable<int> Bin_ker()
        {
            Console.WriteLine("Kérem a keresendő elemet:");

            int Q = Convert.ToInt32(Console.ReadLine());
            int k = 0, e = 0, u = tomb.Length - 1;
            do
            {
                k = (e + u) / 2;
                if (tomb[k] < Q) e = k + 1;
                if (tomb[k] > Q) u = k - 1;
            } while ((tomb[k] != Q) && (e <= u));

            if (e <= u)
                return k;
            else
                return null;
        }
}
