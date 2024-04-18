//Vizsgált objektum:
let helsinki = [
    { helyezes: 1, csapatMeret: 1, sportag: "atletika", versenyszam: "kalapacsvetes" },
    { helyezes: 1, csapatMeret: 1, sportag: "uszas", versenyszam: "400m_gyorsuszas" },
    { helyezes: 1, csapatMeret: 1, sportag: "birkozas", versenyszam: "kotott_fogas_legsuly" },
    { helyezes: 1, csapatMeret: 1, sportag: "torna", versenyszam: "talajtorna" },
    { helyezes: 1, csapatMeret: 1, sportag: "torna", versenyszam: "felemas_korlat" },
    { helyezes: 1, csapatMeret: 1, sportag: "vivas", versenyszam: "kardvivas_egyeni" },
    { helyezes: 1, csapatMeret: 1, sportag: "okolvivas", versenyszam: "nagyvaltosuly" },
    { helyezes: 1, csapatMeret: 1, sportag: "uszas", versenyszam: "200m_melluszas" },
    { helyezes: 1, csapatMeret: 1, sportag: "birkozas", versenyszam: "kotott_fogas_valtosuly" },
    { helyezes: 1, csapatMeret: 1, sportag: "uszas", versenyszam: "100m_gyorsuszas" },
    { helyezes: 1, csapatMeret: 1, sportag: "sportloveszet", versenyszam: "onmukodo_sportpisztoly" },
    { helyezes: 1, csapatMeret: 15, sportag: "labdarugas", versenyszam: "ferfi_csapat" },
    { helyezes: 1, csapatMeret: 3, sportag: "ottusa", versenyszam: "ferfi_csapat" },
    { helyezes: 1, csapatMeret: 6, sportag: "vivas", versenyszam: "kardvivas_csapat" },
    { helyezes: 1, csapatMeret: 5, sportag: "uszas", versenyszam: "4x100m_gyorsuszo_valto" },
    { helyezes: 1, csapatMeret: 13, sportag: "vizilabda", versenyszam: "ferfi_csapat" },
    { helyezes: 2, csapatMeret: 1, sportag: "ottusa", versenyszam: "ottusa_egyeni" },
    { helyezes: 2, csapatMeret: 1, sportag: "vivas", versenyszam: "torvivas_egyeni" },
    { helyezes: 2, csapatMeret: 1, sportag: "vivas", versenyszam: "kardvivas_egyeni" },
    { helyezes: 2, csapatMeret: 1, sportag: "sportloveszet", versenyszam: "onmukodo_sportpisztoly" },
    { helyezes: 2, csapatMeret: 1, sportag: "uszas", versenyszam: "400m_gyorsuszas" },
    { helyezes: 2, csapatMeret: 1, sportag: "uszas", versenyszam: "200m_melluszas" },
    { helyezes: 2, csapatMeret: 1, sportag: "kajakkenu", versenyszam: "kenu_egyes_10000m" },
    { helyezes: 2, csapatMeret: 1, sportag: "kajakkenu", versenyszam: "kajak_egyes_1000m" },
    { helyezes: 2, csapatMeret: 1, sportag: "birkozas", versenyszam: "kotott_fogas_pehelysuly" },
    { helyezes: 2, csapatMeret: 8, sportag: "torna", versenyszam: "noi_osszetett_csapat" },
    { helyezes: 3, csapatMeret: 1, sportag: "sportloveszet", versenyszam: "sportpisztoly" },
    { helyezes: 3, csapatMeret: 1, sportag: "vivas", versenyszam: "kardvivas_egyeni" },
    { helyezes: 3, csapatMeret: 1, sportag: "atletika", versenyszam: "tavolugras" },
    { helyezes: 3, csapatMeret: 1, sportag: "birkozas", versenyszam: "szabad_fogas_kozepsuly" },
    { helyezes: 3, csapatMeret: 1, sportag: "torna", versenyszam: "felemas_korlat" },
    { helyezes: 3, csapatMeret: 1, sportag: "torna", versenyszam: "osszetett_egyeni" },
    { helyezes: 3, csapatMeret: 1, sportag: "torna", versenyszam: "gerenda" },
    { helyezes: 3, csapatMeret: 1, sportag: "torna", versenyszam: "talajtorna" },
    { helyezes: 3, csapatMeret: 1, sportag: "atletika", versenyszam: "kalapacsvetes" },
    { helyezes: 3, csapatMeret: 1, sportag: "atletika", versenyszam: "50km_gyaloglas" },
    { helyezes: 3, csapatMeret: 1, sportag: "ottusa", versenyszam: "ottusa_egyeni" },
    { helyezes: 3, csapatMeret: 1, sportag: "uszas", versenyszam: "100m_gyorsuszas" },
    { helyezes: 3, csapatMeret: 4, sportag: "atletika", versenyszam: "4x100m_valtofutas" },
    { helyezes: 3, csapatMeret: 2, sportag: "kajakkenu", versenyszam: "kenu_kettes_10000m" },
    { helyezes: 3, csapatMeret: 8, sportag: "torna", versenyszam: "keziszer_csapat" },
    { helyezes: 3, csapatMeret: 6, sportag: "vivas", versenyszam: "torvivas_csapat" },
    { helyezes: 4, csapatMeret: 1, sportag: "torna", versenyszam: "gerenda" },
    { helyezes: 4, csapatMeret: 1, sportag: "uszas", versenyszam: "200m_mell" },
    { helyezes: 4, csapatMeret: 1, sportag: "birkozas", versenyszam: "kotottfogas_felnehezsuly" },
    { helyezes: 4, csapatMeret: 1, sportag: "torna", versenyszam: "talaj" },
    { helyezes: 4, csapatMeret: 1, sportag: "birkozas", versenyszam: "kotottfogas_kozepsuly" },
    { helyezes: 4, csapatMeret: 1, sportag: "birkozas", versenyszam: "kotottfogas_konnyusuly" },
    { helyezes: 5, csapatMeret: 1, sportag: "okolvivas", versenyszam: "pehelysuly" },
    { helyezes: 5, csapatMeret: 1, sportag: "okolvivas", versenyszam: "konnyusuly" },
    { helyezes: 5, csapatMeret: 1, sportag: "uszas", versenyszam: "100m_gyors" },
    { helyezes: 5, csapatMeret: 1, sportag: "atletika", versenyszam: "diszkoszvetes" },
    { helyezes: 5, csapatMeret: 1, sportag: "vivas", versenyszam: "parbajtor_egyeni" },
    { helyezes: 5, csapatMeret: 2, sportag: "kajak kenu", versenyszam: "kenu_kettes_1000m" },
    { helyezes: 5, csapatMeret: 2, sportag: "kerekparozas", versenyszam: "ketuleses_verseny" },
    { helyezes: 5, csapatMeret: 4, sportag: "uszas", versenyszam: "4 200m_gyorsvalto" },
    { helyezes: 5, csapatMeret: 5, sportag: "vivas", versenyszam: "parbajtor_csapat" },
    { helyezes: 6, csapatMeret: 1, sportag: "birkozas", versenyszam: "kotottfogas_legsuly" },
    { helyezes: 6, csapatMeret: 1, sportag: "kajak kenu", versenyszam: "kajak_egyes_500m" },
    { helyezes: 6, csapatMeret: 1, sportag: "torna", versenyszam: "osszetett_egyeni" },
    { helyezes: 6, csapatMeret: 1, sportag: "kerekparozas", versenyszam: "repuloverseny" },
    { helyezes: 6, csapatMeret: 1, sportag: "uszas", versenyszam: "400m_gyors" },
    { helyezes: 6, csapatMeret: 1, sportag: "torna", versenyszam: "felemaskorlat" },
    { helyezes: 6, csapatMeret: 8, sportag: "torna", versenyszam: "osszetett_csapat" },
];

function FuggvenyVisszajelzoSor(tesztNeve, adatBe, elvartEredmeny, fuggvenyhivas) {

    //Tábla elemek létrehozása
    var table = document.querySelector("#testTable");
    var adatSor = table.insertRow();
    var tesztNeveMezo = adatSor.insertCell(0);
    var bemenetMezo = adatSor.insertCell(1);
    var elvartEredmenyMezo = adatSor.insertCell(2);
    var fuggvenyEredmenyMezo = adatSor.insertCell(3)
    var visszajelzesMezo = adatSor.insertCell(4)

    //Teszt paraméterek megadása és megjelenítése
    tesztNeveMezo.innerHTML = `${tesztNeve}`;
    bemenetMezo.innerHTML = `${adatBe}`;
    elvartEredmenyMezo.innerHTML = `${elvartEredmeny}`;
    fuggvenyEredmenyMezo.innerHTML = `${fuggvenyhivas}`
    if (String(elvartEredmeny) == String(fuggvenyhivas)) {
        visszajelzesMezo.innerHTML = `Success`;
    }
    else {
        visszajelzesMezo.innerHTML = `Fail`;
    }
}

//Hibás referencia érték esetén lefutó függvény
function HibasFuggvenyFuggvenyVisszajelzoSor(tesztNeve, adatBe, elvartEredmeny) {
    var table = document.querySelector("#testTable");
    var adatSor = table.insertRow();
    var tesztNeveMezo = adatSor.insertCell(0);
    var bemenetMezo = adatSor.insertCell(1);
    var elvartEredmenyMezo = adatSor.insertCell(2);
    var fuggvenyEredmenyMezo = adatSor.insertCell(3)
    var visszajelzesMezo = adatSor.insertCell(4)

    tesztNeveMezo.innerHTML = `${tesztNeve}`;
    bemenetMezo.innerHTML = `${adatBe}`;
    elvartEredmenyMezo.innerHTML = `${elvartEredmeny}`;
    fuggvenyEredmenyMezo.innerHTML = "Fail";
    visszajelzesMezo.innerHTML = "Fail";
}

function Teszt01() {
    try {
        FuggvenyVisszajelzoSor("1.feladat: Téglatest felszín", "2,3,4", "52", TeglaTestFelszin(2, 3, 4));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("1.feladat: Téglatest felszín", "2,3,4", "52");
    }
}



function Teszt02() {
    try {
        FuggvenyVisszajelzoSor("1.feladat: Téglatest felszín", "1,3,5", "46", TeglaTestFelszin(1, 3, 5));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("1.feladat: Téglatest felszín", "1,3,5", "46");
    }
}


function Teszt03() {
    try {
        FuggvenyVisszajelzoSor("1.feladat: Téglatest felszín", "2,4,8", "112", TeglaTestFelszin(2, 4, 8));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("1.feladat: Téglatest felszín", "2,4,8", "112");
    }
}

function Teszt04() {
    try {
        FuggvenyVisszajelzoSor("2.feladat: Téglatest térfogat", "2,3,4", "24", TeglaTestTerfogat(2, 3, 4));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("2.feladat: Téglatest térfogat", "2,3,4", "24");
    }
}



function Teszt05() {
    try {
        FuggvenyVisszajelzoSor("2.feladat: Téglatest térfogat", "1,3,5", "15", TeglaTestTerfogat(1, 3, 5));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("2.feladat: Téglatest térfogat", "1,3,5", "15");
    }
}


function Teszt06() {
    try {
        FuggvenyVisszajelzoSor("2.feladat: Téglatest térfogat", "2,4,8", "64", TeglaTestTerfogat(2, 4, 8));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("2.feladat: Téglatest térfogat", "2,4,8", "64");
    }
}

function Teszt07() {
    try {
        FuggvenyVisszajelzoSor("3.feladat: Ph érték", "9", "lugos", PhErtek(9));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("3.feladat: Ph érték", "9", "lugos");
    }
}
function Teszt08() {
    try {
        FuggvenyVisszajelzoSor("3.feladat: Ph érték", "7", "semleges", PhErtek(7));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("3.feladat: Ph érték", "7", "semleges");
    }
}
function Teszt09() {
    try {
        FuggvenyVisszajelzoSor("3.feladat: Ph érték", "5.5", "savas", PhErtek(5.5));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("3.feladat: Ph érték", "5.5", "savas");
    }
}

function Teszt10() {
    try {
        FuggvenyVisszajelzoSor("4.feladat: Első N szám összege", "3", "6", ElsoNSzamOsszege(3));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("4.feladat: Első N szám összege", "3", "6");
    }
}

function Teszt11() {
    try {
        FuggvenyVisszajelzoSor("4.feladat: Első N szám összege", "10", "55", ElsoNSzamOsszege(10));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("4.feladat: Első N szám összege", "10", "55");
    }
}

function Teszt12() {
    try {
        FuggvenyVisszajelzoSor("4.feladat: Első N szám összege", "21", "231", ElsoNSzamOsszege(21));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("4.feladat: Első N szám összege", "21", "231");
    }
}


function Teszt13() {
    try {
        FuggvenyVisszajelzoSor("5.feladat: Prímek száma", "[13, 7, 12, 15]", "2", PrimekSzama([13, 7, 12, 15]));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("5.feladat: Prímek száma", "[13, 7, 12, 15]", "2");
    }
}

function Teszt14() {
    try {
        FuggvenyVisszajelzoSor("5.feladat: Prímek száma", "[1, 5, 17, 29]", "3", PrimekSzama([1, 5, 17, 29]));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("5.feladat: Prímek száma", "[1, 5, 17, 29]", "3");
    }
}

function Teszt15() {
    try {
        FuggvenyVisszajelzoSor("5.feladat: Prímek száma", "[2, 3, 7, 11]", "4", PrimekSzama([2, 3, 7, 11]));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("5.feladat: Prímek száma", "[2, 3, 7, 11]", "4");
    }
}

function Teszt16() {
    try {
        FuggvenyVisszajelzoSor("5.feladat: Prímek száma", "[1, 2, 3, 14]", "2", PrimekSzama([1, 2, 3, 14]));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("5.feladat: Prímek száma", "[1, 2, 3, 14]", "2");
    }
}

function Teszt17() {
    try {
        FuggvenyVisszajelzoSor("6.feladat: Ékezetes betűk száma", "Szeretem a programozást", "1", EkezetesBetukSzama("Szeretem a programozást"));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("6.feladat: Ékezetes betűk száma", "Szeretem a programozást", "1");
    }
}

function Teszt18() {
    try {
        FuggvenyVisszajelzoSor("6.feladat: Ékezetes betűk száma", "Géza kék az ég", "3", EkezetesBetukSzama("Géza kék az ég"));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("6.feladat: Ékezetes betűk száma", "Géza kék az ég", "3");
    }
}

function Teszt19() {
    try {
        FuggvenyVisszajelzoSor("6.feladat: Ékezetes betűk száma", "Répa, retek, mogyoró", "2", EkezetesBetukSzama("Répa, retek, mogyoró"));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("6.feladat: Ékezetes betűk száma", "Répa, retek, mogyoró", "2");
    }
}

function Teszt20() {
    try {
        FuggvenyVisszajelzoSor("7.feladat: Szám visszafelé", "2024", "4202", SzamVisszafele(2024));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("7.feladat: Szám visszafelé", "2024", "4202");
    }
}

function Teszt21() {
    try {
        FuggvenyVisszajelzoSor("7.feladat: Szám visszafelé", "1222", "2221", SzamVisszafele(1222));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("7.feladat: Szám visszafelé", "1222", "2221");
    }
}

function Teszt22() {
    try {
        FuggvenyVisszajelzoSor("7.feladat: Szám visszafelé", "1848", "8481", SzamVisszafele(1848));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("7.feladat: Szám visszafelé", "1848", "8481");
    }
}

function Teszt23() {
    try {
        FuggvenyVisszajelzoSor("8.feladat: Sportág helyezések", "helsinki, torna, 1", "2", SportagHelyezesek(helsinki, "torna", 1));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("8.feladat: Sportág helyezések", "helsinki, torna, 1", "2");
    }
}

function Teszt24() {
    try {
        FuggvenyVisszajelzoSor("8.feladat: Sportág helyezések", "helsinki, ottusa, 1", "1", SportagHelyezesek(helsinki, "ottusa", 1));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("8.feladat: Sportág helyezések", "helsinki, ottusa, 1", "1");
    }
}

function Teszt25() {
    try {
        FuggvenyVisszajelzoSor("8.feladat: Sportág helyezések", "helsinki, uszas, 2", "2", SportagHelyezesek(helsinki, "uszas", 2));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("8.feladat: Sportág helyezések", "helsinki, uszas, 2", "2");
    }
}

function Teszt26() {
    try {
        FuggvenyVisszajelzoSor("8.feladat: Sportág helyezések", "helsinki, atletika, 3", "4", SportagHelyezesek(helsinki, "atletika", 3));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("8.feladat: Sportág helyezések", "helsinki, atletika, 3", "4");
    }
}
function TesztFuttato() {
    Teszt01();
    Teszt02();
    Teszt03();
    Teszt04();
    Teszt05();
    Teszt06();
    Teszt07();
    Teszt08();
    Teszt09();
    Teszt10();
    Teszt11();
    Teszt12();
    Teszt13();
    Teszt14();
    Teszt15();
    Teszt16();
    Teszt17();
    Teszt18();
    Teszt19();
    Teszt20();
    Teszt21();
    Teszt22();
    Teszt23();
    Teszt24();
    Teszt25();
    Teszt26();
}
TesztFuttato();