

function SzamtaniTeszt(bemenetiAdat1, bemenetiAdat2, bemenetiAdat3, elvartEredmeny) {
    if (Szamtani(bemenetiAdat1, bemenetiAdat2, bemenetiAdat3) == elvartEredmeny) {
        document.write(`<tr><td>Számtani teszt</td><td>${bemenetiAdat1}, ${bemenetiAdat2},${bemenetiAdat3}</td><td>${elvartEredmeny}</td><td>${Szamtani(bemenetiAdat1, bemenetiAdat2, bemenetiAdat3)}</td><td>Siker</td></tr>`);
    }
    else {
        document.write(`<tr><td>Számtani teszt</td><td>${bemenetiAdat1}, ${bemenetiAdat2},${bemenetiAdat3}</td><td>${elvartEredmeny}</td><td>${Szamtani(bemenetiAdat1, bemenetiAdat2, bemenetiAdat3)}</td><td>Hiba</td></tr>`);
    }
}

function SzamtaniEsetek() {
    try {
        SzamtaniTeszt(2, 4, 6, true);
        SzamtaniTeszt(5, 10, 15, true);
        SzamtaniTeszt(3, 7, 21, false);
        SzamtaniTeszt(10, 20, 100, false);
    }
    catch {
        document.write(`<tr><td>Számtani teszt</td><td>Hibás függvény</td><td>Hibás függvény</td><td>Hibás függvény</td><td>Hiba</td></tr>`);
    }
}

function PrimekSzamaTeszt(bemenetiAdat, elvartEredmeny) {
    if (PrimekSzama(bemenetiAdat) == elvartEredmeny) {
        document.write(`<tr><td>Prím-E teszt</td><td>${bemenetiAdat}</td><td>${elvartEredmeny}</td><td>${PrimekSzama(bemenetiAdat)}</td><td>Siker</td></tr>`);
    }
    else {
        document.write(`<tr><td>Prím-E teszt</td><td>${bemenetiAdat}</td><td>${elvartEredmeny}</td><td>${PrimekSzama(bemenetiAdat)}</td><td>Hiba</td></tr>`);
    }
}

function PrimekSzamaEsetek() {
    try {
        PrimekSzamaTeszt([13, 7, 12, 15], 2);
        PrimekSzamaTeszt([1, 5, 17, 29], 3);
        PrimekSzamaTeszt([2, 3, 7, 11], 4);
        PrimekSzamaTeszt([1, 2, 3, 14], 2);
    }
    catch {
        document.write(`<tr><td>Prímek száma teszt</td><td>Hibás függvény</td><td>Hibás függvény</td><td>Hibás függvény</td><td>Hiba</td></tr>`);
    }
}


function MaganhangzokSzamaTeszt(bemenetiAdat, elvartEredmeny) {
    if (MaganhangzokSzama(bemenetiAdat) == elvartEredmeny) {
        document.write(`<tr><td>Magánhangzók száma</td><td>${bemenetiAdat}</td><td>${elvartEredmeny}</td><td>${MaganhangzokSzama(bemenetiAdat)}</td><td>Siker</td></tr>`);
    }
    else {
        document.write(`<tr><td>Magánhangzók száma</td><td>${bemenetiAdat}</td><td>${elvartEredmeny}</td><td>${MaganhangzokSzama(bemenetiAdat)}</td><td>Hiba</td></tr>`);
    }
}

function MaganhangzokSzamaEsetek() {
    try {
        MaganhangzokSzamaTeszt("Alma", 2);
        MaganhangzokSzamaTeszt("Árvíztűrő tükörfúrógép", 9);
        MaganhangzokSzamaTeszt("Junior FrontEnd", 5);
        MaganhangzokSzamaTeszt("Tesztszöveg", 3);
    }
    catch {
        document.write(`<tr><td>Magánhangzók száma teszt</td><td>Hibás függvény</td><td>Hibás függvény</td><td>Hibás függvény</td><td>Hiba</td></tr>`);
    }
}


function TesztFuttato() {
    document.write("<table class=\"table table-dark table-sm table-hover table-striped\">");
    document.write("<thead><tr><td>Teszt neve</td><td>Input adat</td><td>Elvárt eredmény</td><td>Végeredmény</td><td>Sikeresség</td></tr></thead>");
    document.write("<tbody>");
    SzamtaniEsetek();
    PrimekSzamaEsetek();
    MaganhangzokSzamaEsetek();
    document.write("</tbody></table>")
}
TesztFuttato();