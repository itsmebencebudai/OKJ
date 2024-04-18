const mysql2 = require('mysql2');
const config = require('../App/config');

function GetAllIngatlanok(req, res) {
    var con = mysql2.createConnection(config.database);

    con.connect(function (err) {
        if (err) throw err;
        console.log("Connected!");
    });

    const sql = 'CAll GetAllIngatlanok';
    con.query(sql, function (err, result, fields) {
        if (err) throw err;
        res.json(result);
    });

    con.end(function (err) {
        if (err) throw err;
        console.log("Disconnected!");
    });
}

function PostNewIngatlan(req, res, next) {
    var con = mysql2.createConnection(config.database);

    con.connect(function (err) {
        if (err) throw err;
        console.log("Connected!");
    });

    const sql = 'INSERT INTO `ingatlanok`(`id`, `kategoria`, `leiras`, `hirdetesDatuma`, `tehermentes`, `ar`, `kepurl`) VALUES (?,?,?,?,?,?,?)';
    const values = [
      req.body._id,
      req.body.kategoria,
      req.body.leiras,
      req.body.hirdetesDatuma,
      req.body.tehermentes,
      req.body.ar,
      req.body.kepUrl
    ];

    con.query(sql, values, function (err, result, fields) {
      if (err) throw err;
      res.send(JSON.stringify(result));
    });
    
    con.end(function (err) {
        if (err) throw err;
        console.log("Disconnected!");
    });
}

exports.GetAllIngatlanok = GetAllIngatlanok;

exports.PostNewIngatlan = PostNewIngatlan;