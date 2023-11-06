CREATE TABLE gyumolcslevek (
  id int,
  gynev varchar(16) NOT NULL,
  CONSTRAINT pk_gyumolcslevek PRIMARY KEY (id)
);

CREATE TABLE partnerek (
  id int,
  kontakt varchar(20) NOT NULL,
  telepules varchar(20) NOT NULL,
 CONSTRAINT pk_partnerek PRIMARY KEY (id)
);

CREATE TABLE kiszallitasok (
  sorsz int,
  gyumleid int NOT NULL,
  partnerid int NOT NULL,
  datum date NOT NULL,
  karton int NOT NULL,
  CONSTRAINT pk_kiszallitasok PRIMARY KEY (sorsz),
  CONSTRAINT fk_gyumleszall FOREIGN KEY (gyumleid) REFERENCES gyumolcslevek(id),
  CONSTRAINT fk_partnerszall FOREIGN KEY (partnerid) REFERENCES partnerek(id)
);

