-- Active: 1695968358990@@127.0.0.1@3306@gyak_09_29

CREATE DATABASE
    gyak_09_29 default CHARACTER SEt utf8 COLLATE utf8_hungarian_ci

CREATE TABLE
    diak (
        id int NOT NULL,
        nev varchar(50) DEFAULT NULL,
        osztId int DEFAULT NULL,
        PRIMARY KEY (id),
        constraint FK_diak_oszt_osztId FOREIGN KEY(osztId) REFERENCES oszt(id)
    );

CREATE TABLE
    oszt (
        id int NOT NULL,
        nev varchar(50) DEFAULT NULL,
        osztfonokId int DEFAULT NULL,
        PRIMARY KEY (id),
        constraint FK_oszt_osztfonok_osztfonokId FOREIGN KEY (osztfonokId) REFERENCES osztfonok (id)
    );

CREATE TABLE
    osztfonok (
        id int NOT NULL,
        nev varchar(50) DEFAULT NULL,
        PRIMARY KEY (id)
    );

INSERT INTO diak
VALUES (1, 'Budai Bence', 1), (2, 'Tudos Levi', 1), (3, 'Fazekas Balint',1), (4, 'Ponkhazi Barnabás',1), (5, 'Forras Mark',1), (6, 'Nadas Tamas',1), (7, 'Czinege Zoltán',1), (8, 'Gashler Gergo',1), (9, 'Kerepecki Marcell',1), (10, 'Kovács Zoltán',1), (11, 'Major Dominik',1);

INSERT INTO osztfonok VALUES (1,'Szilasi Istvan');

INSERT INTO oszt VALUES (1,'14sz',1);