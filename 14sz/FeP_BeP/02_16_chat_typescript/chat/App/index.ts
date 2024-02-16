import * as dotenv from "dotenv"
import router from '../router/router'
import userRouter from '../user/router'
import express from 'express';
import loginRouter from '../login/router'
import cors from 'cors';
dotenv.config();

var app = express();

//Betölti a CORS támogatást 
app.use(cors({origin: '*'}));

//lehetővé teszi a POST kérések elküldött adatainak (body) elérését
app.use(express.json());
app.use(router);
app.use('/api',userRouter);
app.use('/api',loginRouter);

export default app