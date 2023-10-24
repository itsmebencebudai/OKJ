function handleSelection() {
    var selectedOption = document.getElementById("cars").value;
    var query1Div = document.querySelector(".query1_table");
    var query2Div = document.querySelector(".query2_table");
    var query3Div = document.querySelector(".query3_table");
    var query4Div = document.querySelector(".query4_table");

    if (selectedOption === "query1") {
        query1Div.style.display = "block";
    } else {
        query1Div.style.display = "none";
    }

    if (selectedOption === "query2") {
        query2Div.style.display = "block";
    } else {
        query2Div.style.display = "none";
    }

    if (selectedOption === "query3") {
        query3Div.style.display = "block";
    } else {
        query3Div.style.display = "none";
    }

    if (selectedOption === "query4") {
        query4Div.style.display = "block";
    } else {
        query4Div.style.display = "none";
    }
}