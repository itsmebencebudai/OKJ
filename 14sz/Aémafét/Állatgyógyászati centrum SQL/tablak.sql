CREATE TABLE fajta (
  id int NOT NULL,
  fajtanev varchar(30) DEFAULT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE gazda (
  id int NOT NULL,
  nev varchar(50) DEFAULT NULL,
  kerulet int DEFAULT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE kezelestipus (
  id int NOT NULL,
  jelleg varchar(50) DEFAULT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE kutya (
  id int NOT NULL,
  fajtaId int DEFAULT NULL,
  nem tinyint DEFAULT NULL,
  korEv int DEFAULT NULL,
  korHonap int DEFAULT NULL,
  gazdaId int DEFAULT NULL,
  PRIMARY KEY (id),
  CONSTRAINT FK_kutya_fajta_id FOREIGN KEY (fajtaId)
  REFERENCES fajta (id),
  CONSTRAINT FK_kutya_gazda_id FOREIGN KEY (gazdaId)
  REFERENCES gazda (id)
);

CREATE TABLE kezeles (
  id int NOT NULL,
  kutyaId int DEFAULT NULL,
  kezelestipusId int DEFAULT NULL,
  kezdet date DEFAULT NULL,
  veg date DEFAULT NULL,
  dij int DEFAULT NULL,
  PRIMARY KEY (id),
  CONSTRAINT FK_kezeles_kezelestipus_id FOREIGN KEY (kezelestipusId)
  REFERENCES kezelestipus (id),
  CONSTRAINT FK_kezeles_kutya_id FOREIGN KEY (kutyaId)
  REFERENCES kutya (id)
  );