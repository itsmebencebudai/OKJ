DROP DATABASE IF EXISTS `kolcsonzes`;

CREATE DATABASE `kolcsonzes`
DEFAULT CHARACTER SET utf8
COLLATE utf8_hungarian_ci;

USE `kolcsonzes`;

CREATE TABLE `berlok` (
    id INTEGER PRIMARY KEY auto_increment,
    nev VARCHAR(100) NOT NULL,
    jogositvany VARCHAR(15) NOT NULL,
    telefonszám VARCHAR(20) 
);

CREATE TABLE `autok` (
    id INTEGER PRIMARY KEY auto_increment,
    rendszam VARCHAR(7) NOT NULL UNIQUE,
    tipus VARCHAR(100) NOT NULL,
    evjarat INT,
    szin VARCHAR(30)
);

CREATE Table `kolcsonzes` (
    id INTEGER PRIMARY KEY auto_increment,
    berloid INT NOT NULL,
    autoid INT NOT NULL,
    berletkezdete DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    napokszama INT,
    napidij DOUBLE NOT NULL,
    FOREIGN KEY (berloid) REFERENCES berlok(id),
    FOREIGN KEY (autoid) REFERENCES autok(id)
);

CREATE TRIGGER RendszamNagyBetu
BEFORE INSERT ON autok 
FOR EACH ROW
SET NEW.rendszam = UPPER(NEW.rendszam);

DROP FUNCTION IF EXISTS IsKolcsonozheto;
DELIMITER //
CREATE FUNCTION IsKolcsonozheto (in_id INT)
RETURNS BOOLEAN
BEGIN
    DECLARE napokszama INT;
    DECLARE kolcsonozheto BOOLEAN;
    SELECT kolcsonzes.napokszama INTO napokszama
    FROM kolcsonzes
    INNER JOIN autok ON autok.id=kolcsonzes.autoid 
    INNER JOIN berlok ON berlok.id=kolcsonzes.berloid 
    WHERE autok.id = in_id;
    IF napokszama = 0 THEN
        SET kolcsonozheto = FALSE;
    ELSE
        SET kolcsonozheto = TRUE;
    END IF;
    RETURN kolcsonozheto;
END;


INSERT INTO `berlok` (`nev`, `jogositvany`, `telefonszám`) VALUES 
('Kandúr Károly', 'LR123456', '0622354784'),
('Gipsz Jakab', 'VE566666', '06305248787');

INSERT INTO `autok` (`rendszam`, `tipus`, `evjarat`, `szin`) VALUES 
('AALA475', 'Ford Ka', '2005', 'Szürke'),
('ABC123', 'VW Golf', '2022', 'Fehér'),
('AAJQ625', 'Ford Mondeo', '2021', 'Kék'),
('AADD596', 'Seat Toledo', '2008', 'Zöld');