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
        let tesztElem = document.querySelector("h1");
        if (tesztElem.innerHTML == "W3Schools") {
            ujVisszajelzoSor("1-es szintű címsor tartalma", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("1-es szintű címsor tartalma", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("1-es szintű címsor tartalma", "HIBA");
    }
}

function teszt02() {
    try {
        let tesztElem = document.querySelector("h2");
        if (tesztElem.innerHTML == "A W3Schools az alábbiakban nyújt segítséget:") {
            ujVisszajelzoSor("2-es szintű címsor tartalma", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("2-es szintű címsor tartalma", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("2-es szintű címsor tartalma", "HIBA");
    }
}



function teszt03() {
    try {
        let tesztElem = document.querySelectorAll("img");
        if (tesztElem[0].src.includes("W3Schools_logo.png")) {
            ujVisszajelzoSor("W3Schools_logo forrás", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("W3Schools_logo forrás", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("W3Schools_logo forrás", "HIBA");
    }
}

function teszt04() {
    try {
        let tesztElem = document.querySelectorAll("img");
        if (tesztElem[0].alt == "W3Schools logo") {
            ujVisszajelzoSor("W3Schools_logo kép alternatív szöveg", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("W3Schools_logo kép alternatív szöveg", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("W3Schools_logo kép alternatív szöveg", "HIBA");
    }
}

function teszt05() {
    try {
        let tesztElem = document.querySelectorAll("img");
        if (tesztElem[0].title == "W3Schools logo") {
            ujVisszajelzoSor("W3Schools_logo kép címke", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("W3Schools_logo kép címke", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("W3Schools_logo kép címke", "HIBA");
    }
}

function teszt06() {
    try {
        let tesztElem = document.querySelectorAll("b");
        if (tesztElem[0].innerHTML == "Interaktív oktatóanyagok:") {
            ujVisszajelzoSor("Félkövér kiemelés első listaelemnél", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Félkövér kiemelés első listaelemnél", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Félkövér kiemelés első listaelemnél", "HIBA");
    }
}

function teszt07() {
    try {
        let tesztElem = document.querySelectorAll("b");
        if (tesztElem[1].innerHTML == "Kód példák és demók:") {
            ujVisszajelzoSor("Félkövér kiemelés második listaelemnél", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Félkövér kiemelés második listaelemnél", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Félkövér kiemelés második listaelemnél", "HIBA");
    }
}

function teszt08() {
    try {
        let tesztElem = document.querySelectorAll("b");
        if (tesztElem[2].innerHTML == "API dokumentáció és referenciák:") {
            ujVisszajelzoSor("Félkövér kiemelés harmadik listaelemnél", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Félkövér kiemelés harmadik listaelemnél", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Félkövér kiemelés harmadik listaelemnél", "HIBA");
    }
}

function teszt09() {
    try {
        let tesztElem = document.querySelectorAll("b");
        if (tesztElem[3].innerHTML == "Praktikus segédletek:") {
            ujVisszajelzoSor("Félkövér kiemelés negyedik listaelemnél", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Félkövér kiemelés negyedik listaelemnél", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Félkövér kiemelés negyedik listaelemnél", "HIBA");
    }
}


function teszt10() {
    try {
        let tesztElem = document.querySelectorAll("a");
        if (tesztElem[0].href == "https://www.w3schools.com/html/default.asp") {
            ujVisszajelzoSor("HTML forrás link útvonal", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("HTML forrás link útvonal", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("HTML forrás link útvonal", "HIBA");
    }
}

function teszt11() {
    try {
        let tesztElem = document.querySelectorAll("a");
        if (tesztElem[1].href == "https://www.w3schools.com/css/default.asp") {
            ujVisszajelzoSor("CSS forrás link útvonal", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("CSS forrás link útvonal", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("CSS forrás link útvonal", "HIBA");
    }
}

function teszt12() {
    try {
        let tesztElem = document.querySelectorAll("a");
        if (tesztElem[0].target == "_blank" && tesztElem[1].target == "_blank") {
            ujVisszajelzoSor("Linkek új ablakban", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Linkek új ablakban", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Linkek új ablakban", "HIBA");
    }
}

function teszt13() {
    try {
        let tesztElem = document.querySelectorAll("p");
        if (tesztElem[2].classList == "forras" && tesztElem[3].classList == "forras") {
            ujVisszajelzoSor("Link bekezdésekhez tartozó osztály", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Link bekezdésekhez tartozó osztály", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Link bekezdésekhez tartozó osztály", "HIBA");
    }
}

function teszt14() {
    try {
        let tesztElem = document.querySelectorAll("p");
        if (tesztElem[0].style.textIndent == "20px" && tesztElem[1].style.textIndent == "20px") {
            ujVisszajelzoSor("Első sori behúzás első 2 bekezdés esetén", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Első sori behúzás első 2 bekezdés esetén", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Első sori behúzás első 2 bekezdés esetén", "HIBA");
    }
}

function teszt15() {
    try {
        let tesztElem = document.querySelector("#igazito");
        if (tesztElem != null) {
            ujVisszajelzoSor("Külső igazító DIV elem", "Megfelelő");
        }
        else {
            ujVisszajelzoSor("Külső igazító DIV elem", "NEM megfelelő");
        }
    }
    catch {
        ujVisszajelzoSor("Külső igazító DIV elem", "HIBA");
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
