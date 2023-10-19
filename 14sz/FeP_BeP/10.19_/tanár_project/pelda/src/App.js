const express = require('express');
const cors = require('cors');
const mysql = require('mysql2');
const app = express();
const port = 8000;

//Betölti a CORS támogatást 
app.use(cors({ origin: '*' }));

//lehetővé teszi a POST kérések elküldött adatainak (body) elérését
app.use(express.json());


// ez a végpont mutatja, hogy fut a node js szerver
app.get('/', (req, res) => {
    res.send("<h1>Szerver fut</h1>")
})

// ez a végpont visszaadja az összes felhasználó adatát
app.get('/getdata', (req, res) => {
    var con = mysql.createConnection({ host: "localhost", user: "root", password: "", database: "webshop_tanar" });
    con.connect(function (err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    con.query('select * from User', (err, result) => {
        if (err) throw err;
        res.send(result);
    })
})


// ez a végpont visszaadja egy felhasználó adatát
app.get('/getuserdata', (req, res) => {
    const userId = 2;
    if (!userId) {
        return res.status(400).json({ error: 'UserID is required' });
    }
    const sql = 'SELECT * FROM User WHERE userID = ?';
    pool.query(sql, [userId], (err, result) => {
        if (err) {
            console.error(err);
            return res.status(500).json({ error: 'An error occurred while fetching user data' });
        }
        if (result.length === 0) {
            return res.status(404).json({ error: 'User not found' });
        }
        res.json(result[0]);
    });
});


// Ez a végpont regisztrál egy új felhasználót és lementi az adatbázisba
app.post('/reg', (req, res) => {
    var con = mysql.createConnection({ host: "localhost", user: "root", password: "", database: "webshop_tanar" });
    con.connect(function (err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    const sql = 'insert into User (name,email,password,accountNumber) values ("' + req.body.name + '","' + req.body.email + '","' + req.body.password + '","' + req.body.accountNumber + '")';
    const sql2 = 'insert into User (name,email,password,accountNumber) values (?,?,?,?)';

    console.log(sql);
    con.query(sql2, [req.body.name, req.body.email, req.body.password, req.body.accountNumber], (err, result) => {
        if (err) res.send(err);
        res.send(result);
    })
})

// publikáljuk a szervert
app.listen(port, () => {
    console.log(`Példa alkalmazás publikálva ${port}-on`);

})

