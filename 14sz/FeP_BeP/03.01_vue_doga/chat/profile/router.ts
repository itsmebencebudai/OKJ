import { Router } from 'express';
import profile from '../profile/profile_modul';

const router = Router();    	

router.post('/profile', profile);

export default router;