/**************************************//*Random tomb*//*********************************************/

let array = [];
for (var i = 0; i < 10; i++) {
    var rand = Math.floor(Math.random() * 100);
    array.push(rand);
}

for (var i = 0; i < array.length; i++) {
    console.log(array[i]);
    // document.write(array[i])+",";
}

/**************************************//*Osszeg*//*********************************************/

let osszeg = 0;
for (var i = 0; i < array.length; i++) {
    osszeg += array[i];
}
console.log("Összeg:" + osszeg);

/**************************************//*Hossz*//*********************************************/

console.log("Hossz:" + array.length);

/**************************************//*Atlag*//*********************************************/

console.log("Atlag:" + osszeg / array.length);

/**************************************//*Min*//*********************************************/

let min = array[0];
for (var i = 1; i < array.length; i++) {
    if (min > array[i])
        min = array[i];
}
console.log("Min:" + min);

/**************************************//*Max*//*********************************************/

let max = array[0];
for (var i = 1; i < array.length; i++) {
    if (max < array[i])
        max = array[i];
}
console.log("Max:" + max);

/**************************************//*MinIndex*//*********************************************/

let minIndex = 0;
for (var i = 1; i < array.length; i++) {
    if (array[i] < array[minIndex])
        minIndex = i;
}
console.log("MinIndex:" + (minIndex + 1));

/**************************************//*MaxIndex*//*********************************************/

let maxIndex = 0;
for (var i = 1; i < array.length; i++) {
    if (array[i] > array[maxIndex])
        maxIndex = i;
}
console.log("MaxIndex:" + (maxIndex + 1));

/*************************************//*Parosak*//************************************************/

let parosakSzama = 0;
let parosak = [];
for (var i = 1; i < array.length; i++) {
    if (array[i] % 2 == 0) {
        parosakSzama++;
        parosak.push(array[i])
    }
}
console.log("parosakSzama:" + parosakSzama);
console.log(parosak);

/*************************************//*Paratlanok*//**********************************************/

let paratlanokSzama = 0;
let paratlanok = [];
for (let i = 0; i < array.length; i++) {
    if (array[i] % 2 == 1) {
        paratlanokSzama++;
        paratlanok.push(array[i]);
    }
}
console.log("paratlanokSzama:" + paratlanokSzama);
console.log(paratlanok);