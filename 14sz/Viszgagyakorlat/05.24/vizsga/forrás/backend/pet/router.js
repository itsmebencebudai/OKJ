const pet_module = require('./pet-module');
const router = require('express').Router();

router.get('/pets', pet_module.listPets);
router.get('/pets/:id', pet_module.getPet);
router.post('/pets', pet_module.addPet);
router.put('/pets/:id', pet_module.updatePet);
router.delete('/pets/:id', pet_module.deletePet);

module.exports = router;