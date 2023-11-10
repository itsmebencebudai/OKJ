const express = require('express');
const session = require('express-session');
const ejs = require('ejs');
const mysql = require('mysql2');
const mysql_promise = require('mysql2/promise');
const bodyParser = require('body-parser');

const app = express();
const port = 3000;

app.set('view engine', 'ejs');
app.use(express.static('public'));


const db = mysql.createConnection({
  host: 'localhost',
  user: 'root',
  password: '',
  database: 'voting_db_2'
});

const pool = mysql_promise.createPool({
  host: 'localhost',
  user: 'root',
  password: '',
  database: 'voting_db_2'
});

db.connect((err) => {
  if (err) {
    console.error('Hiba a MySQL -hez való csatlakozás:', err);
  } else {
    console.log('Csatlakozik a MySQL adatbázishoz ');
  }
});


app.use(session({ secret: 'szilasi_a_legjobb_<3', resave: true, saveUninitialized: true }));
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());


app.get('/', (req, res) => {
  res.sendFile(__dirname + '/login.html');
});


app.post('/login', (req, res) => {
  const { username, password } = req.body;

  if (username && password) {
    db.query('SELECT * FROM users WHERE username = ? AND password = ?', [username, password], (err, results) => {
      if (err) throw err;

      if (results.length > 0) {
        req.session.loggedin = true;
        req.session.username = username;
        res.redirect('/vote');
      } else {
        res.send(`
        <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
          <strong>Figyelem!</strong> Rossz felhasználónév vagy jelszó.
        </div>
      `);
      }
      res.end();
    });
  } else {
    res.send(`
    <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
      <strong>Figyelem!</strong> Kérjük, írja be a felhasználónevet és a jelszót.
    </div>
  `);
    res.end();
  }
});


app.get('/vote', (req, res) => {
  if (req.session.loggedin) {
    res.sendFile(__dirname + '/vote.html');
  } else {
    res.send(`
    <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
      <strong>Figyelem!</strong> Kérjük, jelentkezzen be a szavazáshoz.
    </div>
  `);
  }
});


app.post('/submit-vote', async (req, res) => {
  try {
    if (!req.session.loggedin) {
      return res.send(`
        <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
          <strong>Figyelem!</strong> Kérjük, jelentkezzen be a szavazáshoz.
        </div>
      `);
    }

    const connection = await pool.getConnection();

    try {
      const userId = req.body.userId;
      const { option } = req.body;

      const [existingVote] = await connection.query('SELECT * FROM votes WHERE user_id = ?', [userId]);

      if (existingVote.length > 0) {
        return res.send(`
          <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
            <strong>Figyelem!</strong> Már szavazott.
          </div>
        `);
      }

      if (!option) {
        return res.send(`
          <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
            <strong>Figyelem!</strong> Kérjük, válassza ki a szavazati lehetőséget.
          </div>
        `);
      }

      await connection.query('INSERT INTO votes (user_id, option_selected) VALUES (?, ?)', [userId, option]);

      res.send(`
        <div style="background-color: #ffeaa7; padding: 20px; border: 1px solid #fdcb6e; border-radius: 5px; color: #d63031;">
          A szavazás sikeresen benyújtva <strong>Köszönjük!</strong>.
          <form action="/button-click" method="post">
            <button type="submit">Eddigi szavazások</button>
          </form>
        </div>
      `);
    } finally {
      connection.release();
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


app.post('/button-click', async (req, res) => {
  try {
    const connection = await pool.getConnection();
    const [votes] = await connection.query(`
    SELECT votes.*, users.username
    FROM votes
    JOIN users ON votes.user_id = users.id
  `);

    connection.release();
    res.render('votes', { votes });
  } catch (error) {
    console.error(error);
    res.status(500).send('Belső Szerverhiba');
  }
});

app.get('/votes', (req, res) => {
  db.query('SELECT * FROM votes');
  if (err) {
    console.error('Hiba a szavazatok letöltése:', err);
    res.status(500).send('Belső Szerverhiba');
  } else {
    const votes = results;
    res.render('votes', { votes });
  }
});

app.listen(port, () => {
  console.log(`A szerver a ${port} porton fut | http://localhost:${port}`);
});
