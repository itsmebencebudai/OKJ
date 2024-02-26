import mysql from 'mysql2';
import config from '../App/config';
import jwt from 'jsonwebtoken';
import * as dotenv from "dotenv";
dotenv.config();

const { JWT_STRING } = process.env;

function register(req: any, res: any) {
    try {
        const { email, username, password } = req.body;
        if (!(email && username && password)) {
            res.status(400).send({ "status": 404, error: "Nem megfelelően megadott adatok" });
            return;
        }
        var con = mysql.createConnection(config.database);
        con.connect(function (err) {
            if (err) throw err;
            console.log('Sikeres csatlakozás');
        });

        const sql: string = "INSERT INTO user (name, email, password) VALUES (?, ?, ?)";
        con.query(sql, [username, email, password], (err, result: any) => {
            if (err) throw err;

            let payload = {
                userID: result.insertId,
                email: email,
                username: username
            };

            if (!JWT_STRING) {
                return res.status(401).send({ "status": 401, "error": "Hiba történt a regisztrációs token aláírásakor" });
            }

            const token = jwt.sign(
                payload, JWT_STRING, { expiresIn: "2h" }
            );

            let user = { userID: result.insertId, email: email, username: username, token: token };
            con.query("UPDATE user SET token = ? WHERE userID = ?", [token, result.insertId], (err, result, fields) => {
                if (err) throw err;
                res.send({ "success": "Sikeres regisztráció", "user": user });
            });
        });
    } catch (error) {
        console.error("Hiba történt a regisztráció során:", error);
        res.status(500).send({ "status": 500, "error": "Szerver hiba történt" });
    }
}

export default register;
