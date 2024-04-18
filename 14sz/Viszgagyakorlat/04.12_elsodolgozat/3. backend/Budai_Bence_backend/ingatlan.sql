DROP DATABASE IF EXISTS ingatlan;

CREATE DATABASE ingatlan
Default CHARACTER SET utf8
COLLATE utf8_hungarian_ci;

USE ingatlan;

CREATE Table kategoriak(
    id INT PRIMARY KEY,
    nev TEXT
);

CREATE TABLE ingatlanok (
    id INT PRIMARY KEY,
    kategoria INTEGER,
    leiras TEXT,
    hirdetesDatuma DATE DEFAULT CURRENT_TIMESTAMP,
    tehermentes BOOLEAN,
    ar INTEGER,
    kepurl TEXT,
    FOREIGN KEY (kategoria) REFERENCES kategoriak(id)
);

INSERT INTO kategoriak VALUES
(1,"Ház"),
(2,"Lakás"),
(3,"Építési telek"),
(4,"Garázs"),
(5,"Mezőgazdasági terület"),
(6,"Ipari ingatlan");

DROP PROCEDURE IF EXISTS GetAllIngatlanok;
DELIMITER //
CREATE PROCEDURE GetAllIngatlanok()
BEGIN
    SELECT * FROM ingatlanok;
END;
//
DELIMITER ;
