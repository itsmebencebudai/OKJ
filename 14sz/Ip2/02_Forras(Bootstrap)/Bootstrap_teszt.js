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
        let tesztElem = document.querySelectorAll("input");
        if (tesztElem[0].type == "text") {
            ujVisszajelzoSor("Felhasználói név mező típusa", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Felhasználói név mező típusa", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Felhasználói név mező típusa", "HIBA");
    }
}


function teszt06() {
    try {
        let tesztElem = document.querySelectorAll("input");
        if (tesztElem[1].type == "email") {
            ujVisszajelzoSor("E-mail mező típusa", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("E-mail mező típusa", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("E-mail mező típusa", "HIBA");
    }
}

function teszt07() {
    try {
        let tesztElem = document.querySelectorAll("input");
        if (tesztElem[0].id == "nevMezo") {
            ujVisszajelzoSor("Felhasználói név mező azonosítója", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Felhasználói név mező azonosítója", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Felhasználói név mező azonosítója", "HIBA");
    }
}



function teszt08() {
    try {
        let tesztElem = document.querySelectorAll("input");
        if (tesztElem[1].id == "emailMezo") {
            ujVisszajelzoSor("E-mail mező azonosítója", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("E-mail mező azonosítója", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("E-mail mező azonosítója", "HIBA");
    }
}

function teszt09() {
    try {
        let tesztElem = document.querySelector("button");
        if (tesztElem.classList.contains("btn-success")) {
            ujVisszajelzoSor("Gomb kinézete", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Gomb kinézete", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Gomb kinézete", "HIBA");
    }
}
function teszt10() {
    try {
        let tesztElem = document.querySelector("button");
        if (tesztElem.classList.contains("form-control")) {
            ujVisszajelzoSor("Gomb mérete", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Gomb mérete", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Gomb mérete", "HIBA");
    }
}
function teszt11() {
    try {
        let tesztElem = document.querySelector("button");
        if (tesztElem.classList.contains("mt-5")) {
            ujVisszajelzoSor("Gomb igazítása", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Gomb igazítása", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Gomb igazítása", "HIBA");
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
}
allTeszt();