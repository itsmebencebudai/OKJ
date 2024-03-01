import mysql from 'mysql2';
import config from "../App/config";

export function getUserMessagesFromId(req: any, res: any) {
    var con = mysql.createConnection(config.database);
    con.connect(function (err) {
        if (err) throw err;
        console.log('sikeres csatlakozás getUserMessagesFromId');
    })
    con.query('call getAllUserMessages(?)', [req.params['userID']], (err, result: any) => {
        if (err) throw err;
        res.send(result[0]);
    })
}


export function getAllMessages(req: any, res: any) {
    var con = mysql.createConnection(config.database);
    con.connect(function (err) {
        if (err) throw err;
        console.log('sikeres csatlakozás getAllMessages');
    })
    con.query('call getAllMessages', (err, result: any) => {
        if (err) throw err;
        res.send(result[0]);
    })
}

export function saveNewMessage(req: any, res: any) {
    var con = mysql.createConnection(config.database);
    con.connect(function (err) {
        if (err) throw err;
        console.log('sikeres csatlakozás saveNewMessage');
    })

    con.query('call saveNewMessage(?,?)', [req.body.NEWmessage, req.body.userID], (err, result: any) => {
        // console.log('req.body.message=', req.body.NEWmessage, 'req.body.userID=', req.body.userID)
        if (err) throw err;
        res.send(result[0]);
    })
}