const express = require('express');
const mysql = require('mysql2');
const app = express();
const port = 3000;

// Create a MySQL connection pool
const pool = mysql.createPool({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'webshop_tanar',
});

app.get('/getuserdata', (req, res) => {
    const userId = req.query.userId;

    if (!userId) {
        return res.status(400).json({ error: 'UserID is required' });
    }

    const sql = 'SELECT * FROM User WHERE userID = ?';
    pool.query(sql, [userId], (err, result) => {
        if (err) {
            console.error(err);
            return res.status(500).json({ error: 'An error occurred while fetching user data' });
        }

        if (result.length === 0) {
            return res.status(404).json({ error: 'User not found' });
        }

        res.json(result[0]);
    });
});

app.listen(port, () => {
    console.log(`Server is running on port ${port}`);
});
