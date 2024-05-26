const config = require('../app/config');
const mysql2 = require('mysql2');

function listPets(req, res) {
    const connection = mysql2.createConnection(config.database);
    connection.connect((err) => {
        if (err) {
            console.log(err);
            res.status(500).send('Internal Server Error');
        } else {
            connection.query('SELECT * FROM pet', (err, rows) => {
                if (err) {
                    console.log(err);
                    res.status(500).send('Internal Server Error');
                } else {
                    res.json(rows);
                }
            });
        }
    });
}

function getPet(req, res) {
    const connection = mysql2.createConnection(config.database);
    connection.connect((err) => {
        if (err) {
            console.log(err);
            res.status(500).send('Internal Server Error');
        } else {
            connection.query('SELECT * FROM pet WHERE id = ?', req.params.id, (err, rows) => {
                if (err) {
                    console.log(err);
                    res.status(500).send('Internal Server Error');
                } else {
                    res.json(rows);
                }
            });
        }
    });
}

function addPet(req, res) {
    const connection = mysql2.createConnection(config.database);
    connection.connect((err) => {
        if (err) {
            console.log(err);
            res.status(500).send('Internal Server Error');
        } else {
            connection.query('INSERT INTO pet (name, description, pries, stock, picture) VALUES (?, ?, ?, ?, ?)', [req.body.name, req.body.description, req.body.pries, req.body.stock, req.body.picture], (err, rows) => {
                if (err) {
                    console.log(err);
                    res.status(500).send('Internal Server Error');
                } else {
                    res.json(rows);
                }
            });
        }
    });
}

function updatePet(req, res) {
    const connection = mysql2.createConnection(config.database);
    connection.connect((err) => {
        if (err) {
            console.log(err);
            res.status(500).send('Internal Server Error');
        } else {
            connection.query('UPDATE pet SET name = ?, description = ?, pries = ?, stock = ?, picture = ?  WHERE id = ?', [req.body.name, req.body.description, req.body.pries, req.body.stock, req.body.picture, req.params.id], (err, rows) => {
                if (err) {
                    console.log(err);
                    res.status(500).send('Internal Server Error');
                } else {
                    res.json(rows);
                }
            });
        }
    });
}

function deletePet(req, res) {
    const connection = mysql2.createConnection(config.database);
    connection.connect((err) => {
        if (err) {
            console.log(err);
            res.status(500).send('Internal Server Error');
        } else {
            connection.query('DELETE FROM pet WHERE id = ?', req.params.id, (err, rows) => {
                if (err) {
                    console.log(err);
                    res.status(500).send('Internal Server Error');
                } else {
                    res.json(rows);
                }
            });
        }
    });
}

module.exports = {
    listPets,
    getPet,
    addPet,
    updatePet,
    deletePet
};