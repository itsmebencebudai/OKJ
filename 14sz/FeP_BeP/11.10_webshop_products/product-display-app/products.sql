-- Active: 1697197325232@@127.0.0.1@3306

CREATE DATABASE productdb;

USE productdb;

CREATE TABLE
    products (
        id INT AUTO_INCREMENT PRIMARY KEY,
        name VARCHAR(255),
        price DECIMAL(10, 2),
        description TEXT
    );

INSERT INTO products (name, price, description) VALUES
    ('Product A', 19.99, 'A high-quality product with advanced features.'),
    ('Product B', 29.99, 'An affordable option for everyday use.'),
    ('Product C', 39.99, 'Designed for durability and performance.'),
    ('Product D', 49.99, 'Ideal for professional use with advanced functionalities.'),
    ('Product E', 59.99, 'A versatile product suitable for various applications.');