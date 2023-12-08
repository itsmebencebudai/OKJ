//IDE DOLGOZZA KI A FELADATOKAT FÜGGVÉNYES FORMÁBAN

// 1. feladat
function KockaFelszin(a) {
    let d = 6 * Math.pow(a, 2);
    return d;
}
console.log("KockaFelszin(2): " + KockaFelszin(2));
console.log("KockaFelszin(3): " + KockaFelszin(3));
console.log("KockaFelszin(5): " + KockaFelszin(5));


// 2. feladat
function KockaTerfogat(a) {
    let d = Math.pow(a, 3);
    return d;
}
console.log("KockaTerfogat(2): " + KockaTerfogat(2));
console.log("KockaTerfogat(3): " + KockaTerfogat(3));
console.log("KockaTerfogat(5): " + KockaTerfogat(5));


// 3. feladat
function PhErtek(vizsgaltErtek) {
    if (vizsgaltErtek == 7) {
        return 'semleges'
    } else if (vizsgaltErtek < 7) {
        return 'savas'
    } else if (vizsgaltErtek > 7) {
        return 'lugos'
    }
}
console.log("PhErtek(9): " + PhErtek(9));
console.log("PhErtek(5.5): " + PhErtek(5.5));
console.log("PhErtek(7): " + PhErtek(7));

// 4. feladat
function ElsoNSzamOsszege(szamokMennyisege) {
    let osszeg = 0;
    for (let i = 1; i <= szamokMennyisege; i++) {
        osszeg += i;
    }
    return osszeg;
}
console.log("ElsoNSzamOsszege(3): " + ElsoNSzamOsszege(3));
console.log("ElsoNSzamOsszege(10): " + ElsoNSzamOsszege(10));
console.log("ElsoNSzamOsszege(21): " + ElsoNSzamOsszege(21));

// 5. feladat
function MaxParos(vizsgaltTomb) {
    let max = 0;
    vizsgaltTomb.forEach(item => {
        if (item % 2 === 0) {
            if (item > max) {
                max = item;
            }
        }
    });
    return max;
}
console.log("MaxParos ([12,3,7,19,21]): " + MaxParos([12, 3, 7, 19, 21]));
console.log("MaxParos ([28,14,2,42,69]): " + MaxParos([28, 14, 2, 42, 69]));
console.log("MaxParos ([32,21,54,33,21]) : " + MaxParos([32, 21, 54, 33, 21]));

// 6. feladat
function MassalHangzokSzama(vizsgaltSzoveg) {
    let maganhangzok = ["a", "á", "e", "é", "i", "í", "o", "ó", "ö", "ő", "u", "ú", "ü", "ű", " "];
    let count = 0;
    for (let i = 0; i < vizsgaltSzoveg.length; i++) {
        if (maganhangzok.includes(vizsgaltSzoveg[i])) {
            count++;
        }
    }
    return vizsgaltSzoveg.length - count;
}
console.log("MassalHangzokSzama('Javascript'): " + MassalHangzokSzama("Javascript"));
console.log("MassalHangzokSzama('Géza kék az ég'): " + MassalHangzokSzama("Géza kék az ég"));
console.log("MassalHangzokSzama('Minta Márton'): " + MassalHangzokSzama("Minta Márton"));

// 7. feladat
function SzovegVisszafele(szoveg) {
    let forditottszoveg = "";
    for (let i = szoveg.length - 1; i >= 0; i--) {
        forditottszoveg += szoveg[i];
    }
    return forditottszoveg;
}
console.log("SzovegVisszafele('Szeretem a programozás'): " + SzovegVisszafele("Szeretem a programozás"));
console.log("SzovegVisszafele('Géza kék az ég'): " + SzovegVisszafele("Géza kék az ég"));
console.log("SzovegVisszafele('Répa, retek, mogyoró'): " + SzovegVisszafele("Répa, retek, mogyoró"));

// 8. feladat
function PrimekSzama(vizsgaltTomb) {
    function isPrímszám(szam) {
        if (szam < 2) { // 1 kezelése
            return false;
        }
        for (let i = 2; i <= Math.sqrt(szam); i++) {
            if (szam % i === 0) {
                return false;
            }
        }
        return true;
    }

    let prímCount = 0;
    for (let i = 0; i < vizsgaltTomb.length; i++) {
        if (isPrímszám(vizsgaltTomb[i])) {
            prímCount++;
        }
    }
    return prímCount;
}
console.log("PrimekSzama([13, 7, 12, 15]): " + PrimekSzama([13, 7, 12, 15]));
console.log("PrimekSzama([1, 5, 17, 29]): " + PrimekSzama([1, 5, 17, 29]));
console.log("PrimekSzama([2, 3, 7, 11]): " + PrimekSzama([2, 3, 7, 11]));
console.log("PrimekSzama([1, 2, 3, 14]): " + PrimekSzama([1, 2, 3, 14]));
