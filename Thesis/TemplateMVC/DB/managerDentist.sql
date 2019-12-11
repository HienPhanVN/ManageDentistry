DROP DATABASE IF EXISTS `managerdentist`;
CREATE DATABASE IF NOT EXISTS `managerdentist`;
USE `managerdentist`;

CREATE TABLE IF NOT EXISTS `managerdentist`.`tier` (
  `id_tier` INT NOT NULL AUTO_INCREMENT,
  `name_tier` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_tier`));

SET FOREIGN_KEY_CHECKS=0;
TRUNCATE TABLE `managerdentist`.`tier`;
INSERT INTO `managerdentist`.`tier`(name_tier)
VALUES
	('Admin'),
	('Doctor'),
	('Secretary'),
	('Patient');
SET FOREIGN_KEY_CHECKS=1;

CREATE TABLE IF NOT EXISTS `managerdentist`.`user` (
  `id_user` INT NOT NULL AUTO_INCREMENT,
  `name_user` VARCHAR(45) NOT NULL,
  `phone_user` VARCHAR(45) NULL,
  `address_user` VARCHAR(45) NULL,
  `email_user` VARCHAR(45) NULL,
  `id_tier` INT NOT NULL,
  PRIMARY KEY (`id_user`));

ALTER TABLE `managerdentist`.`user` 
ADD CONSTRAINT `fk_tier_user`
  FOREIGN KEY (`id_tier`)
  REFERENCES `managerdentist`.`tier` (`id_tier`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;


SET FOREIGN_KEY_CHECKS=0;
TRUNCATE TABLE `managerdentist`.`user`;

INSERT INTO `managerdentist`.`user`(name_user, phone_user, address_user, email_user, id_tier)
VALUES
	('Doctor 1', '0001', 'address doctor 1', 'doctor0001@mail.com.vn', 2),
    ('Doctor 2', '0002', 'address doctor 2', 'doctor0002@mail.com.vn', 2),
    ('Doctor 3', '0003', 'address doctor 3', 'doctor0003@mail.com.vn', 2),
	('Doctor 4', '0004', 'address doctor 4', 'doctor0004@mail.com.vn', 2),
    ('Doctor 5', '0005', 'address doctor 5', 'doctor0005@mail.com.vn', 2),
    ('Doctor 6', '0006', 'address doctor 6', 'doctor0006@mail.com.vn', 2),
    ('Doctor 7', '0007', 'address doctor 7', 'doctor0007@mail.com.vn', 2),
    ('Doctor 8', '0008', 'address doctor 8', 'doctor0008@mail.com.vn', 2),
    ('Doctor 9', '0009', 'address doctor 9', 'doctor0009@mail.com.vn', 2),
	('Doctor 10', '0010', 'address doctor 10', 'doctor0010@mail.com.vn', 2),
    ('Doctor 11', '0011', 'address doctor 11', 'doctor0011@mail.com.vn', 2),
    ('Doctor 12', '0012', 'address doctor 12', 'doctor0012@mail.com.vn', 2),
    ('Secretary 1', '0001', 'address secretary 1', 'secretary0001@mail.com.vn', 3),
    ('Secretary 2', '0002', 'address secretary 2', 'secretary0002@mail.com.vn', 3),    
    ('Secretary 3', '0003', 'address secretary 3', 'secretary0003@mail.com.vn', 3),
	('Patient 1', '0001', 'address patient 1', 'patient0001@mail.com.vn', 4),
	('Patient 2', '0002', 'address patient 2', 'patient0002@mail.com.vn', 4),
	('Patient 3', '0003', 'address patient 3', 'patient0003@mail.com.vn', 4),
	('Patient 4', '0004', 'address patient 4', 'patient0004@mail.com.vn', 4),
	('Patient 5', '0005', 'address patient 5', 'patient0005@mail.com.vn', 4),
	('Patient 6', '0006', 'address patient 6', 'patient0006@mail.com.vn', 4),
	('Patient 7', '0007', 'address patient 7', 'patient0007@mail.com.vn', 4),
	('Patient 8', '0008', 'address patient 8', 'patient0008@mail.com.vn', 4),
	('Patient 9', '0009', 'address patient 9', 'patient0009@mail.com.vn', 4),
	('Patient 10', '0010', 'address patient 10', 'patient0010@mail.com.vn', 4),
	('Patient 11', '0011', 'address patient 11', 'patient0011@mail.com.vn', 4),
	('Patient 12', '0012', 'address patient 12', 'patient0012@mail.com.vn', 4),
	('Admin', '0005', 'address admin 5', 'admin0005@mail.com.vn', 1),
    ('Unknow', '0006', 'address Unknow 6', 'Unknow06@mail.com.vn', 2);
    

SET FOREIGN_KEY_CHECKS=1;    
    
CREATE TABLE IF NOT EXISTS `managerdentist`.`account` (
  `id_account` INT NOT NULL AUTO_INCREMENT,
  `username_account` VARCHAR(45) NOT NULL,
  `password_account` VARCHAR(45) NOT NULL,
  `id_user` INT NOT NULL,
  PRIMARY KEY (`id_account`),
  UNIQUE INDEX `username_UNIQUE` (`username_account` ASC),
  UNIQUE INDEX `id_user_UNIQUE` (`id_user` ASC),
  CONSTRAINT `fk_user_account`
    FOREIGN KEY (`id_user`)
    REFERENCES `managerdentist`.`user` (`id_user`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);
    
    
SET FOREIGN_KEY_CHECKS=0;
TRUNCATE TABLE `managerdentist`.`account`;
INSERT INTO `managerdentist`.`account`(username_account, password_account, id_user)
VALUES	
    ('username 1', 'password 1', 1),
	('username 2', 'password 2', 2),
    ('username 3', 'password 3', 3),
	('username 4', 'password 4', 4),
    ('username 5', 'password 5', 5),
	('username 6', 'password 6', 6),
    ('username 7', 'password 7', 7),
	('username 8', 'password 8', 8),
    ('username 9', 'password 9', 9),
    ('username 10', 'password 10', 10);
SET FOREIGN_KEY_CHECKS=1;
    
CREATE TABLE IF NOT EXISTS `managerdentist`.`company` (
  `id_company` INT NOT NULL AUTO_INCREMENT,
  `name_company` VARCHAR(45) NOT NULL,
  `address_company` VARCHAR(45) NULL,
  `phone_company` VARCHAR(45) NULL,
  `email_company` VARCHAR(45) NULL,
  PRIMARY KEY (`id_company`));

SET FOREIGN_KEY_CHECKS=0;
TRUNCATE TABLE `managerdentist`.`company`;
INSERT INTO `managerdentist`.`company`(name_company, address_company, phone_company, email_company)
VALUES
	('name_company 1', 'address_company 1', "0001", 'email_company0001@mail.com.vn'),
	('name_company 2', 'address_company 2', "0002", 'email_company0002@mail.com.vn'),
    ('name_company 3', 'address_company 3', "0003", 'email_company0003@mail.com.vn'),
	('name_company 4', 'address_company 4', "0004", 'email_company0004@mail.com.vn'),
    ('name_company 5', 'address_company 5', "0005", 'email_company0005@mail.com.vn'),
	('name_company 6', 'address_company 6', "0006", 'email_company0006@mail.com.vn'),
    ('name_company 7', 'address_company 7', "0007", 'email_company0007@mail.com.vn'),
	('name_company 8', 'address_company 8', "0008", 'email_company0008@mail.com.vn'),
    ('name_company 9', 'address_company 9', "0009", 'email_company0009@mail.com.vn'),
    ('name_company 10', 'address_company 10', "0010", 'email_company0010@mail.com.vn');
SET FOREIGN_KEY_CHECKS=1;


CREATE TABLE IF NOT EXISTS `managerdentist`.`category` (
  `id_category` INT NOT NULL AUTO_INCREMENT,
  `name_category` VARCHAR(45) NULL,
  PRIMARY KEY (`id_category`));
  
  SET FOREIGN_KEY_CHECKS=0;
TRUNCATE TABLE `managerdentist`.`category`;
INSERT INTO `managerdentist`.`category`(name_category)
VALUES	
    ('name_category 1'),
	('name_category 2'),
    ('name_category 3'),
	('name_category 4'),
    ('name_category 5'),
	('name_category 6'),
    ('name_category 7'),
	('name_category 8'),
    ('name_category 9'),
    ('name_category 10');
SET FOREIGN_KEY_CHECKS=1;
  
  CREATE TABLE IF NOT EXISTS `managerdentist`.`bill` (
  `id_bill` INT NOT NULL AUTO_INCREMENT,
  `status_bill` VARCHAR(45) NULL,
  `dayCreate_bill` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  `note_bill` VARCHAR(200) NULL,
  `price_bill` DOUBLE NULL,
  `debt_bill` DOUBLE NULL,
  PRIMARY KEY (`id_bill`));
  
SET FOREIGN_KEY_CHECKS=0;
TRUNCATE TABLE `managerdentist`.`bill`;
INSERT INTO `managerdentist`.`bill`(status_bill, note_bill, price_bill, debt_bill)
VALUES	
    ('status_bill 1', 'note_bill 1', 01.01, 01.01),
	('status_bill 2', 'note_bill 2', 01.02, 01.02),
    ('status_bill 3', 'note_bill 3', 01.03, 01.03),
	('status_bill 4', 'note_bill 4', 01.04, 01.04),
    ('status_bill 5', 'note_bill 5', 01.05, 01.05),
	('status_bill 6', 'note_bill 6', 01.06, 01.06),
    ('status_bill 7', 'note_bill 7', 01.07, 01.07),
	('status_bill 8', 'note_bill 8', 01.08, 01.08),
    ('status_bill 9', 'note_bill 9', 01.09, 01.09),
    ('status_bill 10', 'note_bill 10', 01.10, 01.10);
SET FOREIGN_KEY_CHECKS=1;
  
  CREATE TABLE IF NOT EXISTS `managerdentist`.`product` (
  `id_product` INT NOT NULL AUTO_INCREMENT,
  `name_product` VARCHAR(45) NULL,
  `price_product` DOUBLE NULL,
  `note_product` VARCHAR(200) NULL,
  `id_company` INT NOT NULL,
  `id_category` INT NOT NULL,
  `id_bill` INT NOT NULL,
  PRIMARY KEY (`id_product`),
  UNIQUE INDEX `id_company_UNIQUE` (`id_company` ASC),
  UNIQUE INDEX `id_category_UNIQUE` (`id_category` ASC),
  UNIQUE INDEX `id_bill_UNIQUE` (`id_bill` ASC),
  CONSTRAINT `fk_company_product`
    FOREIGN KEY (`id_company`)
    REFERENCES `managerdentist`.`company` (`id_company`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_category_product`
    FOREIGN KEY (`id_category`)
    REFERENCES `managerdentist`.`category` (`id_category`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_bill_product`
    FOREIGN KEY (`id_bill`)
    REFERENCES `managerdentist`.`bill` (`id_bill`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);
    
SET FOREIGN_KEY_CHECKS=0;
TRUNCATE TABLE `managerdentist`.`product`;
INSERT INTO `managerdentist`.`product`(name_product, price_product, note_product, id_company, id_category, id_bill)
VALUES	
    ('name_product 1', 01.01, 'note_product 1', 1, 1, 1),
	('name_product 2', 01.02, 'note_product 2', 2, 2, 2),
    ('name_product 3', 01.03, 'note_product 3', 3, 3, 3),
	('name_product 4', 01.04, 'note_product 4', 4, 4, 4),
    ('name_product 5', 01.05, 'note_product 5', 5, 5, 5),
	('name_product 6', 01.06, 'note_product 6', 6, 6, 6),
    ('name_product 7', 01.07, 'note_product 7', 7, 7, 7),
	('name_product 8', 01.08, 'note_product 8', 8, 8, 8),
    ('name_product 9', 01.09, 'note_product 9', 9, 9, 9),
    ('name_product 10', 01.10, 'note_product 10', 10, 10, 10);
SET FOREIGN_KEY_CHECKS=1;
      
    
    CREATE TABLE IF NOT EXISTS `managerdentist`.`historyproduct` (
  `id_historyProduct` INT NOT NULL AUTO_INCREMENT,
  `dayUpdate_historyProduct` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  `id_product` INT NOT NULL,
  PRIMARY KEY (`id_historyProduct`),
  UNIQUE INDEX `id_product_UNIQUE` (`id_product` ASC),
  CONSTRAINT `fk_product_historyProduct`
    FOREIGN KEY (`id_product`)
    REFERENCES `managerdentist`.`product` (`id_product`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);

SET FOREIGN_KEY_CHECKS=0;
TRUNCATE TABLE `managerdentist`.`historyproduct`;
INSERT INTO `managerdentist`.`historyproduct`(id_product)
VALUES	
    (1),
	(2),
    (3),
	(4),
    (5),
	(6),
    (7),
	(8),
    (9),
    (10);
SET FOREIGN_KEY_CHECKS=1;


CREATE TABLE IF NOT EXISTS `managerdentist`.`ill` (
  `id_ill` INT NOT NULL AUTO_INCREMENT,
  `name_ill` VARCHAR(45) NULL,
  `status_ill` VARCHAR(45) NULL,
  `id_user` INT NOT NULL,
  PRIMARY KEY (`id_ill`),
  UNIQUE INDEX `id_user_UNIQUE` (`id_user` ASC),
  CONSTRAINT `fk_user_ill`
    FOREIGN KEY (`id_user`)
    REFERENCES `managerdentist`.`user` (`id_user`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);
    
SET FOREIGN_KEY_CHECKS=0;
TRUNCATE TABLE `managerdentist`.`ill`;
INSERT INTO `managerdentist`.`ill`(name_ill, status_ill, id_user)
VALUES
	('R11', 'status_ill 1', 1),
	('R12', 'status_ill 2', 2),
    ('R23', 'status_ill 3', 3),
	('name_ill 4', 'status_ill 4', 4),
    ('name_ill 5', 'status_ill 5', 5),
	('name_ill 6', 'status_ill 6', 6),
    ('name_ill 7', 'status_ill 7', 7),
	('name_ill 8', 'status_ill 8', 8),
    ('name_ill 9', 'status_ill 9', 9),
    ('name_ill 10', 'status_ill 10', 10);
SET FOREIGN_KEY_CHECKS=1;
    
CREATE TABLE IF NOT EXISTS `managerdentist`.`historyill` (
  `id_historyIll` INT NOT NULL AUTO_INCREMENT,
  `dayUpdate_historyIll` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  `id_ill` INT NOT NULL,
  PRIMARY KEY (`id_historyIll`),
  UNIQUE INDEX `id_ill_UNIQUE` (`id_ill` ASC),
  CONSTRAINT `fk_ill_historyIll`
    FOREIGN KEY (`id_ill`)
    REFERENCES `managerdentist`.`ill` (`id_ill`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);
    
SET FOREIGN_KEY_CHECKS=0;
TRUNCATE TABLE `managerdentist`.`historyill`;
INSERT INTO `managerdentist`.`historyill`(id_ill)
VALUES	
    (1),
	(2),
    (3),
	(4),
    (5),
	(6),
    (7),
	(8),
    (9),
    (10);
SET FOREIGN_KEY_CHECKS=1;

ALTER TABLE `managerdentist`.`product` 
DROP FOREIGN KEY `fk_bill_product`;
ALTER TABLE `managerdentist`.`product` 
CHANGE COLUMN `id_bill` `id_bill` INT(11) NULL ,
DROP INDEX `id_bill_UNIQUE` ;
;
ALTER TABLE `managerdentist`.`product` 
ADD CONSTRAINT `fk_bill_product`
  FOREIGN KEY (`id_bill`)
  REFERENCES `managerdentist`.`bill` (`id_bill`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;
  
-- 	edit
SET FOREIGN_KEY_CHECKS=0;
ALTER TABLE `managerdentist`.`historyill` 
ADD COLUMN `id_user` INT NOT NULL AFTER `id_ill`,
ADD INDEX `fk_user_historyIll_idx` (`id_user` ASC);
;
ALTER TABLE `managerdentist`.`historyill` 
ADD CONSTRAINT `fk_user_historyIll`
  FOREIGN KEY (`id_user`)
  REFERENCES `managerdentist`.`user` (`id_user`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;

UPDATE `managerdentist`.`historyill` SET `id_user` = '1' WHERE (`id_historyIll` = '1');
UPDATE `managerdentist`.`historyill` SET `id_user` = '2' WHERE (`id_historyIll` = '2');
UPDATE `managerdentist`.`historyill` SET `id_user` = '3' WHERE (`id_historyIll` = '3');
UPDATE `managerdentist`.`historyill` SET `id_user` = '1' WHERE (`id_historyIll` = '4');
UPDATE `managerdentist`.`historyill` SET `id_user` = '2' WHERE (`id_historyIll` = '5');
UPDATE `managerdentist`.`historyill` SET `id_user` = '3' WHERE (`id_historyIll` = '6');
UPDATE `managerdentist`.`historyill` SET `id_user` = '1' WHERE (`id_historyIll` = '7');
UPDATE `managerdentist`.`historyill` SET `id_user` = '2' WHERE (`id_historyIll` = '8');
UPDATE `managerdentist`.`historyill` SET `id_user` = '3' WHERE (`id_historyIll` = '9');
UPDATE `managerdentist`.`historyill` SET `id_user` = '1' WHERE (`id_historyIll` = '10');


ALTER TABLE `managerdentist`.`ill` 
DROP FOREIGN KEY `fk_user_ill`;
ALTER TABLE `managerdentist`.`ill` 
ADD COLUMN `id_user_doctor` INT(11) NOT NULL AFTER `id_user_patient`,
CHANGE COLUMN `id_user` `id_user_patient` INT(11) NOT NULL ,
ADD INDEX `fk_user_ill_idx` (`id_user_doctor` ASC);
;
ALTER TABLE `managerdentist`.`ill` 
ADD CONSTRAINT `fk_user_ill_patient`
  FOREIGN KEY (`id_user_patient`)
  REFERENCES `managerdentist`.`user` (`id_user`)
  ON DELETE CASCADE
  ON UPDATE CASCADE,
ADD CONSTRAINT `fk_user_ill_doctor`
  FOREIGN KEY (`id_user_doctor`)
  REFERENCES `managerdentist`.`user` (`id_user`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;


DELETE FROM `managerdentist`.`ill` WHERE (`id_ill` = '4');
DELETE FROM `managerdentist`.`ill` WHERE (`id_ill` = '5');
DELETE FROM `managerdentist`.`ill` WHERE (`id_ill` = '6');
DELETE FROM `managerdentist`.`ill` WHERE (`id_ill` = '7');
DELETE FROM `managerdentist`.`ill` WHERE (`id_ill` = '8');
DELETE FROM `managerdentist`.`ill` WHERE (`id_ill` = '9');
DELETE FROM `managerdentist`.`ill` WHERE (`id_ill` = '10');
UPDATE `managerdentist`.`ill` SET `id_user_patient` = '7', `id_user_doctor` = '1' WHERE (`id_ill` = '1');
UPDATE `managerdentist`.`ill` SET `id_user_patient` = '8', `id_user_doctor` = '2' WHERE (`id_ill` = '2');
UPDATE `managerdentist`.`ill` SET `id_user_patient` = '9', `id_user_doctor` = '3' WHERE (`id_ill` = '3');



SET FOREIGN_KEY_CHECKS=1;
-- end edit
        
DROP PROCEDURE IF EXISTS naiveSearchNameUser;    
DELIMITER //
    CREATE PROCEDURE naiveSearchNameUser(IN nameUser varchar(45)) 
	BEGIN     
		SELECT id_user, name_user, phone_user, address_user, email_user, managerdentist.user.id_tier, name_tier FROM managerdentist.user, managerdentist.tier WHERE name_user LIKE CONCAT('%', nameUser, '%') AND managerdentist.user.id_tier = managerdentist.tier.id_tier;
	END
   //
DELIMITER ;

-- CALL naiveSearchNameUser("name user 10");-- 

   