import { postData } from "../scripts/.js";

function regDataSave(data) {
    postData("http://localhost:8000/user", data)
        .then((response) => {
            return response.json();
        }).then((data) => {
            if (data.status == 404) {
                err = document.getElementById("error");
                err.innerHTML = data.error;
            }
            console.log(data.error);
        }).catch((error) => {
            console.log(error);
        });
}
window.regDataSave = regDataSave;

