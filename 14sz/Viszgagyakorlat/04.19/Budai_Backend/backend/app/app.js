const express = require('express');
const cors = require('cors');
const config = require('./config');
const mysql2 = require('mysql2');
const app = require('./index');

app.get('/', (req, res) => {
  res.send('Hello World!');
});

app.listen(config.port, () => {
  console.log(`Futt a szerver | http://localhost:${config.port}`);
});