import { Router } from 'express';
import auth from '../auth/auth';
import { getAllMessages, getUserMessagesFromId, saveNewMessage } from './message_model';

const router = Router();

router.post('/message', auth, saveNewMessage);
router.get('/message', auth, getAllMessages);
router.get('/message/:userID',auth, getUserMessagesFromId)

export default router;