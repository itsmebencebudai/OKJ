const Dolgozok = [{
    nev: "Koaxk Ábel",
    kor: 23,
    fizetes: 400000,
    beosztas: "Rendszergazda"
},
{
    nev: "Zsíros B. Ödön",
    kor: 45,
    fizetes: 1200000,
    beosztas: "Ügyvezető Igazgató"
},
{
    nev: "Meg Győző",
    kor: 32,
    fizetes: 600000,
    beosztas: "Marketing Manager"
},
{
    nev: "Békés Csaba",
    kor: 63,
    fizetes: 180000,
    beosztas: "Takarító"
},
{
    nev: "Pofá Zoltán",
    kor: 25,
    fizetes: 300000,
    beosztas: "Biztonsági Őr"
},
{
    nev: "Fejet Lenke",
    kor: 22,
    fizetes: 220000,
    beosztas: "Irodai Titkár"
},
{
    nev: "Vak Cina",
    kor: 30,
    fizetes: 500000,
    beosztas: "Üzem Orvos"
}
]

function Legnagyobb_Fizetes() {
    let maxfizetes = 0;
    let maxnev;
    Dolgozok.forEach(item => {
        maxfizetes = Math.max(maxfizetes, item.fizetes);
        if (maxfizetes == item.fizetes) {
            maxnev = item.nev;;
        }
    });
    return console.log("A legnagyobb fizetés: ", maxnev, maxfizetes);
}
Legnagyobb_Fizetes();

function AtlagEletkor() {
    let osszeletkor = 0;
    let eletkordb = 0;
    let atlag = 0;
    for (let i = 0; i < Dolgozok.length; i++) {
        osszeletkor += Dolgozok[i].kor;
        eletkordb++;
    }
    return console.log("AtlagEletkor: " + (atlag = osszeletkor / eletkordb).toFixed(0));
}
AtlagEletkor();

function AtlagFizetes() {
    let osszfizetes = 0;
    let fizetesdb = 0;
    let atlag = 0;
    for (let i = 0; i < Dolgozok.length; i++) {
        osszfizetes += Dolgozok[i].fizetes;
        fizetesdb++;
    }
    return (atlag = osszfizetes / fizetesdb).toFixed(0);
}

function AtlagFizetes_Felettiek() {
    let returnarray = [];
    for (let i = 0; i < Dolgozok.length; i++) {
        if (Dolgozok[i].fizetes >= AtlagFizetes()) {
            returnarray.push(Dolgozok[i].nev);
        }
    }
    return console.log("AtlagFizetes_Felettiek: " + returnarray);
}
AtlagFizetes_Felettiek();
