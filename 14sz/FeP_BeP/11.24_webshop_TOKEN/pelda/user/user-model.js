const mysql = require("mysql2");
const config = require("../App/config");
const validator = require("email-validator");
const jwt = require("jsonwebtoken");
const User = require("./user");

// ez a függvény visszaadja az összes felhasználó adatát
 function getAllUserInfos(req,res) {
    var con = mysql.createConnection(config.database);
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    con.query('select * from User', (err,result) =>{
        if (err) throw err;
        res.send(result);
    })   
}

function getUserDataFromId(req,res) {
    var con = mysql.createConnection(config.database);
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    con.query('CALL getAllUserInfos(?) ',[req.params['id']], (err,result) =>{
        if (err) throw err;
        res.send(result);
    })   
}


// Ez a függvény regisztrál egy új felhasználót és lementi az adatbázisba
async function regUser (req,res)  {


    const user = new User(null,req.body.name,req.body.email,req.body.accountNumber,null);

    if (!(user.name && user.email && req.body.password && user.accountNumber)) {
        res.status(400).send("Töltsd ki az adatatokat rendesen!");
    }

    if (!validator.validate(user.email))  {
        res.status(400).send("Nem megfelelő formátumú email!");        
    }

    
    //ecryptedPw = await bcrypt.hash(password,10);    

       

    var con = mysql.createConnection(config.database);
    con.connect(function(err) {
        if (err) throw err;
        console.log('sikeres csatlakozás');
    })
    
    const sql = 'insert into User (name,email,password,accountNumber) values (?,?,?,?)';
    con.query(sql,[req.body.name,req.body.email,req.body.password,req.body.accountNumber], (err,result) =>{
        if (err) throw err;
        const token = jwt.sign(
            {
                userID: result.insertId,
                email: user.email
            },
            config.TokenKey,
            {
                expiresIn:"2h",
            }); 
        user.token = token;
        user.userID = result.insertId;    
        console.log(user.userID)    
        con.connect(function(err) {
            if (err) throw err;
            console.log('sikeres csatlakozás');
        })        
        con.query('call userUpdateToken(?,?)',[user.userID,token],(err,result,fields)=>{
            if (err) throw err;
            console.log(user.token)
            res.send(user);
        })
    })   
}

function createNewAddress (req,res) {
    var con = mysql.createConnection(config.database);
    con.connect(function(err) {
        if (err) throw err; 
        console.log('sikeres csatlakozás');
    })
    const sql = 'insert into Address (zipCode,city,street,userID) values (?,?,?,?)';
    
    console.log(sql);
    con.query(sql,[req.body.zipCode,req.body.city,req.body.street,req.params["id"]], (err,result) =>{
        if (err) throw err;
        res.send(result);
    })   
}


exports.createNewAddress = createNewAddress
exports.getAllUserInfos = getAllUserInfos
exports.getUserDataFromId = getUserDataFromId
exports.regUser = regUser
