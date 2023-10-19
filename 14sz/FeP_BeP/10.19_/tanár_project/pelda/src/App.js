const express = require('express');
const cors = require('cors');
const mysql = require('mysql2');
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
app.get('/getdata',(req,res) => {
    var con = mysql.createConnection({host:"localhost",user:"root",password:"",database:"webshop_tanar"});
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
app.post('/reg', (req,res) => {
    var con = mysql.createConnection({host:"localhost",user:"root",password:"",database:"webshop_tanar"});
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    const sql = 'insert into User (name,email,password,accountNumber) values ("' +req.body.name + '","'+ req.body.email+'","'+ req.body.password+'","'+ req.body.accountNumber+'")';
    const sql2 = 'insert into User (name,email,password,accountNumber) values (?,?,?,?)';
    
    console.log(sql);
    con.query(sql2,[req.body.name,req.body.email,req.body.password,req.body.accountNumber], (err,result) =>{
        if (err) res.send(err);
        res.send(result);
    })   
})

// publikáljuk a szervert
app.listen(port, () => {
console.log(`Példa alkalmazás publikálva ${port}-on`);

})

