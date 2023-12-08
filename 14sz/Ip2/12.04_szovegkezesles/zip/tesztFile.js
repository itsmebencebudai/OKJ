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
    if (elvartEredmeny == fuggvenyhivas) {
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
        FuggvenyVisszajelzoSor("Kocka felszín", 2, 24, KockaFelszin(2));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Kocka felszín", 2, 24);
    }
}

function Teszt02() {
    try {
        FuggvenyVisszajelzoSor("Kocka felszín", 3, 54, KockaFelszin(3));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Kocka felszín", 3, 54);
    }
}
function Teszt03() {
    try {
        FuggvenyVisszajelzoSor("Kocka felszín", 5, 150, KockaFelszin(5));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Kocka felszín", 5, 150);
    }
}

function Teszt04() {
    try {
        FuggvenyVisszajelzoSor("Kocka térfogat", 2, 8, KockaTerfogat(2));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Kocka térfogat", 2, 8);
    }
}

function Teszt05() {
    try {
        FuggvenyVisszajelzoSor("Kocka térfogat", 3, 27, KockaTerfogat(3));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Kocka térfogat", 3, 27);
    }
}

function Teszt06() {
    try {
        FuggvenyVisszajelzoSor("Kocka térfogat", 5, 125, KockaTerfogat(5));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Kocka térfogat", 2, 125);
    }
}

function Teszt07() {
    try {
        FuggvenyVisszajelzoSor("PhÉrték", 9, "lugos", PhErtek(9));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("PhÉrték", 9, "lugos");
    }
}
function Teszt08() {
    try {
        FuggvenyVisszajelzoSor("PhÉrték", 5.5, "savas", PhErtek(5.5));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("PhÉrték", 5.5, "savas");
    }
}
function Teszt09() {
    try {
        FuggvenyVisszajelzoSor("PhÉrték", 7, "semleges", PhErtek(7));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("PhÉrték", 7, "semlegess");
    }
}

function Teszt10() {
    try {
        FuggvenyVisszajelzoSor("Első N szám összege", 3, 6, ElsoNSzamOsszege(3));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Első N szám összege", 3, 6);
    }
}

function Teszt11() {
    try {
        FuggvenyVisszajelzoSor("Első N szám összege", 10, 55, ElsoNSzamOsszege(10));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Első N szám összege", 10, 55);
    }
}


function Teszt12() {
    try {
        FuggvenyVisszajelzoSor("Első N szám összege", 21, 231, ElsoNSzamOsszege(21));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Első N szám összege", 21, 231);
    }
}


function Teszt13() {
    try {
        FuggvenyVisszajelzoSor("Max páros szám", "12,3,7,19,21", 12, MaxParos([12, 3, 7, 19, 21]));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Max páros szám", "12,3,7,19,21", 12);
    }
}

function Teszt14() {
    try {
        FuggvenyVisszajelzoSor("Max páros szám", "28,14,2,42,69", 42, MaxParos([28, 14, 2, 42, 69]));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Max páros szám", "28,14,2,42,69", 42);
    }
}

function Teszt15() {
    try {
        FuggvenyVisszajelzoSor("Max páros szám", "32,21,54,33,21", 54, MaxParos([32, 21, 54, 33, 21]));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Max páros szám", "32,21,54,33,21", 54);
    }
}
function Teszt16() {
    try {
        FuggvenyVisszajelzoSor("Mássalhangzók száma", "Javascript", 7, MassalHangzokSzama("Javascript"));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Mássalhangzók száma", "Javascript", 7);
    }
}

function Teszt17() {
    try {
        FuggvenyVisszajelzoSor("Mássalhangzók száma", "Géza kék az ég", 6, MassalHangzokSzama("Géza kék az ég"));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Mássalhangzók száma", "Géza kék az ég", 6);
    }
}
function Teszt18() {
    try {
        FuggvenyVisszajelzoSor("Mássalhangzók száma", "Minta Márton", 7, MassalHangzokSzama("Minta Márton"));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Mássalhangzók száma", "Minta Márton", 7);
    }
}


function Teszt19() {
    try {
        FuggvenyVisszajelzoSor("Szöveg visszafelé", "Szeretem a programozás", "sázomargorp a meterezS", SzovegVisszafele("Szeretem a programozás"));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Szöveg visszefelé", "Szeretem a programozás", "sázomargorp a meterezS");
    }
}

function Teszt20() {
    try {
        FuggvenyVisszajelzoSor("Szöveg visszafelé", "Géza kék az ég", "gé za kék azéG", SzovegVisszafele("Géza kék az ég"));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Szöveg visszefelé", "Géza kék az ég", "gé za kék azéG");
    }
}

function Teszt21() {
    try {
        FuggvenyVisszajelzoSor("Szöveg visszafelé", "Répa, retek, mogyoró", "óroygom ,keter ,apéR", SzovegVisszafele("Répa, retek, mogyoró"));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Szöveg visszefelé", "Répa, retek, mogyoró", "óroygom ,keter ,apéR”");
    }
}


function Teszt22() {
    try {
        FuggvenyVisszajelzoSor("Prímek száma a tömbben", "13, 7, 12, 15", 2, PrimekSzama([13, 7, 12, 15]));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Prímek száma a tömbben", "13, 7, 12, 15", 2);
    }
}

function Teszt23() {
    try {
        FuggvenyVisszajelzoSor("Prímek száma a tömbben", "1, 5, 17, 29", 3, PrimekSzama([1, 5, 17, 29]));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Prímek száma a tömbben", "1, 5, 17, 29", 3);
    }
}

function Teszt24() {
    try {
        FuggvenyVisszajelzoSor("Prímek száma a tömbben", "2, 3, 7, 11", 4, PrimekSzama([2, 3, 7, 11]));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Prímek száma a tömbben", "2, 3, 7, 11", 4);
    }
}
function Teszt25() {
    try {
        FuggvenyVisszajelzoSor("Prímek száma a tömbben", "1, 2, 3, 14", 2, PrimekSzama([1, 2, 3, 14]));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Prímek száma a tömbben", "1, 2, 3, 14", 2);
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

}
TesztFuttato();