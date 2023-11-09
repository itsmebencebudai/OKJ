-- Active: 1695968358990@@127.0.0.1@3306@szavazas
CREATE DATABASE szavazas
DEFAULT CHARACTER set utf8
COLLATE utf8_hungarian_ci


CREATE Table if not exists user(
    userID int not NULL,
    name VARCHAR(40) not NULL,
    email VARCHAR(50) not NULL,
    password BLOB not NULL,
    szavazott BOOLEAN
)

CREATE Table if not exists tanar (
    name VARCHAR(40) not NULL,
    szavazottDB int not NULL
)

INSERT INTO `tanar` VALUES 
    ('Gipsz Jakab','0'),
    ('Maci Laci', '0'),
    ('Bukta Janos', '0');


SELECT * from tanar

SELECT * FROM user