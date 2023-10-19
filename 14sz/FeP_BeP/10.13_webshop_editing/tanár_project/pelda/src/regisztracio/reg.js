
regDataSave = (data) => {
    postData("http://localhost:8000/reg",data).then((response) => {
    return response.json();
        }).then((data) => {console.log(data)});
}