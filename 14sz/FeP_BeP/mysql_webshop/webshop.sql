-- Active: 1695968358990@@127.0.0.1@3306@webshop

CREATE DATABASE
    webshop DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci

CREATE Table
    `Users`(
        id int(10) NOT NULL AUTO_INCREMENT,
        name varchar(50) NOT NULL,
        email varchar(50) NOT NULL,
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
    -- (NULL, 'Maci Laci', 'maci@laci.com',SHA2('')),
    (NULL,'Kiss Elemér','kiss.elemer@suli.com',SHA2('kisselemer',256),'7894-4562-1236-5478',2,NULL),
    (NULL,'Bukta János','bukta.janos@suli.com',SHA2('buktajani',256),'1234-5678-5424-7947',2,NULL);

    INSERT INTO `Address` VALUES
    (NULL, 1115, 'Budapest','Móricz Zsigmond utca 12',NULL),
    (NULL, 1134, 'Budapest','Váci út 25 1/3',NULL),
    (NULL, 4587, 'Esztergom','Béke ut 25',NULL);

    INSERT INTO `products` VALUES
        (NULL,'Dell laptop','Ez egy jó laptop',524524,5),
        (NULL,'Lenovo laptop','Ez egy jó könnyű laptop',5674524,6),
        (NULL,'Hp laptop','Ez egy jó gyors laptop',534524,6);