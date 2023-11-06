let tomb=[];
function TombGenerator(tombMeret) {
    let generaltTomb = [];
    for (let i = 0; i < tombMeret; i++) {
        let randomSzam = Math.round(Math.random() * 100);
        generaltTomb.push(randomSzam);
    }
    return generaltTomb;
}
tomb = TombGenerator(20);
document.write("A vizsgálat tömbböm elemei:"+tomb);

function OsszegzesTetele(vizsgaltTomb) {
    let osszeg = 0;
    for (let i = 0; i < vizsgaltTomb.length; i++) {
        osszeg += vizsgaltTomb[i];
    }
    return osszeg;
}

document.write("<br>A tömb elemeinek összege:"+OsszegzesTetele(tomb));