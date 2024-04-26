var pet_module = require('./pet_module');
var router = require('express').Router();

router.get('/pet', pet_module.get_pet);
router.get('/pet/:id', pet_module.get_pet_by_id);
router.post('/pet', pet_module.add_pet);
router.put('/pet/:id', pet_module.update_pet);
router.delete('/pet/:id', pet_module.delete_pet);

module.exports = router;