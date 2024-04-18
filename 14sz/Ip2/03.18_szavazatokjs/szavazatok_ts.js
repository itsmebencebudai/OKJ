var data = [
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
    var szavazatokSzama = data.length;
    return szavazatokSzama;
}
function KepviselokSzamaKiír() {
    var feladat_result1 = document.getElementById("1feladat_result");
    if (feladat_result1 !== null) {
        feladat_result1.innerHTML = "A helyhat\u00F3s\u00E1gi v\u00E1laszt\u00E1son ".concat(KepviselokSzama(), " k\u00E9pvisel\u0151jel\u00F6lt indult. <br/>");
    }
    else {
        console.log("Nincsen ".concat(document.getElementById("1feladat_result"), " ilyen ID "));
    }
}
KepviselokSzamaKiír();
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
function PartKepviselok() {
    var kiválasztottpartInput = document.getElementById("partySelect"); // Assuming "partySelect" is a select element
    var kiválasztottpart = kiválasztottpartInput.value;
    var kepviselok = data.filter(function (item) { return item.part === kiválasztottpart; }); // Filter candidates based on selected party
    return { kiválasztottpart: kiválasztottpart, kepviselok: kepviselok }; // Return an object containing both values
}
function PartKepviselokKiír() {
    var _a = PartKepviselok(), kiválasztottpart = _a.kiválasztottpart, kepviselok = _a.kepviselok; // Call PartKepviselok to get filtered candidates
    var feladat_result2 = document.getElementById("2feladat_result");
    if (kiválasztottpart == '' || kiválasztottpart == undefined || kiválasztottpart == null) {
        feladat_result2.innerHTML = "";
    }
    else {
        feladat_result2.innerHTML = "\"".concat(kiválasztottpart, "\" p\u00E1rt/f\u00FCggetlenk\u00E9nt ").concat(kepviselok.length, " k\u00E9pvisel\u0151t ind\u00EDtott a v\u00E1laszt\u00E1son."); // Display the result
    }
}
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
function CalculateCandidateInfo() {
    var vezeteknev = document.getElementById("vezeteknev").value.trim();
    var utonev = document.getElementById("utonev").value.trim();
    var nev = vezeteknev + " " + utonev;
    for (var i = 0; i < data.length; i++) {
        if (data[i].nev === nev) {
            return { nev: nev, szavazatokSzama: data[i].szavazat };
        }
    }
    return null;
}
function WriteCandidateInfoToDOM(info) {
    var feladat_result3 = document.getElementById("3feladat_result");
    if (feladat_result3 !== null) {
        if (info !== null) {
            feladat_result3.classList.remove("text-danger");
            feladat_result3.innerText = "Az ".concat(info.nev, " nev\u0171 k\u00E9pvisel\u0151jel\u00F6lt ").concat(info.szavazatokSzama, " szavazatot kapott.");
        }
        else {
            feladat_result3.innerText = "Ilyen nevű képviselőjelölt nem szerepel a nyilvántartásban!";
            feladat_result3.classList.add("text-danger");
        }
    }
}
function KepviseloInfo() {
    var candidateInfo = CalculateCandidateInfo();
    WriteCandidateInfoToDOM(candidateInfo);
}
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
function CalculateVoterTurnoutRatio(leadottSzavazatokSzama, data) {
    var osszszavazat = 0;
    data.forEach(function (item) {
        osszszavazat += item.szavazat;
    });
    return (osszszavazat / leadottSzavazatokSzama) * 100;
}
function WriteVoterTurnoutRatioToDOM(voterTurnoutRatio, leadottSzavazatokSzama) {
    var feladat_result4 = document.getElementById('4feladat_result');
    if (feladat_result4 !== null) {
        feladat_result4.innerHTML = "A v\u00E1laszt\u00E1son ".concat(leadottSzavazatokSzama, " szavazatot adtak le, a r\u00E9szv\u00E9teli ar\u00E1ny ").concat(voterTurnoutRatio.toFixed(2), "%.");
    }
}
function CalculateAndWriteVoterTurnoutRatio() {
    var leadottSzavazatokSzama = 12345;
    var reszveteliArany = CalculateVoterTurnoutRatio(leadottSzavazatokSzama, data);
    WriteVoterTurnoutRatioToDOM(reszveteliArany, leadottSzavazatokSzama);
}
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
function calculateAndWriteVotesPerParty(szavazatok, tableId) {
    var szavazatokPerPart = {};
    szavazatok.forEach(function (szavazat) {
        var part = szavazat.part || 'Független';
        if (!szavazatokPerPart[part]) {
            szavazatokPerPart[part] = 0;
        }
        szavazatokPerPart[part] += szavazat.szavazat;
    });
    var tableBody = document.querySelector("#".concat(tableId));
    if (tableBody) {
        for (var part in szavazatokPerPart) {
            var szavazatokSzama = szavazatokPerPart[part];
            var row = "<tr><td>".concat(part, "</td><td>").concat(szavazatokSzama, "</td></tr>");
            tableBody.insertAdjacentHTML('beforeend', row);
        }
    }
}
calculateAndWriteVotesPerParty(data, 'feladat_tbody_5');
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
function findCandidatesWithMostVotes(data) {
    var maxSzavazat = Math.max.apply(Math, data.map(function (item) { return item.szavazat; }));
    return data.filter(function (item) { return item.szavazat === maxSzavazat; });
}
function writeCandidatesWithMostVotesToDOM(candidates) {
    var feladat_result6 = document.getElementById("6feladat_result");
    if (feladat_result6 !== null) {
        if (candidates.length === 0) {
            feladat_result6.innerHTML = "Nincs olyan jelölt, aki a legtöbb szavazatot kapta.";
        }
        else {
            var tableBody_6_1 = document.querySelector('#feladat_tbody_6');
            if (tableBody_6_1 !== null) {
                candidates.forEach(function (item) {
                    var partRovidites = item.part !== "-" ? item.part : "független";
                    var row = "<tr><td>".concat(partRovidites, "</td><td>").concat(item.nev, "</td><td>").concat(item.szavazat, "</td></tr>");
                    tableBody_6_1.insertAdjacentHTML('beforeend', row);
                });
            }
            else {
                console.error("Element with ID ".concat(tableBody_6_1, " not found."));
            }
        }
    }
}
function findAndWriteCandidatesWithMostVotes(data) {
    var candidatesWithMostVotes = findCandidatesWithMostVotes(data);
    writeCandidatesWithMostVotesToDOM(candidatesWithMostVotes);
}
findAndWriteCandidatesWithMostVotes(data);
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
function processVotes() {
    data.sort(function (a, b) { return (a.korzet - b.korzet) || (b.szavazat - a.szavazat); });
    var gyoztesek = {};
    data.forEach(function (item) {
        var trimmedNev = item.nev.trim();
        if (!gyoztesek[item.korzet] || gyoztesek[item.korzet].szavazat < item.szavazat) {
            gyoztesek[item.korzet] = {
                vezeteknev: trimmedNev.split(' ')[0],
                utonev: trimmedNev.split(' ')[1],
                part: item.part !== "-" ? item.part : "független",
                szavazat: item.szavazat
            };
        }
    });
    var tableBody_nyertesek = document.getElementById('nyertesek_table_body');
    for (var korzet in gyoztesek) {
        var gyoztes = gyoztesek[korzet];
        var row = "<tr>\n            <td>".concat(korzet, "</td>\n            <td>").concat(gyoztes.vezeteknev, "</td>\n            <td>").concat(gyoztes.utonev, "</td>\n            <td>").concat(gyoztes.part, "</td>\n            <td>").concat(gyoztes.szavazat, "</td>\n        </tr>");
        if (tableBody_nyertesek instanceof HTMLElement) {
            tableBody_nyertesek.insertAdjacentHTML('beforeend', row);
        }
    }
}
processVotes();
