var express = require('express');
const cors = require('cors');
var app = express();

app.use(cors({ origin: '*' }));
app.use(express.json())

app.use(require('../router/app_router'));

app.use('/api', require("../ingatlan/ingatlan_router"));

module.exports = app;