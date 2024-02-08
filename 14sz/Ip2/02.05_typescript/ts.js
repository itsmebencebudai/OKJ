function Erdemjegy(jegy) {
    if (jegy == 1) {
        console.log("Elégtelen");
    }
    else if (jegy == 2) {
        console.log("Elégséges");
    }
    else if (jegy == 3) {
        console.log("Közepes");
    }
    else if (jegy == 4) {
        console.log("Jó");
    }
    else if (jegy == 5) {
        console.log("Jeles");
    }
}
Erdemjegy(3);
function Prim(szam) {
    for (var j = 2; j < Math.sqrt(szam); j++) {
        if (szam % j == 0) {
            console.log(szam + " nem prímszám");
        }
        else {
            console.log("A " + szam + " prímszám");
        }
    }
}
Prim(11);
function TombGenerator(meret, also, felso) {
    var Tomb = [];
    for (var i = 0; i < meret; i++) {
        Tomb.push(Math.floor((Math.random() * (felso - also + 1)) + also));
    }
    return Tomb;
}
console.log(TombGenerator(10, 10, 80));
