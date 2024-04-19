const express = require('express');
const cors = require('cors');
const config = require('./config');
const mysql2 = require('mysql2');
const app = express();

app.get('/', (req, res) => {
  res.send('<a href="http://localhost:8000/api/ingatlan">Get ALL Ingatlanok</a>');
});

// app.get('/api/ingatlan', (req, res) => {
//   var con = mysql2.createConnection(config.database);

//   con.connect(function (err) {
//       if (err) throw err;
//       console.log("Connected!");
//   });

//   const sql = 'CAll GetAllIngatlanok';
//   con.query(sql, function (err, result, fields) {
//       if (err) throw err;
//       res.json(result);
//   });

//   con.end(function (err) {
//       if (err) throw err;
//       console.log("Disconnected!");
//   });
// });

// app.post('/api/ingatlan', (req, res) => {
//   var con = mysql2.createConnection(config.database);

//   con.connect(function (err) {
//       if (err) throw err;
//       console.log("Connected!");
//   });

//   const sql = 'INSERT INTO `ingatlanok`(`id`, `kategoria`, `leiras`, `hirdetesDatuma`, `tehermentes`, `ar`, `kepurl`) VALUES (?,?,?,?,?,?,?)';  

//   con.query(sql, [req.query._id],[req.query.kategoria],[req.query.leiras],[req.query.hirdetesDatum],[req.query.tehermentes],[req.query.ar],[req.query.kepUrl], function (err, result, fields) {
//     if (err) throw err;
//     res.send(JSON.stringify(result));
//   });
  
//   con.end(function (err) {
//       if (err) throw err;
//       console.log("Disconnected!");
//   });
// });


app.listen(config.port, () => {
  console.log(`A szerver fut | http://localhost:${config.port}`);
})
