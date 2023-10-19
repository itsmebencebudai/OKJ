//import { postData } from "../script_copy.mjs"

regDataSave = (data) => {
    postData("http://localhost:8000/reg", data).then((response) => {
        return response.json()
    }).then((data) => { console.log(data) });

    // const name = document.getElementById('userName').value;
    // const email = document.getElementById('userEmail').value;
    // const password = document.getElementById('userPassword').value;
    // const accountnumber = document.getElementById('AccountNumber').value;

    // console.log(
    //     'Name: ' + name,
    //     'Email: ' + email,
    //     'Password: ' + password,
    //     'AccountNumber: ' + accountnumber
    // )
    //postData('http://localhost/8000/reg', data);
}


//PROGRESS BAR
const progressBar = document.querySelector('.progress-bar');
const registrationSteps = document.querySelectorAll('.registration-step');
let currentStep = 0;

function showStep(stepIndex) {
    // registrationSteps[currentStep].style.display = 'none';
    registrationSteps[stepIndex].style.display = 'block';
    currentStep = stepIndex;
    const progressWidth = ((stepIndex + 1) / registrationSteps.length) * 100;
    progressBar.style.width = progressWidth + '%';
}

function OnchangeProgressbar() {
    if (currentStep < registrationSteps.length - 1) {
        showStep(currentStep + 1);
    }
};







