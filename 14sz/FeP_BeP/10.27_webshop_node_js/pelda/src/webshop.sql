-- Active: 1675412648823@@127.0.0.1@3306@webshop
CREATE DATABASE webshop
    DEFAULT CHARACTER SET = 'utf8' COLLATE utf8_hungarian_ci;

create table IF NOT EXISTS User (
    userID int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(40) NOT NULL,
    email VARCHAR(50) NOT NULL,
    password BLOB not null,
    accountNumber VARCHAR(20)
) Engine=Innodb;    

CREATE TABLE IF NOT EXISTS Address (addressID int NOT NULL PRIMARY KEY AUTO_INCREMENT,
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


INSERT INTO `User` VALUES
    (null,'Maci Laci','maci@laci.com',sha2('macika',256),'1234-5648-7878-8975'),
    (null,'Kiss Elemér','kiss.elemer@suli.com',sha2('kisselemer',256),'1234-4487-7878-8976'),
    (null,'Bukta János','bukta.janos@suli.com',sha2('buktajani',256),'1234-3545-7878-8977');

insert into `Address` VALUES 
    (null,1115,'Budapest','Móricz Zsigmond utca 12',0,1),
    (null,1134,'Budapest','Váci út 25 1/3',0,2),
    (null,4587,'Esztergom','Béke ut 25',0,3);

insert INTO `Address` (`addressID`,`zipCode`,city,street) VALUES
     (null,1117,'Budapest','Móricz Zsigmond utca 13');




INSERT INTO `Products` VALUES
    (null,'Dell laptop','Ez egy jó laptop',524542,5),
    (null,'Lenovo laptop','Ez egy jó könnyű laptop',354685,5),
    (null,'Hp laptop','Ez egy jó gyors laptop',784654,5);

Select * from User;

select * from User join `Address` on User.`addressID` = Address.`addressID` ;

alter table `User` MODIFY email VARCHAR(50) NOT NULL UNIQUE;

alter user 'root'@'localhost' identified with mysql_native_password by 'jelszo';
FLUSH PRIVILEGES;

alter table `User` MODIFY addressID int;


insert into User (name,email,password,accountNumber) values ("Bubuka","bubuka@maci.hu","hihi","1234-4567-8978-6547");
select * from User;
delete from User where userID = 5;

delete from Address where addressID = 10;


select * from User left join Address on User.`userID` = Address.`userID` WHERE User.userID = 3;  