async function getData(url="") {
        const response = await fetch(url, {
             method: "GET", // POST, PUT, DELETE ...       
            headers: {
             "Content-Type" : "application/json",
             "Authorization" : "Bearer <token>"
            },    
        })
        return response.json();   
}; 

async function postData(url="", data = {}) {
    const response = await fetch(url, {
         method: "POST", // POST, PUT, DELETE ...       
        headers: {
         "Content-Type" : "application/json",
        }, 
        body: JSON.stringify(data),   
    })
    return response;   
}; 

// getData("http://localhost:8000/user").then((data) => {
//     console.log(data);
// });

// getData("http://localhost:8000/user/1").then((data) => {
//     console.log(data);
// });


// postData("http://localhost:8000/user",{name:"kis pista",email:"maci@gmail.com",password:"valami",accountNumber:"12235-145656"}).then((response) => {
//     return response.json();
//         }).then((data) => {console.log(data)});


// export { getData, postData };

