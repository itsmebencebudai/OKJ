-- Active: 1708416626951@@127.0.0.1@3306@chat
create table IF NOT EXISTS user (
    userID int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(40) NOT NULL,
    email VARCHAR(50) NOT NULL,
    password BLOB not null,
    token BLOB
) Engine=Innodb;    

create table messages (
    messageID integer not null AUTO_INCREMENT PRIMARY KEY,
    userID integer not null,
    message TEXT,
    sendTime TIMESTAMP default CURRENT_TIMESTAMP,
    foreign key  (userID) REFERENCES user(userID)
);

ALTER TABLE user AUTO_INCREMENT=1;

INSERT INTO `user` VALUES
    (null,'Maci Laci','maci@laci.com','macika',null),
    (null,'Kiss Elemér','kiss.elemer@suli.com','kisselemer',null),
    (null,'Bukta János','bukta.janos@suli.com','buktajani',null);

CREATE TRIGGER insertUser BEFORE INSERT on user For Each Row
BEGIN
    SET NEW.password = sha2(NEW.password,256);
END;

CREATE PROCEDURE if not EXISTS userLogin(IN mail Varchar(50), pwd varchar(50))
BEGIN
    select userID, name, email from user  WHERE user.email = mail And user.password = SHA2(pwd,256);
END;
delimiter ;

CREATE PROCEDURE if not EXISTS userUpdateToken(IN id int, token Text)
BEGIN
    UPDATE user Set user.token = token where user.userID = id;     
END;

delimiter ;
CREATE PROCEDURE if not EXISTS getAllUserInfos(IN userID int)
BEGIN
    select * from user WHERE user.userID = userID;
END;

delimiter ;

CREATE PROCEDURE if not EXISTS getAllUserMessages(IN userID int)
BEGIN
    select message, sendTime from messages WHERE messages.userID = userID;
END;

delimiter ;
DROP Procedure `getAllMessages`;
CREATE PROCEDURE if not EXISTS getAllMessages()
BEGIN
    select messages.userID, message, sendTime, user.name from messages inner join user on user.`userID` = messages.`userID`;
END;

delimiter ;

DROP Procedure saveNewMessage;

CREATE PROCEDURE if not EXISTS saveNewMessage(IN message TEXT, userID int)
BEGIN
    insert into messages (messageID,messages.message, messages.userID) value (null,message, userID);     
END;

delimiter ;
call `saveNewMessage`('balablafdsgsdg', 2);
call `getAllUserMessages`(1);

call `getAllMessages`;

select * from user;

 select message, sendTime, user.name from messages inner join user on user.`userID` = messages.`userID`;