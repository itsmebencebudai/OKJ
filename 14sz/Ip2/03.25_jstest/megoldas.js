function TeglaTestFelszin(a, b, c) {
    // Téglalap felszínének számítása
    var felszin = 2 * (a * b + a * c + b * c);
    return felszin;
}

function TeglaTestTerfogat(a, b, c) {
    var terfogat = a * b * c;
    return terfogat;
}
function PhErtek(vizsgaltErtek) {
    if (vizsgaltErtek === 7) {
        return "semleges";
    } else if (vizsgaltErtek < 7) {
        return "savas";
    } else {
        return "lugos";
    }
}
function ElsoNSzamOsszege(szamokMennyisege) {
    return (szamokMennyisege * (szamokMennyisege + 1)) / 2;
}
function PrimekSzama(vizsgaltTomb) {
    function isPrime(num) {
        if (num <= 1) return false;
        if (num <= 3) return true;
        if (num % 2 === 0 || num % 3 === 0) return false;
        let i = 5;
        while (i * i <= num) {
            if (num % i === 0 || num % (i + 2) === 0) return false;
            i += 6;
        }
        return true;
    }
    let count = 0;
    for (let i = 0; i < vizsgaltTomb.length; i++) {
        if (isPrime(vizsgaltTomb[i])) {
            count++;
        }
    }
    return count;
}

function EkezetesBetukSzama(vizsgaltSzoveg) {
    const ekezetek = /[áéíóöőúüű]/gi;
    const matches = vizsgaltSzoveg.match(ekezetek);
    return matches ? matches.length : 0;
}

function SzamVisszafele(megforditandoSzam) {
    return parseInt(megforditandoSzam.toString().split("").reverse().join(""), 10);
}

function SportagHelyezesek(vizsgaltObjektumTomb, sportagNeve, keresettHelyezes) {
    let count = 0;
    for (let i = 0; i < vizsgaltObjektumTomb.length; i++) {
        if (vizsgaltObjektumTomb[i].sportag === sportagNeve && vizsgaltObjektumTomb[i].helyezes === keresettHelyezes) {
            count++;
        }
    }
    return count;
}