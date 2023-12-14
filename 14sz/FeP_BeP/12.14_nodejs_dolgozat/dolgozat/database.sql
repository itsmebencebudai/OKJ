-- Active: 1695968358990@@127.0.0.1@3306@voting_db_2

CREATE DATABASE online_filmnezes;

USE online_filmnezes;


DROP TABLE users;
CREATE TABLE
    users (
        id INT PRIMARY KEY AUTO_INCREMENT,
        username VARCHAR(255) NOT NULL,
        password VARCHAR(255) NOT NULL,
        token VARCHAR(255) NOT NULL
    );

CREATE Table
    movies (
        id int AUTO_INCREMENT PRIMARY KEY,
        name VARCHAR(255),
        link VARCHAR(255),
        cost INT,
        hossz VARCHAR(255),
        token VARCHAR(255)
    );

DROP TABLE selected_movies;

CREATE Table
    selected_movies (
        movies_id INT AUTO_INCREMENT PRIMARY KEY,
        userId INT,
        username VARCHAR(255),
        movie_selected VARCHAR(255),
        movie_selected_link VARCHAR(255),
        token VARCHAR(255)
    );


INSERT INTO
    users (username, password)
VALUES ('admin', 'admin'), ('maci', 'laci');

SELECT * FROM votes;

SELECT * FROM users;

INSERT INTO
    users (username, password)
VALUES ('user1', 'password1'), ('user2', 'password2'), ('user3', 'password3');

INSERT INTO
    movies (name, link, cost, hossz)
VALUES (
        'Madagaszkár 1',
        'https://magadaszkar/1',
        '1000',
        '1'
    ), (
        'Madagaszkár 2',
        'https://magadaszkar/2',
        '1000',
        '2'
    ), (
        'John Vick',
        'https://johnvick',
        '1000',
        '1'
    ), (
        'Breaking Bad',
        'https://breakingbad',
        '1000',
        '2'
    ), (
        'Lego Movie',
        'https://legomovie',
        '1000',
        '2'
    ), (
        'The Maze',
        'https://themaze',
        '1000',
        '2'
    );