//PH érték teszt
function PhErtekTeszt(bemenetiAdat, elvartEredmeny) {
    var table = document.querySelector("#backupTable");
    var adatSor = table.insertRow(1);
    var tesztNeveMezo = adatSor.insertCell(0);
    var bemenetMezo = adatSor.insertCell(1);
    var elvartEredmenyMezo = adatSor.insertCell(2);
    var megoldasMezo = adatSor.insertCell(3)
    var visszajelzesMezo = adatSor.insertCell(4)
    //Módosítanndó rész a tesztekben
    tesztNeveMezo.innerHTML = "PH érték teszt";
    bemenetMezo.innerHTML = `${bemenetiAdat}`;
    elvartEredmenyMezo.innerHTML = `${elvartEredmeny}`;
    let aktMegoldas = PhErtek(bemenetiAdat);
    //További részeket nem kell megadni
    megoldasMezo.innerHTML = `${aktMegoldas}`;
    if (PhErtek(bemenetiAdat) == elvartEredmeny) {

        visszajelzesMezo.innerHTML = `Success`;
    }
    else {
        visszajelzesMezo.innerHTML = `Fail`;
    }
}

//Tesztesetek megadása

function PhErtekEsetek() {
    try {
        PhErtekTeszt(9, "lugos");
        PhErtekTeszt(7, "semleges");
        PhErtekTeszt(5.5, "savas");
    }
    catch {
        var table = document.querySelector(".backupTable");
        var adatSor = table.insertRow(1);
        var bemenet = adatSor.insertCell(0);
        var elvartEredmeny = adatSor.insertCell(1);
        var megoldas = adatSor.insertCell(2)
        var visszajelzes = adatSor.insertCell(3)
        bemenet.innerHTML = `PhErtek teszt`;//Teszeset nevét módosítani
        elvartEredmeny.innerHTML = `Hiba`;
        megoldas.innerHTML = `Hiba`;
        visszajelzes.innerHTML = `Hiba`;
    }
}

function TesztFuttato() {

    PhErtekEsetek();
}
TesztFuttato();