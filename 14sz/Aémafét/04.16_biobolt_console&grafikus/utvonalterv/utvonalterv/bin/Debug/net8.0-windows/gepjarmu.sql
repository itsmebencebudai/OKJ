DROP DATABASE IF EXISTS `GepjarmuUtvonal`;

CREATE DATABASE `GepjarmuUtvonal`
DEFAULT CHARACTER SET utf8
COLLATE utf8_hungarian_ci;

USE `GepjarmuUtvonal`;

CREATE TABLE `vizsga_gepjarmu` (
    rendszam VARCHAR(7) PRIMARY KEY,
    marka TEXT(20),
    tipus TEXT(20),
    tulaj_neve TEXT(50),
    fogyasztas INTEGER
);

CREATE Table vizsga_utvonal (
    id INT PRIMARY KEY auto_increment,
    gepjartmuID VARCHAR(7),
    honnan TEXT(50),
    hova TEXT(50),
    km INTEGER,
    FOREIGN KEY (gepjartmuID) 
		REFERENCES vizsga_gepjarmu(rendszam)
);


INSERT INTO vizsga_gepjarmu (rendszam, marka, tipus, tulaj_neve, fogyasztas) VALUES
('abc-123', 'Opel', 'Corsa Van','Kiss Béla', 6),
('asd-234','Skoda', 'Van', 'Kiss Béla', 7.5),
('fgh-123', 'VW', 'Transporter', 'Kedves Emese', 8),
('xyz-123', 'Mercedes', 'Vaneo', 'Transzporter Imre', 7);

INSERT INTO vizsga_utvonal (gepjartmuID, honnan, hova, km) VALUES
('abc-123', 'Budapest', 'Hatvan', 60),
('xyz-123', 'Budapest', 'Szentendre', 20),
('xyz-123', 'Budapest', 'Baja', 200);


