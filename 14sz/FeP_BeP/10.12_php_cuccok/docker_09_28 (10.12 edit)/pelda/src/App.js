const express = require('express'); // express module
const cors = require('cors'); // cors module 
const mysql = require('mysql'); // mysql module
const app = express(); // express app instance 
const port = 8000; // port number for server and client connections

app.use(cors({ origin: '*' })); // cors

app.get('/', (req, res) => { //get, post, put, delete, patch ...
    res.send("Hello world!")
    // res.send({ valasz: "hello world" });
})
app.get('/getdata', (req, res) => { //post 
    var con = mysql.createConnenction({host: "localhost", port:"root", password: "",database:"webshop"});
    con.connect(function (err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    con.query('select * from users', (err, results) => {
        if (err) throw err;
        res.send({results});
    })
    // res.send({ postvalasz: "hihi" });
});

app.post('/data', (req, res) => { //post
    res.send({valami: 'ertek'});
});

app.delete('/', (req, res) => { // delete 
    res.send('ez egy delete');
});


/*app.post('/szorzas', (req, res) => { //post 
    res.send({ eredmeny: req.body.szorzas});
});*/
/*app.listen(port, () => { // listen 
    console.log(`Server is running on port ${port}`);
});*/


