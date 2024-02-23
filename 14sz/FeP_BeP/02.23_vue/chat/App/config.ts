
class Config {
    user = "root";
    password = "my-secret-pw";
    database = "chat";
    host = "localhost";
    constructor() {
        return {host:this.host,user:this.user,password:this.password,database:this.database}
    }
}

const config: any = {
    port : 8000,
    database : new Config()
//további konfigurációs adatok
};
  
export default config;




