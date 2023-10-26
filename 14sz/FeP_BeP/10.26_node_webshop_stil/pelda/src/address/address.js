import { postData } from "../script.js";

function regDataSave(data)  {
    postData("http://localhost:8000/address",data).then((response) => {
    return response.json();
        }).then((data) => {console.log(data)});
}
window.regDataSave = regDataSave;