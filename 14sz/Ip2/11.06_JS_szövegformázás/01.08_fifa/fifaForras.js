//1. érték: Csapat neve (nev)
//2. érték: Csapat helyezése (helyezes)
//3. érték: Csapat helyének változása (valtozas)
//4. érték: Csapat Pontszama (pont)

const csapatAdat = [
    "Anglia;4;0;1662",
    "Argentína;10;0;1614",
    "Belgium;1;0;1752",
    "Brazília;3;-1;1719",
    "Chile;17;-3;1576",
    "Dánia;14;-1;1584",
    "Franciaország;2;1;1725",
    "Hollandia;13;3;1586",
    "Horvátország;8;-1;1625",
    "Kolumbia;9;-1;1622",
    "Mexikó;12;0;1603",
    "Németország;16;-1;1580",
    "Olaszország;15;1;1583",
    "Peru;19;0;1551",
    "Portugália;5;1;1643",
    "Spanyolország;7;2;1631",
    "Svájc;11;0;1604",
    "Svédország;18;0;1560",
    "Szenegál;20;0;1546",
    "Uruguay;6;-1;1639"
];

// 1. feladat
function feladat1() {
    let s = 0;
    csapatAdat.forEach(item => {
        s++;
    });
    return s;
}
function feladat1_kiír() {
    document.write("1. Ada meg aktuálisan hány csapat szerepel a ranglistán: " + "<b>" + feladat1() + "</b>" + "<br><br>");
}
feladat1_kiír();

// 2. feladat
function feladat2() {
    let osszes = 0;
    let db = feladat1();
    csapatAdat.forEach(item => {
        let array = item.split(";");
        osszes += parseFloat(array[3]);
    })
    let atlag = osszes / db;
    return atlag;
}

function feladat2_kiír(array) {
    document.write("2. Írja ki mennyi a résztvevő csapatok átlagpontszáma: " + "<b>" + array + "</b>" + "<br><br>");
}
feladat2_kiír(feladat2());


// 3. feladat
function feladat3() {
    let atlag = feladat2();
    let altagfeletticsapatok = [];
    csapatAdat.forEach(item => {
        let array = item.split(";");
        if (array[3] >= atlag) {
            altagfeletticsapatok.push(array[0])
        }
    })
    return altagfeletticsapatok;
}

// 3. feladat
function feladat3_kiir(array) {
    document.write("3. Listázza ki azokat a csapatokat, akik az átlagnál több pontot értek el:");
    document.write("<table border='1'><tr><th>Csapat neve</th></tr>");

    array.forEach(csapatNeve => {
        document.write(`<tr><td>${csapatNeve}</td></tr>`);
    });

    document.write("</table><br>");
}

feladat3_kiir(feladat3());


function feladat4() {
    let valtozas = -Infinity;
    let javultcsapat = [];

    csapatAdat.forEach(item => {
        let array = item.split(";");
        let javulas = parseInt(array[2]);

        if (javulas > valtozas) {
            valtozas = javulas;
            javultcsapat = [{ helyezes: array[1], csapatNeve: array[0], pontszam: array[3] }];
        } else if (javulas === valtozas) {
            javultcsapat.push({ helyezes: array[1], csapatNeve: array[0], pontszam: array[3] });
        }
    });

    return javultcsapat;
}


function feladat4_kiir(array) {
    document.write("4. Írja ki a legtöbbet javító csapat adatait: Helyezés, CsapatNeve, Pontszáma:");
    document.write("<table border='1'><tr><th>Helyezés</th><th>Csapat neve</th><th>Pontszám</th></tr>");

    console.log(array);
    array.forEach(csapat => {
        document.write(`<tr><td>${csapat.helyezes}</td><td>${csapat.csapatNeve}</td><td>${csapat.pontszam}</td></tr>`);
    });

    document.write("</table><br>");
}

feladat4_kiir(feladat4());


// 5. feladat
let csapat = prompt("Kérem a csapat nevét: ");

function feladat5() {
    let megtalalhato = false;
    csapatAdat.forEach(item => {
        let array = item.split(";");
        if (array[0] === csapat) {
            megtalalhato = true;
        }
    })

    if (megtalalhato === false) {
        return "Nem található meg";
    } else if (megtalalhato === true) {
        return "Megtalálható";
    }
}

function feladat5_kiír(string) {
    document.write(`5. Határozza meg a adatok közöt megtalálható-e ${csapat} csapata: ` + "<b>" + string + "</b>" + "<br><br>")
}
feladat5_kiír(feladat5());

// 6. feladat
function feladat6() {
    let csapatokValtozasa = {};
    csapatAdat.forEach(item => {
        let [csapatNeve, helyezes, helyezesValtozas, pontszam] = item.split(";");
        let valtozas = parseInt(helyezesValtozas);

        if (Math.abs(valtozas) > 1) {
            if (!csapatokValtozasa.hasOwnProperty(valtozas)) {
                csapatokValtozasa[valtozas] = [];
            }

            csapatokValtozasa[valtozas].push({
                csapatNeve,
                helyezes: parseInt(helyezes),
                pontszam: parseInt(pontszam)
            });
        }
    });

    return csapatokValtozasa;
}

function feladat6_kiir(obj) {
    document.write("6. Készítsen  statisztikát  a  helyezések  változása  (Valtozas)  alapján  csoportosítva  a  csapatok számáról  a  minta  szerint!  Csak  azok  a  helyezésváltozások  jelenjenek  meg  a  képernyőn, amelyek esetében a csapatok száma több mint egy volt! A megjelenő csoportok sorrendje tetszőleges.<br><br>");
    for (const [valtozas, csapatok] of Object.entries(obj)) {
        document.write(`Csapatok változása ${valtozas} helyezéssel: <br>`);
        document.write("<table border='1'><tr><th>Csapat neve</th><th>Helyezés</th><th>Pontszám</th></tr>");

        csapatok.forEach(csapat => {
            document.write(`<tr><td>${csapat.csapatNeve}</td><td>${csapat.helyezes}</td><td>${csapat.pontszam}</td></tr>`);
        });

        document.write("</table><br>");
    }
}

feladat6_kiir(feladat6());
