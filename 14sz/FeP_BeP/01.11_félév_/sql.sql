-- Active: 1697197325232@@127.0.0.1@3306@attendence

-- Database
DROP database if exists dolgozat_01_11;
CREATE DATABASE dolgozat_01_11
DEFAULT CHARACTER set utf8
COLLATE utf8_hungarian_ci;
use dolgozat_01_11;


-- Create
create table konyv(
	cím varchar(255),
    kiadas datetime,
    szerzo varchar(255),
    kiadó varchar(255),
    leltáriszam INT auto_increment primary key,
    típus varchar(255)
);
create table felhasznalo(
	felhasznalo_id INT auto_increment primary key,
	nev varchar(255),
    olvasojegy varchar(255),
    cím varchar(255),
    telefonszama varchar(255),
    tagdij bool
);
create table kolcsonzes (
	felhasznalo_id INT,
    konyv_id INT,
    foreign key (felhasznalo_id)
		references felhasznalo (felhasznalo_id),
	foreign key (konyv_id)
		references konyv (leltáriszam)
);


-- Insert
insert into konyv (cím,kiadas,szerzo,kiadó,típus) values
('cím1','2024-01-11T12:30:00','szerzo1','kiadó1','típus1'),
('cím2','2024-02-11T13:30:00','szerzo2','kiadó2','típus2'),
('cím3','2024-03-11T14:30:00','szerzo3','kiadó3','típus3'),
('cím4','2024-04-11T15:30:00','szerzo4','kiadó4','típus4'),
('cím5','2024-05-11T16:30:00','szerzo5','kiadó5','típus5'),
('cím6','2024-06-11T17:30:00','szerzo6','kiadó6','típus6');
insert into felhasznalo(nev,olvasojegy,cím,telefonszama,tagdij) values 
('nev1','AAAA-0001','cím1','0630000001','true'),
('nev2','AAAA-0002','cím2','0630000002','false'),
('nev3','AAAA-0003','cím3','0630000003','true'),
('nev4','AAAA-0004','cím4','0630000004','false'),
('nev5','AAAA-0005','cím5','0630000005','true');
insert into kolcsonzes (felhasznalo_id,konyv_id) values 
('1','1'),
('1','4'),
('5','3'),
('4','4'),
('2','2'),
('3','5');


-- Ki kölcsönözte ki az adott könyvet
DELIMITER //
create procedure feladat1(IN konyvid INT)
begin
	select felhasznalo.nev, felhasznalo.olvasojegy,felhasznalo.cím, felhasznalo.telefonszama,felhasznalo.tagdij
    from felhasznalo inner join kolcsonzes on kolcsonzes.felhasznalo_id = felhasznalo.felhasznalo_id inner join konyv on konyv.leltáriszam = kolcsonzes.konyv_id
    where konyv.leltáriszam = konyvid;
end;
//
DELIMITER ;
call feladat1(3);

-- Ha ki van kölcsönözve mikor hozzák vissza?
DELIMITER //
create procedure feladat2(IN konyvid INT)
begin
	select konyv.leltáriszam, DATE_ADD(kiadas, interval 1 month) as 'visszahozás dátum'
    from konyv
    where konyv.leltáriszam = konyvid;
end;
//
DELIMITER ;
call feladat2(2);

-- Mikor és kik kölcsönözték ki a könyvet
DELIMITER //
create procedure feladat3(IN konyvid INT)
begin 
	select  konyv.kiadas, felhasznalo.nev
    from felhasznalo inner join kolcsonzes on kolcsonzes.felhasznalo_id = felhasznalo.felhasznalo_id inner join konyv on konyv.leltáriszam = kolcsonzes.konyv_id
	where konyv.leltáriszam = konyvid;
end;
//
DELIMITER ;
call feladat3(4);

-- Adott felhasználó melyik könyveket kölcsönzte ki
DELIMITER //
create procedure feladat4(IN felhasznaloid INT)
begin
	select konyv.cím, konyv.kiadas, konyv.szerzo, konyv.kiadó, konyv.leltáriszam, konyv.típus
    from felhasznalo inner join kolcsonzes on kolcsonzes.felhasznalo_id = felhasznalo.felhasznalo_id inner join konyv on konyv.leltáriszam = kolcsonzes.konyv_id
    where felhasznalo.felhasznalo_id = felhasznaloid;
end;
//
DELIMITER ;
call feladat4(5);

-- Az adott felhasználónál hány darab könyv van
DELIMITER //
create procedure feladat5(IN felhasznaloid INT)
begin 
	select COUNT(konyv.leltáriszam)
    from felhasznalo inner join kolcsonzes on kolcsonzes.felhasznalo_id = felhasznalo.felhasznalo_id inner join konyv on konyv.leltáriszam = kolcsonzes.konyv_id
    where felhasznalo.felhasznalo_id = felhasznaloid;
end;
//
DELIMITER ;
call feladat5(1);

-- Ha rögzítünk egy új felhasználót, akkor az olvasójegy egy "AAAA-0000" formátumú karaktersorozat legyen, ez a beszúráskor automatikusan jöjjön létre és mentődjön
DELIMITER //

create procedure feladat6(IN felhasznalo_nev VARCHAR(50))
begin
    declare uj_olvasojegy varchar(10);

    SET uj_olvasojegy = CONCAT(UPPER(SUBSTRING(UUID(), 1, 4)),'-',LPAD((SELECT IFNULL(MAX(SUBSTRING(olvasojegy, 6)), 0) + 1 FROM felhasznalo), 4, '0'));
    
    insert into felhasznalo (nev, olvasojegy) values
    (felhasznalo_nev, uj_olvasojegy);
end;
//
DELIMITER ;
call feladat6('Új felhasználó');

select *
from felhasznalo;



