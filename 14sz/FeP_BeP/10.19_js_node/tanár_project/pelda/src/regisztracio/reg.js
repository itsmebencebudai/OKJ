regDataSave = (data) => {
    let loading = document.getElementById("loading");
    loading.style.visibility = "visible";
    postData("http://localhost:8000/reg", data).then((response) => {
        if (response.status == 404) {
            err = document.getElementById('error');
            err.innerHtml = "hiba";
            throw err.innerHtml = "hiba";
        }
        return response.json();
    }).then((data) => {
        console.log(data)
    }).catch((error) => {
        console.log(error)
        alert("hiba");
    }).finally(()=>{
        loading.style.visibility="hidden";
    })
}