
function regDataSave(data)  {
    console.log(data)
    postData("http://localhost:8000/api/address/1",data).then((response) => {
    return response.json();
        }).then((data) => {console.log(data)});
}
window.regDataSave = regDataSave;