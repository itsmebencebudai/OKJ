import mysql from 'mysql2'
import config from "../App/config";

export function getUserDataFromId(req: any,res:any) {
    var con = mysql.createConnection(config.database);
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    con.query('call getAllUserInfos(?)',[req.params['id']], (err,result:any) =>{
        if (err) throw err;
        res.send(result[0][0]);
    })   
}


// Ez a függvény regisztrál egy új felhasználót és lementi az adatbázisba
export function regUser (req: any,res:any)  {
    var con = mysql.createConnection(config.database);
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    const sql2 = 'insert into User (name,email,password) values (?,?,?)';
    con.query(sql2,[req.body.name,req.body.email,req.body.password], (err,result) =>{
        if (err) throw err;
        res.send(result);
    })   
}




