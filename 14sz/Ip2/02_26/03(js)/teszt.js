//Vizsgált objektum:
const szavazatok = [
    { korzet: 5, szavazat: 19, nev: "Ablak Antal", part: "-" },
    { korzet: 1, szavazat: 120, nev: " Alma Dalma", part: "GYEP" },
    { korzet: 7, szavazat: 162, nev: " Bab Zsuzsanna", part: "ZEP" },
    { korzet: 2, szavazat: 59, nev: "Barack Barna", part: "GYEP" },
    { korzet: 6, szavazat: 73, nev: "Birs Helga", part: "GYEP" },
    { korzet: 1, szavazat: 154, nev: " Bors Botond", part: "HEP" },
    { korzet: 5, szavazat: 188, nev: " Brokkoli Gyula", part: "ZEP" },
    { korzet: 6, szavazat: 29, nev: "Ceruza Zsombor", part: "-" },
    { korzet: 4, szavazat: 143, nev: " Fasirt Ferenc", part: "HEP" },
    { korzet: 8, szavazat: 157, nev: " Gomba Gitta", part: "TISZ" },
    { korzet: 3, szavazat: 13, nev: "Halmi Helga", part: "-" },
    { korzet: 2, szavazat: 66, nev: "Hold Ferenc", part: "-" },
    { korzet: 7, szavazat: 34, nev: "Hurka Herold", part: "HEP" },
    { korzet: 5, szavazat: 288, nev: " Joghurt Jakab", part: "TISZ" },
    { korzet: 4, szavazat: 77, nev: "Kajszi Kolos", part: "GYEP" },
    { korzet: 2, szavazat: 187, nev: " Kapor Karola", part: "ZEP" },
    { korzet: 6, szavazat: 13, nev: "Karfiol Ede", part: "ZEP" },
    { korzet: 6, szavazat: 187, nev: " Kefir Ilona", part: "TISZ" },
    { korzet: 7, szavazat: 130, nev: " Kupa Huba", part: "-" },
    { korzet: 8, szavazat: 98, nev: "Languszta Auguszta", part: "-" },
    { korzet: 1, szavazat: 34, nev: "Lila Lilla", part: "-" },
    { korzet: 1, szavazat: 56, nev: "Medve Rudolf", part: "-" },
    { korzet: 5, szavazat: 67, nev: "Meggy Csilla", part: "GYEP" },
    { korzet: 3, szavazat: 45, nev: "Moly Piroska", part: "-" },
    { korzet: 4, szavazat: 221, nev: " Monitor Tibor", part: "-" },
    { korzet: 8, szavazat: 288, nev: " Narancs Edmond", part: "GYEP" },
    { korzet: 2, szavazat: 220, nev: " Oldalas Olga", part: "HEP" },
    { korzet: 3, szavazat: 185, nev: " Pacal Kata", part: "HEP" },
    { korzet: 1, szavazat: 199, nev: " Petrezselyem Petra", part: "ZEP" },
    { korzet: 8, szavazat: 77, nev: "Pokol Vidor", part: "-" },
    { korzet: 8, szavazat: 67, nev: "Ragu Ida", part: "HEP" },
    { korzet: 3, szavazat: 156, nev: " Retek Etelka", part: "ZEP" },
    { korzet: 7, szavazat: 129, nev: " Sajt Hajnalka", part: "TISZ" },
    { korzet: 4, szavazat: 38, nev: "Simon Simon", part: "-" },
    { korzet: 3, szavazat: 87, nev: "Szilva Szilvia", part: "GYEP" },
    { korzet: 3, szavazat: 187, nev: " Tejes Attila", part: "TISZ" },
    { korzet: 2, szavazat: 65, nev: "Tejfel Edit", part: "TISZ" },
    { korzet: 4, szavazat: 39, nev: "Uborka Ubul", part: "ZEP" },
    { korzet: 6, szavazat: 288, nev: " Vadas Marcell", part: "HEP" },
    { korzet: 5, szavazat: 68, nev: "Vagdalt Edit", part: "HEP" },
];

function FuggvenyVisszajelzoSor(tesztNeve, adatBe, elvartEredmeny, fuggvenyhivas) {

    //Tábla elemek létrehozása
    var table = document.querySelector("#testTable");
    var adatSor = table.insertRow(1);
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
    var adatSor = table.insertRow(1);
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
        FuggvenyVisszajelzoSor("Páros számok feladat", "10,20", [10, 12, 14, 16, 18, 20], ParosSzamok(10, 20));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Páros számok feladat", "10,20", [10, 12, 14, 16, 18, 20]);
    }
}


function Teszt02() {
    try {
        FuggvenyVisszajelzoSor("Páros számok feladat", "42, 56", [42, 44, 46, 48, 50, 52, 54, 56], ParosSzamok(42, 56));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Páros számok feladat", "42, 56", [42, 44, 46, 48, 50, 52, 54, 56]);
    }

}

function Teszt03() {
    try {
        FuggvenyVisszajelzoSor("Páros számok feladat", "3, 9", [4, 6, 8], ParosSzamok(3, 9));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Páros számok feladat", "3, 9", [4, 6, 8]);
    }
}



function Teszt04() {
    try {
        FuggvenyVisszajelzoSor("snake_case_szoveg feladat", "Hello World!", "hello_world!", snake_case_szoveg("Hello World!"));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("snake_case_szoveg feladat", "Hello World!", "hello_world!");
    }
}

function Teszt05() {
    try {
        FuggvenyVisszajelzoSor("snake_case_szoveg feladat", "Junior Frontend Vizsga", "junior_frontend_vizsga", snake_case_szoveg("Junior Frontend Vizsga"));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("snake_case_szoveg feladat", "Junior Frontend Vizsga", "junior_frontend_vizsga");
    }
}

function Teszt06() {
    try {
        FuggvenyVisszajelzoSor("snake_case_szoveg feladat", "Snake Case Szoveg", "snake_case_szoveg", snake_case_szoveg("Snake Case Szoveg"));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("snake_case_szoveg feladat", "Snake Case Szoveg", "snake_case_szoveg");
    }
}




function Teszt07() {
    try {
        FuggvenyVisszajelzoSor("Képviselők száma feladat", "szavazatok, ZEP", 7, KepviselokSzama(szavazatok, "ZEP"));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Képviselők száma feladat", "szavazatok, ZEP", 7);
    }
}

function Teszt08() {
    try {
        FuggvenyVisszajelzoSor("Képviselők száma feladat", "szavazatok, HEP", 8, KepviselokSzama(szavazatok, "HEP"));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Képviselők száma feladat", "szavazatok, HEP", 8);
    }
}

function Teszt09() {
    try {
        FuggvenyVisszajelzoSor("Képviselők száma feladat", "szavazatok, GYEP", 7, KepviselokSzama(szavazatok, "GYEP"));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Képviselők száma feladat", "szavazatok, GYEP", 7);
    }
}

function Teszt10() {
    try {
        FuggvenyVisszajelzoSor("Képviselők száma feladat", "szavazatok, TISZ", 6, KepviselokSzama(szavazatok, "TISZ"));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Képviselők száma feladat", "szavazatok, TISZ", 6);
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
}
TesztFuttato();