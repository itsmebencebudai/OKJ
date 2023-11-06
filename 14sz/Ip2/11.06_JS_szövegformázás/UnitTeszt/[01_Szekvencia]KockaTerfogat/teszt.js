//Kocka Térfogat teszt
function KockaTerfogatTeszt(bemenetiAdat, elvartEredmeny) {
    var table = document.querySelector("#backupTable");
    var adatSor = table.insertRow(1);
    var tesztNeveMezo = adatSor.insertCell(0);
    var bemenetMezo = adatSor.insertCell(1);
    var elvartEredmenyMezo = adatSor.insertCell(2);
    var megoldasMezo = adatSor.insertCell(3)
    var visszajelzesMezo = adatSor.insertCell(4)
    //Módosítanndó rész a tesztekben
    tesztNeveMezo.innerHTML = "Kocka térfogata teszt";
    bemenetMezo.innerHTML = `${bemenetiAdat}`;
    elvartEredmenyMezo.innerHTML = `${elvartEredmeny}`;
    let aktMegoldas = KockaTerfogat(bemenetiAdat);
    //További részeket nem kell megadni
    megoldasMezo.innerHTML = `${aktMegoldas}`;
    if (KockaTerfogat(bemenetiAdat) == elvartEredmeny) {

        visszajelzesMezo.innerHTML = `Success`;
    }
    else {
        visszajelzesMezo.innerHTML = `Fail`;
    }
}

//Tesztesetek megadása

function KockaTerfogatEsetek() {
    try {
        KockaTerfogatTeszt(2, 8);
        KockaTerfogatTeszt(3, 27);
        KockaTerfogatTeszt(5, 125);
    }
    catch {
        var table = document.querySelector(".backupTable");
        var adatSor = table.insertRow(1);
        var bemenet = adatSor.insertCell(0);
        var elvartEredmeny = adatSor.insertCell(1);
        var megoldas = adatSor.insertCell(2)
        var visszajelzes = adatSor.insertCell(3)
        bemenet.innerHTML = `Kocka térfogata teszt`;//Teszeset nevét módosítani
        elvartEredmeny.innerHTML = `Hiba`;
        megoldas.innerHTML = `Hiba`;
        visszajelzes.innerHTML = `Hiba`;
    }
}

function TesztFuttato() {

    KockaTerfogatEsetek();
}
TesztFuttato();

