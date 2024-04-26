const mysql2 = require('mysql2');
const config = require('../app/config');
const express = require('express');

function get_vasarlas(req, res) {
    const connection = mysql2.createConnection(config.database);
    connection.connect(function (err) {
        if (err) throw err;
        connection.query('SELECT * FROM megrendeles', function (err, result) {
            if (err) throw err;
            res.send(result);
        });
    });
}

function get_vasarlas_by_id(req, res) {
    const connection = mysql2.createConnection(config.database);
    connection.connect(function (err) {
        if (err) throw err;
        connection.query('SELECT *, DATE_FORMAT(datum, "%Y-%m-%d") AS datum FROM megrendeles WHERE id = ?', [req.params.id], function (err, result) {
            if (err) throw err;
            res.send(result[0]);
        });
    });
}

function add_vasarlas(req, res) {

    const vasarloid = req.body.vasarloid;
    const datum = req.body.datum;
    const kisallat = req.body.kisallat;
    var megrendelesId;

    const connection = mysql2.createConnection(config.database);
    connection.connect(function (err) {
        if (err) throw err;
        connection.query('INSERT INTO megrendeles (vasarloid, datum) VALUES (?, ?)', [vasarloid, datum], function (err, result) {
            if (err) throw err;
            megrendelesId = result.insertId;
            res.status(201).send(JSON.stringify(megrendelesId));

            kisallat.forEach(function (kisallat) {
                const id = kisallat.id;
                const mennyiseg = kisallat.mennyiseg;

                const connection = mysql2.createConnection(config.database);
                connection.connect(function (err) {
                    if (err) throw err;
                    connection.query('INSERT INTO tetelek (megrendelesId, petId, mennyiseg) VALUES (?, ?, ?)', [megrendelesId, id, mennyiseg], function (err, result) {
                        if (err) throw err;
                    });
                });
            });
        });
    });
}

function get_vasarlasok_by_id(req, res) {
    let id = req.params.id;
    let datum = req.body.datum;
    const connection = mysql2.createConnection(config.database);
    connection.connect(function (err) {
        if (err) throw err;
        connection.query('CALL FelhasznaloNapVasarlas(?, ?)', [id, datum], function (err, result) {
            if (err) throw err;
            res.status(200).send(JSON.stringify({ id: id, datum: result[0][0].datum, kisallat: [ result[0][0].id, result[0][0].nev, result[0][0].mennyiseg] }));
        });
    });
}

exports.get_vasarlasok_by_id = get_vasarlasok_by_id;
exports.get_vasarlas = get_vasarlas;
exports.get_vasarlas_by_id = get_vasarlas_by_id;
exports.add_vasarlas = add_vasarlas;