-- Active: 1695968358990@@127.0.0.1@3306@voting_db
CREATE DATABASE IF NOT EXISTS voting_db;
USE voting_db;


CREATE TABLE IF NOT EXISTS users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL
);


CREATE TABLE IF NOT EXISTS votes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    option VARCHAR(255),
    FOREIGN KEY (user_id) REFERENCES users(id)
);


INSERT INTO users (username, password) VALUES
('user1', 'password1'),
('user2', 'password2'),
('user3', 'password3');

INSERT INTO users (username, password) VALUES 
('adminocska','adminocska');

INSERT INTO votes (user_id, option) VALUES
(1, 'Option A'),
(2, 'Option B'),
(3, 'Option C'),
(4, 'Option D');


SELECT * FROM users;

SELECT * FROM votes;
