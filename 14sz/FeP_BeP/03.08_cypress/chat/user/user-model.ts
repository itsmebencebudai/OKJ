import mysql from 'mysql2'
import config from "../App/config";
import * as validator from 'email-validator';
import jwt from "jsonwebtoken";
import { User } from './user';




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
  


        const user = new User(null,req.body.name,
                           req.body.email,
                           req.body.password);
        
        if (!(user.name && user.email && req.body.password && req.body.password)) {
            res.status(400).send("Töltsd ki az adatatokat rendesen!");
        }
    
        if (user.password != req.body.password1) {
            res.status(400).send("Nem egyeznek a jelszavak"); 
        }
        
        if (!validator.validate(user.email))  {
            res.status(400).send("Nem megfelelő formátumú email!");        
        }
    
        
        //ecryptedPw = await bcrypt.hash(password,10);    
    
           
    
        var con = mysql.createConnection(config.database);
        con.connect(function(err) {
            if (err) throw err;
            console.log('sikeres csatlakozás');
        })
        
        const sql = 'insert into User (name,email,password) values (?,?,?)';
        con.query(sql,[req.body.name,req.body.email,req.body.password,req.body.accountNumber], (err,result:any) =>{
            if (err) throw err;
            const token = jwt.sign(
                {
                    userID: result.insertId,
                    email: user.email
                },
                config.TokenKey,
                {
                    expiresIn:"2h",
                }); 
            user.token = token;
            user.userid = result.insertId;    
            console.log(user.userid)    
            con.connect(function(err) {
                if (err) throw err;
                console.log('sikeres csatlakozás');
            })        
            con.query('call userUpdateToken(?,?)',[user.userid,token],(err,result,fields)=>{
                if (err) throw err;
                console.log(user.token)
                res.send(user);
            })
        })   
    
}




