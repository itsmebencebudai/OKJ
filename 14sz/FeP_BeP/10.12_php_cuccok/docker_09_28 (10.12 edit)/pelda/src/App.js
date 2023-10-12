const express = require('express'); // express module
const cors = require('cors'); // cors module 
const mysql = require('mysql2'); // mysql module
const app = express(); // express app instance 
const port = 8000; // port number for server and client connections

app.use(cors({ origin: '*' })); // cors

app.get('/',(req, res) => {
    res.send('Welcome');
})

app.get('/getdata', (req, res) => { //post 
    var con = mysql.createConnection({host: "localhost", port:"root", password: "",database:"webshop"});
    con.connect(function (err) {
        if(err) throw err;
        console.log('sikeres csatlakozás');
    })
    con.query('select * from Users', (err, results) => {
        if(err) throw err;
        res.send(results);
    })
    // res.send({ postvalasz: "hihi" });
});

app.get('/', (req, res) => { //get, post, put, delete, patch ...
    res.send("Hello world!")
    // res.send({ valasz: "hello world" });
})

app.post('/data', (req, res) => { //post
    res.send({valami: 'ertek'});
});

app.delete('/', (req, res) => { // delete 
    res.send('ez delete kérés');
});

app.listen(port, () => { // listen 
    console.log(`Server is running on port ${port}`);
});

/*app.post('/szorzas', (req, res) => { //post 
    res.send({ eredmeny: req.body.szorzas});
});*/



