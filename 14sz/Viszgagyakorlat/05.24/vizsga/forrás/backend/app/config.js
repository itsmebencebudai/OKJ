const config = module.exports;

class Config{
    user = 'root';
    password = '';
    host = 'localhost';
    database = 'kisállat';
    constructor(){
        return{
            host: this.host,
            database: this.database,
            password: this.password,
            user: this.user
        }
    }
}

config.database = new Config();
config.port = 8000;