var address = require('./addr-model')
var router = require('express').Router()

router.post('/address/:id', (req, res) => { address.newAddress(req, res) });

module.exports = router