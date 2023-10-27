-- Active: 1695968358990@@127.0.0.1@3306@test

CREATE TABLE TempData (Val INT);
INSERT INTO TempData (Val) VALUES (10), (20), (30), (40), (50);
DROP TABLE TempData;
SELECT * FROM TempData;


create procedure tombfeltolt(length int)
BEGIN
    Declare hossz int;
    create table IF NOT EXISTS tomb (value int);
    delete from tomb;
    set hossz = length;
    WHILE hossz > 0 DO
    insert into tomb values (ROUND(RAND()*100));
    SET hossz = hossz - 1;
END WHILE;  
END;
DELIMITER ;

DELIMITER//

create function osszegzes()
RETURNS int DETERMINISTIC
BEGIN
    DECLARE osszeg int default 0; 
    DECLARE elem int;
    DECLARE done INT DEFAULT FALSE;
    DECLARE cur1 CURSOR FOR SELECT * from tomb;                   
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
    OPEN cur1;
    read_loop: LOOP
    FETCH cur1 into elem; 
        set osszeg = osszeg+elem; 
        IF done THEN
        LEAVE read_loop;
        END IF;
    END LOOP;
    CLOSE cur1;
Return osszeg;
END;
DELIMITER;
call tombfeltolt(10);


--Összegzés
DELIMITER //
CREATE PROCEDURE CalculateSum()
BEGIN
    DECLARE total INT;
    DECLARE i INT;

    SET i = 1;
    SET total = 0;
    WHILE i <= (SELECT COUNT(*) FROM Tempdata) DO
        SET total = total + (SELECT Val FROM Tempdata WHERE ID = 1);
        SET i = i + 1;
    END WHILE;
    SELECT total as Total;
END;
//
DELIMITER ;
DROP PROCEDURE CalculateSum;
CALL CalculateSum();

--Megszámlálás
DELIMITER //
CREATE PROCEDURE CountProcedure()
BEGIN
    DECLARE i INT;
    
    SET i = 0;
    
    WHILE i < (SELECT COUNT(*) FROM Tempdata) DO
        SET i = i+1;
    END WHILE;
    
    SELECT i AS 'LENGTH';
END;
//
DELIMITER ;
DROP PROCEDURE CountProcedure;
CALL CountProcedure();

--Min
DELIMITER //
CREATE Procedure Minimum()
BEGIN
    DECLARE minint INT;
    DECLARE i INT;
    DECLARE b INT;
    SET i = 1;
    SET minint = (SELECT Val FROM Tempdata LIMIT 0, 1);
    
    WHILE i < (SELECT COUNT(*) FROM Tempdata) DO
        SET b = (SELECT Val FROM Tempdata LIMIT i, 1);
        IF b < minint THEN
            SET minint = b;
        END IF;
        SET i = i + 1;
    END WHILE;

    SELECT minint AS Minimum;
END;
//
DELIMITER;
DROP PROCEDURE Minimum;
CALL Minimum();

--Max
DELIMITER //
CREATE Procedure Maximum()
BEGIN
    DECLARE maxint INT;
    DECLARE i INT;
    DECLARE b INT;
    SET i = 1;
    SET maxint = (SELECT Val FROM Tempdata LIMIT 0, 1);
    
    WHILE i < (SELECT COUNT(*) FROM Tempdata) DO
        SET b = (SELECT Val FROM Tempdata LIMIT i, 1);
        IF b > maxint THEN
            SET maxint = b;
        END IF;
        SET i = i + 1;
    END WHILE;

    SELECT maxint AS Maximum;
END;
//
DELIMITER;
DROP PROCEDURE Maximum;
call Maximum();


--Lineáris kersés
DELIMITER //
CREATE PROCEDURE Linear_search(keresett int)
BEGIN
    DECLARE index_of INT;
    DECLARE i INT;
    declare b int;
    SET index_of = -1;
    SET i = 0;
    lab: WHILE i < (SELECT COUNT(*) FROM TempData) DO
        SET b = (SELECT Val FROM TempData Limit i, 1);
        IF b = keresett THEN
            SET index_of = i;
            LEAVE lab;
        END IF;
        SET i = i + 1;
    END WHILE lab;
    SELECT index_of as 'Keresett ertek indexe';
END;
//
DELIMITER ;
DROP PROCEDURE Linear_search;
CALL Linear_search(20);



----------------------------------------------------------------
DELIMITER //

CREATE PROCEDURE AddProduct(
    p_product_name VARCHAR(255),
    p_price DECIMAL(10, 2),
    p_description TEXT
)
BEGIN
    INSERT INTO products (product_name, price, description)
    VALUES (p_product_name, p_price, p_description);
END;
//

DELIMITER ;
CALL AddProduct();
----------------------------------------------------------------
DELIMITER //

CREATE PROCEDURE UpdateProduct(
    p_product_id INT,
    p_product_name VARCHAR(255),
    p_price DECIMAL(10, 2),
    p_description TEXT
)
BEGIN
    UPDATE products
    SET product_name = p_product_name, price = p_price, description = p_description
    WHERE id = p_product_id;
END;
//

DELIMITER ;
CALL UpdateProduct();

----------------------------------------------------------------
DELIMITER //

CREATE PROCEDURE DeleteProduct(
    IN p_product_id INT
)
BEGIN
    DELETE FROM products
    WHERE id = p_product_id;
END;
//

DELIMITER ;
CALL DeleteProduct();

----------------------------------------------------------------
DELIMITER //

CREATE PROCEDURE GetProductDetails(
    IN p_product_id INT
)
BEGIN
    SELECT product_name, price, description
    FROM products
    WHERE id = p_product_id;
END;
//

DELIMITER ;
CALL GetProductDetails();

----------------------------------------------------------------
DELIMITER //

CREATE PROCEDURE GetAllProducts()
BEGIN
    SELECT id, product_name, price, description
    FROM products;
END;
//

DELIMITER ;
CALL GetAllProducts();
