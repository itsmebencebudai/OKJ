//Számgenerátor adott intervallumban, egész szám általunk megadott intervallumban
function SzamGeneralo(alsoHatar, felsoHatar) {
  let randomSzam = Math.round(
    Math.random() * (felsoHatar - alsoHatar) + alsoHatar
  );
  return randomSzam;
}

//Univerzális tömbgenerátor, megadható intervallummal és tömbmérettel
function UniverzalisTombGenerator(tombMeret, alsoHatar, felsoHatar) {
  let generaltTomb = [];
  for (let i = 0; i < tombMeret; i++) {
    let randomSzam = SzamGeneralo(alsoHatar, felsoHatar);
    generaltTomb.push(randomSzam);
  }
  return generaltTomb;
}

//Deklarálom és kiírtam a generált tömbömet
let tomb = UniverzalisTombGenerator(20, 20, 80);
document.write("A vizsgálat tömbböm elemei:" + tomb);

//Összegzés tétele: A tömbben lévő elemek összegét adja vissza
function OsszegzesTetele(vizsgaltTomb) {
  let osszeg = 0;
  for (let i = 0; i < vizsgaltTomb.length; i++) {
    osszeg += vizsgaltTomb[i];
  }
  return osszeg;
}
document.write("<br>A tömb elemeinek összege:" + OsszegzesTetele(tomb));

//Átlagszámítás tétele: A tömbben lévő elemek átlagát adja vissza
//Ugyanaz az alapja mint összegzésnek a módosítás csak a kiíratásnál van:
function AtlagszamitasTetele(vizsgaltTomb) {
  let osszeg = 0;
  for (let i = 0; i < vizsgaltTomb.length; i++) {
    osszeg += vizsgaltTomb[i];
  }
  return osszeg / vizsgaltTomb.length;
}
document.write("<br>A tömb elemeinek átlaga:" + AtlagszamitasTetele(tomb));

//Minimum keresés
//-értékkel: A tömbben szereplő legkisebb éréket adjuk vissza
function MinimumkeresesTeteleErtek(vizsgaltTomb) {
  let minErtek = vizsgaltTomb[0];
  for (let i = 0; i < vizsgaltTomb.length; i++) {
    if (vizsgaltTomb[i] < minErtek) {
      minErtek = vizsgaltTomb[i];
    }
  }
  return minErtek;
}
document.write(
  "<br>A tömb legkisebb elemének értéke:" + MinimumkeresesTeteleErtek(tomb)
);

//Minimum keresés
//-indexxel: A tömbben szereplő legkisebb értéknek a helyét adjuk vissza
function MinimumkeresesTeteleIndex(vizsgaltTomb) {
  let minIndex = 0;
  for (let i = 0; i < vizsgaltTomb.length; i++) {
    if (vizsgaltTomb[i] < vizsgaltTomb[minIndex]) {
      minIndex = i;
    }
  }
  return minIndex;
}
document.write(
  "<br>A tömb legkisebb elemének indexe:" + MinimumkeresesTeteleIndex(tomb)
);
document.write(
  "<br>A tömb legkisebb elemének helye:" + (MinimumkeresesTeteleIndex(tomb) + 1)
);

//Maximum keresés
//-értékkel: A tömbben szereplő legnagyobb éréket adjuk vissza
function MaximumkeresesTeteleErtek(vizsgaltTomb) {
  let maxErtek = vizsgaltTomb[0];
  for (let i = 0; i < vizsgaltTomb.length; i++) {
    if (vizsgaltTomb[i] > maxErtek) {
      maxErtek = vizsgaltTomb[i];
    }
  }
  return maxErtek;
}
document.write(
  "<br>A tömb legnagyobb elemének értéke:" + MaximumkeresesTeteleErtek(tomb)
);

//Maximum keresés
//-indexxel: A tömbben szereplő legnagyobb értéknek a helyét adjuk vissza
function MaximumkeresesTeteleIndex(vizsgaltTomb) {
  let maxIndex = 0;
  for (let i = 0; i < vizsgaltTomb.length; i++) {
    if (vizsgaltTomb[i] > vizsgaltTomb[maxIndex]) {
      maxIndex = i;
    }
  }
  return maxIndex;
}
document.write(
  "<br>A tömb legnagyobb elemének indexe:" + MaximumkeresesTeteleIndex(tomb)
);
document.write(
  "<br>A tömb legnagyobb elemének helye:" +
    (MaximumkeresesTeteleIndex(tomb) + 1)
);



//Megszámlálás: Adott T tulajdonságú elemek számát adja vissza a tömbből(feltéte határozza meg)
function MegszamlalasTeteleParos(vizsgaltTomb) {
  let parosakSzama = 0;
  for (let i = 0; i < vizsgaltTomb.length; i++) {
    if (vizsgaltTomb[i] % 2 == 0) {
      parosakSzama++;
    }
  }
  return parosakSzama;
}
document.write("<br>A tömbben lévő páros elemek mennyisége:" + MegszamlalasTeteleParos(tomb));

//Kiválogatás: Adott T tulajdonságú elemek listáját adja vissza a tömbből(feltéte határozza meg)
function KivalogatasTeteleParos(vizsgaltTomb) {
    let parosakListaja = [];
    for (let i = 0; i < vizsgaltTomb.length; i++) {
      if (vizsgaltTomb[i] % 2 == 0) {
        parosakListaja.push(vizsgaltTomb[i]);
      }
    }
    return parosakListaja;
  }
  document.write("<br>A tömbben lévő páros elemek listája:" + KivalogatasTeteleParos(tomb));
