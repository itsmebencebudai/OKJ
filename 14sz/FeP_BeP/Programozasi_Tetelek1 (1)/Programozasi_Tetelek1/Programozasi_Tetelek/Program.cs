using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programozasi_Tetelek
{
    
    class Program
        {
        
        static void Main(string[] args)
            {
            Tomb_C tomb_peld = new Tomb_C(); //A Tomb_C osztály példányosítása a tomb_peld változóba
            tomb_peld.kiir(tomb_peld.S);
            //tomb_peld.kiir(tomb_peld.Z);// Mivel a Tomb_C osztályban definiáltunk egy kiir() metodust ezért a tomb_peldany.kiir metodusát használva a paraméterként kapott tömböt kiírja
                                        //A zárojelek közt található tomb_peld.S tartalmazza az s tomb értékeit (valójában a Getter metodust hívjuk meg), amit Tomb_C osztályban definiáltunk 

            //Összegzés tétele
             Osszegzes_C osszegzes_peld = new Osszegzes_C(tomb_peld.S); //Az Osszezes_C osztály példányosítása
            Console.WriteLine(osszegzes_peld.osszegzes()); //Az Osszegzes_C osztálynak van egy osszegzés metódusa, ami rendelkezik visszatérési értékkel
            //eldöntés tétele
            //Eldont_C eldont_p = new Eldont_C(tomb_peld.S);
            //Console.WriteLine(eldont_p.eldont_mind());
           // Bin_Ker_C bin_ker_p = new Bin_Ker_C(tomb_peld.S);
           // Console.WriteLine(bin_ker_p.Bin_ker());
            //Maximum_Kivalasztas_C max_kiv_p = new Maximum_Kivalasztas_C(tomb_peld.S);
            //Console.WriteLine(max_kiv_p.maximum());         

            //Megszamlálás tétele
            //Megszamlal_C megszamlal_peld = new Megszamlal_C(tomb_peld.S); //A Megszamlal_C osztály példányosítása
            //Console.WriteLine(megszamlal_peld.megszamlal());//Az Megszamlal_C osztálynak van egy osszegzés metódusa, ami rendelkezik visszatérési értékkel

            //Maximum kiválasztás tétele
            //Maximum_Kivalasztas_C max_peld = new Maximum_Kivalasztas_C(tomb_peld.S);//A Maximum_kivalasztas_C osztály példányosítása
            //Console.WriteLine(max_peld.maximum()); //A Maxumum_Kivalasztas_C osztálynak van egy osszegzés metódusa, ami rendelkezik visszatérési értékkel

            //Kiválogatás tétele
            //Kivalogat_C kivalogat_p = new Kivalogat_C(tomb_peld.S);
            //tomb_peld.kiir(kivalogat_p.kivalogatas());
           // Szetvalogat_C szetv_p = new Szetvalogat_C(tomb_peld.S);
           // szetv_p.szetvalogat();
           // tomb_peld.kiir(szetv_p.D);
            //tomb_peld.kiir(szetv_p.Dn);
            //Metszetképzés
            //Metszet_C metszet_p = new Metszet_C();
            //tomb_peld.kiir(metszet_p.metszet_tetel(tomb_peld.S,tomb_peld.Z));
            //Unio képzés tétele
            // Unio_C unio_p = new Unio_C();
            // tomb_peld.kiir(unio_p.unio_tetel(tomb_peld.S,tomb_peld.Z));
            //Rendezés közvetlen kiválasztással
            // Kiv_Rend_C rend_kozv_kiv_p = new Kiv_Rend_C(tomb_peld.S);
            // tomb_peld.kiir(rend_kozv_kiv_p.kiv_rend());
            //shell rendezés
            //Shell_Rend_C shell_p = new Shell_Rend_C(tomb_peld.S);
            //tomb_peld.kiir(shell_p.rendezes());

            //Összefuttatás tétele
            //  Osszefuttatas_C osszefutat_p = new Osszefuttatas_C();
            // tomb_peld.kiir(osszefutat_p.unio_rendezett(tomb_peld.S,tomb_peld.Z));
            //indexvektoros rendezés
            //Index_Vekt_Rend_C index_p = new Index_Vekt_Rend_C();
            //index_p.rendezes(tomb_peld.S);
            //tomb_peld.kiir(index_p.Ind);
            //buborékos rendezés
           // Buborekos_Rend_C buborekos_p = new Buborekos_Rend_C(tomb_peld.S);
            //tomb_peld.kiir(buborekos_p.rendezes());
            //Kártyás rendezés
            //Beszur_Rend_C beszur_p = new Beszur_Rend_C(tomb_peld.S);
            //tomb_peld.kiir(beszur_p.rendezes());

            //Gyors rendezés
            //Gyors_Rend_C gyors_p = new Gyors_Rend_C(tomb_peld.S);
            //gyors_p.rendezes(0, 9);
            //tomb_peld.kiir(gyors_p.S);

            Console.ReadLine(); //egy enter leütésre vár
        }
        }
    
}
