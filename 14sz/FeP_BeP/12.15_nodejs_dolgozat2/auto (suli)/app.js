const express = require('express');
// const mysql = require('mysql');
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const mysql = require('mysql2');
const mysql_promise = require('mysql2/promise');
const cors = require('cors');
const util = require('util');
const PORT = process.env.PORT || 3000;

const app = express();
app.use(express.json());
app.use(cors());

// html 
app.set('view engine', 'ejs');
app.use(express.static('public'));

// MySQL szerver kapcsolat
const connection = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '',
    multipleStatements: true,
});

// Csatlakozás a MySQL szerverhez
connection.connect((err) => {
    if (err) {
        console.error('Hiba a MySQL-hez való csatlakozás:', err);
        return;
    }
    console.log('Csatlakozott a MySQL szerverhez');

    // Drop Database
    const drop_database_slq = `DROP DATABASE IF EXISTS autonodejs`;
    connection.query(drop_database_slq, (err) => {
        if (err) throw err;
        console.log('\tAz adatbázis törlésre került');

        // Create database if not exists
        const create_database_sql = 'CREATE DATABASE IF NOT EXISTS autonodejs';
        connection.query(create_database_sql, (err) => {
            if (err) throw err;
            console.log('\tAz adatbázis létrehozva vagy már létezik');

            // Use database -> create table
            const use_database_sql = 'USE autonodejs';
            connection.query(use_database_sql, (err) => {
                if (err) throw err;
                console.log('Create table:');

                // create Users Table
                const users_sql = `CREATE TABLE IF NOT EXISTS users (id INT AUTO_INCREMENT PRIMARY KEY,email VARCHAR(255) UNIQUE NOT NULL,password VARCHAR(255) NOT NULL,name VARCHAR(255) NOT NULL,isAdmin BOOLEAN DEFAULT FALSE,token VARCHAR(255))`;
                connection.query(users_sql, (err) => {
                    if (err) throw err;
                    console.log('\tA Users tábla létrehozott vagy már létezik');

                    // create Autok tábla
                    const filmek_slq = `CREATE TABLE IF NOT EXISTS autok (id INT AUTO_INCREMENT PRIMARY KEY,típus VARCHAR(255) NOT NULL,marka VARCHAR(255) NOT NULL,gyartasiev VARCHAR(255) NOT NULL,muszaki VARCHAR(255) NOT NULL,ar VARCHAR(255) NOT NULL,felszereltseg VARCHAR(255) NOT NULL, lathatosag BOOL DEFAULT FALSE)`;
                    connection.query(filmek_slq, (err) => {
                        if (err) throw err;
                        console.log('\tA Autók tábla létrehozott vagy már létezik');

                        // create Parkolo tábla
                        const watchedmovies_sql = `CREATE TABLE IF NOT EXISTS parkolo (id INT AUTO_INCREMENT PRIMARY KEY,userId INT,autokid INT,FOREIGN KEY (userId) REFERENCES users(id),FOREIGN KEY (autokid) REFERENCES autok(id))`;
                        connection.query(watchedmovies_sql, (err) => {
                            if (err) throw err;
                            console.log('\tParkolo tábla létrehozott vagy már létezik');

                            // Insert data
                            console.log('Insert Into: ');

                            // insert Users adatok
                            const usersData = [
                                { email: 'admin_email', password: 'admin', name: 'admin', isAdmin: true, token: 'im_an_admin' },
                                { email: '1_email', password: '1', name: '1', isAdmin: false, token: 'token1' },
                            ];

                            const usersInsertQuery = 'INSERT INTO users (email, password, name, isAdmin, token) VALUES ?';
                            connection.query(usersInsertQuery, [usersData.map(user => Object.values(user))], (err) => {
                                if (err) throw err;
                                console.log('\tA felhasználói táblázatba mintaadatok sikeresen beillesztve');

                                // insert Autok adatok
                                const filmekData = [
                                    { típus: 'Tipus 1', marka: 'Marka 1', gyartasiev: 2000, muszaki: 2022, ar: 100000, felszereltseg: 'kormány,fék, ködlámpa' },
                                    { típus: 'Tipus 2', marka: 'Marka 2', gyartasiev: 2001, muszaki: 2023, ar: 200000, felszereltseg: 'fék, ködlámpa' },
                                ];

                                const filmekInsertQuery = 'INSERT INTO autok (típus, marka, gyartasiev, muszaki, ar, felszereltseg) VALUES ?';
                                connection.query(filmekInsertQuery, [filmekData.map(filmek => Object.values(filmek))], (err) => {
                                    if (err) throw err;
                                    console.log('\tA Filmek táblázatba mintaadatok sikeresen beillesztve');

                                    // insert WatchedMovies adatok
                                    const parkoloData = [
                                        { userId: 1, autokid: 1 },
                                        { userId: 2, autokid: 2 },
                                    ];

                                    const parkoloInsertQuery = 'INSERT INTO parkolo (userId, autokid) VALUES ?';
                                    connection.query(parkoloInsertQuery, [parkoloData.map(parkolo => Object.values(parkolo))], (err) => {
                                        if (err) throw err;
                                        console.log('\tA WatchedMovies táblázatba mintaadatok sikeresen beillesztve');

                                        //Close database kapcsolat
                                        connection.end((err) => {
                                            if (err) {
                                                console.error('Hiba a MySQL kapcsolat bezárásakor:', err);
                                                return;
                                            }
                                            console.log('A MySQL kapcsolat bezárva');
                                        });
                                    });
                                });
                            });
                        });
                    });
                });
            });
        });
    });
});


// Adatbázis kapcsolat létrehozása
const db = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'autonodejs',
});
// Pool
const pool = mysql_promise.createPool({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'autonodejs'
});

// Kapcsolat ellenőrzése
db.connect((err) => {
    if (err) {
        console.error('Nem tudott csatlakozni a MySQL-hez:', err);
    } else {
        console.log('Csatlakozik a MySQL adatbázishoz');
    }
});

app.get('/', async (req, res) => {

    // admin password to hashed password
    const admin_jelszo = await bcrypt.hash('admin', 10);
    const admin_email = 'admin_email';
    const admin_password_update_slq = (`UPDATE users SET password = ? WHERE email = ?`);
    db.query(admin_password_update_slq, [admin_jelszo, admin_email], function (err, result) {
        if (err) throw err;
        console.log('Admin jelszó frissítve: ', admin_jelszo);
    });

    // admin password to hashed password
    const user1_jelszo = await bcrypt.hash('1', 10);
    const user1_email = '1_email';
    const user1_password_update_slq = (`UPDATE users SET password = ? WHERE email = ?`);
    db.query(user1_password_update_slq, [user1_jelszo, user1_email], function (err, result) {
        if (err) throw err;
        console.log('User 1 jelszó frissítve: ', user1_jelszo);
    });

    res.sendFile(__dirname + '/login.html');
});

// Regisztráció
app.post('/regisztracio', async (req, res) => {
    try {

        const { email, password, name } = req.body;

        // Validate that the name is not empty
        if (!email.trim() || !password.trim() || !name.trim()) {
            return res.status(400).json({ error: 'Az adatmezo nem lehet üres!' });
        }

        const hashedPassword = await bcrypt.hash(req.body.password, 10);
        const user = {
            email: req.body.email,
            password: hashedPassword,
            name: req.body.name,
        };
        console.log(user);

        db.query('INSERT INTO users SET ?', user, (err, result) => {
            if (err) {
                console.error('Nem sikerült regisztrálni a felhasználót:', err);
                return res.status(500).json({ error: 'A regisztráció meghiúsult' });
            }
            res.status(201).json({ message: 'aFelhasználóSikeresenRegisztrált' });
        });
    } catch (error) {
        console.error('Hiba a regisztráció során:', error);
        res.status(500).json({ error: 'A regisztráció meghiúsult' });
    }
});

var loggedInUser;
let loggedInUserId;

// Bejelentkezés
app.post('/bejelentkezes', async (req, res) => {
    try {
        const nev = req.body.name;
        const jelszo = req.body.password;
        loggedInUser = req.body.name;

        console.log('Megkapta a felhasználói bejelentkezési kérelmet:', nev, 'Jelszóval:', jelszo);
        console.log('logged in user: ', loggedInUser);

        db.query('SELECT * FROM users WHERE name = ?', [nev], async (err, results) => {
            if (err) throw err;

            if (results.length === 0) {
                res.status(401).json({ error: 'Felhasználó nem található' });
            } else {
                console.log('Megkapott jelszó:', results[0].password);

                const isJelszoIgaz = await bcrypt.compare(jelszo, results[0].password);
                if (!isJelszoIgaz) {
                    console.log('Érvénytelen jelszó: ', jelszo, 'a felhasználó számára:', nev);
                    console.error('Bcrypt error:', isJelszoIgaz);
                    res.status(401).json({ error: 'Érvénytelen jelszó' });
                } else {
                    const token = jwt.sign({ userId: results[0].id }, 'tokenkey', { expiresIn: '2d' });
                    db.query('UPDATE users SET token = ? WHERE id = ?', [token, results[0].id], (err) => {
                        if (err) throw err;
                        loggedInUserId = results[0].id;
                        console.log('loggedInUser', loggedInUser, 'loggedInUserId', loggedInUserId);
                        res.cookie('token', token);
                        const tovabblepes = (nev === 'admin' ? '/adminadd' : '/autovalasztas');
                        res.status(200).json({ message: 'Sikeres bejelentkezés', redirect: tovabblepes, loggedInUserId: loggedInUserId });
                    });
                }
            }
        });

    } catch (error) {
        console.error('Hiba a bejelentkezés során:', error);
        res.status(401).json({ error: 'Hitelesítés nem sikerült' });
    }
});

// Auto kiválasztása (user által)
app.get('/autovalasztas', (req, res) => {
    res.sendFile(__dirname + '/autokselect.html');
});

// Végpont a bejelentkezett felhasználói információk megszerzéséhez
app.get('/bejelentkezett-felhasznalo', (req, res) => {
    console.log(loggedInUser, loggedInUserId);
    res.json({ loggedInUserId });
});



// Autok kiválasztása (user által)
app.post(`/autoparkolo/:autoId/user/:userId`, (req, res) => {
    try {
        const sql = 'INSERT INTO parkolo (userId, autokId) VALUES (?,?)';
        db.query(sql, [req.params['userId'], req.params['autoId']], (err) => {
            if (err) {
                console.error('Nem sikerült kiválasztani az autot:', err);
                return res.status(500).json({ error: 'Hiba a auto kiválasztásakor' });
            }
            res.status(200).json({ message: 'Sikeres kiválasztás', redirect: '/userparkolo' });
        });
    } catch (error) {
        console.error('Hiba az autó választás során:', error);
        res.status(500).json({ error: 'Hiba az autó kiválasztásakor' });
    }
});

// list minden auto
app.get('/mindenauto', async (req, res) => {
    try {
        db.query('SELECT * FROM autok', (err, result) => {
            if (err) throw err;
            res.status(200).json(result);
        });
    } catch (error) {
        res.status(500).json({ error: 'Hiba a autok letöltésekor' });
    }
});

// minden auto
app.get('/userparkolo', (req, res) => {
    res.sendFile(__dirname + '/userparkolo.html');
});

// Auto parkolo (user által)
app.get('/autok', (req, res) => {
    res.sendFile(__dirname + '/autok.html');
});

// user parkolo
app.get('/parkolo/:userId', (req, res) => {
    db.connect();
    console.log(req.params['userId']);
    try {
        db.query('select * from autok where id in (SELECT autokid FROM parkolo WHERE userId =?)', [req.params['userId']], (err, result) => {
            if (err) throw err;
            // console.log(result);
            res.send(result);
        });
    } catch (err) {
        if (err) throw err;
    }
});

// Admin jogosultság ellenőrzése middleware
const isAdmin = (req, res, next) => {
    if (loggedInUser === 'admin') {
        next();
    } else {
        res.status(403).json({ error: 'Hozzáférés megtagadva' });
    }
};

// Admin auto hozzáadás (user által)
app.get('/adminadd', (req, res) => {
    res.sendFile(__dirname + '/addauto.html');
});

// Film hozzáadása (csak admin)
app.post('/addauto/:tipus/:marka/:gyartasev/:muszaki/:ar/:felszereltseg', isAdmin, async (req, res) => {
    try {
        db.query('INSERT INTO autok SET ?,?,?,?,?,?', [req.params['tipus'], req.params['muszaki'], req.params['marka'], req.params['gyartasev'], req.params['ar'], req.params['felszereltseg']], (err) => {
            if (err) throw err;
            res.status(201).json({ message: 'A auto sikeresen hozzáadva', redirect: '/autok' });
        });
    } catch (error) {
        res.status(500).json({ error: 'Hiba az auto hozzáadásánál' });
    }
});

// Port beállítása
app.listen(PORT, () => {
    console.log(`A szerver a ${PORT} porton fut [ http://localhost:${PORT} ]`);
});
