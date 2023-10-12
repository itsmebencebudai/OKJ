const express = require('express'); // express module
const cors = require('cors'); // cors module 
const app = express(); // express app instance 
const port = 8000; // port number for server and client connections

app.use(cors({ origin: '*' })); // cors
app.get('/', (req, res) => { //get, post, put, delete, patch ...
    // res.send("Hello world!")
    res.send({ valasz: "hello world" });
})
app.post('/', (req, res) => { //post 
    res.send({ postvalasz: "hihi" });
})
app.post('/szorzas', (req, res) => { //post 
    res.send({ eredmeny: req.body.szorzas});
});
app.listen(port, () => { // listen 
    console.log(`Server is running on port ${port}`);
})


