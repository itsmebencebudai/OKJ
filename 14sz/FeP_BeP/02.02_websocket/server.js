const express = require('express');
const WebSocket = require('ws');
const mysql = require('mysql');
const http = require('http');
const app = express();
const fs = require('fs');
const bcrypt = require('bcrypt');



const db = mysql.createConnection({
  host: 'localhost',
  user: 'root',
  password: '',
  database: 'websocket_demo',
});

db.connect((err) => {
  if (err) {
    console.error('Error connecting to MySQL:', err);
  } else {
    console.log('Connected to MySQL');
  }
});

const server = http.createServer((req, res) => {
  if (req.url === '/client.html') {
    fs.readFile('client.html', 'utf8', (err, data) => {
      if (err) {
        res.writeHead(500, { 'Content-Type': 'text/plain' });
        res.end('Internal Server Error');
      } else {
        res.writeHead(200, { 'Content-Type': 'text/html' });
        res.end(data);
      }
    });
  } else {
    res.writeHead(404, { 'Content-Type': 'text/plain' });
    res.end('Not Found');
  }
});

const wss = new WebSocket.Server({ server });

wss.on('connection', (ws) => {
  console.log('WebSocket connection established');

  ws.on('message', (message) => {
    handleMessage(ws, message);
  });

  ws.on('close', () => {
    console.log('WebSocket connection closed');
  });
});

function handleMessage(ws, message) {
  try {
    const data = JSON.parse(message);

    switch (data.type) {
      case 'login':
        handleLogin(ws, data.username, data.password);
        break;
      case 'register':
        handleRegister(ws, data.username, data.password);
        break;
      case 'message':
        broadcastMessage(ws, `${data.username}: ${data.message}`);
        break;
      default:
        console.error('Invalid message type:', data.type);
    }
  } catch (error) {
    console.error('Error parsing message:', error);
  }
}

function handleLogin(ws, username, password) {
  const sql = 'SELECT * FROM users WHERE username = ?';
  db.query(sql, [username], (error, results) => {
    if (error) {
      console.error('Error during login:', error);
      ws.send(JSON.stringify({ type: 'loginResponse', success: false, message: 'Login failed' }));
    } else {
      if (results.length > 0) {
        console.log('Password:', results[0].password);
        if (comparePasswords(password, results[0].password)) {
          ws.send(JSON.stringify({ type: 'loginResponse', success: true, message: 'Login successful' }));

        } else {
          ws.send(JSON.stringify({ type: 'loginResponse', success: false, message: 'Invalid credentials' }));
        }
      } else {
        ws.send(JSON.stringify({ type: 'loginResponse', success: false, message: 'Invalid credentials' }));
      }
    }
  });
}


function handleRegister(ws, username, password) {
  const hashedPassword = hashPassword(password);
  const sql = 'INSERT INTO users (username, password) VALUES (?, ?)';
  db.query(sql, [username, hashedPassword], (error, results) => {
    if (error) {
      console.error('Error registering user:', error);
      ws.send(JSON.stringify({ type: 'registerResponse', success: false, message: 'Registration failed' }));
    } else {
      ws.send(JSON.stringify({ type: 'registerResponse', success: true, message: 'Registration successful' }));
    }
  });
}

function comparePasswords(enteredPassword, storedHashedPassword) {
  return bcrypt.compareSync(enteredPassword, storedHashedPassword);
}

function broadcastMessage(sender, message) {
  wss.clients.forEach((client) => {
    if (client !== sender && client.readyState === WebSocket.OPEN) {
      client.send(message);
    }
  });
}

function hashPassword(password) {
  const saltRounds = 10;
  return bcrypt.hashSync(password, saltRounds);
}

const PORT = 3000;
server.listen(PORT, () => {
  console.log(`Server listening on http://localhost:${PORT}`);
});
