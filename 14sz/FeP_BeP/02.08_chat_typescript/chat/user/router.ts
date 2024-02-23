import { Router } from 'express';
import * as user from './user-model';
import auth from '../auth/auth';

const router: Router = Router();

router.get('/user', auth, user.getAllUserInfos);
router.get('/user/:id', user.getUserDataFromId);
router.post('/user/reg', user.regUser);
router.post('/user/:id/address', user.createNewAddress);

export default router;