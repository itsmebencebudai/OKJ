import { Router } from 'express';
import * as user from './user-model';
import auth from '../auth/auth';

const router: Router = Router();


router.get('/user/:id',auth, user.getUserDataFromId);
router.post('/user/reg', user.regUser);


export default router;