const express = require('express');
const mysql = require('mysql');
const app = express();
const port = 3000;

const connection = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'webshop_tanar3'
});

connection.connect();

app.set('view engine', 'ejs');

app.get('/products', (req, res) => {
    
    connection.query('SELECT * FROM products', (error, results) => {
        if (error) throw error;
        res.render('index', { products: results });
    });
});

app.listen(port, () => {
    console.log(`Server is running on http://localhost:${port}`);
});
