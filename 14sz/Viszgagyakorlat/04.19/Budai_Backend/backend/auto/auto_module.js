const mysql2 = require('mysql2');
const config = require('../app/config');
const express = require('express');

function getAuto(req, res) {
    var con = mysql2.createConnection(config.database);

    con.connect(function (err) {
        if (err) throw err;
        console.log("Connected!");
    });

    const sql = 'SELECT * FROM `autok` WHERE `id` = ?';
    con.query(sql, [req.params['id']], function (err, result) {
        if (err) throw err;
        res.send(result);
    });

    con.end(function (err) {
        if (err) throw err;
        console.log("Disconnected!");
    });
}

function getAllAuto(req, res) {
    var con = mysql2.createConnection(config.database);

    con.connect(function (err) {
        if (err) throw err;
        console.log("Connected!");
    });

    const sql = 'SELECT * FROM `autok`';
    con.query(sql, function (err, result) {
        if (err) throw err;
        res.status(201).send(result);
    });

    con.end(function (err) {
        if (err) throw err;
        console.log("Disconnected!");
    });
}


function uploadAuto(req, res) {
    var con = mysql2.createConnection(config.database);

    con.connect(function (err) {
        if (err) throw err;
        console.log("Connected!");
    });

    const sql = 'INSERT INTO `autok` (`tipus`, `rendszam`, `evjarat`, `szin`) VALUES (?, ?, ?, ?)';
    con.query(sql, [req.body['tipus'], req.body['rendszam'], req.body['evjarat'], req.body['szin']], function (err, result) {
        if (err) throw err;
        res.send('id: ' + result.insertId);
    });

    con.end(function (err) {
        if (err) throw err;
        console.log("Disconnected!");
    });
}

function deleteAuto(req, res) {
    var con = mysql2.createConnection(config.database);

    con.connect(function (err) {
        if (err) throw err;
        console.log("Connected!");
    });

    const sql = 'DELETE FROM `autok` WHERE `id` = ?';
    con.query(sql, [req.params['id']], function (err, result) {
        if (err) throw err;
        if (result.affectedRows == 0) {
            res.status(404).send('Az autó nem létezik');
        }
        else{
            res.status(201).send('');
        }
    });

    con.end(function (err) {
        if (err) throw err;
        console.log("Disconnected!");
    });
}

function updateAuto(req, res) {
    var con = mysql2.createConnection(config.database);

    con.connect(function (err) {
        if (err) throw err;
        console.log("Connected!");
    });
    if (req.params['id'] == null) {
        res.status(400).send('Az adatok nem megfelelőek!');
    }

    const sql = 'UPDATE `autok` SET `tipus` = ?, `rendszam` = ?, `evjarat` = ?, `szin` = ? WHERE `id` = ?';
    con.query(sql, [req.body['tipus'], req.body['rendszam'], req.body['evjarat'], req.body['szin'], req.params['id']], function (err, result) {
        if (err) throw err;

        if (result.affectedRows == 0) {
            res.status(404).send('Az elem nem létezik');
        }else{
            res.status(201).send('Sikeres módositás');
        }
    });

    con.end(function (err) {
        if (err) throw err;
        console.log("Disconnected!");
    });
}

exports.updateAuto = updateAuto;
exports.deleteAuto = deleteAuto;
exports.uploadAuto = uploadAuto;
exports.getAuto = getAuto;
exports.getAllAuto = getAllAuto;