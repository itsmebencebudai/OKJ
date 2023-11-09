import { getData } from "../";

getData(`https://locahost:8000/tanar`).then(() => {
    const tanarTable = document.getElementById("tanar-list");

    userData.forEach((tanar) => {
        const row = tanarTable.insertRow();
        row.innerHTML = `
            <td>${tanar.name}</td>
            <td>${tanar.szavazott}</td>
        `;
    })
});