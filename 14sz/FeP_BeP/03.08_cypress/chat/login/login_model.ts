import mysql from 'mysql2'
import config from '../App/config'
import jwt from 'jsonwebtoken'
import * as dotenv from "dotenv"
dotenv.config();

const  { JWT_STRING } =  process.env;

function signin(req:any,res:any) {
    try {

        const {email, password} = req.body;
        if (!(email && password)) {
            res.status(400).send({"status": 404,error:"Nem megfelelően megadott adatok"});
            return
        }
        var con = mysql.createConnection(config.database);
        con.connect(function(err) {
            if (err) throw err;
            console.log('sikeres csatlakozás');
        })
        const sql: string  = "call userLogin(?,?)";
        con.query(sql,[email,password],(err,result:any) => {
            if (err) throw err;
           
            if(result[0].length > 0) {
                let payload = {
                    userID : result[0][0].userID,
                    email : result[0][0].email
                }
                
                if (!JWT_STRING) {
                    return res.status(401).send({"status":401,"error":"Hiba történ a regisztrációs token aláírásakor"});
                }
                
                const token = jwt.sign(
                payload,JWT_STRING,{ expiresIn:"2h" }
                )
            let user:any = result[0][0]
            con.query("call userUpdateToken(?,?)",[user.userID,token],(err,result,fields) => {
                if(err) throw err;
                user.token = token;
                res.send({"success": "oks", "user": user});
            })
            
            }
            else res.status(401).send({"status":401,"error":"Nem engedélyezett!"});

        })





    } catch(error) {

    }
}
export default signin;

