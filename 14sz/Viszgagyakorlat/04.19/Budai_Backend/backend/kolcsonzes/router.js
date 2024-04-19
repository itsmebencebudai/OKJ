var kolcsonzes_module = require('./kolcsonzes_module');
var router = require('express').Router();

router.post('/kolcsonzes', kolcsonzes_module.uploadKolcsonzes);
router.get('/kolcsonzes/auto/:id', kolcsonzes_module.getKolcsonzes);

module.exports = router;