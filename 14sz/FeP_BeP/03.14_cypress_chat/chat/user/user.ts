export class User {
    userid: number | null = null;
    name: string = "";
    email: string = "";
    password: string = "";
    token: string| null = "";

    constructor (userid:number|null,name:string,email:string,token:string|null = "" ) {
        this.userid = userid;
        this.name = name;
        this.email = email;
        this.token = token;
    }
}