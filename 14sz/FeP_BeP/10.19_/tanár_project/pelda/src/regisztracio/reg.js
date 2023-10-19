regDataSave = (data) => {
    postData("http://localhost:8000/reg",data).then((response) => {
        console.log(response.status);
        console.log(headers);
    return response.json();
        }).then((data) => {
            console.log(data)
        }).catch((error)=>{
            console.log(error)
            alert("hiba");
        })
}