function KockaTerfogat(oldalMeret) {
    // Kocka térfogata: oldalMeret^3
    var terfogat = Math.pow(oldalMeret, 3);
    return terfogat;
}
// Tesztelés
var oldalMeret = 5;
var terfogat = KockaTerfogat(oldalMeret);
console.log("A kocka t\u00E9rfogata ".concat(terfogat, " egys\u00E9g."));
function Szamtani(elsoErtek, masodikErtek, harmadikErtek) {
    // Eldöntjük, hogy a számok alkotnak-e számtani sorozatot
    var kulonbseg1 = masodikErtek - elsoErtek;
    var kulonbseg2 = harmadikErtek - masodikErtek;
    return kulonbseg1 === kulonbseg2;
}
// Tesztelés
var elsoErtek = 2;
var masodikErtek = 4;
var harmadikErtek = 6;
var eredmeny = Szamtani(elsoErtek, masodikErtek, harmadikErtek);
console.log("Az eredm\u00E9ny: ".concat(eredmeny));
function EkezetNelkuliekMennyisege(vizsgaltSzovegek) {
    var ekezetNelkuliSzavakSzama = 0;
    for (var _i = 0, vizsgaltSzovegek_1 = vizsgaltSzovegek; _i < vizsgaltSzovegek_1.length; _i++) {
        var szo = vizsgaltSzovegek_1[_i];
        if (!/[áéíóöőúüűÁÉÍÓÖŐÚÜŰ]/.test(szo)) {
            ekezetNelkuliSzavakSzama++;
        }
    }
    return ekezetNelkuliSzavakSzama;
}
// Tesztelés
var szavak = ["alma", "körte", "szilva", "barát", "ló", "tej"];
var ekezetNelkuliSzavak = EkezetNelkuliekMennyisege(szavak);
console.log("Az \u00E9kezet n\u00E9lk\u00FCli szavak sz\u00E1ma: ".concat(ekezetNelkuliSzavak));
