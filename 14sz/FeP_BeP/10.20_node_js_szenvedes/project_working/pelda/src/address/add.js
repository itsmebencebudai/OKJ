import { getData } from "../script.js";
import { postData } from "../script.js";

// Felhasználó ID bekérése a prompt ablakban
const userId = prompt("Kérem, adja meg a felhasználó ID-jét:");

// Ellenőrzés, hogy valóban van-e megadva ID
if (userId !== null && userId !== "") {
    // Felhasználó adatainak lekérése a szerverről
    getData(`http://localhost:8000/user/${userId}`).then((userData) => {
        // Ellenőrzés, hogy a szerver visszatért-e adatokkal
        if (userData.length > 0) {
            // Az adatok megjelenítése a táblázatban
            const addTable = document.getElementById("user-list");
            userData.forEach((address) => {
                const row = addTable.insertRow();
                row.innerHTML = `
                        <td>${address.addressID}</td>
                        <td>${address.zipCode}</td>
                        <td>${address.city}</td>
                        <td>${address.street}</td>
                        <td>${address.delevery}</td>
                    `;
            });
        } else {
            alert("Nincs találat a megadott ID-re.");
        }
    })
        .catch((error) => {
            console.error("Hiba történt:", error);
        });
} else {
    alert("Nem adott meg ID-t vagy a műveletet megszakította.");
}

function addDataSave(data) {
    let loading = document.getElementById("loading");
    loading.style.visibility = "visible";
    postData("http://localhost:8000/user", data)
        .then((response) => {
            return response.json();
        }).then((data) => {
            if (data.status == 404) {
                err = document.getElementById("error");
                err.innerHTML = data.error;
            }
            console.log(data.error);
        }).catch((error) => {
            console.log(error);
        }).finally(() => {
            loading.style.visibility = "hidden";
        });
}
export { addDataSave }; 
