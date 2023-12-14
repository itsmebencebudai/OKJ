const express = require('express');
const session = require('express-session');
const ejs = require('ejs');
const mysql = require('mysql2');
const mysql_promise = require('mysql2/promise');
const bodyParser = require('body-parser');
const jwt = require('jsonwebtoken');

const app = express();
const port = 3000;

app.set('view engine', 'ejs');
app.use(express.static('public'));


const db = mysql.createConnection({
  host: 'localhost',
  user: 'root',
  password: '',
  database: 'online_filmnezes'
});

const pool = mysql_promise.createPool({
  host: 'localhost',
  user: 'root',
  password: '',
  database: 'online_filmnezes'
});

db.connect((err) => {
  if (err) {
    console.error('Hiba a MySQL -hez való csatlakozás:', err);
  } else {
    console.log('Csatlakozik a MySQL adatbázishoz ');
  }
});

app.use(express.json());

app.get('/', (req, res) => {
  res.sendFile(__dirname + '/login.html');
});

app.post('/bejelentkezes', (req, res) => {
  const { username, password } = req.body;
  console.log(req.body);

  try {
    if (!username || !password) {
      return res.send(`
      <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
        <strong>Figyelem!</strong> Kérjük, írja be a felhasználónevet és a jelszót.
      </div>
    `);
    }

  } catch (error) {
    console.log(error)
  }

  const titkoskulcs = 'titkosmikkentyű';
  const opciok = {
    expiresIn: '2d',
  };

  if (username === 'admin') {
    req.session.userId = 0;
    req.session.loggedin = true;
    req.session.username = 'admin';
  } else {
    const query = 'SELECT id FROM users WHERE username = ? AND password = ?';
    db.query(query, [username, password], (err, results) => {
      if (err) {
        console.error('Hiba a felhasználó hitelesítése:', err);
        return res.status(500).send('Belső Szerverhiba');
      }

      if (results.length > 0) {
        req.session.userId = results[0].id;
        req.session.loggedin = true;
        req.session.username = username;
      } else {
        console.log('Nincsen ilyen user');
        return res.send(`
          <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
            <strong>Figyelem!</strong> Rossz felhasználónév vagy jelszó.
          </div>
        `);
      }
    });
  }

  const felepeites = {
    userId: req.session.userId,
    username: req.session.username,
  };

  const token = jwt.sign(felepeites, titkoskulcs, opciok);
  console.log(`Generált token (${username}):`, token);

  const frissítés = 'UPDATE users SET token = ? WHERE username = ?';
  const frissítésÉrték = [token, username];

  db.query(frissítés, frissítésÉrték, (error) => {
    if (error) {
      console.error('Hiba a token frissítésékor az adatbázisban:', error);
      return res.status(500).send('Belső Szerverhiba');
    }

    console.log('A token sikeresen beillesztve az adatbázisba.');
    const redirectPath = username === 'admin' ? '/filmekvalasztasadmin' : '/filmekvalasztas';
    res.redirect(redirectPath);
  });
});

app.get('/filmekvalasztas', (req, res) => {
  if (req.session.loggedin) {
    res.sendFile(__dirname + '/movies.html');
    console.log(req.session);
  } else {
    res.send(`
    <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
      <strong>Figyelem!</strong> Kérjük, jelentkezzen be a szavazáshoz.
    </div>
  `);
  }
});

app.post('/kivalasztottfilmek', async (req, res) => {
  try {
    if (!req.session.loggedin) {
      return res.send(`
        <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
          <strong>Figyelem!</strong> Kérjük, jelentkezzen be.
        </div>
      `);
    }
    try {
      const userId = req.session.userId;
      const userName = req.session.username;
      const { option } = req.body;
      console.log(req.session);
      if (!option) {
        return res.send(`
          <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
            <strong>Figyelem!</strong> Kérjük, válassza ki a film lehetőséget.
          </div>
        `);
      }
      db.query('INSERT INTO selected_movies (userId, username, movie_selected) VALUES (?, ?, ?)', [userId, userName, option]);
      res.send(`
        <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
          A film sikeresen kiválasztva <strong>Nyomjon a gombra hogy elérje a linket!</strong>.
          <form action="/filmjeim" method="post">
            <button type="submit">Eddigi filmjei</button>
          </form>
          <form action="/filmeklista" method="get">
            <button type="submit">Összes filmek</button>
          </form>
        </div>
      `);
    } catch (error) {
      console.error(error);
    }
  } catch (error) {
    console.error(error);
    res.status(500).send(`
      <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
        <strong>Figyelem!</strong> Hiba történt a szavazás során.
      </div>
    `);
  }
});

app.post('/filmjeim', async (req, res) => {
  db.connect();
  try {
    if (!req.session.loggedin) {
      return res.send(`
        <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
          <strong>Figyelem!</strong> Kérjük, jelentkezzen be.
        </div>
      `);
    }
    const connection = await pool.getConnection();
    console.log(req.session.userId);
    const userId = req.session.userId;
    console.log(userId);
    const [movies] = await connection.query(`
    SELECT selected_movies.*
    FROM selected_movies
    JOIN users ON selected_movies.userId = users.id
    WHERE selected_movies.userId LIKE ${userId}
  `);
    connection.release();
    res.render('movies', { movies });
    console.log(movies);
  } catch (error) {
    console.error('Hiba a lekérdezés közben:', error);
    res.status(500).send('Belső Szerverhiba (post)');
  }
});

app.get('/filmeklista', async (req, res) => {
  db.connect();
  console.log(req.session);
  try {
    if (!req.session.loggedin) {
      return res.send(`
        <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
          <strong>Figyelem!</strong> Kérjük, jelentkezzen be.
        </div>
      `);
    }
    const connection = await pool.getConnection();
    const [movies] = await connection.query('SELECT * FROM selected_movies');;
    res.render('movies', { movies });
  } catch (err) {
    console.error('Hiba a filmek letöltésekor: ', err);
    res.status(500).send('Belső Szerverhiba (get)');
  }
});

app.get('/filmekvalasztasadmin', (req, res) => {
  if (req.session.loggedin) {
    res.sendFile(__dirname + '/moviesadmin.html');
    console.log(req.session);
  } else {
    res.send(`
    <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
      <strong>Figyelem!</strong> Kérjük, jelentkezzen be a szavazáshoz.
    </div>
  `);
  }
});

app.post('/filmupload', (req, res) => {
  if (req.session.loggedin) {
    res.sendFile(__dirname + '/moviesadmin.html');
    console.log(req.session);
  } else {
    res.send(`
    <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
      <strong>Figyelem!</strong> Kérjük, jelentkezzen be a feltöltéshez (csak admin).
    </div>
  `);
  }
});

app.listen(port, () => {
  console.log(`A szerver a ${port} porton fut | http://localhost:${port}`);
});
