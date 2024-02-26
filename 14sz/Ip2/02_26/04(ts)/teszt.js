
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
        FuggvenyVisszajelzoSor("Kocka térfogat feladat", 5, 125, KockaTerfogat(5));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Kocka térfogat feladat", 5, 125);
    }
}


function Teszt02() {
    try {
        FuggvenyVisszajelzoSor("Kocka térfogat feladat", 3, 27, KockaTerfogat(3));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Kocka térfogat feladat", 3, 27);
    }
}


function Teszt03() {
    try {
        FuggvenyVisszajelzoSor("Kocka térfogat feladat", 2, 8, KockaTerfogat(2));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Kocka térfogat feladat", 2, 8);
    }
}





function Teszt04() {
    try {
        FuggvenyVisszajelzoSor("Számtani sorozat-e?", "2, 4, 6", true, Szamtani(2, 4, 6));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Számtani sorozat-e?", "2, 4, 6", true);
    }
}


function Teszt05() {
    try {
        FuggvenyVisszajelzoSor("Számtani sorozat-e?", "3, 5, 9", false, Szamtani(3, 5, 9));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Számtani sorozat-e?", "3, 5, 9", false);
    }
}


function Teszt06() {
    try {
        FuggvenyVisszajelzoSor("Számtani sorozat-e?", "7, 11, 21", false, Szamtani(7, 11, 21));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Számtani sorozat-e?", "7, 11, 21", false);
    }
}


function Teszt07() {
    try {
        FuggvenyVisszajelzoSor("Számtani sorozat-e?", "1, 11, 21", true, Szamtani(1, 11, 21));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Számtani sorozat-e?", "1, 11, 21", true);
    }
}




function Teszt08() {
    try {
        FuggvenyVisszajelzoSor("Ékezet nélküliek mennyisége feladat", "[Álmos, ács, madár]", 0, EkezetNelkuliekMennyisege(["Álmos", "ács", "madár"]));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Ékezet nélküliek mennyisége feladat", "[Álmos, ács, madár]", 0);
    }
}

function Teszt09() {
    try {
        FuggvenyVisszajelzoSor("Ékezet nélküliek mennyisége feladat", "[Alma, Barack, Banán]", 2, EkezetNelkuliekMennyisege(["Alma", "Barack", "Banán"]));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Ékezet nélküliek mennyisége feladat", "[Alma, Barack, Banán]", 2);
    }
}


function Teszt10() {
    try {
        FuggvenyVisszajelzoSor("Ékezet nélküliek mennyisége feladat", "[Feri, Éva, Ádám]", 1, EkezetNelkuliekMennyisege(["Feri", "Éva", "Ádám"]));
    }
    catch {
        HibasFuggvenyFuggvenyVisszajelzoSor("Ékezet nélküliek mennyisége feladat", "[Feri, Éva, Ádám]", 1);
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