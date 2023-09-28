/*
Shell rendezés
 A Shell módszer nem foglalkozik egyszerre minden rendezend) elemmel, hanem csak az egymástól
adott távolságra lev)kkel. A rendezés több menetben történik. Minden menet elején meghatározunk
egy lépésközt „d”, amely azt jelenti, hogy az adott menetben a sorozat egymástól „d” távolságra
lev) elemeit rendezzük. Az utolsó menetben „d=1” esetén a sorozat rendezetté válik.
A Shell rendezés el)nye, hogy viszonylag kevés m:velettel az eredeti sorozat „nagyjából”
rendezetté válik. Az elemek körülbelül egyszerre haladnak végleges helyük felé. A lépésköz
csökkentésével ebben a nagyjából rendezett sorozatban már csak kisebb korrekciókat kell
végrahajtanunk. Egy adott meneten belül a beszúró rendezést használjuk.

Eljárás Rendezés(s,n)
    Változó i,j,d,B:egész
    REK:elemtípus
    d:=n-1
    Ciklus
        i:=0
        Ciklus amíg i<d és i+d<n
            Ciklus j:=i+d-t/l n-ig, d-esével (lépésköz d)
                REK:=s[j]; B:=j-d
                Ciklus amíg B>0 és REK<s[B]
                    S[B+d]:=s[B]; B:=B-d
                Ciklus vége
                S[B+d]:=REK
            Ciklus vége
            i:=i+1
        Ciklus vége
        d:=int(d/2)
    amíg d<1
    Ciklus vége
Eljárás vége
 */
using System;

class Shell_Rend_C
{
    const int N = 10;
    int[] s = new int[N];
    public Shell_Rend_C(int[] s_p) //paraméterezett konstruktor tömböt vár paraméterként, mit rendezzen
    {
        s = s_p;
    }
    public int[] rendezes() //rendezés tételét megvalósító metodus
    {
        int i, d, B, REK; //változók definiálása, i: ciklus változó, d: lépésköz B: ciklus változó, REK: segéd változó tömb egy adott indexű elemének értékét tároljuk el benne 
        d = s.Length - 1; // Lépésköz alapértékének beállítása
        do // hátultesztelő ciklus
        {
            i = 0;
            while (i < d && i + d < s.Length)
            {
                for (int j = i + d; j < s.Length; j = j + d)
                {
                    REK = s[j]; B = j - d;
                    while (B >= 0 && REK < s[B])
                    {
                        s[B + d] = s[B];
                        B = B - d;
                    }
                    s[B + d] = REK;
                }
                i++;
            }
            d = d / 2;
        } while (d >= 1); // addig fut a ciklusmag, amíg a lépésköz nem éri el az egyet 

        return s; //visszatérési érték
    }

}
