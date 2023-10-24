CREATE TABLE csapat (
  id int,
  nev varchar(255),
  alapitva int,
  PRIMARY KEY (id)
);

CREATE TABLE palya (
  id int,
  nev varchar(255),
  hossz float,
  orszag varchar(255),
  PRIMARY KEY (id)
);

CREATE TABLE versenyzo (
  id int,
  nev varchar(255),
  eletkor int,
  csapatid int,
  PRIMARY KEY (id),
  CONSTRAINT FK_versenyzo_csapat_id FOREIGN KEY(csapatid) REFERENCES csapat(id)
);

CREATE TABLE korido (
  id int,
  palyaid int,
  versenyzoid int,
  korido time DEFAULT NULL,
  kor int DEFAULT NULL,
  PRIMARY KEY (id),
  CONSTRAINT FK_korido_palya_id FOREIGN KEY (palyaid) REFERENCES palya(id),
  CONSTRAINT FK_korido_versenyzo_id FOREIGN KEY (versenyzoid) REFERENCES versenyzo(id)
);