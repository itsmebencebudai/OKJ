const express = require('express');
// const mysql = require('mysql');
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const mysql = require('mysql2');
const cors = require('cors');
const util = require('util');
const PORT = process.env.PORT || 3000;

const app = express();
app.use(express.json());
app.use(cors());

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
    const drop_database_slq = `DROP DATABASE IF EXISTS filmkölcsönző`;
    connection.query(drop_database_slq, (err) => {
        if (err) throw err;
        console.log('\tAz adatbázis törlésre került');

        // Create database if not exists
        const create_database_sql = 'CREATE DATABASE IF NOT EXISTS filmkölcsönző';
        connection.query(create_database_sql, (err) => {
            if (err) throw err;
            console.log('\tAz adatbázis létrehozva vagy már létezik');

            // Use database -> create table
            const use_database_sql = 'USE filmkölcsönző';
            connection.query(use_database_sql, (err) => {
                if (err) throw err;
                console.log('Create table:');

                // create Users Table
                const users_sql = `CREATE TABLE IF NOT EXISTS users (id INT AUTO_INCREMENT PRIMARY KEY,email VARCHAR(255) UNIQUE NOT NULL,password VARCHAR(255) NOT NULL,name VARCHAR(255) NOT NULL,isAdmin BOOLEAN DEFAULT FALSE,token VARCHAR(255))`;
                connection.query(users_sql, (err) => {
                    if (err) throw err;
                    console.log('\tA Users tábla létrehozott vagy már létezik');

                    // create Film tábla
                    const filmek_slq = `CREATE TABLE IF NOT EXISTS filmek (id INT AUTO_INCREMENT PRIMARY KEY,title VARCHAR(255) NOT NULL,duration INT NOT NULL,categories VARCHAR(255),releaseYear INT NOT NULL,directors VARCHAR(255),actors JSON)`;
                    connection.query(filmek_slq, (err) => {
                        if (err) throw err;
                        console.log('\tA Filmek tábla létrehozott vagy már létezik');

                        // create WatchedMovies tábla
                        const watchedmovies_sql = `CREATE TABLE IF NOT EXISTS watchedmovies (id INT AUTO_INCREMENT PRIMARY KEY,userId INT,movieId INT,FOREIGN KEY (userId) REFERENCES users(id),FOREIGN KEY (movieId) REFERENCES filmek(id))`;
                        connection.query(watchedmovies_sql, (err) => {
                            if (err) throw err;
                            console.log('\tWatchedMovies tábla létrehozott vagy már létezik');

                            // Insert data
                            console.log('Insert Into: ');

                            // insert Users adatok
                            const usersData = [
                                { email: 'user1@example.com', password: 'password1', name: 'User 1', isAdmin: false, token: 'token1' },
                                { email: 'admin@example.com', password: 'admin', name: 'admin', isAdmin: true, token: 'im_an_admin' },
                            ];

                            const usersInsertQuery = 'INSERT INTO users (email, password, name, isAdmin, token) VALUES ?';
                            connection.query(usersInsertQuery, [usersData.map(user => Object.values(user))], (err) => {
                                if (err) throw err;
                                console.log('\tA felhasználói táblázatba mintaadatok sikeresen beillesztve');

                                // insert Filmek adatok
                                const moviesData = [
                                    { title: 'Movie 1', duration: 120, categories: 'Action', releaseYear: 2022, directors: 'Director 1', actors: '{"actor1": "Role1"}' },
                                    { title: 'Movie 2', duration: 150, categories: 'Drama', releaseYear: 2021, directors: 'Director 2', actors: '{"actor2": "Role2"}' },
                                ];

                                const moviesInsertQuery = 'INSERT INTO filmek (title, duration, categories, releaseYear, directors, actors) VALUES ?';
                                connection.query(moviesInsertQuery, [moviesData.map(movie => Object.values(movie))], (err) => {
                                    if (err) throw err;
                                    console.log('\tA Filmek táblázatba mintaadatok sikeresen beillesztve');

                                    // insert WatchedMovies adatok
                                    const watchedMoviesData = [
                                        { userId: 1, movieId: 1 },
                                        { userId: 2, movieId: 2 },
                                    ];

                                    const watchedMoviesInsertQuery = 'INSERT INTO watchedmovies (userId, movieId) VALUES ?';
                                    connection.query(watchedMoviesInsertQuery, [watchedMoviesData.map(watchedMovie => Object.values(watchedMovie))], (err) => {
                                        if (err) throw err;
                                        console.log('\tA WatchedMovies táblázatba mintaadatok sikeresen beillesztve');

                                        // Close database kapcsolat
                                        // connection.end((err) => {
                                        //     if (err) {
                                        //         console.error('Hiba a MySQL kapcsolat bezárásakor:', err);
                                        //         return;
                                        //     }
                                        //     console.log('A MySQL kapcsolat bezárva');
                                        // });
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
    database: 'filmkölcsönző',
});

// Kapcsolat ellenőrzése
db.connect((err) => {
    if (err) {
        console.error('Nem tudott csatlakozni a MySQL-hez:', err);
    } else {
        console.log('Csatlakozik a MySQL adatbázishoz');
    }
});

const queryAsync = util.promisify(db.query).bind(db);

app.get('/', (req, res) => {
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
        const name = req.body.name;
        const password = req.body.password;
        loggedInUser = req.body.name;

        console.log('Megkapta a felhasználói bejelentkezési kérelmet:', name, 'Jelszóval:', password);

        const results = await queryAsync('SELECT * FROM users WHERE name = ?', [name]);

        db.query('SELECT * FROM users WHERE name = ?', [name], async (err, results) => {
            if (err) throw err;

            if (results.length === 0) {
                res.status(401).json({ error: 'Felhasználó nem található' });
            } else {
                console.log('Megkapott jelszó:', results[0].password);

                const isPasswordValid = await bcrypt.compare(password, results[0].password);
                if (!isPasswordValid) {
                    console.log('Érvénytelen jelszó a felhasználó számára:', name);
                    console.error('Bcrypt error:', isPasswordValid);
                    res.status(401).json({ error: 'Érvénytelen jelszó' });
                } else {
                    const token = jwt.sign({ userId: results[0].id }, 'tokenkey', { expiresIn: '2d' });
                    db.query('UPDATE users SET token = ? WHERE id = ?', [token, results[0].id], (err) => {
                        if (err) throw err;
                        loggedInUserId = results[0].id;
                        console.log(loggedInUser, loggedInUserId);
                        res.cookie('token', token);
                        res.status(200).json({ message: 'Sikeres bejelentkezés', redirect: '/filmvalasztas', loggedInUserId: loggedInUserId });
                    });
                }
            }
        });

    } catch (error) {
        console.error('Hiba a bejelentkezés során:', error);
        res.status(401).json({ error: 'Hitelesítés nem sikerült' });
    }
});

// Filmek kiválasztása (user által)
app.get('/filmvalasztas', (req, res) => {
    res.sendFile(__dirname + '/movieselect.html');
});

// Végpont a bejelentkezett felhasználói információk megszerzéséhez
app.get('/bejelentkezett-felhasznalo', (req, res) => {
    res.json({ loggedInUserId });
});



// Filmek kiválasztása (user által)
app.post('/filmkivalasztas', async (req, res) => {
    try {
        const userId = loggedInUserId;
        const selectedMovieIds = JSON.parse(req.body.selectedMovies);

        const values = selectedMovieIds.map(movieId => [userId, movieId]);

        const sql = 'INSERT INTO watchedmovies (userId, movieId) VALUES ?';

        db.query(sql, [values], (err) => {
            if (err) {
                console.error('Nem sikerült kiválasztani a filmeket:', err);
                return res.status(500).json({ error: 'Hiba a filmek kiválasztásakor' });
            }
            res.status(200).json({ message: 'A film sikeresen kiválasztva' });
        });
    } catch (error) {
        console.error('Hiba a filmválasztás során:', error);
        res.status(500).json({ error: 'Hiba a filmek kiválasztásakor' });
    }
});


app.get('/filmek', async (req, res) => {
    try {
        db.query('SELECT * FROM filmek', (err, results) => {
            if (err) throw err;
            // console.log('Filmek beolvasva:', results);
            res.status(200).json(results);
        });
    } catch (error) {
        res.status(500).json({ error: 'Hiba a filmek letöltése' });
    }
});


// Admin jogosultság ellenőrzése middleware
const isAdmin = (req, res, next) => {
    if (req.user && req.user.isAdmin) {
        next();
    } else {
        res.status(403).json({ error: 'Hozzáférés megtagadva' });
    }
};

// Film hozzáadása (csak admin)
app.post('/addfilm', isAdmin, async (req, res) => {
    try {
        const movie = req.body;
        db.query('INSERT INTO movies SET ?', movie, (err) => {
            if (err) throw err;
            res.status(201).json({ message: 'A film sikeresen hozzáadva' });
        });
    } catch (error) {
        res.status(500).json({ error: 'Hiba a film hozzáadásánál' });
    }
});

// Port beállítása
app.listen(PORT, () => {
    console.log(`A szerver a ${PORT} porton fut [ http://localhost:${PORT} ]`);
});
