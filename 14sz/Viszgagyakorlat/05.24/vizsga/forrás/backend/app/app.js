const express = require('express');
const cors = require('cors');
const app = require('./index');
const config = require('./config');

app.get('/', (req, res) =>{
    res.send("Hello World!");
});

app.listen(config.port, () =>{
    console.log(`http://localhost:${config.port}`);
});