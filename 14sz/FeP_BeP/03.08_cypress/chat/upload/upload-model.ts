import { Request, Response } from "express";
import { uploadFileMiddleware } from "./upload";
import * as fs from "fs";

const upload = async (req: Request, res: Response) => {
  
  try {
    await uploadFileMiddleware(req,res);

    if (req.file === undefined) {
      return res.status(400).send({ message: "Please upload a file!" });
    }

    res.status(200).send({
      message: "Uploaded the file successfully: " + req.file.originalname,
    });
  } catch (err) {
    res.status(500).send({
      message: `Could not upload the file: ${req.file?.originalname}. ${err}`,
    });
  }
};

const getListFiles = (req: Request, res: Response) => {
  const directoryPath = __dirname + "/uploads/";

  fs.readdir(directoryPath, function (err, files) {
    if (err) {
      res.status(500).send({
        message: "Unable to scan files!",
      });
    }

    let fileInfos:any[] = [];

    files.forEach((file) => {
      fileInfos.push({
        name: file,
        url: "http://localhost:8000/api/files/" + file} );
    });

    res.status(200).send(fileInfos);
  });
};

const download = (req: Request, res: Response) => {
  const fileName: string = req.params.name;
  const directoryPath = __dirname + "/uploads/";

  res.download(directoryPath + fileName, fileName, (err) => {
    if (err) {
      res.status(500).send({
        message: "Could not download the file. " + err,
      });
    }
  });
};

export { upload, getListFiles, download };
