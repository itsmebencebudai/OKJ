
// Felhasználó ID bekérése a prompt ablakban
const userId = prompt("Kérem, adja meg a felhasználó ID-jét:");

// Ellenőrzés, hogy valóban van-e megadva ID
if (userId !== null && userId !== "") {
    // Felhasználó adatainak lekérése a szerverről
   // getData(`http://localhost:8000/api/user/${userId}`).then((userData) => {
        getData(`http://localhost:3000/backend/RESTAPI/index.php?user=`).then((userData) => {
            console.log(userData);
            // Ellenőrzés, hogy a szerver visszatért-e adatokkal
            if (userData) {
                // Az adatok megjelenítése a táblázatban
                const userTable = document.getElementById("user-list");
                const row = userTable.insertRow();
                    row.innerHTML = `
                       
                        <td>${userData.name}</td>
                        <td>${userData.email}</td>
                        <td>${userData.accountNumber}</td>
                    `;    

                    row.innerHTML +='<td>'
                    
                    userData.address.forEach((address) => {
                    row.innerHTML += address.zipCode+', '+ address.city + ' ' + address.street+'<br>';
                });
                    row.innerHTML +='</td>'
            } else {
                alert("Nincs találat a megadott ID-re.");
            }
        })
        .catch((error) => {
            console.error({"Hiba történt": error});
        });
} else {
    alert("Nem adott meg ID-t vagy a műveletet megszakította.");
}
