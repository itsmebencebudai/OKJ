var auto_module = require('./auto_module');
var router = require('express').Router();

router.get('/auto/:id', auto_module.getAuto);
router.get('/auto/all', auto_module.getAllAuto);
router.post('/auto', auto_module.uploadAuto);
router.put('/auto/:id', auto_module.updateAuto);
router.delete('/auto/:id', auto_module.deleteAuto);

module.exports = router;