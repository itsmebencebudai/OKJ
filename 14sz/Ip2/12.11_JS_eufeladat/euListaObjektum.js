const EuropaiUnio = [{
    orszag: "Ausztria",
    csatlakozas: "1995.01.01"
},
{
    orszag: "Belgium",
    csatlakozas: "1958.01.01"
},
{
    orszag: "Bulgária",
    csatlakozas: "2007.01.01"
},
{
    orszag: "Ciprus",
    csatlakozas: "2004.05.01"
},
{
    orszag: "Csehország",
    csatlakozas: "2004.05.01"
},
{
    orszag: "Dánia",
    csatlakozas: "1973.01.01"
},
{
    orszag: "Egyesült Királyság",
    csatlakozas: "1973.01.01"
},
{
    orszag: "Észtország",
    csatlakozas: "2004.05.01"
},
{
    orszag: "Finnország",
    csatlakozas: "1995.01.01"
},
{
    orszag: "Franciaország",
    csatlakozas: "1958.01.01"
},
{
    orszag: "Görögország",
    csatlakozas: "1981.01.01"
},
{
    orszag: "Hollandia",
    csatlakozas: "1958.01.01"
},
{
    orszag: "Horvátország",
    csatlakozas: "2013.07.01"
},
{
    orszag: "Írország",
    csatlakozas: "1973.01.01"
},
{
    orszag: "Lengyelország",
    csatlakozas: "2004.05.01"
},
{
    orszag: "Lettország",
    csatlakozas: "2004.05.01"
},
{
    orszag: "Litvánia",
    csatlakozas: "2004.05.01"
},
{
    orszag: "Luxemburg",
    csatlakozas: "1958.01.01"
},
{
    orszag: "Magyarország",
    csatlakozas: "2004.05.01"
},
{
    orszag: "Málta",
    csatlakozas: "2004.05.01"
},
{
    orszag: "Németország",
    csatlakozas: "1958.01.01"
},
{
    orszag: "Olaszország",
    csatlakozas: "1958.01.01"
},
{
    orszag: "Portugália",
    csatlakozas: "1986.01.01"
},
{
    orszag: "Románia",
    csatlakozas: "2007.01.01"
},
{
    orszag: "Spanyolország",
    csatlakozas: "1986.01.01"
},
{
    orszag: "Svédország",
    csatlakozas: "1995.01.01"
},
{
    orszag: "Szlovákia",
    csatlakozas: "2004.05.01"
},
{
    orszag: "Szlovénia",
    csatlakozas: "2004.05.01"
}
]


function TagokSzama() {
    let eutag_db = 0;
    for (let i = 0; i < EuropaiUnio.length; i++) {
        eutag_db++;
    }
    return eutag_db;
}
console.log("TagokSzama: " + TagokSzama());

function csatlakozott() {
    let csatlakozott_db = 0
    EuropaiUnio.forEach(item => {
        if (item.csatlakozas.includes("2007")) {
            csatlakozott_db++;
        }
    });
    return csatlakozott_db;
}
console.log("csatlakozott 2007-ben: " + csatlakozott());

function csatlakozott_fejlesztett(ev) {
    let csatlakozott_db = 0
    EuropaiUnio.forEach(item => {
        if (item.csatlakozas.includes(ev)) {
            csatlakozott_db++;
        }
    });
    return csatlakozott_db;
}
let ev = 1958;
console.log(`csatlakozott ${ev}-ban: ` + csatlakozott_fejlesztett(ev));

function MagyarországCsatlakozott() {
    let magyarországCsatlakozott = false;
    EuropaiUnio.forEach(item => {
        if (item.orszag == "Magyarország") {
            magyarországCsatlakozott = true;
        }
    });
    return magyarországCsatlakozott;
}
console.log("Magyarország csatlakozott?  " + MagyarországCsatlakozott());

function CsatlakozottOrszag() {
    let CsatlakozottOrszag = false;
    EuropaiUnio.forEach(item => {
        if (item.orszag == "Magyarország") {
            CsatlakozottOrszag = true;
        }
    });
    return CsatlakozottOrszag;
}
let orszag = "Horvátország";
console.log(`${orszag} csatlakozott?  ` + CsatlakozottOrszag(orszag));

function MajusCsatlakozas() {
    let volt = false;
    let valasz =""
    EuropaiUnio.forEach(item => {
        if (item.csatlakozas.includes(".05.")) {
            volt = true;
        }
        if(!volt)
        {
            valasz = "nem"
        }else{
            valasz = "igen"
        }
    });
    return valasz;
}
console.log("Volt májusban csatlakozas? " + MajusCsatlakozas());

function HonapCsatlakozas(honap) {
    let volt = false;
    let orszag= "";
    let valasz = "";
    EuropaiUnio.forEach(item => {
        if (item.csatlakozas.includes("." + honap + ".")) {
            volt = true;
            orszag = item.orszag;
        }
        if(!volt)
        {
            valasz = "nem"
        }else{
            valasz = "igen"
        }
    });
    return valasz + ` (${orszag})`;
}
let honap = "01";
console.log(`Volt a ${honap}. honapban csatlakozas? ` + HonapCsatlakozas(honap));

function UtolsoCsatlakozas() {
    let orszagneve = "";
    let max = 0;
    let csatlakozas = "";
    EuropaiUnio.forEach(item => {
        let intDatum = parseInt(item.csatlakozas.replace(/\./g, ""));
        if (intDatum > max) {
            max = intDatum;
            orszagneve = item.orszag;
            csatlakozas = item.csatlakozas;
        }
    });
    return orszagneve+ ` (${csatlakozas})`;
}
console.log("UtolsoCsatlakozas: " + UtolsoCsatlakozas());

function Statszitika() {
    let a = {};
    EuropaiUnio.forEach(item => {
        let ev = item.csatlakozas.substring(0, 4);

        if (a.hasOwnProperty(ev)) {
            a[ev]++;
        } else {
            a[ev] = 1;
        }
    });

    console.log("Csatlakozasok: ");
    for (let year in a) {
        console.log(`${year}: ${a[year]} orszag`);
    }
}
Statszitika();
