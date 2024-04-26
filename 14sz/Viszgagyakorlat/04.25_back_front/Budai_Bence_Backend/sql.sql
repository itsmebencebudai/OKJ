DROP DATABASE IF EXISTS `kisallat`;

CREATE DATABASE `kisallat`;

USE `kisallat`;

CREATE TABLE `vasarlo` (
  `id`INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `nev` varchar(100) NOT NULL,
  `cim` varchar(80) NOT NULL,
  `telefonszam` varchar(20)
);

CREATE TABLE `pet`(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nev varchar(30) NOT NULL UNIQUE,
    leiras VARCHAR(100) NOT NULL,
    ar INT NOT NULL,
    raktaron INT NOT NULL,
    kep VARCHAR(100)
);

CREATE TABLE `megrendeles`(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    vasarloid INT NOT NULL,
    datum DATE NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE `tetelek`(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    megrendelesId INT NOT NULL,
    petId INT NOT NULL,
    mennyiseg INT NOT NULL,
    FOREIGN KEY (megrendelesId) REFERENCES megrendeles(id),
    FOREIGN KEY (petId) REFERENCES pet(id)
);

INSERT INTO `vasarlo` (`nev`, `cim`, `telefonszam`) VALUES
('Kandúr Károly', '1112 Budapest Varjú u. 12', '0622354784'),
('Gipsz Jakab', '1024 Budapest Gipsz u. 23', '06305248787');

INSERT INTO `pet` (`nev`, `leiras`, `ar`, `raktaron`, `kep`) VALUES
('Hörcsög', 'Ez meg rágcsál', 10500, 5, './pictures/horcsog.jpg'),
('Tengeri malac', 'Tengeri röfi', 6300, 8, './pictures/tmalac.jpg'),
('Madárpók', 'Veszélyes madárpók', 80000, 3, './pictures/madarpok.jpg'),
('Aranyhal', 'Szép aranyhal', 3500, 1, './pictures/aranyhal.jpg');

-- INSERT INTO `megrendeles` (`vasarloid`, `datum`) VALUES
-- (1, '2024-04-25'),
-- (1, '2018-02-01');

-- INSERT INTO `tetelek` (`megrendelesId`, `petId`, `mennyiseg`) VALUES
-- (1, 1, 1),
-- (1, 2, 3),
-- (2, 1, 4);

CREATE TRIGGER PetNagyBetu
BEFORE INSERT ON pet 
FOR EACH ROW
SET NEW.nev = UPPER(NEW.nev);

DROP PROCEDURE IF EXISTS FelhasznaloNapVasarlas;
DELIMITER //
CREATE PROCEDURE `FelhasznaloNapVasarlas` (in_id INT, In_date DATE)
BEGIN
    SELECT vasarlo.nev, tetelek.megrendelesId, pet.nev, tetelek.mennyiseg, megrendeles.datum, pet.id
    FROM `tetelek` INNER JOIN megrendeles ON megrendeles.id=tetelek.megrendelesId INNER JOIN vasarlo ON megrendeles.vasarloid=vasarlo.id INNER JOIN pet ON pet.id=tetelek.petId
    WHERE vasarlo.id = in_id
    AND megrendeles.datum = in_date;
END;
//
DELIMITER ;