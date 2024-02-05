-- Active: 1706877955099@@127.0.0.1@3306@phpmyadmin
CREATE DATABASE IF NOT EXISTS websocket_demo;
USE websocket_demo;

CREATE TABLE IF NOT EXISTS users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL
);

INSERT INTO users (username, password) VALUES
    ('user1', 'hashed_password_1'),
    ('user2', 'hashed_password_2'),
    ('user3', 'hashed_password_3');
