interface Adatok {
    helyezes: string;
    spotolokszama: number;
    sportagneve: string;
    versenySzam: string;
}

let helsinki: string[] = [
    "1 1 atletika kalapacsvetes",
    "1 1 uszas 400m_gyorsuszas",
    "1 1 birkozas kotott_fogas_legsuly",
    "1 1 torna talajtorna",
    "1 1 torna felemas_korlat",
    "1 1 vivas kardvivas_egyeni",
    "1 1 okolvivas nagyvaltosuly",
    "1 1 uszas 200m_melluszas",
    "1 1 birkozas kotott_fogas_valtosuly",
    "1 1 uszas 100m_gyorsuszas",
    "1 1 sportloveszet onmukodo_sportpisztoly",
    "1 15 labdarugas ferfi_csapat",
    "1 3 ottusa ferfi_csapat",
    "1 6 vivas kardvivas_csapat",
    "1 5 uszas 4x100m_gyorsuszo_valto",
    "1 13 vizilabda ferfi_csapat",
    "2 1 ottusa ottusa_egyeni",
    "2 1 vivas torvivas_egyeni",
    "2 1 vivas kardvivas_egyeni",
    "2 1 sportloveszet onmukodo_sportpisztoly",
    "2 1 uszas 400m_gyorsuszas",
    "2 1 uszas 200m_melluszas",
    "2 1 kajakkenu kenu_egyes_10000m",
    "2 1 kajakkenu kajak_egyes_1000m",
    "2 1 birkozas kotott_fogas_pehelysuly",
    "2 8 torna noi_osszetett_csapat",
    "3 1 sportloveszet sportpisztoly",
    "3 1 vivas kardvivas_egyeni",
    "3 1 atletika tavolugras",
    "3 1 birkozas szabad_fogas_kozepsuly",
    "3 1 torna felemas_korlat",
    "3 1 torna osszetett_egyeni",
    "3 1 torna gerenda",
    "3 1 torna talajtorna",
    "3 1 atletika kalapacsvetes",
    "3 1 atletika 50km_gyaloglas",
    "3 1 ottusa ottusa_egyeni",
    "3 1 uszas 100m_gyorsuszas",
    "3 4 atletika 4x100m_valtofutas",
    "3 2 kajakkenu kenu_kettes_10000m",
    "3 8 torna keziszer_csapat",
    "3 6 vivas torvivas_csapat",
    "4 1 torna gerenda",
    "4 1 uszas 200m_mell",
    "4 1 birkozas kotottfogas_felnehezsuly",
    "4 1 torna talaj",
    "4 1 birkozas kotottfogas_kozepsuly",
    "4 1 birkozas kotottfogas_konnyusuly",
    "5 1 okolvivas pehelysuly",
    "5 1 okolvivas konnyusuly",
    "5 1 uszas 100m_gyors",
    "5 1 atletika diszkoszvetes",
    "5 1 vivas parbajtor_egyeni",
    "5 2 kajak-kenu kenu_kettes_1000m",
    "5 2 kerekparozas ketuleses_verseny",
    "5 4 uszas 4x200m_gyorsvalto",
    "5 5 vivas parbajtor_csapat",
    "6 1 birkozas kotottfogas_legsuly",
    "6 1 kajak-kenu kajak_egyes_500m",
    "6 1 torna osszetett_egyeni",
    "6 1 kerekparozas repuloverseny",
    "6 1 uszas 400m_gyors",
    "6 1 torna felemaskorlat",
    "6 8 torna osszetett_csapat"
];

const adatok: Adatok[] = helsinki.map(item => {
    const [helyezes, spotolokszamaStr, sportagneve, versenySzam] = item.split(' ');
    const spotolokszama = parseInt(spotolokszamaStr);
    return {
        helyezes,
        spotolokszama,
        sportagneve,
        versenySzam
    };
});
// console.log(adatok);


const result3 = document.getElementById('result3');
if (result3) {
    result3.innerHTML = '3. feladat megoldas';
} else {
    console.log('Element with id "result3" not found.');
}

const result4 = document.getElementById('result4');
if (result4) {
    result4.innerHTML = '4. feladat megoldas';
} else {
    console.log('Element with id "result4" not found.');
}

const result5 = document.getElementById('result5');
if (result5) {
    result5.innerHTML = '5. feladat megoldas';
} else {
    console.log('Element with id "result5" not found.');
}

const result6 = document.getElementById('result6');
if (result6) {
    result6.innerHTML = '6. feladat megoldas';
} else {
    console.log('Element with id "result6" not found.');
}

const result7 = document.getElementById('result7');
if (result7) {
    result7.innerHTML = '7. feladat megoldas';
} else {
    console.log('Element with id "result7" not found.');
}

const result8 = document.getElementById('result8');
if (result8) {
    result8.innerHTML = '8. feladat megoldas';
} else {
    console.log('Element with id "result8" not found.');
}


const result3_title = document.getElementById('result3_title');
if (result3_title) {
    result3_title.innerHTML = '3. feladat';
} else {
    console.log('Element with id "result3_title" not found.');
}

const result4_title = document.getElementById('result4_title');
if (result4_title) {
    result4_title.innerHTML = '4. feladat';
} else {
    console.log('Element with id "result4_title" not found.');
}

const result5_title = document.getElementById('result5_title');
if (result5_title) {
    result5_title.innerHTML = '5. feladat';
} else {
    console.log('Element with id "result5_title" not found.');
}

const result6_title = document.getElementById('result6_title');
if (result6_title) {
    result6_title.innerHTML = '6. feladat';
} else {
    console.log('Element with id "result6_title" not found.');
}

const result7_title = document.getElementById('result7_title');
if (result7_title) {
    result7_title.innerHTML = '7. feladat';
} else {
    console.log('Element with id "result7_title" not found.');
}

const result8_title = document.getElementById('result8_title');
if (result8_title) {
    result8_title.innerHTML = '8. feladat';
} else {
    console.log('Element with id "result8_title" not found.');
}


//3.feladat
const podiumFinishes = adatok.filter(item => {
    const helyezesNumber = parseInt(item.helyezes);
    return helyezesNumber >= 1 && helyezesNumber <= 3;
});
const podiumFinishCount = podiumFinishes.length;
if (result3 == null) { console.log(`Nincsen result ID`); } else { result3.innerHTML = (`Pontszerző helyezések száma: ${podiumFinishCount?.toString()}`); }

//4.feladat
// Számoljuk meg az arany-, ezüst- és bronzérmek számát
let aranyErmek = 0;
let ezustErmek = 0;
let bronzErmek = 0;

// Iteráljuk végig az adatokat és növeljük a megfelelő érmtípus számát
adatok.forEach(item => {
    const helyezesNumber = parseInt(item.helyezes);
    if (helyezesNumber === 1) {
        aranyErmek++;
    } else if (helyezesNumber === 2) {
        ezustErmek++;
    } else if (helyezesNumber === 3) {
        bronzErmek++;
    }
});

// Összesítés a minta szerint
const osszesitettStatisztika = `
    Arany: ${aranyErmek} <br />
    Ezüst: ${ezustErmek} <br />
    Bronz: ${bronzErmek} <br />
    Összesen: ${aranyErmek + ezustErmek + bronzErmek}
`;

if (result4) {
    result4.innerHTML = osszesitettStatisztika;
} else {
    console.log('Element with id "result4" not found.');
}

const olimpiaiPontok = [7, 5, 4, 3, 2, 1];
let osszOlimpiaiPont = 0;

adatok.forEach(item => {
    const helyezesNumber = parseInt(item.helyezes);
    if (helyezesNumber >= 1 && helyezesNumber <= 6) {
        osszOlimpiaiPont += olimpiaiPontok[helyezesNumber - 1];
    }
});

if (result5) {
    result5.innerHTML = (`Olimpiai pontok száma: ${osszOlimpiaiPont}`);
} else {
    console.log('Element with id "result5" not found.');
}


let uszasErmeSzam = 0;
let tornaErmeSzam = 0;
adatok.forEach(item => {
    if (item.sportagneve === 'uszas') {
        uszasErmeSzam++;
    } else if (item.sportagneve === 'torna') {
        tornaErmeSzam++;
    }
});
if (uszasErmeSzam > tornaErmeSzam) {
    if (result6) {
        result6.innerHTML = 'Úszás sportágban szereztek több érmet';
    } else {
        console.log('Element with id "result6" not found.');
    }
} else if (tornaErmeSzam > uszasErmeSzam) {
    if (result6) {
        result6.innerHTML = 'Torna sportágban szereztek több érmet';
    } else {
        console.log('Element with id "result6" not found.');
    }
} else {
    if (result6) {
        result6.innerHTML = 'Mind ketto sportágban ugyan annyi ermet szereztek';
    } else {
        console.log('Element with id "result6" not found.');
    }
}


const helsinki2 = helsinki.map(item => {
    const [helyezes, sportolokszamaStr, sportagneve, versenySzam] = item.split(' ');

    const correctedSportagneve = sportagneve.replace('kajakkenu', 'kajak-kenu');

    return `${helyezes} ${sportolokszamaStr} ${correctedSportagneve} ${versenySzam}`;
});
// console.log(helsinki2.join('\n'));

let tableHTML = '<details><summary>Mutasd a táblázatot</summary><table><thead><tr><th>Helyezés</th><th>Sportág</th><th>Versenyszám</th><th>Sportolók száma</th></tr></thead><tbody>';

helsinki2.forEach(item => {
    const [helyezes, sportolokszamaStr, sportagneve, versenySzam] = item.split(' ');
    tableHTML += `<tr><td>${helyezes}</td><td>${sportagneve}</td><td>${versenySzam}</td><td>${sportolokszamaStr}</td></tr>`;
});

tableHTML += '</tbody></table></details>';

if (result7) {
    result7.innerHTML = (tableHTML);
} else {
    console.log('Element with id "result7" not found.');
}



let maxSportolokSzama = -1;
let legtobbSportoloHelyezes: string = "";
adatok.forEach(item => {
    const helyezesNumber = parseInt(item.helyezes);
    if (helyezesNumber >= 1 && helyezesNumber <= 3) {
        if (item.spotolokszama > maxSportolokSzama) {
            maxSportolokSzama = item.spotolokszama;
            legtobbSportoloHelyezes = `Helyezés: ${item.helyezes} <br> Sportág: ${item.sportagneve} <br> Versenyszám: ${item.versenySzam} <br> Sportolók száma: ${item.spotolokszama}`;
        }
    }
});

if (result8) {
    result8.innerHTML = legtobbSportoloHelyezes;
} else {
    console.log('Element with id "result8" not found.');
}
