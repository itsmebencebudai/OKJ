CREATE TABLE megye(
   id integer NOT NULL,
   mnev varchar(40) NOT NULL,
  CONSTRAINT pk_megye PRIMARY KEY (id)
);

CREATE TABLE varostipus(
   id integer NOT NULL,
   vtip varchar(40) NOT NULL,
  CONSTRAINT pk_varostipus PRIMARY KEY (id)
);

CREATE TABLE varos(
   id integer NOT NULL,
   vnev varchar(40) NOT NULL,
   vtipid integer NOT NULL,
   megyeid integer NOT NULL,
   jaras varchar(20),
   kisterseg varchar(20),
   nepesseg integer,
   terulet real,
  CONSTRAINT pk_varos PRIMARY KEY (id)
);

ALTER TABLE varos
  ADD CONSTRAINT FK_varos_varostipus FOREIGN KEY (vtipid)
    REFERENCES varostipus(id);
ALTER TABLE varos
  ADD CONSTRAINT FK_varos_megye FOREIGN KEY (megyeid)
    REFERENCES megye(id);
