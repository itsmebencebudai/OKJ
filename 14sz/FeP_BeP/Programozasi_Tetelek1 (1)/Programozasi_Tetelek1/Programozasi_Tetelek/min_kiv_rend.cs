/*
Rendezés minimum-kiválasztással.

A közvetlen kiválasztással történ) rendezés során sokszor feleslegesen végzünk cserét. A felesleges
cserék kiküszöbölése érdekében két segédváltozót – „érték”, „index” vezetünk be. Az „érték” nev:
változó tartalmazza az adott menetben addig megtalált legkisebb elemet, az „index” pedig annak
sorozatbeli sorszámát, indexét. Minden menetben az „s” sorozat elemeit az „érték” nev: változóval
hasonlítjuk össze, s ha az „érték”-nél kisebb elemet találunk, akkor azt betesszük az „érték” nev:
változóba, s az „index”-ben megjegyezzük a szóban forgó elem indexét. A menet végére az „érték”
a sorozat soron következ) legkisebb elemét tartalmazza, az „index” pedig azt a sorszámot, ahol ezt
az elemet találtuk. Cserére csak a menet utolsó lépésében van szükségünk, amikor az „érték”-ben
lev) legkisebb elemet a helyére tesszük.
 
Eljárás Rendezés(s,n)
    Változó i,j:egész
    Ciklus i:=0-tól n-1-ig, 1-sével
        érték:=s[i]
        index:=i
        Ciklus j:=i+1-t/l n-ig, 1-sével
            Ha érték>s[j] akkor 
                érték:=s[j]; 
                index:=j
            Elágazás vége
        Ciklus vége
        s[index]:=s[i]
        s[i]:=érték
    Ciklus vége
Eljárás vége
 */
using System;

class Min_Kiv_Rend_C
{
    const int N = 10;
    int[] s = new int[N];
    public Min_Kiv_Rend_C(int[] s_p)
    {
        s = s_p;
    }

    public int[] S { get { return s; } }

    public int[] rendez()
    {
        int index, ertek;

        for (int i = 0; i < s.Length - 1; i++)
        {
            ertek = s[i];
            index = i;
            for (int j = i + 1; j < s.Length; j++)
            {
                if (ertek > s[j])
                {
                    ertek = s[j];
                    index = j;
                }
            }
            s[index] = s[i];
            s[i] = ertek;
        }
        return s;
    }
}