-- Active: 1695968358990@@127.0.0.1@3306@webshop

CREATE DATABASE
    webshop DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci

CREATE Table
    `Users`(
        id int(10) NOT NULL AUTO_INCREMENT,
        name varchar(50) NOT NULL,
        email varchar(50) NOT NULL,-- UNIQUE => egyedi nem lehet 2 ugyan olya
        pw BLOB,
        shipping int DEFAULT NULL,
        addressId int DEFAULT NULL,
        account_number VARCHAR(16),
        PRIMARY KEY (id),
        FOREIGN KEY(addressId) REFERENCES `Address` (id)
    )

CREATE Table
    `Address`(
        id int DEFAULT NULL AUTO_INCREMENT,
        street VARCHAR(50) Not NULL,
        city VARCHAR(20) Not NULL,
        zip_code int DEFAULT NULL,
        delivery_address BOOLEAN,
        PRIMARY KEY (id)
    )

CREATE TABLE
    `products`(
        id int(10) NOT NULL AUTO_INCREMENT,
        product_name varchar(50) NOT NULL,
        product_description TEXT NOT NULL,
        product_price int DEFAULT NULL,
        stock int DEFAULT NULL,
        PRIMARY KEY (id)
    )

CREATE Table
    `cart` (
        id int(10) NOT NULL AUTO_INCREMENT,
        userId int DEFAULT NULL,
        date DATETIME,
        PRIMARY KEY (id),
        FOREIGN KEY (userId) REFERENCES `Users` (id)
    )

CREATE TABLE
    `cartitems` (
        cartId INT DEFAULT NULL,
        productId INT DEFAULT NULL,
        quantity INT DEFAULT NULL,
        FOREIGN KEY (cartId) REFERENCES `cart` (id),
        FOREIGN KEY (productId) REFERENCES `products` (id)
    )

CREATE Table
    `invoice` (
        id int(10) NOT NULL AUTO_INCREMENT,
        userId int DEFAULT NULL,
        date DATETIME,
        total int DEFAULT NULL,
        PRIMARY KEY (id),
        FOREIGN KEY (userId) REFERENCES `Users` (id)
    )

CREATE Table
    invoce_items(
        invoiceId INT DEFAULT NULL,
        productId INT DEFAULT NULL,
        constraint FK_invoice_items_invoice_invoiceId FOREIGN KEY (invoiceId) REFERENCES invoice (id),
        constraint FK_invoice_items_products_productId FOREIGN KEY (productId) REFERENCES products (id)
    )

    INSERT into `Users` VALUES
    (NULL, 'Maci Laci', 'maci@laci.com',SHA2('maclaci',256),2,NULL,'1313-4234-1236-5466'),
    (NULL,'Kiss Elemér','kiss.elemer@suli.com',SHA2('kisselemer',256),2,NULL,'7894-4562-1236-5478'),
    (NULL,'Bukta János','bukta.janos@suli.com',SHA2('buktajani',256),2,NULL,'1234-5678-5424-7947');

    INSERT INTO `Address` VALUES
    (NULL, 'Móricz Zsigmond utca 12','Budapest',1115,NULL),
    (NULL, 'Váci út 25 1/3', 'Budapest',1134,NULL),
    (NULL, 'Béke ut 25', 'Esztergom',4587,NULL);

    INSERT INTO `products` VALUES
        (NULL,'Dell laptop','Ez egy jó laptop',524524,5),
        (NULL,'Lenovo laptop','Ez egy jó könnyű laptop',5674524,6),
        (NULL,'Hp laptop','Ez egy jó gyors laptop',534524,6);


ALTER Table Users MODIFY email varchar(50) NOT NULL UNIQUE; 
    
ALTER Table `Users` MODIFY account_number varchar(20) NOT NULL UNIQUE;

ALTER Table `Users` MODIFY id int(10) NOT NULL AUTO_INCREMENT

INSERT INTO `Users` (name,email,pw,account_number) VALUES("Bubuka","bubuka@gmail.com","hihi","1234-1234-1234-1234");

SELECT * FROM `Users`

DELETE FROM `Users` WHERE pw = "hihi";