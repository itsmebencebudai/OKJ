import { Router } from 'express';
import signin from '../login/login_model';

const router = Router();

router.post('/login', signin);

export default router;