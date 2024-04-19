const mysql2 = require('mysql2');
const config = require('../app/config');
const express = require('express');

function uploadKolcsonzes(req, res) {
    var con = mysql2.createConnection(config.database);

    con.connect(function (err) {
        if (err) throw err;
        console.log("Connected!");
    });

    const sql = 'INSERT INTO `kolcsonzes` (`autoid`, `berloid`, `berletkezdete`, `napokszama`, `napidij`) VALUES (?, ?, ?, ?, ?)';
    con.query(sql, [req.body['autoid'], req.body['berloid'], req.body['berletkezdete'], req.body['napokszama'], req.body['napidij']], function (err, result) {
        if (err) throw err;
        res.status(201).send(result.insertId);
    });

    con.end(function (err) {
        if (err) throw err;
        console.log("Disconnected!");
    });
}

function getKolcsonzes (req, res) {
    var con = mysql2.createConnection(config.database);

    con.connect(function (err) {
        if (err) throw err;
        console.log("Connected!");
    });

    const sql = 'SELECT IsKolcsonozheto(?) as kolcsonozheto';
    con.query(sql, [req.params['id']], function (err, result) {
        if (err) throw err;
        res.send(result);
    });

    con.end(function (err) {
        if (err) throw err;
        console.log("Disconnected!");
    });
}

exports.uploadKolcsonzes = uploadKolcsonzes;
exports.getKolcsonzes = getKolcsonzes;