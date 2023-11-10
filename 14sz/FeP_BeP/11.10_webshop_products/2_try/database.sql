-- Active: 1695968358990@@127.0.0.1@3306@voting_db_2
CREATE DATABASE voting_db_2;

USE voting_db_2;

CREATE TABLE users (
    id INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL
);s

CREATE TABLE votes (
    id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT,
    option_selected INT,
    FOREIGN KEY (user_id) REFERENCES users(id)
);

INSERT INTO users VALUES 
('','admin','admin');

SELECT * FROM votes

INSERT INTO users (username, password) VALUES 
('user1', 'password1'),
('user2', 'password2'),
('user3', 'password3');