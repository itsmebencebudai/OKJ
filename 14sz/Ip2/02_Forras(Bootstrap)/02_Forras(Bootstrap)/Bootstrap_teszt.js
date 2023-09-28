function ujVisszajelzoSor(tesztneve, visszajelzes) {
    var table = document.querySelector("#testTable");
    var adatSor = table.insertRow(1);
    var tesztNeveMezo = adatSor.insertCell(0);
    var visszajelzesMezo = adatSor.insertCell(1);
    tesztNeveMezo.innerHTML = `${tesztneve}`;
    visszajelzesMezo.innerHTML = `${visszajelzes}`;
}

function teszt01() {
    try {
        let tesztElem = document.querySelector("div");
        if (tesztElem.classList == "container") {
            ujVisszajelzoSor("Oldal fő tartalmának igazítása", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Oldal fő tartalmának igazítása", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Oldal fő tartalmának igazítása", "HIBA");
    }
}

function teszt02() {
    try {
        let tesztElem = document.querySelector("h1");
        if (tesztElem.classList.contains("text-center")) {
            ujVisszajelzoSor("1-es szintű címsor  igazítása", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("1-es szintű címsor  igazítása", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("1-es szintű címsor  igazítása", "HIBA");
    }
}

function teszt03() {
    try {
        let tesztElem = document.querySelector("h1");
        if (tesztElem.classList.contains("mt-1")) {
            ujVisszajelzoSor("1-es szintű címsor felső margó", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("1-es szintű címsor felső margó", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("1-es szintű címsor felső margó", "HIBA");
    }
}

function teszt04() {
    try {
        let tesztElem = document.querySelector("h1");
        if (tesztElem.classList.contains("mb-5")) {
            ujVisszajelzoSor("1-es szintű címsor alsó margó", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("1-es szintű címsor alsó margó", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("1-es szintű címsor alsó margó", "HIBA");
    }
}



function teszt05() {
    try {
        let tesztElem = document.querySelector("table");
        if (tesztElem.classList.contains("table")) {
            ujVisszajelzoSor("Táblázat alap bootstrap osztálya", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Táblázat alap bootstrap osztálya", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Táblázat alap bootstrap osztálya", "HIBA");
    }
}
function teszt06() {
    try {
        let tesztElem = document.querySelector("thead");
        if (tesztElem.classList.contains("table-primary")) {
            ujVisszajelzoSor("Táblázat fejlécének színe", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Táblázat fejlécének színe", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Táblázat fejlécének színe", "HIBA");
    }
}

function teszt07() {
    try {
        let tesztElem = document.querySelector("tfoot");
        if (tesztElem.classList.contains("table-info")) {
            ujVisszajelzoSor("Táblázat láblécének színe", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Táblázat láblécének színe", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Táblázat láblécének színe", "HIBA");
    }
}
function teszt08() {
    try {
        let tesztElem = document.querySelector("table");
        if (tesztElem.classList.contains("table-striped")) {
            ujVisszajelzoSor("Táblázat csíkozása", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Táblázat csíkozása", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Táblázat csíkozása", "HIBA");
    }
}

function teszt09() {
    try {
        let tesztElem = document.querySelector("table");
        if (tesztElem.classList.contains("table-hover")) {
            ujVisszajelzoSor("Táblázati sor kiemelése ha felé megyünk egérrel", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Táblázati sor kiemelése ha felé megyünk egérrel", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Táblázati sor kiemelése ha felé megyünk egérrel", "HIBA");
    }
}

function teszt10() {
    try {
        let tesztElem = document.querySelectorAll("#vizsgainfo tr");
        if (tesztElem.length == 8) {
            ujVisszajelzoSor("Táblázatban lévő sorok száma", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Táblázatban lévő sorok száma", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Táblázatban lévő sorok száma", "HIBA");
    }
}

function teszt11() {
    try {
        let tesztElem = document.querySelectorAll("#vizsgainfo th");
        if (tesztElem.length == 3) {
            ujVisszajelzoSor("Fejléc cellák mennyisége", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Fejléc cellák mennyisége", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Fejléc cellák mennyisége", "HIBA");
    }
}

function teszt12() {
    try {
        let tesztElem = document.querySelectorAll("#vizsgainfo td");
        if (tesztElem.length == 21) {
            ujVisszajelzoSor("Adat cellák mennyisége", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Adat cellák mennyisége", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Adat cellák mennyisége", "HIBA");
    }
}
function teszt13() {
    try {
        if (document.querySelector("#vizsgainfo") != null) {
            ujVisszajelzoSor("Táblázat megfelelő azonosítóval létrehozva", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Táblázat megfelelő azonosítóval létrehozva", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Táblázat megfelelő azonosítóval létrehozva", "HIBA");
    }
}
function teszt14() {
    try {
        let tesztElem = document.querySelectorAll("thead th");
        if (tesztElem[0].innerHTML == "Modul neve" && tesztElem[1].innerHTML == "Szerezhető pontszám" && tesztElem[2].innerHTML == "Időtartam") {
            ujVisszajelzoSor("Fejléc cellák tartalma", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Fejléc cellák tartalma", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Fejléc cellák tartalma", "HIBA");
    }
}
function teszt15() {
    try {
        let tesztElem = document.querySelectorAll("tfoot td");
        if (tesztElem[0].innerHTML == "Összesen" && tesztElem[1].innerHTML == "100 pont" && tesztElem[2].innerHTML == "180 perc") {
            ujVisszajelzoSor("Lábléc cellák tartalma", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Lábléc cellák tartalma", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Lábléc cellák tartalma", "HIBA");
    }
}

function allTeszt() {
    teszt01();
    teszt02();
    teszt03();
    teszt04();
    teszt05();
    teszt06();
    teszt07();
    teszt08();
    teszt09();
    teszt10();
    teszt11();
    teszt12();
    teszt13();
    teszt14();
    teszt15();
}
allTeszt();