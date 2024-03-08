import { Router } from 'express';
import   auth  from '../auth/auth';
import { download, getListFiles, upload } from './upload-model';
const router: Router = Router();
router.post("/upload", upload);
router.get("/files", getListFiles);
router.get("/files/:name", download);
export default router;