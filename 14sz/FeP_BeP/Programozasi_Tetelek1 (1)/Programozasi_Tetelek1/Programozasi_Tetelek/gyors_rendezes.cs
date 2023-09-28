/*
 Gyors rendezés
A gyors rendezés során a rendezend) sorozatunkat részekre bontjuk. Kiválasztjuk a sorozat egyik
tetszõleges elemét (ezt alapnak vagy strázsának nevezzük), és ehhez az elemhez fogjuk hasonlítani
a többi elemet.
A sorozatban elõször balról, azaz a sorozat elejérõl indulva lépegetünk egészen addig, amíg a
strázsánál kisebb elemet találunk. Ha egy elem nagyobb vegy egyenlõ mint a strázsa, akkor ott
megállunk, és a sorozat jobb oldaláról, azaz a végérõl lépegetünk egészen addig, amíg a strázsánál
nagyobb elemet találunk. Ha egy elem kisebb vagy egyenlõ mint a strázsa, akkor ott megállunk, és
felcseréljük azt a két elemet, ahol megálltunk a lépegetések során. A lépegetést, keresést, cserét a
következõ nagyobb illetve kisebb indexü elemnél folytatjuk egészen addig, amíg a két index össze
nem ér (találkozik, vagy helyet cserél). Az eljárást, felosztási módszert egészen addig folytatjuk,
amíg a felosztandó rész hossza 1 nem lesz.

Eljárás Gyors(tól,ig)
    Változó bal,jobb,tól,igy:egész
    bal:=tól
    jobb:=ig
    alap:=s[egészrész(tól+ig)/2)]
    Ciklus
        Ciklus amíg s[bal]<alap
            bal:=bal+1
        Ciklus vége
        Ciklus amíg s[jobb]>alap
            jobb:=jobb-1
        Ciklus vége
        Ha bal<=jobb akkor
            csere(s[bal],s[jobb]); 
            bal:=bal+1; 
            jobb:=jobb-1
        Elágazás vége
    amíg bal>jobb
    Ha tól<jobb akkor 
        Gyors(tól,jobb)
    Elágazás vége
    Ha bal<ig akkor 
        Gyors(bal,ig)
    Elágazás vége
Eljárás vége

 */
using System;

class Gyors_Rend_C
{
    const int N = 10;
    int[] s = new int[N];
    public Gyors_Rend_C(int[] s_p)
    {
        s = s_p;
    }
    public void rendezes(int tol, int ig)
    {
        int bal, jobb, alap, csere;
        bal = tol;
        jobb = ig;
        alap = s[(tol + ig) / 2];
        do
        {
            while (s[bal] < alap)
            {
                bal++;
            }
            while (s[jobb] > alap)
            {
                jobb--;
            }
            if (bal <= jobb)
            {
                csere = s[bal];
                s[bal] = s[jobb];
                s[jobb] = csere;
                bal++;
                jobb--;
            }
        } while (bal <= jobb);
        if (tol < jobb) rendezes(tol, jobb);
        if (bal < ig) rendezes(bal, ig);
    }
    public int[] S { get { return s; } }
}
