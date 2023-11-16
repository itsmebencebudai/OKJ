var user = require('./user-model')
var router = require('express').Router()

router.get('/user',user.getAllUserInfos);
router.get('/user/:id', (req,res)=>{user.getUserDataFromID(req,res)});

module.exports = router