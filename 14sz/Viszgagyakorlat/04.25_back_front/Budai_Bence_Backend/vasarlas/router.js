var vasarlas_module = require('./vasarlas_module');
var router = require('express').Router();

router.get('/vasarlas', vasarlas_module.get_vasarlas);
router.get('/vasarlas/:id', vasarlas_module.get_vasarlas_by_id);
router.post('/vasarlas', vasarlas_module.add_vasarlas);

router.get('/vasarlasok/:id', vasarlas_module.get_vasarlasok_by_id);

module.exports = router;