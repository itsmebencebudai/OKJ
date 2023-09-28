/*
 Egyszerű beillesztéses rendezés (Beszúrásos rendezés)
A ‘kártyás rendezésnél’ úgy végezzük a rendezést, mintha kártyáznánk, és kezünkbe egyesével
vennénk fel az asztalról a kiosztott lapokat. Az éppen felvett lapnak megkeressük a kezünkben levő
már rendezett sorozatban a helyét úgy, hogy közben a nála nagyobbakat egy hellyel elcsúsztatjuk,
végül beillesztjük a felvett lapot a neki megfelelő helyre.
 
Eljárás Rendezés(s,n)
    Változó i,j:egész
    M:elemtípus
    Ciklus i:=1-t/l n-ig, 1-sével
        M:=s[i]
        j:=i-1
        Ciklus amíg M<s[j] és j>=0
            S[j+1]:=s[j]
            j:=j-1
        Ciklus vége
        S[j+1]:=M
    Ciklus vége
Eljárás vége
 */
using System;

class Beszur_Rend_C // Beszúrásos rendezést megvalósító  osztály
{
    const int N = 10;
    
    int[] s = new int[N];
    public Beszur_Rend_C(int[] s_p)
    {
        s = s_p;
    }
    public int[] rendezes() //rendezést megvalósító metodus /viszatérési értéke a rendezett tömb
    {
        int M, j;
        for (int i = 1; i < s.Length; i++)
        {
            M = s[i]; // M változóba beletesszük tömb i-dik indexű elemét
            j = i - 1;
            while (j >= 0 && M < s[j])  //M változónál nagyobb elemeket eltoljuk
            {
                s[j + 1] = s[j];
                j--;
            }
            s[j + 1] = M;
        }
        return s;
    }

}
