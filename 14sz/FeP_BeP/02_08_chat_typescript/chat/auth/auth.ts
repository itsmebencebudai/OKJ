import jwt from "jsonwebtoken"
const { JWT_STRING } = process.env;

function verifyToken(req:any,res:any,next:any) {
    const token = req.body?.token || req.query?.token || req.headers?.['x-access-token'];
    if (!token) {
          return res.status(403).send("Token szükséges a hozzáféréshez!")  
    }

    try {

        if (!JWT_STRING){
            return res.status(401).send("Hiba van a token visszafejtésénél"); 
        }
        const decodedToken = jwt.verify(token,JWT_STRING);
            console.log(decodedToken);
            req.user = decodedToken;
        
    } catch(e) {
        return res.status(401).send("Hibás token");        
    }
    return next();
}

export default verifyToken