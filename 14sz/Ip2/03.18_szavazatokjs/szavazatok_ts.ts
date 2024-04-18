interface Szavazatok {
    korzet: number;
    szavazat: number;
    nev: string;
    part: string;
}

interface Gyoztes {
    vezeteknev: string;
    utonev: string;
    part: string;
    szavazat: number;
}

const data: Szavazatok[] = [
    { korzet: 5, szavazat: 19, nev: "Ablak Antal", part: "-" },
    { korzet: 1, szavazat: 120, nev: " Alma Dalma", part: "GYEP" },
    { korzet: 7, szavazat: 162, nev: " Bab Zsuzsanna", part: "ZEP" },
    { korzet: 2, szavazat: 59, nev: "Barack Barna", part: "GYEP" },
    { korzet: 6, szavazat: 73, nev: "Birs Helga", part: "GYEP" },
    { korzet: 1, szavazat: 154, nev: " Bors Botond", part: "HEP" },
    { korzet: 5, szavazat: 188, nev: " Brokkoli Gyula", part: "ZEP" },
    { korzet: 6, szavazat: 29, nev: "Ceruza Zsombor", part: "-" },
    { korzet: 4, szavazat: 143, nev: " Fasirt Ferenc", part: "HEP" },
    { korzet: 8, szavazat: 157, nev: " Gomba Gitta", part: "TISZ" },
    { korzet: 3, szavazat: 13, nev: "Halmi Helga", part: "-" },
    { korzet: 2, szavazat: 66, nev: "Hold Ferenc", part: "-" },
    { korzet: 7, szavazat: 34, nev: "Hurka Herold", part: "HEP" },
    { korzet: 5, szavazat: 288, nev: " Joghurt Jakab", part: "TISZ" },
    { korzet: 4, szavazat: 77, nev: "Kajszi Kolos", part: "GYEP" },
    { korzet: 2, szavazat: 187, nev: " Kapor Karola", part: "ZEP" },
    { korzet: 6, szavazat: 13, nev: "Karfiol Ede", part: "ZEP" },
    { korzet: 6, szavazat: 187, nev: " Kefir Ilona", part: "TISZ" },
    { korzet: 7, szavazat: 130, nev: " Kupa Huba", part: "-" },
    { korzet: 8, szavazat: 98, nev: "Languszta Auguszta", part: "-" },
    { korzet: 1, szavazat: 34, nev: "Lila Lilla", part: "-" },
    { korzet: 1, szavazat: 56, nev: "Medve Rudolf", part: "-" },
    { korzet: 5, szavazat: 67, nev: "Meggy Csilla", part: "GYEP" },
    { korzet: 3, szavazat: 45, nev: "Moly Piroska", part: "-" },
    { korzet: 4, szavazat: 221, nev: " Monitor Tibor", part: "-" },
    { korzet: 8, szavazat: 288, nev: " Narancs Edmond", part: "GYEP" },
    { korzet: 2, szavazat: 220, nev: " Oldalas Olga", part: "HEP" },
    { korzet: 3, szavazat: 185, nev: " Pacal Kata", part: "HEP" },
    { korzet: 1, szavazat: 199, nev: " Petrezselyem Petra", part: "ZEP" },
    { korzet: 8, szavazat: 77, nev: "Pokol Vidor", part: "-" },
    { korzet: 8, szavazat: 67, nev: "Ragu Ida", part: "HEP" },
    { korzet: 3, szavazat: 156, nev: " Retek Etelka", part: "ZEP" },
    { korzet: 7, szavazat: 129, nev: " Sajt Hajnalka", part: "TISZ" },
    { korzet: 4, szavazat: 38, nev: "Simon Simon", part: "-" },
    { korzet: 3, szavazat: 87, nev: "Szilva Szilvia", part: "GYEP" },
    { korzet: 3, szavazat: 187, nev: " Tejes Attila", part: "TISZ" },
    { korzet: 2, szavazat: 65, nev: "Tejfel Edit", part: "TISZ" },
    { korzet: 4, szavazat: 39, nev: "Uborka Ubul", part: "ZEP" },
    { korzet: 6, szavazat: 288, nev: " Vadas Marcell", part: "HEP" },
    { korzet: 5, szavazat: 68, nev: "Vagdalt Edit", part: "HEP" },
];


// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


function KepviselokSzama() {
    const szavazatokSzama: number = data.length;
    return szavazatokSzama;
}
function KepviselokSzamaKiír() {
    const feladat_result1 = document.getElementById("1feladat_result");
    if (feladat_result1 !== null) {
        feladat_result1.innerHTML = `A helyhatósági választáson ${KepviselokSzama()} képviselőjelölt indult. <br/>`;
    } else {
        console.log(`Nincsen ${document.getElementById("1feladat_result")} ilyen ID `);
    }
}
KepviselokSzamaKiír();


// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


function PartKepviselok() {
    const kiválasztottpartInput = document.getElementById("partySelect") as HTMLSelectElement; // Assuming "partySelect" is a select element
    const kiválasztottpart = kiválasztottpartInput.value;
    const kepviselok = data.filter(item => item.part === kiválasztottpart); // Filter candidates based on selected party
    return { kiválasztottpart, kepviselok }; // Return an object containing both values
}
function PartKepviselokKiír() {
    const { kiválasztottpart, kepviselok } = PartKepviselok(); // Call PartKepviselok to get filtered candidates
    const feladat_result2 = document.getElementById("2feladat_result") as HTMLParagraphElement;
    if (kiválasztottpart == '' || kiválasztottpart == undefined || kiválasztottpart == null) {
        feladat_result2.innerHTML = "";
    } else {
        feladat_result2.innerHTML = `"${kiválasztottpart}" párt/függetlenként ${kepviselok.length} képviselőt indított a választáson.`; // Display the result
    }
}


// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


function CalculateCandidateInfo(): { nev: string; szavazatokSzama: number } | null {
    const vezeteknev: string = (document.getElementById("vezeteknev") as HTMLInputElement).value.trim();
    const utonev: string = (document.getElementById("utonev") as HTMLInputElement).value.trim();
    const nev: string = vezeteknev + " " + utonev;

    for (let i: number = 0; i < data.length; i++) {
        if (data[i].nev === nev) {
            return { nev: nev, szavazatokSzama: data[i].szavazat };
        }
    }
    return null;
}
function WriteCandidateInfoToDOM(info: { nev: string; szavazatokSzama: number } | null): void {
    const feladat_result3: HTMLElement | null = document.getElementById("3feladat_result");
    if (feladat_result3 !== null) {
        if (info !== null) {
            feladat_result3.classList.remove("text-danger");
            feladat_result3.innerText = `Az ${info.nev} nevű képviselőjelölt ${info.szavazatokSzama} szavazatot kapott.`;
        } else {
            feladat_result3.innerText = "Ilyen nevű képviselőjelölt nem szerepel a nyilvántartásban!";
            feladat_result3.classList.add("text-danger");
        }
    }
}
function KepviseloInfo(): void {
    const candidateInfo = CalculateCandidateInfo();
    WriteCandidateInfoToDOM(candidateInfo);
}


// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


function CalculateVoterTurnoutRatio(leadottSzavazatokSzama: number, data: { szavazat: number }[]): number {
    let osszszavazat: number = 0;

    data.forEach(item => {
        osszszavazat += item.szavazat;
    });

    return (osszszavazat / leadottSzavazatokSzama) * 100;
}
function WriteVoterTurnoutRatioToDOM(voterTurnoutRatio: number, leadottSzavazatokSzama: number): void {
    const feladat_result4: HTMLElement | null = document.getElementById('4feladat_result');
    if (feladat_result4 !== null) {
        feladat_result4.innerHTML = `A választáson ${leadottSzavazatokSzama} szavazatot adtak le, a részvételi arány ${voterTurnoutRatio.toFixed(2)}%.`;
    }
}
function CalculateAndWriteVoterTurnoutRatio(): void {
    const leadottSzavazatokSzama: number = 12345;
    const reszveteliArany: number = CalculateVoterTurnoutRatio(leadottSzavazatokSzama, data);
    WriteVoterTurnoutRatioToDOM(reszveteliArany, leadottSzavazatokSzama);
}


// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


function calculateAndWriteVotesPerParty(szavazatok: Szavazatok[], tableId: string): void {
    const szavazatokPerPart: Record<string, number> = {};
    szavazatok.forEach((szavazat: Szavazatok) => {
        const part: string = szavazat.part || 'Független';
        if (!szavazatokPerPart[part]) {
            szavazatokPerPart[part] = 0;
        }
        szavazatokPerPart[part] += szavazat.szavazat;
    });
    const tableBody: HTMLElement | null = document.querySelector(`#${tableId}`);
    if (tableBody) {
        for (const part in szavazatokPerPart) {
            const szavazatokSzama: number = szavazatokPerPart[part];
            const row: string = `<tr><td>${part}</td><td>${szavazatokSzama}</td></tr>`;
            tableBody.insertAdjacentHTML('beforeend', row);
        }
    }
}
calculateAndWriteVotesPerParty(data, 'feladat_tbody_5');


// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


function findCandidatesWithMostVotes(data: Szavazatok[]): Szavazatok[] {
    const maxSzavazat = Math.max(...data.map(item => item.szavazat));
    return data.filter(item => item.szavazat === maxSzavazat);
}
function writeCandidatesWithMostVotesToDOM(candidates: Szavazatok[]): void {
    const feladat_result6: HTMLElement | null = document.getElementById("6feladat_result");
    if (feladat_result6 !== null) {
        if (candidates.length === 0) {
            feladat_result6.innerHTML = "Nincs olyan jelölt, aki a legtöbb szavazatot kapta.";
        } else {
            const tableBody_6 = document.querySelector('#feladat_tbody_6');
            if (tableBody_6 !== null) {
                candidates.forEach(item => {
                    let partRovidites = item.part !== "-" ? item.part : "független";
                    const row = `<tr><td>${partRovidites}</td><td>${item.nev}</td><td>${item.szavazat}</td></tr>`;
                    tableBody_6.insertAdjacentHTML('beforeend', row);
                });
            } else {
                console.error(`Element with ID ${tableBody_6} not found.`);
            }
        }
    }
}
function findAndWriteCandidatesWithMostVotes(data: Szavazatok[]): void {
    const candidatesWithMostVotes = findCandidatesWithMostVotes(data);
    writeCandidatesWithMostVotesToDOM(candidatesWithMostVotes);
}
findAndWriteCandidatesWithMostVotes(data);


// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

function processVotes(): void {
    data.sort((a, b) => (a.korzet - b.korzet) || (b.szavazat - a.szavazat));
    const gyoztesek: Record<number, Gyoztes> = {};
    data.forEach(item => {
        const trimmedNev = item.nev.trim();
        if (!gyoztesek[item.korzet] || gyoztesek[item.korzet].szavazat < item.szavazat) {
            gyoztesek[item.korzet] = {
                vezeteknev: trimmedNev.split(' ')[0],
                utonev: trimmedNev.split(' ')[1],
                part: item.part !== "-" ? item.part : "független",
                szavazat: item.szavazat
            };
        }
    });
    const tableBody_nyertesek = document.getElementById('nyertesek_table_body');
    for (const korzet in gyoztesek) {
        const gyoztes = gyoztesek[korzet];
        const row = `<tr>
            <td>${korzet}</td>
            <td>${gyoztes.vezeteknev}</td>
            <td>${gyoztes.utonev}</td>
            <td>${gyoztes.part}</td>
            <td>${gyoztes.szavazat}</td>
        </tr>`;
        if (tableBody_nyertesek instanceof HTMLElement) {
            tableBody_nyertesek.insertAdjacentHTML('beforeend', row);
        }
    }
}
processVotes();