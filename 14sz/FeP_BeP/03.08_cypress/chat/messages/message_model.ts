import mysql from 'mysql2'
import config from "../App/config";

export function getUserMessagesFromId(req: any,res:any) {
    var con = mysql.createConnection(config.database);
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    con.query('call getAllUserMessages(?)',[req.params['userID']], (err,result:any) =>{
        if (err) throw err;
        res.send(result[0]);
    })   
}


export function getAllMessages(req: any,res:any) {
    var con = mysql.createConnection(config.database);
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    con.query('call getAllMessages', (err,result:any) =>{
        if (err) throw err;
        res.send(result[0]);
    })   
}

export function saveNewMessage(req: any,res:any) {
    var con = mysql.createConnection(config.database);
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })

    con.query('call saveNewMessage(?,?)',[req.body.message,req.body.userID], (err,result:any) =>{
        if (err) throw err;
        res.send(result[0]);
})
}