
import router from '../router/router'
import userRouter from '../user/router'
import express from 'express';
import loginRouter from '../login/router'
import messageRouter from '../messages/router'
import cors from 'cors';
import 'dotenv/config'
import bodyParser from 'body-parser';
import uploadRouter  from '../upload/router';


var app = express();

//Betölti a CORS támogatást 
app.use(cors({origin: '*'}));

//lehetővé teszi a POST kérések elküldött adatainak (body) elérését


app.use(express.json());
app.use(express.urlencoded({ extended: true }));
app.use(bodyParser.urlencoded({
    extended: true
  }));
app.use(router);
app.use('/api',userRouter);
app.use('/api',loginRouter);
app.use('/api',messageRouter);
app.use('/api',uploadRouter);


export default app