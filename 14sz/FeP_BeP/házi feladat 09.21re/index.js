//  Javascript programozási tételek  //


//Összegzés
let tomb = [1, 2, 3, 4, 5];
let osszeg = 0;
tomb.forEach((elem) => {
  osszeg += elem;
});
console.log(osszeg); // 15

//Megszámolás
var adatok = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
var parosSzamok = 0;
for (var i = 0; i < adatok.length; i++) {
  if (adatok[i] % 2 === 0) {
    parosSzamok++;
  }
}
console.log("Páros számok száma: " + parosSzamok);

//Eldöntés
let number = 10;
if (number > 0) {
  console.log("A szám pozitív.");
} else {
  console.log("A szám nem pozitív.");
}

//Kiválasztás
let numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
let evenNumbers = numbers.filter(function (number) {
  return number % 2 === 0;
});
console.log(evenNumbers); // [2, 4, 6, 8, 10]

//Keresés
const array = [1, 2, 3, 4, 5];
console.log(array.indexOf(3)); // 2
console.log(array.includes(6)); // false

//Másolás
var eredetiObjektum = { name: "BB", age: 19 };
var masoltObjektum = Object.assign({}, eredetiObjektum);
console.log(masoltObjektum); // { name: "BB", age: 19 }

//Kiválogatás
let szamok = [1, 2, 3, 4, 5, 6];
let parosSzamok = szamok.filter(function(szam) {
  return szam % 2 === 0;
});
console.log(parosSzamok); // [2, 4, 6]

//Szétválogatás
function szetvalogatas(array, feltetel) {
  let igazak = [];
  let hamisak = [];
  for (let i = 0; i < array.length; i++) {
    if (feltetel(array[i])) {
      igazak.push(array[i]);
    } else {
      hamisak.push(array[i]);
    }
  }
  return [igazak, hamisak];
}
let adatok = [10, 15, 20, 25, 30];
let [igazak, hamisak] = szetvalogatas(adatok, (elem) => elem > 20);
console.log(igazak); // [25, 30]
console.log(hamisak); // [10, 15, 20]

//Metszet
function kozosElemek(halmaz1, halmaz2) {
  let metszet = [];
  for (let elem of halmaz1) {
    if (halmaz2.includes(elem)) {
      metszet.push(elem);
    }
  }
  return metszet;
}
let halmaz1 = [1, 2, 3, 4, 5];
let halmaz2 = [4, 5, 6, 7, 8];
let metszet = kozosElemek(halmaz1, halmaz2);
console.log(metszet); // [4, 5]

//Unió
let array1 = [1, 2, 3];
let array2 = [4, 5, 6];
let array3 = [7, 8, 9];
let combinedArray = array1.concat(array2, array3);
console.log(combinedArray); // [1, 2, 3, 4, 5, 6, 7, 8, 9]

//Maximum kiválasztás
function maximumKivalasztas(tomb) {
  if (tomb.length === 0) {
    throw "A tömb üres!";
  }
  let max = tomb[0];
  for (let i = 1; i < tomb.length; i++) {
    if (tomb[i] > max) {
      max = tomb[i];
    }
  }
  return max;
}
let maxhalmaz=[1, 2, 3, 4, 5];
let maxsorted = minimumKivalasztas(maxhalmaz);
console.log(maxsorted); // 5

//Minimum kiválasztás
function minimumKivalasztas(arr) {
  if (arr.length === 0) {
    throw "A tömb üres!";
  }
  let min = arr[0];
  for (let i = 1; i < arr.length; i++) {
    if (arr[i] < min) {
      min = arr[i];
    }
  }
  return min;
}
let minhalmaz = [64, 25, 12, 22, 11];
let minsorted = minimumKivalasztas(minhalmaz);
console.log(minsorted); // 11

// function Kiv_rend(let[] p_s){
//   let csere;
//         for (let i = 0; i < s.Length - 1; i++)
//         {
//             for (let j = i + 1; j < s.Length; j++)
//             {
//                 if (s[i] > s[j])
//                 {
//                     csere = s[i];
//                     s[i] = s[j];
//                     s[j] = csere;
//                 }
//             }
//         }
//         return s;
// }
// let kiv_rend_tomb = [3,5,6,7,3,23,2,56,747,47];
// console.log(Kiv_rend(kiv_rend_tomb));