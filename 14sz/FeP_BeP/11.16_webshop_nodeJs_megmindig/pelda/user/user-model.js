const mysql = require('mysql2');
const config  = require('../App/config');

// Ez a végpont regisztrál egy új felhasználót és lementi az adatbázisba
function getAllUserInfos (req,res) {

    var con = mysql.createConnection(config.database);
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    
    const userSQL = 'insert into User (name,email,password,accountNumber) values (?,?,?,?)'; 
    con.query(userSQL,[req.body.name,req.body.email,req.body.password,req.body.accountNumber], (err,result) => {
        if (err) { 
            console.log(err)
                res.status(404).send({status: 404 , error: "Hiba a user rögzítésekor"});
        }   else {
            res.status(200).send({status:200,success:"Sikeres adatrögzítés"})
        }
    }) 
   
}

function getUserDataFromID(req,res) {
    var con = mysql.createConnection(new Config());
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    con.query('CALL getAllUserInfos(?)',[req.params['id']], (err,result) =>{
        if (err) throw err;
            console.log("Result:", result[0])
            resultData = result[0];
            if (resultData.length > 0) {
                data = {name: "",
                email: "",

                accountNumber:"",
                address: []

            } ;
                data.name = resultData[0].name;
                data.email = resultData[0].email;
                data.accountNumber = resultData[0].accountNumber;
                resultData.forEach(row => {
                data.address.push({zipCode: row.zipCode,city: row.city,street:row.street,delivery:row.delivery}) 
                });
        }
        console.log(data)    
        res.send(data);
    })     
}


