// A jármű oszály definiálása történik
class Jarmu {

    //Az adatagok mindig a konstruktorban kerülnek definiálásra
    constructor (marka, sebesseg=0) {
        this._marka = marka;
        this._sebesseg = sebesseg;
        this.utasok = [];
    }
    
    get sebesseg () {
        return this._sebesseg;
    }

    set sebesseg(ujErtek) {
        if (typeof ujErtek ==='number' && ujErtek >0)
        {
            this._sebesseg = ujErtek;
        }
        else {
            console.log(`Hibas adat: ${ujErtek}!`);
        }
    }

    
    
    //Tagfüggvények definiciója
    info() {
        console.log(`${this._marka} márkájú jármű, melynek sebessége: ${this._sebesseg} km/h és az utasainak száma: ${this.utasok.length} `);
    }
    utasfelvesz(utasNeve) {
        if (typeof utasNeve === 'string') {
            this.utasok.push(utasNeve);
        }

    }
}

class Auto extends Jarmu {
    constructor (marka, sebesseg=0, onvezeto = false) {
        super(marka,sebesseg);
        this.onvezeto = onvezeto;
    }
    
    info() {
        console.log(`${this._marka} márkájú auto, melynek sebessége: ${this._sebesseg} km/h és az utasainak száma: ${this.utasok.length} önvezető: ${this.onvezeto ? "igen" : "nem"} `);
    }

    duda() {
        console.log("dudál");
    }
    
}

const jarmu = new Jarmu('Skoda', 50); //A Jármű osztály példányosítása létrejön a jarmu objektum

const jarmu1 = new Jarmu();


const auto = new Auto("skoda2",55,true);
auto.utasfelvesz("bubuka");
auto.info();
auto.duda();

console.log(jarmu instanceof Jarmu );
console.log(auto instanceof Jarmu );
console.log(jarmu instanceof  Auto);
console.log(jarmu.utasok instanceof  Array);



/*
jarmu.utasfelvesz('Maci Laci'); //Értéket adok a tagfüggvény segítségével az utasok változonak az Objektumban
jarmu.utasfelvesz("Bubu");
jarmu.info();
jarmu.sebesseg = 55;
console.log(jarmu.sebesseg);

jarmu1.info();
*/

class TombGeneral {
    constructor(elemszam = 10, min=1, max=10) {
        this.tomb = [];
        for (let i = 0; i < elemszam; i++) {
            this.tomb.push(Math.floor((Math.random() * (max-1))) + min);      
        }
    }
}

class Osszegzes extends TombGeneral{
    constructor() {
        super(12,1,-15);
        this.tomb2 = new TombGeneral().tomb;
        this.osszeg = 0
        for (let i = 0; i < this.tomb.length; i++) {
                this.osszeg += this.tomb[i];
        }
    }
    eredmeny () {
        console.log(`A tomb elemeinek összege: ${this.osszeg}`);

    }
}

class Linker extends TombGeneral {
        constructor (keresettElem) {
             super(10,1,20);
             let i = 0
             while (this.tomb[i] !== keresettElem && this.tomb.length>=i) {
                i++;
             }
             this.van = this.tomb.length >= i;
        }
    
        eredmeny() {
            console.log(this.tomb);
            console.log(`A keresett elem ${this.van ? "megtalálható": "nem található meg"} a tömben`);
        }
}

linker = new Linker(5);
console.log(linker.van);


//osszeg = new Osszegzes();

// for (const prop in osszeg) {
//    console.log(osszeg[prop])
// }

//osszeg.eredmeny();


