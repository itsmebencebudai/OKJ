import * as script from "../script.js";
// Felhasználó ID bekérése a prompt ablakban
const userId = prompt("Kérem, adja meg a felhasználó ID-jét:");

// Ellenőrzés, hogy valóban van-e megadva ID
if (userId !== null && userId !== "") {
    // Felhasználó adatainak lekérése a szerverről
    script.getData(`http://localhost:8000/user/${userId}`).then((data) => {
        console.log(data);
    }).then((userData) => {
        // Ellenőrzés, hogy a szerver visszatért-e adatokkal
        if (userData.length > 0) {
            // Az adatok megjelenítése a táblázatban
            const userTable = document.getElementById("user-list");

            userData.forEach((user) => {
                const row = userTable.insertRow();
                row.innerHTML = `
                        <td>${user.userID}</td>
                        <td>${user.name}</td>
                        <td>${user.email}</td>
                        <td>${user.password}</td>
                        <td>${user.accountNumber}</td>
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
