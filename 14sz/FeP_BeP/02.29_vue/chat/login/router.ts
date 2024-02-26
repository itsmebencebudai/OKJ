import { Router } from 'express';
import login from '../login/login_model';

const router = Router();

router.post('/login', login);

export default router;