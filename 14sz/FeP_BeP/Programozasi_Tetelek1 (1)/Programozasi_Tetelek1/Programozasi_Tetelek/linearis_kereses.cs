/*
 Lineáris keresés tétele

Megoldás: A feladat az eldöntés tételének és a kiválasztás tételének az „összevonása”. Döntsük el,
hogy van-e a sorozatban „T” tulajdonságú elem, és ha van, akkor adjuk meg a sorszámát! A
vizsgálóciklusból kilépve a sorozatindex mutatja meg, hogy hányadik elem a „T” tulajdonságú
elem.

Eljárás Keresés(s,n,T,van,sorsz)
    Változó: i,sorsz:egész
    van:logikai
    i:=0
    Ciklus amíg s[i] nem T tul. és i<n
        i:=i+1
    Ciklus vége
    van:=(i<n)
    Ha van akkor 
        sorsz:=i
    Elágazás vége
Eljárás vége
 */
using System;

class Lin_ker
{
    const int N = 10;
    int[] tomb = new int[N];
    public Lin_ker(int[] i_tomb)
    {
        tomb = i_tomb;
    }
    public Nullable<int> Lin_keres()
    {
        Console.WriteLine("Adja meg az értéket:");
        int Ttul = int.Parse(Console.ReadLine());
        //Convert.ToInt32(Console.ReadLine()); 
        int i = 0;
        while (i < tomb.Length && tomb[i] != Ttul)
        {
            i++;
        }
        if (i < tomb.Length)
            return i + 1;
        else
            return null;

    }
}
