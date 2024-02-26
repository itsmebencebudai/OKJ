function KockaTerfogat(oldalMeret: number): number {
    // Kocka térfogata: oldalMeret^3
    const terfogat = Math.pow(oldalMeret, 3);
    return terfogat;
}

// Tesztelés
const oldalMeret = 5;
const terfogat = KockaTerfogat(oldalMeret);
console.log(`A kocka térfogata ${terfogat} egység.`);


function Szamtani(elsoErtek: number, masodikErtek: number, harmadikErtek: number): boolean {
    // Eldöntjük, hogy a számok alkotnak-e számtani sorozatot
    const kulonbseg1 = masodikErtek - elsoErtek;
    const kulonbseg2 = harmadikErtek - masodikErtek;
    
    return kulonbseg1 === kulonbseg2;
}

// Tesztelés
const elsoErtek = 2;
const masodikErtek = 4;
const harmadikErtek = 6;
const eredmeny = Szamtani(elsoErtek, masodikErtek, harmadikErtek);
console.log(`Az eredmény: ${eredmeny}`);

function KockaTerfogat(oldalMeret: number): number {
    // Kocka térfogata: oldalMeret^3
    const terfogat = Math.pow(oldalMeret, 3);
    return terfogat;
}

// Tesztelés
const oldalMeret = 5;
const terfogat = KockaTerfogat(oldalMeret);
console.log(`A kocka térfogata ${terfogat} egység.`);


function Szamtani(elsoErtek: number, masodikErtek: number, harmadikErtek: number): boolean {
    // Eldöntjük, hogy a számok alkotnak-e számtani sorozatot
    const kulonbseg1 = masodikErtek - elsoErtek;
    const kulonbseg2 = harmadikErtek - masodikErtek;
    
    return kulonbseg1 === kulonbseg2;
}

// Tesztelés
const elsoErtek = 2;
const masodikErtek = 4;
const harmadikErtek = 6;
const eredmeny = Szamtani(elsoErtek, masodikErtek, harmadikErtek);
console.log(`Az eredmény: ${eredmeny}`);


function EkezetNelkuliekMennyisege(vizsgaltSzovegek: string[]): number {
    let ekezetNelkuliSzavakSzama = 0;

    for (const szo of vizsgaltSzovegek) {
        if (!/[áéíóöőúüűÁÉÍÓÖŐÚÜŰ]/.test(szo)) {
            ekezetNelkuliSzavakSzama++;
        }
    }

    return ekezetNelkuliSzavakSzama;
}

// Tesztelés
const szavak: string[] = ["alma", "körte", "szilva", "barát", "ló", "tej"];
const ekezetNelkuliSzavak = EkezetNelkuliekMennyisege(szavak);
console.log(`Az ékezet nélküli szavak száma: ${ekezetNelkuliSzavak}`);
