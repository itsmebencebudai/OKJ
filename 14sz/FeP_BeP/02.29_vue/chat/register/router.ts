import { Router } from 'express';
import register from '../register/register-modul';

const router = Router();    	

router.post('/registration', register);

export default router;