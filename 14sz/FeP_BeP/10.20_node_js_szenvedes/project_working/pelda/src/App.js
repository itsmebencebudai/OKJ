const express = require('express');
const cors = require('cors');
const mysql = require('mysql2');
const Config  = require('../config');
const app = express();
const port = 8000;

//Betölti a CORS támogatást 
app.use(cors({origin: '*'}));

//lehetővé teszi a POST kérések elküldött adatainak (body) elérését
app.use(express.json());


// ez a végpont mutatja, hogy fut a node js szerver
app.get('/',(req,res) => {
    res.send("<h1>Szerver fut</h1>")
})

// ez a végpont visszaadja az összes felhasználó adatát
app.get('/user',(req,res) => {

    var con = mysql.createConnection(new Config());
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    con.query('select * from User', (err,result) =>{
        if (err) throw err;
        res.send(result);
    })   
})

// Ez a végpont regisztrál egy új felhasználót és lementi az adatbázisba
app.post('/user', (req,res) => {

    var con = mysql.createConnection(new Config());
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    const sql = 'insert into User (name,email,password,accountNumber) values ("' +req.body.name + '","'+ req.body.email+'","'+ req.body.password+'","'+ req.body.accountNumber+'")';
    const sql2 = 'insert into User (name,email,password,accountNumber) values (?,?,?,?)';
    const sl3 = 'insert into Address (addressID,zipCode,city,street,delevery) values (?,?,?,?)';
    
    console.log(sql);
    con.query(sql3,[req.body.addressID,req.body.zipCode,req.body.city,req.body.street,req.body.delevery], (err,result) =>{
        console.log(err);
        // if (err) 
        //     if (err.errno == 1062) res.status(404).send({status: 404 , error: "Már létező email cím"});
        
        res.send(result);
    })   
})

app.get('/user/:id', (req,res) => {
    var con = mysql.createConnection(new Config());
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    con.query('select * from Address where userID = ?',[req.params['id']], (err,result) =>{
        if (err) throw err;
        res.send(result);
    })  
    
     
})





// publikáljuk a szervert
app.listen(port, () => {
console.log(`Példa alkalmazás publikálva ${port}-on`);

})

