var helsinki = [
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
var adatok = helsinki.map(function (item) {
    var _a = item.split(' '), helyezes = _a[0], spotolokszamaStr = _a[1], sportagneve = _a[2], versenySzam = _a[3];
    var spotolokszama = parseInt(spotolokszamaStr);
    return {
        helyezes: helyezes,
        spotolokszama: spotolokszama,
        sportagneve: sportagneve,
        versenySzam: versenySzam
    };
});
// console.log(adatok);
var result3 = document.getElementById('result3');
if (result3) {
    result3.innerHTML = '3. feladat megoldas';
}
else {
    console.log('Element with id "result3" not found.');
}
var result4 = document.getElementById('result4');
if (result4) {
    result4.innerHTML = '4. feladat megoldas';
}
else {
    console.log('Element with id "result4" not found.');
}
var result5 = document.getElementById('result5');
if (result5) {
    result5.innerHTML = '5. feladat megoldas';
}
else {
    console.log('Element with id "result5" not found.');
}
var result6 = document.getElementById('result6');
if (result6) {
    result6.innerHTML = '6. feladat megoldas';
}
else {
    console.log('Element with id "result6" not found.');
}
var result7 = document.getElementById('result7');
if (result7) {
    result7.innerHTML = '7. feladat megoldas';
}
else {
    console.log('Element with id "result7" not found.');
}
var result8 = document.getElementById('result8');
if (result8) {
    result8.innerHTML = '8. feladat megoldas';
}
else {
    console.log('Element with id "result8" not found.');
}
var result3_title = document.getElementById('result3_title');
if (result3_title) {
    result3_title.innerHTML = '3. feladat';
}
else {
    console.log('Element with id "result3_title" not found.');
}
var result4_title = document.getElementById('result4_title');
if (result4_title) {
    result4_title.innerHTML = '4. feladat';
}
else {
    console.log('Element with id "result4_title" not found.');
}
var result5_title = document.getElementById('result5_title');
if (result5_title) {
    result5_title.innerHTML = '5. feladat';
}
else {
    console.log('Element with id "result5_title" not found.');
}
var result6_title = document.getElementById('result6_title');
if (result6_title) {
    result6_title.innerHTML = '6. feladat';
}
else {
    console.log('Element with id "result6_title" not found.');
}
var result7_title = document.getElementById('result7_title');
if (result7_title) {
    result7_title.innerHTML = '7. feladat';
}
else {
    console.log('Element with id "result7_title" not found.');
}
var result8_title = document.getElementById('result8_title');
if (result8_title) {
    result8_title.innerHTML = '8. feladat';
}
else {
    console.log('Element with id "result8_title" not found.');
}
//3.feladat
var podiumFinishes = adatok.filter(function (item) {
    var helyezesNumber = parseInt(item.helyezes);
    return helyezesNumber >= 1 && helyezesNumber <= 3;
});
var podiumFinishCount = podiumFinishes.length;
if (result3 == null) {
    console.log("Nincsen result ID");
}
else {
    result3.innerHTML = ("Pontszerz\u0151 helyez\u00E9sek sz\u00E1ma: ".concat(podiumFinishCount === null || podiumFinishCount === void 0 ? void 0 : podiumFinishCount.toString()));
}
//4.feladat
// Számoljuk meg az arany-, ezüst- és bronzérmek számát
var aranyErmek = 0;
var ezustErmek = 0;
var bronzErmek = 0;
// Iteráljuk végig az adatokat és növeljük a megfelelő érmtípus számát
adatok.forEach(function (item) {
    var helyezesNumber = parseInt(item.helyezes);
    if (helyezesNumber === 1) {
        aranyErmek++;
    }
    else if (helyezesNumber === 2) {
        ezustErmek++;
    }
    else if (helyezesNumber === 3) {
        bronzErmek++;
    }
});
// Összesítés a minta szerint
var osszesitettStatisztika = "\n    Arany: ".concat(aranyErmek, " <br />\n    Ez\u00FCst: ").concat(ezustErmek, " <br />\n    Bronz: ").concat(bronzErmek, " <br />\n    \u00D6sszesen: ").concat(aranyErmek + ezustErmek + bronzErmek, "\n");
if (result4) {
    result4.innerHTML = osszesitettStatisztika;
}
else {
    console.log('Element with id "result4" not found.');
}
var olimpiaiPontok = [7, 5, 4, 3, 2, 1];
var osszOlimpiaiPont = 0;
adatok.forEach(function (item) {
    var helyezesNumber = parseInt(item.helyezes);
    if (helyezesNumber >= 1 && helyezesNumber <= 6) {
        osszOlimpiaiPont += olimpiaiPontok[helyezesNumber - 1];
    }
});
if (result5) {
    result5.innerHTML = ("Olimpiai pontok sz\u00E1ma: ".concat(osszOlimpiaiPont));
}
else {
    console.log('Element with id "result5" not found.');
}
var uszasErmeSzam = 0;
var tornaErmeSzam = 0;
adatok.forEach(function (item) {
    if (item.sportagneve === 'uszas') {
        uszasErmeSzam++;
    }
    else if (item.sportagneve === 'torna') {
        tornaErmeSzam++;
    }
});
if (uszasErmeSzam > tornaErmeSzam) {
    if (result6) {
        result6.innerHTML = 'Úszás sportágban szereztek több érmet';
    }
    else {
        console.log('Element with id "result6" not found.');
    }
}
else if (tornaErmeSzam > uszasErmeSzam) {
    if (result6) {
        result6.innerHTML = 'Torna sportágban szereztek több érmet';
    }
    else {
        console.log('Element with id "result6" not found.');
    }
}
else {
    if (result6) {
        result6.innerHTML = 'Mind ketto sportágban ugyan annyi ermet szereztek';
    }
    else {
        console.log('Element with id "result6" not found.');
    }
}
var helsinki2 = helsinki.map(function (item) {
    var _a = item.split(' '), helyezes = _a[0], sportolokszamaStr = _a[1], sportagneve = _a[2], versenySzam = _a[3];
    var correctedSportagneve = sportagneve.replace('kajakkenu', 'kajak-kenu');
    return "".concat(helyezes, " ").concat(sportolokszamaStr, " ").concat(correctedSportagneve, " ").concat(versenySzam);
});
// console.log(helsinki2.join('\n'));
var tableHTML = '<details><summary>Mutasd a táblázatot</summary><table><thead><tr><th>Helyezés</th><th>Sportág</th><th>Versenyszám</th><th>Sportolók száma</th></tr></thead><tbody>';
helsinki2.forEach(function (item) {
    var _a = item.split(' '), helyezes = _a[0], sportolokszamaStr = _a[1], sportagneve = _a[2], versenySzam = _a[3];
    tableHTML += "<tr><td>".concat(helyezes, "</td><td>").concat(sportagneve, "</td><td>").concat(versenySzam, "</td><td>").concat(sportolokszamaStr, "</td></tr>");
});
tableHTML += '</tbody></table></details>';
if (result7) {
    result7.innerHTML = (tableHTML);
}
else {
    console.log('Element with id "result7" not found.');
}
var maxSportolokSzama = -1;
var legtobbSportoloHelyezes = "";
adatok.forEach(function (item) {
    var helyezesNumber = parseInt(item.helyezes);
    if (helyezesNumber >= 1 && helyezesNumber <= 3) {
        if (item.spotolokszama > maxSportolokSzama) {
            maxSportolokSzama = item.spotolokszama;
            legtobbSportoloHelyezes = "Helyez\u00E9s: ".concat(item.helyezes, " <br> Sport\u00E1g: ").concat(item.sportagneve, " <br> Versenysz\u00E1m: ").concat(item.versenySzam, " <br> Sportol\u00F3k sz\u00E1ma: ").concat(item.spotolokszama);
        }
    }
});
if (result8) {
    result8.innerHTML = legtobbSportoloHelyezes;
}
else {
    console.log('Element with id "result8" not found.');
}
