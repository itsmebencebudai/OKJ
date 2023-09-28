class Tomb {
  constructor() {
    this.elemek = [];
  }
  hozzaad(elem) {
    this.elemek.push(elem);
  }
  meret() {
    return this.elemek.length;
  }
  listaz() {
    return this.elemek;
  }
  torol() {
    this.elemek.shift // az első elem eltávolítása
  }
}
// Példányosítás és használat
const tomb = new Tomb();
for (let i = 0; i < (Math.floor(Math.random() * 10) + 1); i++) {
  tomb.hozzaad(Math.floor(Math.random() * 100) + 1);
}
console.log("Lista: " + tomb.listaz() + " Meret: " + tomb.meret());

/**********************************************************************/

//Szétválogatás
class Szetvalogato {
  constructor(tombbeolvas) {
    this.tomb = tombbeolvas;
  }

  parosSzamok() {
    return this.tomb.filter(elem => elem % 2 === 0);
  }

  paratlanSzamok() {
    return this.tomb.filter(elem => elem % 2 !== 0);
  }
}
const eredetiTomb_szetvalogato = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
const szetvalogato = new Szetvalogato(eredetiTomb_szetvalogato);
//páros
const parosak = szetvalogato.parosSzamok();
console.log("Páros számok:", parosak);
//páratlan
const paratlanok = szetvalogato.paratlanSzamok();
console.log("Páratlan számok:", paratlanok);

/**********************************************************************/

//Rendezés közvetlen kiválasztással
class SelectionSort {
  constructor(tomb) {
    this.tomb = tomb;
  }
  rendezes() {
    const n = this.tomb.length;
    for (let i = 0; i < n - 1; i++) {
      let minIndex = i;
      for (let j = i + 1; j < n; j++) {
        if (this.tomb[j] < this.tomb[minIndex]) {
          minIndex = j;
        }
      }
      if (minIndex !== i) {
        const temp = this.tomb[i];
        this.tomb[i] = this.tomb[minIndex];
        this.tomb[minIndex] = temp;
      }
    }
  }
  listaz() {
    return this.tomb;
  }
}
const eredetiTomb_selectionsort = [64, 34, 25, 12, 22, 11, 90];
const rendezo_selectionsort = new SelectionSort(eredetiTomb_selectionsort);
rendezo_selectionsort.rendezes();
console.log("(Selection Sort) Rendezett tömb: ", rendezo_selectionsort.listaz());

/**********************************************************************/

//Shell rendezés
class ShellSort {
  constructor(tomb) {
    this.tomb = tomb;
  }
  rendezes() {
    const n = this.tomb.length;
    let gap = Math.floor(n / 2);
    while (gap > 0) {
      for (let i = gap; i < n; i++) {
        const kulcs = this.tomb[i];
        let j = i;
        while (j >= gap && this.tomb[j - gap] > kulcs) {
          this.tomb[j] = this.tomb[j - gap];
          j -= gap;
        }
        this.tomb[j] = kulcs;
      }
      gap = Math.floor(gap / 2);
    }
  }
  listaz() {
    return this.tomb;
  }
}
const eredetiTomb_shellsort = [64, 34, 25, 12, 22, 11, 90];
const rendezo_shellsort = new ShellSort(eredetiTomb_shellsort);
rendezo_shellsort.rendezes();
console.log("(Shell Sort) Rendezett tömb: ", rendezo_shellsort.listaz());

/**********************************************************************/

//Únio
class UnionSet {
  constructor(halmaz1, halmaz2) {
    this.halmaz1 = halmaz1;
    this.halmaz2 = halmaz2;
  }
  unio() {
    const eredmenyHalmaz_unio = [...this.halmaz1];
    for (const elem of this.halmaz2) {
      if (!this.halmaz1.includes(elem)) {
        eredmenyHalmaz_unio.push(elem);
      }
    }
    return eredmenyHalmaz_unio;
  }
}
const halmazA_unio = [1, 2, 3, 4, 5];
const halmazB_unio = [3, 4, 5, 6, 7];
const unioSet = new UnionSet(halmazA_unio, halmazB_unio);
const eredmenyHalmaz_unio = unioSet.unio();
console.log("Unió eredmény:", eredmenyHalmaz_unio);

/**********************************************************************/

//Beszúrásos rendezés
class BeszuroRendezes {
  constructor(tomb) {
    this.tomb = tomb;
  }
  rendezes() {
    const n = this.tomb.length;
    for (let i = 1; i < n; i++) {
      const kulcs = this.tomb[i];
      let j = i - 1;
      while (j >= 0 && this.tomb[j] > kulcs) {
        this.tomb[j + 1] = this.tomb[j];
        j--;
      }
      this.tomb[j + 1] = kulcs;
    }
  }
  listaz() {
    return this.tomb;
  }
}
const eredetiTomb_beszurasosrendezes = [64, 34, 25, 12, 22, 11, 90];
const rendezo_beszurasosrendezes = new BeszuroRendezes(eredetiTomb_beszurasosrendezes);
rendezo_beszurasosrendezes.rendezes();
console.log("(Beszurasos Rendezes) Rendezett tömb: ", rendezo_beszurasosrendezes.listaz());

/**********************************************************************/

//BinárisKeresés
class BinarySearch {
  constructor(tomb) {
    this.tomb = tomb.sort((a, b) => a - b); // A tömb rendezése
  }
  kereses(keresettElem) {
    let balIndex = 0;
    let jobbIndex = this.tomb.length - 1;
    while (balIndex <= jobbIndex) {
      const kozepIndex = Math.floor((balIndex + jobbIndex) / 2);
      const kozepElem = this.tomb[kozepIndex];
      if (kozepElem === keresettElem) {
        return kozepIndex; // Az elem megtalálva
      } else if (kozepElem < keresettElem) {
        balIndex = kozepIndex + 1; // Folytatás a jobb felé
      } else {
        jobbIndex = kozepIndex - 1; // Folytatás a bal felé
      }
    }
    return -1; // Az elem nem található a tömbben
  }
}
const eredetiTomb_binariskereses = [2, 4, 6, 8, 10, 12, 14, 16];
const keresettElem_binariskereses = 10;
const kereso_binariskereses = new BinarySearch(eredetiTomb_binariskereses);
const eredmeny_binariskereses = kereso_binariskereses.kereses(keresettElem_binariskereses);
if (eredmeny_binariskereses !== -1) {
  console.log(`Az elem megtalálva a pozíció: ${eredmeny_binariskereses}, keresett elem a ${keresettElem_binariskereses}`);
} else {
  console.log("Az elem nem található a tömbben.");
}

/**********************************************************************/

//Buborékos rendezés
class BuborekosRendezes {
  constructor(tomb) {
    this.tomb = tomb;
  }
  rendezes() {
    const n = this.tomb.length;
    for (let i = 0; i < n - 1; i++) {
      for (let j = 0; j < n - i - 1; j++) {
        if (this.tomb[j] > this.tomb[j + 1]) {
          const temp = this.tomb[j];
          this.tomb[j] = this.tomb[j + 1];
          this.tomb[j + 1] = temp;
        }
      }
    }
  }
  listaz() {
    return this.tomb;
  }
}
const eredetiTomb_buborekosrendezes = [64, 34, 25, 12, 22, 11, 90];
const rendezo_buborekosrendezes = new BuborekosRendezes(eredetiTomb_buborekosrendezes);
rendezo_buborekosrendezes.rendezes();
console.log("(Buborekos Rendezes) Rendezett tömb: ", rendezo_buborekosrendezes.listaz());

/**********************************************************************/

//Eldöntés
class Eldontes {
  constructor(tomb) {
    this.tomb = tomb;
  }
  mindenElemParos() {
    for (const elem of this.tomb) {
      if (elem % 2 !== 0) {
        return false;
      }
    }
    return true;
  }
}
const tomb1_Eldontes = [2, 4, 6, 8, 10];
const tomb2_Eldontes = [2, 4, 6, 7, 8];
const eldontes1_Eldontes = new Eldontes(tomb1_Eldontes);
const eldontes2_Eldontes = new Eldontes(tomb2_Eldontes);
console.log("Az összes elem páros tomb1-ben:", eldontes1_Eldontes.mindenElemParos() + ` ${tomb1_Eldontes}`);
console.log("Az összes elem páros tomb2-ben:", eldontes2_Eldontes.mindenElemParos() + ` ${tomb2_Eldontes}`);

/**********************************************************************/

//Gyors rendezés
class GyorsRendezes {
  constructor(tomb) {
    this.tomb = tomb;
  }
  rendezes(balIndex = 0, jobbIndex = this.tomb.length - 1) {
    if (balIndex < jobbIndex) {
      const pivotIndex = this.particio(balIndex, jobbIndex);
      this.rendezes(balIndex, pivotIndex - 1);
      this.rendezes(pivotIndex + 1, jobbIndex);
    }
  }
  particio(balIndex, jobbIndex) {
    const pivot = this.tomb[jobbIndex];
    let i = balIndex - 1;
    for (let j = balIndex; j < jobbIndex; j++) {
      if (this.tomb[j] < pivot) {
        i++;
        this.csere(i, j);
      }
    }
    this.csere(i + 1, jobbIndex);
    return i + 1;
  }
  csere(index1, index2) {
    const temp = this.tomb[index1];
    this.tomb[index1] = this.tomb[index2];
    this.tomb[index2] = temp;
  }
  listaz() {
    return this.tomb;
  }
}
const eredetiTomb_GyorsRendezes = [64, 34, 25, 12, 22, 11, 90];
const rendezo_GyorsRendezes = new GyorsRendezes(eredetiTomb_GyorsRendezes);
rendezo_GyorsRendezes.rendezes();
console.log("(Gyors Rendezes) Rendezett tömb: ", rendezo_GyorsRendezes.listaz());

/**********************************************************************/

//Indexvektoros rendezés
class IndexVektorosRendezes {
  constructor(tomb) {
    this.tomb = tomb;
    this.indexek = this.initIndexek();
  }
  initIndexek() {
    const indexek = [];
    for (let i = 0; i < this.tomb.length; i++) {
      indexek.push(i);
    }
    return indexek;
  }
  rendezes() {
    this.indexek.sort((a, b) => {
      return this.tomb[a] - this.tomb[b];
    });
  }
  listaz() {
    const rendezettTomb = [];
    for (const index of this.indexek) {
      rendezettTomb.push(this.tomb[index]);
    }
    return rendezettTomb;
  }
}
const eredetiTomb_IndexVektorosRendezes = [64, 34, 25, 12, 22, 11, 90];
const rendezo_IndexVektorosRendezes = new IndexVektorosRendezes(eredetiTomb_IndexVektorosRendezes);
rendezo_IndexVektorosRendezes.rendezes();
console.log("(Index Vektoros Rendezes) Rendezett tömb:", rendezo_IndexVektorosRendezes.listaz());

/**********************************************************************/

//Kiválogatás
class Kivalogatas {
  constructor(tomb) {
    this.tomb = tomb;
  }
  kivalogat(feltetel) {
    const kivalogatottElemek = [];
    for (const elem of this.tomb) {
      if (feltetel(elem)) {
        kivalogatottElemek.push(elem);
      }
    }
    return kivalogatottElemek;
  }
}
const eredetiTomb_Kivalogatas = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
const kivalogatasOsztaly = new Kivalogatas(eredetiTomb_Kivalogatas);
const parosSzamok_Kivalogatas = kivalogatasOsztaly.kivalogat(elem => elem % 2 === 0);
console.log("Páros számok:", parosSzamok_Kivalogatas);

/**********************************************************************/

//Lineáris keresés 
class LinearSearch {
  constructor(tomb) {
    this.tomb = tomb;
  }
  kereses(keresettElem) {
    for (let i = 0; i < this.tomb.length; i++) {
      if (this.tomb[i] === keresettElem) {
        return i; // Az elem pozíciója, ha megtaláljuk
      }
    }
    return -1; // -1, ha az elem nem található a tömbben
  }
}
const eredetiTomb_LinearSearch = [3, 7, 1, 9, 2, 6, 4, 8, 5];
const keresendoElem_LinearSearch = 6;
const kereso_LinearSearch = new LinearSearch(eredetiTomb_LinearSearch);
const eredmeny_LinearSearch = kereso_LinearSearch.kereses(keresendoElem_LinearSearch);
if (eredmeny_LinearSearch !== -1) {
  console.log(`Az elem megtalálva, a pozíció: ${eredmeny_LinearSearch}`);
} else {
  console.log("Az elem nem található a tömbben.");
}

/**********************************************************************/

//Max
class MaxKereses {
  constructor(tomb) {
    this.tomb = tomb;
  }
  keresMax() {
    if (this.tomb.length === 0) {
      throw new Error("A tömb üres, nincs maximum.");
    }
    let maxElem = this.tomb[0];
    for (let i = 1; i < this.tomb.length; i++) {
      if (this.tomb[i] > maxElem) {
        maxElem = this.tomb[i];
      }
    }
    return maxElem;
  }
}
const eredetiTomb_MaxKereses = [3, 7, 1, 9, 2, 6, 4, 8, 5];
const kereso_MaxKereses = new MaxKereses(eredetiTomb_MaxKereses);
try {
  const maxElem = kereso_MaxKereses.keresMax();
  console.log("A tömb legnagyobb eleme:", maxElem);
} catch (error) {
  console.error(error.message);
}

/**********************************************************************/

//Megszalalas
class Megszamlalas {
  constructor(tomb) {
    this.tomb = tomb;
  }
  megszamol(feltetel) {
    let szamlalo = 0;
    for (const elem of this.tomb) {
      if (feltetel(elem)) {
        szamlalo++;
      }
    }
    return szamlalo;
  }
}
const eredetiTomb_Megszamlalas = [3, 7, 1, 9, 2, 6, 4, 8, 5];
const feltetel = elem => elem % 2 === 0; //Páros számok megszámolása
const megszamlalo_Megszamlalas = new Megszamlalas(eredetiTomb_Megszamlalas);
const szamoltElemek_Megszamlalas = megszamlalo_Megszamlalas.megszamol(feltetel);
console.log("Megszámolt elemek száma:", szamoltElemek_Megszamlalas);

/**********************************************************************/

//Metszet
class Metszet {
  constructor(tomb1, tomb2) {
    this.tomb1 = tomb1;
    this.tomb2 = tomb2;
  }
  kiszamolMetszet() {
    const eredmeny = [];
    for (const elem1 of this.tomb1) {
      if (this.tomb2.includes(elem1) && !eredmeny.includes(elem1)) {
        eredmeny.push(elem1);
      }
    }
    return eredmeny;
  }
}
const tomb1_Metszet = [1, 2, 3, 4, 5];
const tomb2_Metszet = [3, 4, 5, 6, 7];
const metszetKereso = new Metszet(tomb1_Metszet, tomb2_Metszet);
const metszet = metszetKereso.kiszamolMetszet();
console.log("A két tömb metszete:", metszet);

/**********************************************************************/

//Min
class MinKereses {
  constructor(tomb) {
    this.tomb = tomb;
  }
  keresMin() {
    if (this.tomb.length === 0) {
      throw new Error("A tömb üres, nincs minimum.");
    }
    let minElem = this.tomb[0];
    for (let i = 1; i < this.tomb.length; i++) {
      if (this.tomb[i] < minElem) {
        minElem = this.tomb[i];
      }
    }
    return minElem;
  }
}
const eredetiTomb_MinKereses = [3, 7, 1, 9, 2, 6, 4, 8, 5];
const kereso_MinKereses = new MinKereses(eredetiTomb_MinKereses);
try {
  const minElem = kereso_MinKereses.keresMin();
  console.log("A tömb legkisebb eleme:", minElem);
} catch (error) {
  console.error(error.message);
}

/**********************************************************************/

//Összefuttatás
class Osszefuttatas {
  constructor(tomb1, tomb2) {
    this.tomb1 = tomb1;
    this.tomb2 = tomb2;
  }
  osszefuttat() {
    const eredmeny = [];
    let i = 0;
    let j = 0;
    while (i < this.tomb1.length && j < this.tomb2.length) {
      if (this.tomb1[i] < this.tomb2[j]) {
        eredmeny.push(this.tomb1[i]);
        i++;
      } else {
        eredmeny.push(this.tomb2[j]);
        j++;
      }
    }
    while (i < this.tomb1.length) {
      eredmeny.push(this.tomb1[i]);
      i++;
    }
    while (j < this.tomb2.length) {
      eredmeny.push(this.tomb2[j]);
      j++;
    }
    return eredmeny;
  }
}
const tomb1_Osszefuttatas = [1, 3, 5, 7, 9];
const tomb2_Osszefuttatas = [2, 4, 6, 8, 10];
const osszefuttato = new Osszefuttatas(tomb1_Osszefuttatas, tomb2_Osszefuttatas);
const eredmeny_Osszefuttatas = osszefuttato.osszefuttat();
console.log("Összefuttatott tömb:", eredmeny_Osszefuttatas);

/**********************************************************************/

//Összegzés
class Osszegzes {
  constructor(tomb) {
    this.tomb = tomb;
  }
  osszegzes() {
    let osszeg = 0;
    for (const elem of this.tomb) {
      osszeg += elem;
    }
    return osszeg;
  }
}
const eredetiTomb_Osszegzes = [3, 7, 1, 9, 2, 6, 4, 8, 5];
const osszegzo = new Osszegzes(eredetiTomb_Osszegzes);
const osszeg = osszegzo.osszegzes();
console.log("A tömb elemeinek összege:", osszeg);
