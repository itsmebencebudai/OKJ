/*
Indexvektoros rendezés
Az indexvektoros rendezést akkor használjuk, ha:
- szükségünk van az eredeti sorozatra (az eredeti sorrendre).
- a sorozatunk egy-egy eleme sok információt tartalmaz (pl. rekord), így a mozgatás id) és
munkaigényes.
Az indexvektoros rendezés bármely más rendezési algoritmussal „egybeépíthet)”, most a közvetlen
kiválasztással történ) rendezés elvével építjük össze. A rendezés során egy segédvektort
(indexvektort) alkalmazunk, amelyben a rendezend) sorozat elemeinek a sorszámát, indexét
helyezzük el. Az eredeti sorozat elemeit hasonlítjuk egymással, de a szükséges cseréket csak
jelezzük oly módon, hogy az indexvektorban a megcserélend) elemek sorszámát, indexét
felcseréljük. A rendezés során az elemek sorrendje - az indexvektor tartalma - változik, de a sorozat
változatlan marad.
 
Eljárás Rendezés(s,n)
    Változó i,j:egész
    ind:Tömb[0..n:egész]
    Ciklus i:=0-tól n-ig, 1-sével
        ind[i]:=i
    Ciklus vége
    Ciklus i:=0-t/l n-1-ig, 1-sével
        Ciklus j:=i+1-t/l n-ig, 1-sével
            Ha s[ind[i]]>s[ind[j]] akkor 
                csere(ind[i],ind[j])
            Elágazás vége
        Ciklus vége
    Ciklus vége
Eljárás vége

 */
using System;

class Index_Vekt_Rend_C
{
    const int N = 10;
    int[] ind = new int[N];
    public Index_Vekt_Rend_C()
    {
        for (int i = 0; i < ind.Length; i++)
        {
            ind[i] = i;
        }
    }
    public int[] Ind { get { return ind; } }
    public void rendezes(int[] s)
    {
        int csere;
        for (int i = 0; i < s.Length - 1; i++)
        {
            for (int j = i + 1; j < s.Length; j++)
            {
                if (s[ind[i]] > s[ind[j]])
                {
                    csere = ind[i];
                    ind[i] = ind[j];
                    ind[j] = csere;
                }
            }
        }
    }
}