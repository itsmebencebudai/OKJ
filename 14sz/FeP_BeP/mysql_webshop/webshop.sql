CREATE DATABASE
    webshop DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci

CREATE Table
    Users_(
        id int(10) NOT NULL AUTO_INCREMENT,
        name varchar(50) NOT NULL,
        email varchar(50) NOT NULL,
        pw BLOB,
        shipping int DEFAULT NULL,
        addressId int DEFAULT NULL,
        account_number VARCHAR(16),
        PRIMARY KEY (user_id),
        constraint FK_users_address_addressId FOREIGN (addressId) REFERENCES address_ (addressId),
    )

CREATE Table
    Address_(
        addressId int DEFAULT NULL AUTO_INCREMENT,
        street VARCHAR(50) Not NULL,
        city VARCHAR(20) Not NULL,
        zip_code int DEFAULT NULL,
        delivery_address BOOLEAN,
        PRIMARY KEY (id),
    )

CREATE products(
    id int(10) NOT NULL AUTO_INCREMENT,
    product_name varchar(50) NOT NULL,
    product_description TEXT NOT NULL,
    product_price int DEFAULT NULL,
    stock int DEFAULT NULL,
    PRIMARY KEY (id)
)

CREATE Table
    cart (
        id int(10) NOT NULL AUTO_INCREMENT,
        userId int DEFAULT NULL,
        date DATETIME,
        PRIMARY KEY (id),
        constraint FK_cart_users_userId FOREIGN KEY (userId) REFERENCES users (id)
    )
CREATE TABLE
    cartitems (
        cartId INT DEFAULT NULL,
        productId INT DEFAULT NULL,
        quantity INT DEFAULT NULL,
        constraint FK_cartitems_productsId FOREIGN KEY (productId) REFERENCES products (id)
        constraint FK_cartitems_cartId FOREIGN KEY (cartId) REFERENCES cart (id)
    )

CREATE Table
    invoice (
        id int(10) NOT NULL AUTO_INCREMENT,
        userId int DEFAULT NULL,
        date DATETIME,
        total int DEFAULT NULL,
        constraint FK_invoice_user_userId FOREIGN KEY (userid) REFERENCES user (id)
    )

CREATE Table
    invoce_items(
        invoice_id INT DEFAULT NULL,
        product_id INT DEFAULT NULL,
    )