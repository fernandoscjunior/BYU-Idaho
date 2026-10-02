-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema art
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `art` ;

-- -----------------------------------------------------
-- Schema art
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `art` DEFAULT CHARACTER SET utf8mb3 ;
USE `art` ;

-- -----------------------------------------------------
-- Table `art`.`artists`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `art`.`artists` ;

CREATE TABLE IF NOT EXISTS `art`.`artists` (
  `artists_id` INT NOT NULL AUTO_INCREMENT,
  `first_name` VARCHAR(25) NOT NULL,
  `middle_name` VARCHAR(25) NULL DEFAULT NULL,
  `last_name` VARCHAR(30) NOT NULL,
  `country` VARCHAR(30) NOT NULL,
  `is_local` VARCHAR(1) NOT NULL,
  `dob` INT NOT NULL,
  `dod` INT NULL,
  PRIMARY KEY (`artists_id`, `is_local`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `art`.`artworks`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `art`.`artworks` ;

CREATE TABLE IF NOT EXISTS `art`.`artworks` (
  `artworks_id` INT NOT NULL AUTO_INCREMENT,
  `title` VARCHAR(35) NOT NULL,
  `year` INT NOT NULL,
  `type` VARCHAR(35) NOT NULL,
  `file` VARCHAR(45) NOT NULL,
  `artists_id` INT NOT NULL,
  `period` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`artworks_id`, `artists_id`),
  INDEX `fk_artworks_artists_idx` (`artists_id` ASC) VISIBLE,
  CONSTRAINT `fk_artworks_artists`
    FOREIGN KEY (`artists_id`)
    REFERENCES `art`.`artists` (`artists_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `art`.`keywords`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `art`.`keywords` ;

CREATE TABLE IF NOT EXISTS `art`.`keywords` (
  `keywords_id` INT NOT NULL AUTO_INCREMENT,
  `keyword` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`keywords_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `art`.`artworks_has_keywords`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `art`.`artworks_has_keywords` ;

CREATE TABLE IF NOT EXISTS `art`.`artworks_has_keywords` (
  `artworks_id` INT NOT NULL,
  `artists_id` INT NOT NULL,
  `keywords_id` INT NOT NULL,
  PRIMARY KEY (`artworks_id`, `artists_id`, `keywords_id`),
  INDEX `fk_artworks_has_keywords_keywords1_idx` (`keywords_id` ASC) VISIBLE,
  INDEX `fk_artworks_has_keywords_artworks1_idx` (`artworks_id` ASC, `artists_id` ASC) VISIBLE,
  CONSTRAINT `fk_artworks_has_keywords_artworks1`
    FOREIGN KEY (`artworks_id` , `artists_id`)
    REFERENCES `art`.`artworks` (`artworks_id` , `artists_id`),
  CONSTRAINT `fk_artworks_has_keywords_keywords1`
    FOREIGN KEY (`keywords_id`)
    REFERENCES `art`.`keywords` (`keywords_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `art`.`users`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `art`.`users` ;

CREATE TABLE IF NOT EXISTS `art`.`users` (
  `users_id` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(20) NOT NULL,
  `password` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`users_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- My Script --

USE art;

INSERT INTO artists (first_name, middle_name, last_name, country, is_local, dob, dod)
VALUES ('Vicent', NULL, 'Van Gogh', 'France', 'N', 1853, 1890),
	   ('Rembrandt', 'Harmenszoon', 'van Rijn', 'Netherlands', 'N', 1606, 1669),
	   ('Leonardo', NULL, 'Da Vinci', 'Italy', 'N', 1452, 1519),
       ('Venture', 'Lonzo', 'Coy', 'United States', 'Y', 1965, NULL),
       ('Debora', NULL, 'GIll', 'United States', 'Y', 1970, NULL),
       ('Claude', NULL, 'Monet', 'France', 'N', 1840, 1926),
       ('Pablo', NULL, 'Picasso', 'Spain', 'N', 1904, 1973),
       ('Michelangelo', 'di Lodovico', 'Simoni', 'Italy', 'N', 1475, 1564);
       
SELECT * FROM artists;

INSERT INTO artworks (title, year, type, file, artists_id, period)
VALUES ('Irises', 1889, 'Oil', 'irises.jpg', 1,'Impressionism'),
	   ('The Starry Night', 1889, 'Oil', 'starrynight.jpg', 1,'Post-impressionism'),
       ('Sunflowers', 1888, 'Oil', 'sunflowers.jpg', 1,'Post-impressionism'),
       ('Night Watch', 1642, 'Oil', 'nightwatch.jpg', 2,'Baroque'),
       ('Storm of The Sea of Galilee', 1633, 'Oil', 'stormgalilee.jpg', 2,'Dutch Golden Age'),
       ('Head of a Woman', 1508, 'Oil', 'headwoman.jpg', 3,'High Renaissance'),
       ('Last Supper', 1498, 'Tempra', 'lastsupper.jpg', 3,'Renaissance'),
       ('Mona Lisa', 1517, 'Oil', 'monalisa.jpg', 3,'Renaissance'),
       ('Hillside Stream', 2005, 'Oil', 'hillsidestream.jpg', 4,'Modern'),
       ('Old Barn', 1992, 'Oil', 'oldbarn.jpg', 4,'Modern'),
       ('Beach Baby', 1999, 'Watercolor', 'beachababy.jpg', 5,'Modern'),
       ('Women in the Garden', 1866, 'Oil', 'womengarden.jpg', 6,'Impressionism'),
       ('Old Guitarist', 1904, 'Oil', 'guitarist.jpg', 7,'Modern');

SELECT * FROM artworks;

INSERT INTO keywords (keyword)
VALUES ('Flowers'),
	   ('Blue'),
       ('Landscape'),
       ('Girl'),
       ('People'),
       ('Battle'),
       ('Boat'),
       ('Water'),
       ('Christ'),
       ('Food'),
       ('Baby');
       
SELECT * FROM keywords;