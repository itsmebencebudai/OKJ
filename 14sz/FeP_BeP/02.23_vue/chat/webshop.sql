-- Active: 1708009143398@@127.0.0.1@3306@webshop
drop database if exists webshop;

CREATE DATABASE if not exists webshop
    DEFAULT CHARACTER SET = 'utf8' COLLATE utf8_hungarian_ci;
    
use webshop;

create table IF NOT EXISTS User (
    userID int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(40) NOT NULL,
    email VARCHAR(50) NOT NULL,
    password BLOB not null,
    accountNumber VARCHAR(20)
) Engine=Innodb;    

CREATE TABLE IF NOT EXISTS Address (
	addressID int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    zipCode CHAR(4) NOT NULL,
    city VARCHAR(40) NOT NULL,
    street varchar(50) NOT NULL,
    delevery TINYINT(1) DEFAULT 0,
    userID int not null
) Engine=Innodb;

CREATE TABLE IF NOT EXISTS Products (
    productID int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    productName VARCHAR(50) NOT NULL,
    description TEXT NULL,
    price FLOAT,
    stock integer DEFAULT 0
) Engine=Innodb; 

CREATE TABLE IF NOT EXISTS Cart (
    cartID int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    userID int NOT NULL,
    cartDate DATETIME DEFAULT CURRENT_TIMESTAMP
) Engine=Innodb;

CREATE TABLE IF NOT EXISTS ChartItems (
    cartID int NOT NULL,
    productID int NOT NULL,
    quantity int DEFAULT 1
) Engine=Innodb;

CREATE TABLE IF NOT EXISTS Invoice (
    invoiceId int NOT NULL PRIMARY KEY AUTO_INCREMENT ,
    userID int NOT NULL,
    invoiceDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    totalPrice FLOAT
) Engine=Innodb;

CREATE TABLE IF NOT EXISTS InvoiceItem (
    invoiceID int NOT NULL,
    productID int NOT NULL
) Engine=Innodb;

ALTER TABLE `Address` ADD FOREIGN KEY (userID) REFERENCES `User`(userID);
ALTER TABLE Cart ADD FOREIGN KEY (userId) REFERENCES User(userID);
ALTER TABLE Invoice ADD FOREIGN KEY (userId) REFERENCES User(userID);
-- ALTER table User AUTO_INCREMENT = 1;

INSERT INTO `User` (name, email, password, accountNumber) VALUES 
('Maci Laci', 'maci@laci.com', 'macika', '1234-5648-7878-8975'),
('Kiss Elemér', 'kiss.elemer@suli.com', 'kisselemer', '1234-4487-7878-8976'),
('Bukta János', 'bukta.janos@suli.com', 'buktajani', '1234-3545-7878-8977');

-- ALTER table Address AUTO_INCREMENT = 1;
insert into `Address` VALUES 
    (null,1115,'Budapest','Móricz Zsigmond utca 12',0,1),
    (null,1134,'Budapest','Váci út 25 1/3',0,1),
    (null,4587,'Esztergom','Béke ut 25',0,2);

INSERT INTO `Address` (`addressID`, `zipCode`, `city`, `street`, `userID`)
VALUES (null, 1117, 'Budapest', 'Móricz Zsigmond utca 13', 1);


INSERT INTO `Products` VALUES
    (null,'Dell laptop','Ez egy jó laptop',524542,5),
    (null,'Lenovo laptop','Ez egy jó könnyű laptop',354685,5),
    (null,'Hp laptop','Ez egy jó gyors laptop',784654,5);

-- select * from User join `Address` on User.`addressID` = Address.`addressID` ;

alter table `User` MODIFY email VARCHAR(50) NOT NULL UNIQUE;

-- ALTER USER 'root'@'localhost' IDENTIFIED WITH mysql_native_password BY 'jelszo';
-- FLUSH PRIVILEGES;

-- alter table `User` MODIFY addressID int;

insert into User (name,email,password,accountNumber) values ("Bubuka","bubuka@maci.hu","hihi","1234-4567-8978-6547");

drop procedure if exists getAllUserInfos;
delimiter //
CREATE PROCEDURE getAllUserInfos(IN userID int)
BEGIN
    select * from User left join Address on User.`userID` = Address.`userID` WHERE User.userID = userID;
END//
delimiter ;
CALL getAllUserInfos(3);

drop procedure if exists allUserCount;
DELIMITER //
CREATE PROCEDURE allUserCount(OUT count int)
BEGIN
    select count(userID) into count from User;
END//
DELIMITER ;

-- call allUserCount(@count);
-- SELECT @count;

DROP FUNCTION IF EXISTS valami;
DELIMITER //
CREATE FUNCTION valami (s VARCHAR(20))
RETURNS VARCHAR(50) DETERMINISTIC
BEGIN
    RETURN CONCAT('Hello ', s, '!');
END //
DELIMITER ;
SELECT valami('world');

drop procedure if exists fullName;
DELIMITER //
CREATE FUNCTION fullName (vezNev VARCHAR(20), kerNev VARCHAR(40))
RETURNS VARCHAR(60) DETERMINISTIC
BEGIN
    RETURN CONCAT(vezNev, ' ', kerNev);
END //
DELIMITER ;
SELECT fullName(name, name) FROM User;

DELIMITER //
CREATE TRIGGER insertUser BEFORE INSERT ON User FOR EACH ROW
BEGIN
    SET NEW.password = SHA2(NEW.password, 256);
END;
//
DELIMITER ;
INSERT INTO User (name, email, password, accountNumber) VALUES ('Bubuka', 'bubuka@macigg.hu', 'hihi', '1234-4567-8978-6547');
INSERT INTO User (name, email, password, accountNumber) VALUES ('admin', 'admin@gmail.com', 'admin', '1');

alter table User ADD token VARCHAR(255);

DROP PROCEDURE IF EXISTS userLogin;
DELIMITER //
CREATE PROCEDURE userLogin(IN mail VARCHAR(50), pwd VARCHAR(50))
BEGIN
    SELECT userID, name, email FROM User WHERE User.email = mail AND User.password = SHA2(pwd, 256);
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS userUpdateToken;
DELIMITER //
CREATE PROCEDURE userUpdateToken(IN id INT, token TEXT)
BEGIN
    UPDATE `User` SET `User`.token = token WHERE `User`.userID = id;     
END //
DELIMITER ;

-- call userLogin("maci@laci.com","macika");

-- call `userUpdateToken`(1,"dsagfdsg");
	
alter table User MODIFY token TEXT;

-- select userID, name, email from User  WHERE  User.password = sha2("macika",256);


-- 88daa826fbe1108a8eff7848f62560dfd81754dae90dcd0bed9882a8065fd8b6;
-- select sha2('macika',256);