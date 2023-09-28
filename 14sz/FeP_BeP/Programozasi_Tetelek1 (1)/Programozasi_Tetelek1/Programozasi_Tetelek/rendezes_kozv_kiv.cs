/*
 Rendezés közvetlen kiválasztással.
A rendezend) elemek az „s” sorozat elemei. A els) menetben kiválasztjuk a sorozat legkisebb
elemét úgy, hogy a sorozat „nulladik” elemét, „s[0]”-át összehasonlítjuk a sorozat soron következ)
elemeivel (s[1], s[2], ... s[n])-el). Ha az s[0]-ál kisebb elemet találunk, akkor felcseréljük )ket,
vagyis ezt a kisebb elemet tesszük „s[0]”-ba. A menet végére „s[0]” a sorozat legkisebb elemét
tartalmazza. Az „s[0]”-át leválasztva - mivel már a helyére került - az eljárást „s[1]”-el folytatjuk,
ezt hasonlítjuk össze az (s[2], ... s[n]) elemekkel. Az eljárást folytatva - menetenként a soron
következ) legkisebb elem kiválasztásával - n-1 menet után a sorozat rendezetté válik.

Eljárás Rendezés(s,n)
    Változó i,j:egész
    Ciklus i:=0-t/l n-1-ig, 1-sével
        Ciklus j:=i+1-t/l n-ig, 1-sével
            Ha s[i]>s[j]
                akkor csere(s[i],s[j])
            Elágazás vége
        Ciklus vége
    Ciklus vége
Eljárás vége
 
 */
using System;

class Kiv_Rend_C
{
    const int N = 10;
    int[] s = new int[N];
    public Kiv_Rend_C(int[] p_s) //paraméterezett konstruktor tömböt vár paraméterként
    {
        s = p_s;
    }

    public int[] kiv_rend() // rendezést megvalósító metodus
    {
        int csere;
        for (int i = 0; i < s.Length - 1; i++)
        {
            for (int j = i + 1; j < s.Length; j++)
            {
                if (s[i] > s[j])
                {
                    csere = s[i];
                    s[i] = s[j];
                    s[j] = csere;
                }
            }
        }
        return s;
    }
}
