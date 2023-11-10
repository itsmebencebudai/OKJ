const express = require('express');
const session = require('express-session');
const bodyParser = require('body-parser');
const bcrypt = require('bcrypt');
const mysql = require('mysql');

const app = express();

app.use(bodyParser.urlencoded({ extended: true }));
app.use(session({
    secret: 'XD',
    resave: true,
    saveUninitialized: true
}));

const db = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'voting_db'
});

db.connect((err) => {
    if (err) {
        console.error('Hiba a MySql-hez való csatlakozás: ');
        return;
    }
    console.log('Csatlakoztatva a MySQL-hez ');
});

app.set('view engine', 'ejs');

// Routes
app.get('/', (req, res) => {
    res.render('index', { user: req.session.user });
});

app.get('/login', (req, res) => {
    res.render('login');    
});

app.post('/login', (req, res) => {
    const { username, password } = req.body;

    db.query('SELECT * FROM users WHERE username = ?', [username], (err, results) => {
        if (err) {
            console.error('Hiba az adatbázis lekérdezése:', err);
            res.status(500).send('Belső Szerverhiba');
            return;
        }

        if (results.length > 0) {
            bcrypt.compare(password, results[0].password, (bcryptErr, bcryptResult) => {
                if (bcryptErr){
                    console.error('Hiba a jelszavak összehasonlításának:', bcryptErr);
                    res.status(500).send('Belső Szerverhiba');
                    return;
                }

                if (bcryptResult) {
                    req.session.user = results[0];
                    res.redirect('/');
                } else {
                    res.status(401).send('hibás jelszó');
                }
            });
        } else {
            res.status(404).send('Felhasználó nem található');
        }
    });
});

app.get('/logout', (req, res) => {
    req.session.destroy();
    res.redirect('/');
});

app.listen(3000, () => {
    console.log('A szerver a 3000-es porton indult');
});
