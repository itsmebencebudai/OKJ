create database kisállat
default character set utf8
collate utf8_hungarian_ci;

use kisállat; 

create table user (
    userid integer AUTO_INCREMENT PRIMARY KEY,
    name varchar(50) NOT NULL,
    email varchar(80) NOT NULL UNIQUE,
    password blob,
    address varchar(80) NOT NULL
);

CREATE TABLE pet (
	id integer AUTO_INCREMENT PRIMARY KEY,
    name varchar(30) NOT NULL UNIQUE,
    description varchar(100) NOT NULL,
    pries int NOT NULL,
    stock integer NOT NULL,
    picture varchar(100)
);

CREATE TABLE orders (
    orderid integer AUTO_INCREMENT PRIMARY KEY,
    userid int,
    date date NOT NULL DEFAULT CURRENT_TIMESTAMP,
    petid int,
    FOREIGN KEY (userid)
    	REFERENCES user(userid),
    FOREIGN KEY (petid)
    	REFERENCES pet(id)
);

DELIMITER //
CREATE TRIGGER Insert_User
BEFORE INSERT on user
for each ROW
BEGIN
	SET NEW.password = SHA2(NEW.password, 256);
END//
DELIMITER ;

DELIMITER //
CREATE PROCEDURE IsUserExists (IN username varchar(50), OUT van INT)
BEGIN
	DECLARE userCount INT;
    SELECT COUNT(*) INTO userCount FROM user WHERE name = username;
   	IF userCount > 0 THEN
    	SET van = 1;
    ELSE
    	SET van = 0;
    END IF;
END //
DELIMITER ;


INSERT INTO user (name,address,email,password) values
("Mekk Elek", "1112 Budapest Varjú u. 12", "mekk.elek@bolyai.hu","Titok123"),
("Gipsz Jakab", "1024 Budapest Gipsz u. 23", "gipsz.jakab@bolyai.hu","Titok123");

INSERT INTO pet (name,description,pries,stock,picture) values 
("Hörcsög", "Ez megrágcsál", 10500,5,"./picture/horcsog.jpg"),
("Tengeri Malac", "Tengeri röfi", 6300,3,"./picture/tmalac.jpg"),
("Madárpók", "Veszélyes madárpók", 80000,5,"./picture/madarpok.jpg"),
("Aranyhal", "Szép aranyhal", 3500,1,"./picture/aranyhal.jpg");