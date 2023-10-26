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
    
    const userSQL = 'insert into User (name,email,password,accountNumber,addressID) values (?,?,?,?,?)'; 
    const addressSQL = 'insert into Address (zipCode,city,street) values (?,?,?)';
     
    con.query(addressSQL,[req.body.zipCode,req.body.city,req.body.street], (err,result) =>{
        if (err) { 
            if (err) res.status(404).send({status: 404 , error: "Hiba az address rögzítésekor"});
            console.log(err)
        }
        else {
        _resultid = result?.insertId     
        if (_resultid) {
            con.query(userSQL,[req.body.name,req.body.email,req.body.password,req.body.accountNumber,_resultid], (err,result) => {
                if (err) { 
                        deleteSQL = "delete from Address where addressID = ?"
                        con.query(deleteSQL,[_resultid], (err,result) => {
                              
                        })
                        res.status(404).send({status: 404 , error: "Hiba a user rögzítésekor"});
                }
                else {
                    res.status(200).send({status:200,success:"Sikeres adatrögzítés"})
                }
            }) 
            }
        }
        
    })  

})

app.post('/address', (req,res) => {

    var con = mysql.createConnection(new Config());
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
   
    const sql = 'insert into Address (zipCode,city,street) values (?,?,?)';

    con.query(sql,[req.body.zipCode,req.body.city,req.body.street], (err,result) =>{
        if (err) 
            if (err.errno == 1062) res.status(404).send({status: 404 , error: "Már létező email cím"});
        
        res.send(result);
    })   
})



app.get('/user/:id', (req,res) => {
    var con = mysql.createConnection(new Config());
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    con.query('select * from User where userID = ?',[req.params['id']], (err,result) =>{
        if (err) throw err;
        res.send(result);
    })  
    
     
})





// publikáljuk a szervert
app.listen(port, () => {
console.log(`Példa alkalmazás publikálva ${port}-on`);

})

