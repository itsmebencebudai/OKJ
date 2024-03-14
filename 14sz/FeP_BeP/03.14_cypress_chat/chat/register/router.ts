import { Router } from 'express';
import register from '../register/register-modul';

const router = Router();    	

router.post('/signup', register);

export default router;