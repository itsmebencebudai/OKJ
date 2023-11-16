var user = require('./user-model')
var router = require('express').Router()

router.get('/user',getAllUserInfos);
router.get('/user/:id', getUserDataFromID);

module.exports = router