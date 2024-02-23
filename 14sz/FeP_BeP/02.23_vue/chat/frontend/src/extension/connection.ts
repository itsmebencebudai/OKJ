export async function autFetch(url="", data: {}) {
    const response = await fetch(url, {
         method: "POST", // POST, PUT, DELETE ...       
        headers: {
         "Content-Type" : "application/json",
        }, 
        body: JSON.stringify(data),      
    })
    return response.json();   
}; 

export async function getData(url="", token:string) {
    const response = await fetch(url, {
         method: "GET", // POST, PUT, DELETE ...       
        headers: {
         "Content-Type" : "application/json",
         "x-access-token" : token
        },    
    })
    return response.json();   
}; 



export async function postData(url="", data = {}, token:string) {
const response = await fetch(import.meta.env.BASE_API_URL + url, {
     method: "POST", // POST, PUT, DELETE ...       
    headers: {
     "Content-Type" : "application/json",
     "x-access-token" : token
    }, 
    body: JSON.stringify(data),   
})
return response;   
};