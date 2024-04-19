var ingatlan_model = require('./ingatlan_module');
var router = require('express').Router();

router.get('/ingatlan', ingatlan_model.GetAllIngatlanok);
router.post('/ingatlan', ingatlan_model.PostNewIngatlan);

module.exports = router;