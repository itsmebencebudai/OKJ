var express = require('express');
var cors = require('cors');
var app = express();

app.use(cors({origin: '*'}));
app.use(express.json());

app.use(require('../router/router'));

app.use('/api', require('../pet/router'));
app.use('/api', require('../vasarlas/router'));

module.exports = app;