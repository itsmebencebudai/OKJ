var express = require('express');
const cors = require('cors');
const bodyParser = require('body-parser');
var app = express();

app.use(cors({ origin: '*' }));
app.use(express.json());


app.use(require('../router/router'));

app.use('/api', require("../auto/router"));
app.use('/api', require("../kolcsonzes/router"));

module.exports = app;