/*
 Buborékos rendezés
A buborékos rendezés alapelve a szomszédos elemek cseréje. Az els) menetben a rendezend)
sorozat végér)l elindulva minden elemet összehasonlítunk az el)tte lev)vel. Ha rossz sorrendben
vannak, akkor felcseréljük )ket. Az els) menet végére a legkisebb elem a helyére kerül. Minden
további menetben ismét a sorozat végér)l indulunk, de egyre kevesebb összehasonlításra van
szükségünk, ugyanis a sorozat eleje fokozatosan rendezetté válik.

Eljárás Rendezés(s,n)
    Változó i,j:egész
    Ciklus i:=1-t/l n-ig, 1-sével
        Ciklus j:=n-t/l i-ig, -1-sével
            Ha s[j-1]>s[j] akkor 
                csere(s[j-1],s[j])
            Elágazás vége
        Ciklus vége
    Ciklus vége
Eljárás vége
 
 */
using System;

class Buborekos_Rend_C
{
    const int N = 10;
    int[] s = new int[N];
    public Buborekos_Rend_C(int[] s_p)
    {
        s = s_p;
    }

    public int[] rendezes()
    {
        int csere;
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = s.Length - 1; j > i; j--)
            {
                if (s[j - 1] > s[j])
                {
                    csere = s[j - 1];
                    s[j - 1] = s[j];
                    s[j] = csere;
                }
            }
        }
        return s;
    }
}

