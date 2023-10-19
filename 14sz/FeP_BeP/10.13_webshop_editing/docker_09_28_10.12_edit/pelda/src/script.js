/*async function getData(url = "") { // async function getData
    const response = await fetch(url, {
        method: "GET", // post, get, delete, etc.
        headers: {
            "Content-Type": "application/json", // application
        },
    })
    // alert("HTTP-Error: " + response.status);
    return response.json(); // return
}

async function postData(url = "", data = {}) {  // async function postData
    const response = await fetch(url, {
        method: "POST", // post, get, delete, etc.
        headers: {
            "Content-Type": "application/json", // application
        },
        body: data, // JSON
    })
    // if (!response.ok) {
    //     const message = `An error has occured: ${response.status}`;
    //     throw new Error(message);
    // }
    return response; // return 

}

getData("http://localhost:8000/getdata").then((data) => { // return data in json format 
    console.log(data);
});

postData("http://localhost:8000", { a: 5 }).then((response) => { // return data in json format 
    return response.json()
}).then((data) => { console.log(data) });

/*postData("http://localhost:8000", {}).then((data) => { // return data in json format 
    console.log(data); 
});*/

/*postData("http://localhost:8000/szorzas", {}).then((data) => { // return data in json format  
    console.log(data);
}); */

async function getData(url = "") {
    const response = await fetch(url, {
        method: "GET", // POST, PUT, DELETE ...
        headers: {
            "Content-Type": "application/json",
        },
    })
    return response.json();
}

async function postData(url = "", data = {}) {
    const response = await fetch(url, {
        method: "POST", // POST, PUT, DELETE ...
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
    })
    return response;
}

getData("http://localhost:8000/getdata").then((data) => {
    console.log(data);
});

// const data = {
//     name: 'Mekk Elek',
//     email: 'mekk.elek@gmail.com',
//     password: 'hihi',
//     accountNumber: '1234-5464-5678-3233'
// }

// postData("http://localhost:8000/reg", data).then((response) => {
//     return response.json()
// }).then((data) => { console.log(data) });
