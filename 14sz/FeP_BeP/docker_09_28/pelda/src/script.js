async function getData(url = "") { // async function getData
    const response = await fetch(url, {
        method: "GET", // post, get, delete, etc.
        headers: { 
            "Content-Type": "application/json", // application
        },
    })
    return response.json(); // return
}
getData("http://localhost:8000", {}).then((data) => { // return data in json format 
    console.log(data); 
});

async function postData(url = "",data = {}) {  // async function postData
    const response = await fetch(url, {  
        method: "POST", // post, get, delete, etc.
        headers: { 
            "Content-Type": "application/json", // application
        },
        body: JSON.stringify({data}), // JSON
    })
    return response.json(); // return 
}
postData("http://localhost:8000", {}).then((data) => { // return data in json format 
    console.log(data); 
});
postData("http://localhost:8000/szorzas", {}).then((data) => { // return data in json format  
    console.log(data);
}); 