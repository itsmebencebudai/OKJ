module.exports = class User {
    userID = null;
    name = "";
    email = "";
    accountNumber = "";
    token = "";

    constructor (userID = null,name,email,accountNumber,token = "" ) {
        this.userID = userID;
        this.name = name;
        this.email = email;
        this.accountNumber = accountNumber;
        this.token = token;
    }
}
