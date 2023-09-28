/*
Feladat: Adott egy „n” elem: „s” és egy „m” elem: „z” rendezett sorozat. Határozzuk meg a két
sorozat unióját! Természetesen a „unió” sorozat is rendezett lesz.
Megoldás: A megoldás során párhuzamosan haladunk a két sorozatban. Az eredménysorozat els)
eleme vagy s0 vagy z0 lesz. A kisebbet az eredménysorozatba tesszük, és továbblépünk ebben a
sorozatban. Újra hasonlítunk két elemet… Ha a két elem egyenl), akkor csak az egyiket tesszük az
eredménysorozatba, és továbblépünk mindkét sorozatban. Ha az egyik sorozatnak a végére értünk,
akkor a másik sorozatot változatlanul az eredménysorozatba másoljuk.

Eljárás Összefuttatás(s,n,z,m,unio,db)
    Változó: i,j,db:egész
    i:=0; j:=0; db:=-1
    Ciklus amíg i<n és j<m
        db:=db+1
        Elágazás
            s[i]<z[j] esetén unio[db]:=s[i]; i:=i+1
            s[i]=z[j] esetén unio[db]:=s[i]; i:=i+1; j:=j+1
            s[i]>z[j] esetén unio[db]:=z[j]; j:=j+1
        Elágazás vége
    Ciklus vége
    Ciklus amíg i<n
        db:=db+1; unio[db]:=s[i]; i:=i+1
    Ciklus vége
    Ciklus amíg j<m
        db:=db+1; unio[db]:=z[j]; j:=j+1
    Ciklus vége
Eljárás vége 
*/
using System;

class Osszefuttatas_C
{
    const int N = 10;
    const int M = 15;
    int[] unio = new int[N + M];
    public int[] unio_rendezett(int[] s, int[] z)
    {
        int i = 0, j = 0, db = 0;
        while (i < s.Length && j < z.Length)
        {
            if (s[i] < z[j]) { unio[db] = s[i]; i++; }
            else
                if (s[i] == z[j]) { unio[db] = s[i]; i++; j++; }
            else
            {
                unio[db] = z[j];
                j++;
            }
            db++;
        }
        while (i < s.Length)
        {
            unio[db] = s[i];
            db++;
            i++;
        }
        while (j < z.Length)
        {
            unio[db] = z[j];
            db++;
            j++;
        }
        return unio;
    }
}
