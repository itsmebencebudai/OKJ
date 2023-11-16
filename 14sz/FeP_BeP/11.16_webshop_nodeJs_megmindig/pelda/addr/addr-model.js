const mysql = require('mysql2');
const config = require('../App/config');

function newAddress(req, res) {

    if (!req.params['id']) {
        res.status(404).send({ status: 404, error: "Nem adaott meg user id-t" });
    }

    var con = mysql.createConnection(config.database);
    con.connect(function (err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })

    const sql = 'insert into Address (zipCode,city,street,userID) values (?,?,?,?)';

    con.query(sql, [req.body.zipCode, req.body.city, req.body.street, req.params['id']], (err, result) => {
        if (err)
            if (err) res.status(404).send({ status: 404, error: "Hiba a cím rögzítésekor" });

        res.status(200).send({ status: 200, success: "success" });
    })
}

exports.newAddress = newAddress;



