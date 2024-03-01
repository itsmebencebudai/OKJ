import mysql from 'mysql2';
import config from '../App/config';
import * as dotenv from "dotenv";
import jwt, { Secret } from 'jsonwebtoken';
dotenv.config();

const { JWT_STRING } = process.env;

function profile(req: any, res: any) {
    const token = req.headers.authorization?.split(' ')[1];
    if (!token) {
        return res.status(401).json({ message: "Hiányzó token" });
    }
    jwt.verify(token, JWT_STRING as Secret, (err: any, decoded: any) => {
        if (err) {
            return res.status(401).json({ message: "Érvénytelen token" });
        }

        const userID = decoded.userID;
        console.log('decoded.userID: ' + decoded.userID);

        const pool = mysql.createPool(config.database);

        pool.getConnection((err, connection) => {
            if (err) {
                return res.status(500).json({ message: "Adatbázis hiba" });
            }

            connection.query('SELECT name, email, password FROM user WHERE userID = ?', [userID], (err, result: any) => {
                connection.release();

                if (err) {
                    return res.status(500).json({ message: "Adatbázis hiba" });
                }

                if (result.length === 0) {
                    return res.status(404).json({ message: "Felhasználó nem található" });
                }

                res.json(result[0]);
            });
        });
    });
}

export default profile;
