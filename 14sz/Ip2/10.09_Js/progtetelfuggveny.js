function TombGenerator(arraymeret) {
    let generaltarray = [];
    for (var i = 0; i < arraymeret; i++) {
        var rand = Math.floor(Math.random() * 100);
        generaltarray.push(rand);
    }

    for (var i = 0; i < generaltarray.length; i++) {
        console.log(generaltarray[i]);
    }
    return generaltarray;

}
let generaltarray = TombGenerator(20);

function Osszeg(array) {
    let osszeg = 0;
    for (var i = 0; i < array.length; i++) {
        osszeg += array[i];
    }
    return (osszeg);
}
console.log("Osszeg: " + Osszeg(generaltarray));

function Hossz(array) {
    return (array.length);
}
console.log("Hossz: " + Hossz(generaltarray));

function Atlag(array) {
    console.log("Atlag: " + Osszeg(generaltarray) / array.length);
}
Atlag(generaltarray);

function Minimum(array) {
    let min = array[0];
    for (var i = 1; i < array.length; i++) {
        if (min > array[i]) {
            min = array[i];
        }
    }
    return (min);
}
console.log("Minimum: " + Minimum(generaltarray));

function Maximum(array) {
    let max = array[0];
    for (var i = 1; i < array.length; i++) {
        if (max < array[i])
            max = array[i];
    }
    return (max);
}
console.log("Maximum: " + Maximum(generaltarray));

function MinIndex(array) {
    let minIndex = 0;
    for (var i = 1; i < array.length; i++) {
        if (array[i] < array[minIndex])
            minIndex = i;
    }
    return ((minIndex + 1));
}
console.log("MinIndex: " + MinIndex(generaltarray));

function MaxIndex(array) {
    let maxIndex = 0;
    for (var i = 1; i < array.length; i++) {
        if (array[i] > array[maxIndex])
            maxIndex = i;
    }
    return ((maxIndex + 1));
}
console.log("MaxIndex: " + MaxIndex(generaltarray));

function Parosak(array) {
    let parosakSzama = 0;
    let parosak = [];
    for (var i = 1; i < array.length; i++) {
        if (array[i] % 2 == 0) {
            parosakSzama++;
            parosak.push(array[i])
        }
    }
    return (parosakSzama);
}
console.log("Parosak: " + Parosak(generaltarray));

function Paratlanok(array) {
    let paratlanokSzama = 0;
    let paratlanok = [];
    for (let i = 0; i < array.length; i++) {
        if (array[i] % 2 == 1) {
            paratlanokSzama++;
            paratlanok.push(array[i]);
        }
    }
    return(paratlanokSzama);
}
console.log("Paratlanok: "+Paratlanok(generaltarray));