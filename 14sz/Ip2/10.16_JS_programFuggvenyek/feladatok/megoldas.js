function feladat1() {
    var nev = "Nev: Budai Bence";
    var csoport = "Csoport: 14sz";
    var html = "HTML: 90"
    var css = "CSS: 80";
    var js = "Js: 75";

    document.write("Feladat 1: " + nev + " " + csoport + " " + html + " " + css + " " + js)
}
feladat1();
document.write("<br>");


function feladat2(szam, hatvanymertek) {
    var eredmeny = Math.sqrt(szam, hatvanymertek);
    return eredmeny;
}
const szam = prompt('Kérem a számot: ');
const hatvanymertek = prompt('Kérem a hatvanymertek: ');
document.write("Feladat 2: " + feladat2(5, 5));
document.write("<br>");


function feladat3(alsohatar, felsohatar) {
    let randomszam;
    do {
        randomszam = Math.round(Math.random() * [felsohatar - alsohatar] + alsohatar);
    } while (randomszam % 2 !== 0)
    return randomszam;

}
const alsohatar = prompt("Kérem az alsóhatárt: ");
const felsohatar = prompt("Kérem az felsőhatárt: ");
document.write("Feladat 3: " + feladat3(alsohatar, felsohatar));
document.write("<br>");

function feladat4(eletkor) {
    let besorolas
    if (eletkor < 0 || eletkor > 120) {
        if (eletkor >= 0 && eletkor <= 6) {
            besorolas = "Kisgyermekkor";
        } else if (eletkor <= 12) {
            besorolas = "Gyermekkor";
        } else if (eletkor <= 16) {
            besorolas = "Serdülőkor";
        } else if (eletkor <= 20) {
            besorolas = "Ifjúkor";
        } else if (eletkor <= 30) {
            besorolas = "Fiatal felnőtt kor";
        } else if (eletkor <= 60) {
            besorolas = "Felnőtt kor";
        } else {
            besorolas = "Aggkor";
        }
    }
    return besorolas;
}
const eletkor = prompt("Kérem az életkort: ");
document.write("Feladat 4: " + feladat4(eletkor));
document.write("<br>");

function feladat5(szam, oszto) {
    if (szam % oszto == 0) {
        return "A szám oszthato";
    } else {
        return "A szám nem oszthato";
    }
}
const szam_feladat5 = prompt("Kérem a számot");
const oszto_feladat5 = prompt("Kérem az osztot");
document.write("Feladat 5: " + feladat5(szam_feladat5));
document.write("<br>");


function feladat6() {
    var array = [];
    for (let i = 1; i <= 10; i++) {
        var s = i ** 2;
        array.push(s);
    }
    return array
}
document.write("Feladat 6: " + feladat6());