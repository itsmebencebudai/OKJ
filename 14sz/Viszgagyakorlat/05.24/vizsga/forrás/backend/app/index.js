const express = require('express');
const cors = require('cors');
const app = express();

app.use(cors({origin: '*'}));
app.use(express.json());

app.use(require('../router/router'));

app.use('/api', require('../pet/router'));
// app.use('/api', require('../order/router'));

module.exports = app;