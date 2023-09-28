/*
 Feladat: Adott egy „n” elem: „s” és egy „m” elem: „z” sorozat. Határozzuk meg a két sorozat
metszetét!
Megoldás: Halmazokról van szó, feltesszük, hogy minden elem csak egyszer fordul el) a
sorozatban. A megoldás során megvizsgáljuk az „s” sorozat minden elemét, hogy benne van-e a „z”
sorozatban. Ha igen, akkor betesszük egy harmadik (metszet, „metszet”) sorozatba. Kiválogatjuk az
„s” sorozat azon elemeit, melyek benne vannak a „z” sorozatban.

Eljárás Metszetképzés(s,n,z,m,metszet,db)
    Változó: i,j,db:egész
    db:=0
    Ciklus i:=0-t/l n-ig 1-sével
        j:=0
        Ciklus amíg j<m és s[i]z[j]
            j:=j+1
        Ciklus vége
        Ha j<m akkor 
            db:=db+1
            metszet[db]:=s[i]
        Elágazás vége
    Ciklus vége
Eljárás vége
 */
using System;

public class Metszet_C
{
    const int N = 10;
    int[] metszet = new int[N];
        public int[] metszet_tetel(int[] s, int[] z)
        {
            int db = 0, j;
            for (int i = 0; i < s.Length; i++)
            {
                j = 0;
                while (j < z.Length && s[i] != z[j])
                {
                    j++;
                }
                if (j < z.Length)
                {
                    metszet[db] = s[i];
                    db++;
                }
            }
            return metszet;
        }  
}
