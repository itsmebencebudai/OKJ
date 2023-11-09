const express = require('express');
const cors = require('cors');
const mysql = require('mysql2');
const Config = require('./config');
const app = express();
const port = 8000;

app.use(cors({ origin: '*' }));

app.get('/', (req, res) => {
    res.send('<h1>A szerver fut</h1>');
})

app.get('/user', (req, res) => {
    var con = mysql.createConnection(new Config());
    con.connect(function (err) {
        if (err) console.log(err)
        console.log('Sikeres a csatlakozas');
    })
    con.query('select * from user', (err, result) => {
        if (err) console.log(err);
        res.send(result);
    })
});

app.post('/user', (req, res) => {

    var con = mysql.createConnection(new Config());
    con.connect(function (err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })

    const userSQL = 'insert into user (name,email,password,szavazott) values (?,?,?,?)';

    _resultid = result?.insertId
    if (_resultid) {
        con.query(userSQL, [req.body.name, req.body.email, req.body.password, req.body.szavazott], (err, result) => {
            if (err) {
                con.query(deleteSQL, [_resultid], (err, result) => {
                })
                res.status(404).send({ status: 404, error: "Hiba a user rögzítésekor" });
            }
            else {
                res.status(200).send({ status: 200, success: "Sikeres adatrögzítés" })
            }
        })
    }
})

app.get('/tanar', (req, res) => {
    var con = mysql.createConnection(new Config());
    con.connect(function (err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })

    con.query('SELECT * FROM `tanar`', (req, result) => {
        if (err) console.log(err);
        res.send(result);
    })
})


app.listen(port, () => {
    console.log(`Példa alkalmazás publikálva ${port}-on`);

})