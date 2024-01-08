DROP DATABASE IF EXISTS mozimusor;

CREATE DATABASE mozimusor
DEFAULT CHARACTER SET utf8
COLLATE utf8_hungarian_ci;

USE mozimusor;

CREATE TABLE ember(
    EAZON INT auto_increment PRIMARY KEY,
    nev VARCHAR(255)
);

CREATE TABLE film(
    FAZON INT auto_increment PRIMARY KEY,
    cím TEXT,
    hossz INT,
    mufaj TEXT,
    rendezo INT,
    gyart_ev INT,
    szarmazas TEXT
);

CREATE Table mozi(
    MOAZON INT auto_increment PRIMARY KEY,
    nev TEXT,
    kerulet INT,
    típus VARCHAR(255)
);

CREATE Table musor(
    MUAZON INT auto_increment PRIMARY KEY,
    FAZON INT,
    MOAZON INT,
    datum DATE,
    idopont TIME
);

CREATE Table szerepel(
    FAZON INT,
    EAZON INT
);

ALTER Table film ADD Foreign Key (rendezo) REFERENCES ember(EAZON);

ALTER Table musor ADD FOREIGN KEY (FAZON) REFERENCES film (FAZON);
ALTER Table musor ADD FOREIGN KEY (MOAZON) REFERENCES mozi (MOAZON);

ALTER Table szerepel ADD FOREIGN KEY (FAZON) REFERENCES film (FAZON);

INSERT INTO ember (nev) VALUES
    -- Az eltűnt katona
    ('Dani Rosenberg'), -- rendezo 1
    ('Ido Tako'),
    ('Mika Reiss'), 
    ('Efrat Ben Tzur'),
	-- Palace Hotel
    ('Roman Polanski'), -- rendezo 5
    ('Mickey Rourke'),
    ('John Cleese'), 
    ('Oliver Masucci'), 
    ('Joaquim de Almeida'), 
    ('Fanny Ardant'), 
    -- Repülés kezdőknek
    ('Hafsteinn Gunnar Sigurðsson'), -- rendezo 11 
    ('Lydia Leonard'), 
	('Timothy Spall'), 
    ('Ella Rumpf'), 
    ('Emun Elliott'), 
    ('Nick Blakeley'), 
    -- Golda
    ('Guy Nattiv'), -- rendezo 17
    ('Helen Mirren'),
    ('Liev Schreiber'),
    ('Emma Davies'),
    ('Camille Cottin'),
    ('Rotem Keinan'),
    -- Wonka
    ('Paul King'), -- rendezo 23
    ('Timothée Chalamet'),
    ('Olivia Colman'),
    ('Hugh Grant'),
    ('Sally Hawkins'),
    ('Rowan Atkinson'),
    ('Keegan-Michael Key'),
    ('Simon Farnaby'),
    ('Matt Lucas'),
    ('Mathew Baynton'),
    ('Paterson Joseph'),
    -- Magyarázat mindenre
     ('Reisz Gábor'), -- rendezo 34
     ('Adonyi-Walsh Gáspár'),
     ('Znamenák István'),
     ('Rusznák András'),
     ('Hatházi Rebeka'),
     ('Sodró Eliza'),
     ('Kizlinger Lilla'),
     ('Urbanovits Krisztina'),
     -- A csodák útján
     ("Thaddeus O'Sullivan"), -- rendezo 42
     ('Kathy Bates'),
     ('Maggie Smith'),
     ("Agnes O'Casey"),
     ('Laura Linney'),
     -- Valami madarak
     ('Hevér Dániel'), -- rendezo 47
     ('Szacsvay László'),
     ('Kizlinger Lilla'),
     ('Valcz Péter'),
     ('Réti Adrienn'),
     ('Barbinek Péter'),
     ('Kopek Janka'),
     ('Péter Dávid'),
     ('Janicsek Péter'),
     ('Erdélyi Mária'),
     ('Bókai Mária'),
     ('Andai Kati'),
     ('Ujréti László'),
     ('Bajomi Nagy György'),
     ('Kiss Gábor'),
     ('Hajdu Miklós'),
     -- A szerelem természete
     ('Monia Chokri'), -- rendezo 63
     ('Magalie Lépine Blondeau'),
     ('Pierre-Yves Cardinal'),
     ('Francis-William Rhéaume'),
     ('Monia Chokri');

INSERT INTO film (cím,hossz,mufaj,rendezo,gyart_ev,szarmazas) VALUES

    ('Az eltűnt katona',105,'háborús filmdráma',1,2023,' izraeli-francia'), -- 1
    ('Palace Hotel',100 ,'filmdráma',5,2023,'olasz-svájci-lengyel-francia'), -- 2
    ('Repülés kezdőknek',97,'vígjáték',11,2023,' angol-izlandi-néme'), -- 3
    
    ('Golda',100,'életrajzi film',17,2023,'angol'), -- 4
    ('Wonka',112,'vígjáték',23,2023,'amerikai'), -- 5
    ('Magyarázat mindenre',151,'játékfilm',34,2023,'magyar'), -- 6
    
    ('A csodák útján',90,'dráma',42,2023,'ír-angol'), -- 7
    ('Valami madarak',90,'játékfilm',47,2023,'magyar'), -- 8
    ('A szerelem természete',110,'',63,2023,''); -- 9

INSERT INTO mozi (nev,kerulet,típus) VALUES
    ('Cirko-Gejzír',05,'Művész'), -- 1
    ('Művész',06,'Művész'), -- 2
    ('Puskin',05,'Művész'); -- 3

INSERT INTO musor (FAZON, MOAZON, datum, idopont) VALUES 
	-- Cirko-Gejzír
    -- 19
    (1, 1, '2023-12-19', '16:00'), -- Az eltűnt katona
    (2, 1, '2023-12-19', '16:15'), -- Palace Hotel
    (3, 1, '2023-12-19', '16:30'), -- Repülés kezdőknek
    (6, 1, '2023-12-19', '18:00'), -- Magyarázat mindenre
    (2, 1, '2023-12-19', '18:15'), -- Palace Hotel
	-- (0, 1, '2023-12-19', '18:30'), -- Vendég a francia kastélyban
	-- (0, 1, '2023-12-19', '20:15'), -- Egy zuhanás anatómiája
    (2, 1, '2023-12-19', '20:45'), -- Palace Hotel
    (1, 1, '2023-12-19', '21:00'), -- Az eltűnt katona
    -- 20
    (1, 1, '2023-12-20', '16:00'), -- Az eltűnt katona
    (2, 1, '2023-12-20', '16:15'), -- Palace Hotel
    (3, 1, '2023-12-20', '16:30'), -- Repülés kezdőknek
    (6, 1, '2023-12-20', '18:00'), -- Magyarázat mindenre
    (2, 1, '2023-12-20', '18:15'), -- Palace Hotel
    -- (0, 1, '2001-04-15', '18:30'), -- Vendég a francia kastélyban
    -- (0, 1, '2001-04-15', '20:15'), -- Egy zuhanás anatómiája
    (2, 1, '2023-12-20', '20:45'), -- Palace Hotel
    (1, 1, '2023-12-20', '21:00'), -- Az eltűnt katona
    -- Művész mozi
    -- 19
    (4, 2, '2023-12-19', '13:15'), -- Golda
    (5, 2, '2023-12-19', '13:15'), -- Wonka
    (6, 2, '2023-12-19', '14:00'), -- Magyarázat mindenre
    (8, 2, '2023-12-19', '14:00'), -- Valami madarak
    (7, 2, '2023-12-19', '14:15'), -- A csodák útján
    -- (0, 2, '2023-12-19', '15:15'), -- Filip
    -- (0, 2, '2023-12-19', '15:30'), -- Semmelweis
    -- (0, 2, '2023-12-19', '15:45'), -- Vendég a francia kastélyban
    -- (0, 2, '2023-12-19', '16:15'), -- Egy zuhanás anatómiája
    (5, 2, '2023-12-19', '17:45'), -- Wonka
    (2, 2, '2023-12-19', '17:00'), -- Palace Hotel
    (4, 2, '2023-12-19', '17:45'), -- Golda
    -- (0, 2, '2023-12-19', '18:00'), -- Semmelweis
    (8, 2, '2023-12-19', '19:00'), -- Valami madarak
    (2, 2, '2023-12-19', '19:00'), -- Palace Hotel
    -- (0, 2, '2023-12-19', '19:45'), -- Parasztok
    -- (0, 2, '2023-12-19', '20:00'), -- Napóleon
    -- (0, 2, '2023-12-19', '20:30'), -- Egy zuhanás anatómiája
    (6, 2, '2023-12-19', '20:45'), -- Magyarázat mindenre
    -- (0, 2, '2023-12-19', '21:15'), -- Mesterjátszma
    -- 20
	(5, 2, '2023-12-20', '13:15'), -- Wonka
    (4, 2, '2023-12-20', '13:15'), -- Golda
    (6, 2, '2023-12-20', '14:00'), -- Magyarázat mindenre
    (8, 2, '2023-12-20', '14:00'), -- Valami madarak
    -- (0, 2, '2023-12-20', '14:00'), -- Libertate’89 – Nagyszeben
	-- (0, 2, '2023-12-20', '15:15'), -- Filip
    -- (0, 2, '2023-12-20', '15:30'), -- Semmelweis
    -- (0, 2, '2023-12-20', '15:45'), -- Vendég a francia kastélyban
    -- (0, 2, '2023-12-20', '16:15'), -- Egy zuhanás anatómiája
    (2, 2, '2023-12-20', '17:00'), -- Palace Hotel
    (4, 2, '2023-12-20', '17:45'), -- Golda
    (5, 2, '2023-12-20', '17:45'), -- Wonka
    -- (0, 2, '2023-12-2', '18:00'), -- Semmelweis
    (8, 2, '2023-12-20', '19:00'), -- Valami madarak
    (3, 2, '2023-12-20', '19:00'), -- Repülés kezdőknek
    -- (0, 2, '2023-12-20', '19:45'), -- Megfojtott virágok
    -- (0, 2, '2023-12-20', '20:00'), -- Napóleon
    -- (0, 2, '2023-12-20', '20:30'), -- Egy zuhanás anatómiája
    (6, 2, '2023-12-20', '20:45'), -- Magyarázat mindenre
    -- (0, 2, '2023-12-20', '21:15'), -- Cicaverzum
    -- Puskin mozi
    -- 20
	(7, 3, '2023-12-20', '15:00'), -- A csodák útján
    (8, 3, '2023-12-20', '15:00'), -- Valami madarak
    -- (0, 3, '2023-12-20', '15:00'), -- Semmelweis
    (4, 3, '2023-12-20', '15:15'), -- Golda
    (9, 3, '2023-12-20', '16:15'), -- A szerelem természete
    (7, 3, '2023-12-20', '16:45'), -- A csodák útján
    (2, 3, '2023-12-20', '16:45'), -- Palace Hotel
    -- (0, 3, '2023-12-20', '17:15'), -- Egy zuhanás anatómiája
    (5, 3, '2023-12-20', '17:30'), -- Wonka
    -- (0, 3, '2023-12-20', '18:15'), -- Elfogy a levegő
    -- (0, 3, '2023-12-20', '18:30'), -- Ennél csak jobb jöhet
    -- (0, 3, '2023-12-20', '18:30'), -- Vendég a francia kastélyban
    -- (0, 3, '2023-12-20', '19:45'), -- Semmelweis
    -- (0, 3, '2023-12-20', '20:00'), -- Egy zuhanás anatómiája
    (3, 3, '2023-12-20', '20:15'), -- Repülés kezdőknek
    -- (0, 3, '2023-12-20', '20:30'), -- Vendég a francia kastélyban
    (2, 3, '2023-12-20', '20:30'); -- Palace Hotel
    

INSERT INTO szerepel (FAZON,EAZON) VALUES
	-- Az eltűnt katona
    (1,1), -- Dani Rosenberg
    (1,2), -- Ido Tako
    (1,3), -- Mika Reisss
    (1,4), -- Efrat Ben Tzur
    
    -- Palace Hotel
    (2,5), -- Roman Polanski
    (2,6), -- Mickey Rourke
    (2,7), -- John Cleese
    (2,8), -- Oliver Masucci
    (2,9), -- Joaquim de Almeida
    (2,10), -- Fanny Ardant
    
    -- Repülés kezdőknek
    (3,11), -- Hafsteinn Gunnar Sigurðsson
    (3,12), -- Lydia Leonard
    (3,13), -- Timothy Spall
    (3,14), -- Ella Rumpf
    (3,15), -- Emun Elliott
    (3,16), -- Nick Blakeley
    
    -- Golda
    (4,17), -- Guy Nattiv
    (4,18), -- Helen Mirren
    (4,19), -- Liev Schreiber
    (4,20), -- Emma Davies
    (4,21), -- Camille Cottin
    (4,22), -- Rotem Keinan
    
    -- Wonka
    (5,23), -- Paul King
    (5,24), -- Timothée Chalamet
    (5,25), -- Olivia Colman
    (5,26), -- Hugh Grant
    (5,27), -- Sally Hawkins
    (5,28), -- Rowan Atkinson
    (5,29), -- Keegan-Michael Key
    (5,30), -- Simon Farnaby
    (5,31), -- Matt Lucas
    (5,32), -- Mathew Baynton
    (5,33), -- Paterson Joseph
    
	-- Magyarázat mindenre
    (6,34), -- Reisz Gábor
    (6,35), -- Adonyi-Walsh Gáspár
    (6,36), -- Znamenák István
    (6,37), -- Rusznák András
    (6,38), -- Hatházi Rebeka
    (6,39), -- Sodró Eliza
    (6,40), -- Kizlinger Lilla
    (6,41), -- Urbanovits Krisztina
    
    -- A csodák útján
    (7,42), -- Thaddeus O'Sullivan
    (7,43), -- Kathy Bates
    (7,44), -- Maggie Smith
    (7,45), -- Agnes O'Casey
    (7,46), -- Laura Linne
    
    -- Valami madarak
    (8,47), -- Hevér Dániel
    (8,48), -- Szacsvay László
    (8,49), -- Kizlinger Lilla
    (8,50), -- Valcz Péter
    (8,51), -- Réti Adrienn
    (8,52), -- Barbinek Péter
    (8,53), -- Kopek Janka
    (8,54), -- Péter Dávid
    (8,55), -- Janicsek Péter
    (8,56), -- Erdélyi Mária
    (8,57), -- Bókai Mária
    (8,58), -- Andai Kati
    (8,59), -- Ujréti László
    (8,60), -- Bajomi Nagy György
    (8,61), -- Kiss Gábor
    (8,62), -- Hajdu Miklós
    
    -- A szerelem természete
    (9,63), -- Monia Chokri
    (9,64), -- Magalie Lépine Blondeau
    (9,65), -- Pierre-Yves Cardina
    (9,66), -- Francis-William Rhéaume
    (9,67); -- Monia Chokri
    
    
    