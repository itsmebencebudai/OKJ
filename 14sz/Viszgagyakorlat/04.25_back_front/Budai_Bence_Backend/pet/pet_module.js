const mysql2 = require('mysql2');
const config = require('../app/config');
const express = require('express');

function get_pet(req, res) {
    const connection = mysql2.createConnection(config.database);
    connection.connect(function (err) {
        if (err) throw err;
        connection.query('SELECT * FROM pet', function (err, result) {
            if (err) throw err;
            res.send(result);
        });
    });
}

function get_pet_by_id(req, res) {
    const connection = mysql2.createConnection(config.database);
    connection.connect(function (err) {
        if (err) throw err;
        connection.query('SELECT * FROM pet WHERE id = ?', [req.params.id], function (err, result) {
            if (err) throw err;
            res.send(result);
        });
    });
}

function add_pet(req, res) {

    const nev = req.body.nev;
    const leiras = req.body.leiras;
    const ar = req.body.ar;
    const raktaron = req.body.raktaron;
    const kep = req.body.kep;

    const connection = mysql2.createConnection(config.database);
    connection.connect(function (err) {
        if (err) throw err;
        connection.query('INSERT INTO pet (nev, leiras, ar, raktaron, kep) VALUES (?, ?, ?, ?, ?)', [nev, leiras, ar, raktaron, kep], function (err, result) {
            if (err) throw err;
            res.status(201).send(JSON.stringify({ id: result.insertId }));
        });
    });
}

function update_pet(req, res) {

    const id = req.params.id;
    const nev = req.body.nev;
    const leiras = req.body.leiras;
    const ar = req.body.ar;
    const raktaron = req.body.raktaron;
    const kep = req.body.kep;

    if (id == res) {
        res.status(404).send("Az elem nem letezik");
    }

    const connection = mysql2.createConnection(config.database);
    connection.connect(function (err) {
        if (err) throw err;
        connection.query('UPDATE pet SET nev = ?, leiras = ?, ar = ?, raktaron = ?, kep = ? WHERE id = ?', [nev, leiras, ar, raktaron, kep, id], function (err, result) {
            if (err) throw err;
            if (result.affectedRows == 0) {
                res.status(404).send("Az elem nem letezik");
            } else if (id == null || nev == null || leiras == null || ar == null || raktaron == null || kep == null) {
                res.status(400).send("Az adatok nem megfelelőek");
            } else{
                res.status(201).send(JSON.stringify("Sikeres módositás"));
            }
        });
    });
}

function delete_pet(req, res) {
    const connection = mysql2.createConnection(config.database);
    connection.connect(function (err) {
        if (err) throw err;
        connection.query('DELETE FROM pet WHERE id = ?', [req.params.id], function (err, result) {
            if (err) throw err;

            if (result.affectedRows == 0) {
                res.status(404).send("A kisallatnem létezik");
            } else {
                res.status(204);
            }
        });
    });
}


exports.get_pet = get_pet;
exports.get_pet_by_id = get_pet_by_id;
exports.add_pet = add_pet;
exports.update_pet = update_pet;
exports.delete_pet = delete_pet;