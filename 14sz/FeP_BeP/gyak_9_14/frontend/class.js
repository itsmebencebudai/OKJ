// Jármű osztály defíniálása
// class Jarmu {
//   // az adatok mindig a construktorban kerülnek defíniálásra
//   constructor(marka, sebesseg = 0) {
//     //ha nem adom meg az értéket akkor a 0-at veszi fel alapértelmezettnek
//     this._marka = marka;
//     this._sebesseg = sebesseg;
//     this.utasok = [];
//   }

//   // get set metódus / új érték beállításához
//   get sebesseg() {
//     return this._sebesseg;
//   }
//   set sebesseg(ujertek) {
//     if (typeof ujertek === "number" && ujertek >= 0) {
//       this._sebesseg = ujertek;
//     } else {
//       console.log(`Hibás adat: ${ujertek}`);
//     }
//   }

//   //tagfüggvények defíniciója
//   info() {
//     console.log(
//       `${this._marka} márkájú jármű, melynek sebbesége: ${this._sebesseg} km/h és az utasok száma: ${this.utasok.length}`
//     );
//   }
//   utasfelvesz(utasneve) {
//     if (typeof utasneve === "string") {
//       this.utasok.push(utasneve); //this kell elé ha osztályon belül használjuk
//     }
//   }
// }

// // öröklés a Jarmu osztályból
// class Auto extends Jarmu {
//   constructor(marka, sebesseg = 0, onvezeto = false) {
//     super(marka, sebesseg); // ős osztály construktora lehívása
//     this.onvezeto = onvezeto;
//   }
//   info() {
//     console.log(
//       `${this._marka} márkájú auto, melynek sebbesége: ${this._sebesseg
//       } km/h és az utasok száma: ${this.utasok.length} és az auto ovezeto: ${this.onvezeto ? "igen" : "nem"
//       } `
//     );
//   }
//   duda() {
//     console.log("dudál");
//   }
// }
// const jarmu = new Jarmu("Skoda", 50); // A Jármű osztály példányosítása létrejön a jarmu objektum

// const jarmu1 = new Jarmu();

// const auto = new Auto("Skoda2", 70, true);

// auto.utasfelvesz("Pista");

// // jarmu.utasfelvesz('Maci Laci'); // értéket adok meg tagfüggvény segítségével az utasok változonak az Objektumban
// // jarmu.utasfelvesz('Bubu');
// // jarmu.sebesseg = 100;
// // console.log(jarmu.sebesseg);

// // jarmu.info(); // Output: Skoda márkájú jármű, melynek sebbesége: 50 km/h és az utasok száma: 2
// // jarmu1.info(); // Output: undefined (mivel nem adtam meg neki értéket) márkájú jármű, melynek sebbesége: 0 km/h (alap sebesség ami be lett állítva) és az utasok száma: 0 (nincsen utas)
// auto.info(); // Output: Skoda2 márkájú auto, melynek sebbesége: 70 km/h és az utasok száma: 0
// auto.duda(); // Output: dudál

// // console.log(typeof jarmu == "Jarmu"); // false
// console.log(jarmu instanceof Jarmu); // true
// console.log(auto instanceof Jarmu); // true
// console.log(jarmu instanceof Auto); // false
// console.log(jarmu.utasok instanceof Array); // true

class TombGeneral {
  constructor(elemszam = 10, min = 1, max = 10) {
    this.tomb = [];
    for (let i = 0; i < elemszam; i++) {
      this.tomb.push(Math.floor(Math.random() * (max - 1)) + min);
    }
    // return this.tomb;
  }
}
tomb = new TombGeneral(undefined, undefined, 15); // undefined
// console.log(tomb);

// class Osszegzes {
//   constructor(tomb) {
//     this.ossz = 0;
//     for (let i = 0; i < tomb.length; i++) {
//       this.ossz += tomb[i];
//     }
//     return this.ossz;
//   }
// }
// ossz = new Osszegzes(new TombGeneral());
// console.log(`Osszeg: ${this.ossz}`);

// class Osszegzes extends TombGeneral {
//   constructor() {
//     super(12, 1, 15);
//     this.osszeg = 0;
//     for (let i = 0; i < this.tomb.length; i++) {
//       this.ossz += this.tomb[i];
//     }

//     console.log('ös oszt: ' + this.tomb);
//     console.log('gyerek oszt tomb: ' + this.tomb2);
//   }
// }
// osszeg = new Osszegzes();

// for (const prop in osszeg) {
//   console.log(osszeg[prop]);
// }

// console.log('Osszeg: ${osszegs.osszeg}');



// class Lineral_search extends TombGeneral {
//   constructor(ker) {
//     super(20, 1, 99);

//     let randomnumber = Math.floor(Math.random());
//     console.log(`randomnumber: ${randomnumber}`);
//     this.randomnumber = randomnumber;

//     let randomnumberforker = Math.floor(Math.random());
//     console.log(`randomnumberforker: ${randomnumberforker}`);
//     this.randomnumberforker = randomnumberforker;

//     this.ker = randomnumberforker;

//     let i = 0;
//     while (tomb[randomnumber] != ker) {
//       i++;
//     }
//     // return i;
//   }
// }
// lineral_s = new Lineral_search();
// console.log(`Index-e a ${this.ker} -nek: ${this.randomnumber} `);


class Linker extends TombGeneral {
  constructor(keresettElem) {
    super(10,1,100); // elemszam, min, max módósítása / felülírása    // superrel meghívjuk a TombGeneral-t
    this.keresettElem = keresettElem; 
    // this.van = false; // fölösleges
    let i = 0;
    while (this.tomb[i] !== keresettElem && this.tomb.length >= i) {
      console.log(this.tomb[i]); // kiírja a tömb elemeit
      i++;
    }
    this.van = this.tomb.length >= i;
  }
  eredmeny() { // eredmeny kiírása
    console.log(`A ${this.keresettElem} ${this.van ? "megtalálható" : "nem található meg"} a tömbben`);
  }
}
linker = new Linker(Math.floor(Math.random() * 100)); // keresettElem értékének meghívása
linker.eredmeny(); // eredmeny meghivása