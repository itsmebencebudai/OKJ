const config = module.exports


class Config {
    user =  "root";
    password = "my-secret-pw";
    database = "webshop";
    host = "localhost";
    constructor() {
        return {host:this.host, user:this.user, password: this.password, database:this.database};
    }
} 

config.database = new Config(); 
config.port = 8000;

