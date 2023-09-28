/*
Az osztály definiál  's', 'z' tömböket. A tömböket a konstruktor metodus segítségével inicializáljuk vagyis,
feltöltjük véletlen számokkal 0 és 99 között. A tömbök értékeit getter metodusok segítségével érhetjük el.
Az osztály rendelkezik egy kiírómetodussal, ami a paraméterként kapott tömb értékeit megjeleníti a képernyőn.
 */

using System;

public class Tomb_C //osztály definició
{
    const int N = 10;     //Konstans változó definiálása a tömb méretének meghatározására
    const int M = 15;
    //adattag definició
    int[] s = new int[N]; //Tömb deklarálása a progromozási tételekben szereplő ('N' elemű 's' sorozat)
    int[] z = new int[M]; //Tömb deklarálása a progromozási tételekben szereplő ('M' elemű 'z' sorozat)

    //konstruktor definició
    public Tomb_C()       //Konstruktor definiálása (inicializálja az osztályt) pl. az adatagoknak kezdőértéket adhatunk, meghívhatunk metodusokat, ami
                          //pl. kiíja a képernyőre az értékeit. A konstruktor a példányosításkor mindig lefut még akkor is, ha nem írunk bele semmit!!!
                          //Ez a konstruktor a példányosításkor feltölti véletlenszámokkal az 's' 'z' tömböket
    {           
        Random rnd = new Random();          // Véletlenszám osztály példányosítása 'rnd' változóba.
        for (int i = 0; i < s.Length; i++)  //Növekményes, számlálásos ciklus definiciója az 'i' változó a ciklus, amit mindíg eggyel növelünk.
        {                                   //s.Length utasítás a tömb elemeinek számát adja vissza, megegyezik az 'N' konstans értékével.
                                            //A ciklus mag addig fut, amíg az 'i' ciklusváltozó kissebb mint a tömb elemeinek a száma.  
            s[i] = rnd.Next(100);           //A tömb i-dik elemének értéket adunk, ami egy véletlenszám lesz 0 és 99 között. 

        }
        //Array.Sort(s);
        for (int i = 0; i < z.Length; i++) // z tömb feltöltése csak néhány programozási tételnél használjuk
        {
            z[i] = rnd.Next(100);
        }
        Array.Sort(z);
    }

    //metodus definiciók
    public int[] S { get { return s; }  /*set {s = value;}*/}   //Getter, setter metódus definició. A getter rész van definiálva!!! Setter rész kommentezett
    public int[] Z { get { return z; } }                        //A G-S metodus az adattagok elérésére szolgál az osztályon kivülről
                                                                //minden adatag láthatósága alapértelmezés szerint private. Public láthatóságot nem állítunk be adatagra biztonsági okokból   

    public void kiir(int[] tomb) //Metodus definició paraméterrel. A metodus egy tömböt vár paraméterként, melynek értékeit kiírja a képernyőre
    {
        for (int i = 0; i < tomb.Length; i++) // Növekményes ciklus definició
        {
            Console.Write(tomb[i] + " "); //Kiírja a tömb i-dik értékét a képernyőre. A Console osztály tartalmazza konzolos adat be és kivitel utasításait
                                          //Write utasítás sortörés nélkül írja ki a képernyőre a paraméterként (a zárójelek közé beírt "szöveget, utasításokat") megadott értéke(ke)t. 
        }
        Console.WriteLine();//Sortörést csinál, mivel nincs paraméterként megadva semmi.
    }
}
    

