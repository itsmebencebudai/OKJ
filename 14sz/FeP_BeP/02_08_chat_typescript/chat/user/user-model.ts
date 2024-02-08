import mysql from 'mysql2'
import config from "../App/config";

// ez a függvény visszaadja az összes felhasználó adatát
 export function getAllUserInfos(req: any,res:any) {
    var con = mysql.createConnection(config.database);
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    con.query('select * from User', (err,result) =>{
        if (err) throw err;
        res.send(result);
    })   
}

export function getUserDataFromId(req: any,res:any) {
    var con = mysql.createConnection(config.database);
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    con.query('select * from User where userID = ?',[req.params['id']], (err,result) =>{
        if (err) throw err;
        res.send(result);
    })   
}


// Ez a függvény regisztrál egy új felhasználót és lementi az adatbázisba
export function regUser (req: any,res:any)  {
    var con = mysql.createConnection(config.database);
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    const sql = 'insert into User (name,email,password,accountNumber) values ("' +req.body.name + '","'+ req.body.email+'","'+ req.body.password+'","'+ req.body.accountNumber+'")';
    const sql2 = 'insert into User (name,email,password,accountNumber) values (?,?,?,?)';
    
    console.log(sql);
    con.query(sql2,[req.body.name,req.body.email,req.body.password,req.body.accountNumber], (err,result) =>{
        if (err) throw err;
        res.send(result);
    })   
}

export function createNewAddress (req: any,res:any) {
    var con = mysql.createConnection(config.database);
    con.connect(function(err) {
        if (err) throw err; 
        console.log('sikeres csatlakozás');
    })
    const sql = 'insert into Address (zipCode,city,street,userID) values (?,?,?,?)';
    
    console.log(sql);
    con.query(sql,[req.body?.zipCode,req.body?.city,req.body?.street,req.params["id"]], (err,result) =>{
        if (err) throw err;
        res.send(result);
    })   
}


