-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema university
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `university` ;

-- -----------------------------------------------------
-- Schema university
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `university` DEFAULT CHARACTER SET utf8 ;
USE `university` ;

-- -----------------------------------------------------
-- Table `university`.`college`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `university`.`college` ;

CREATE TABLE IF NOT EXISTS `university`.`college` (
  `college_id` INT NOT NULL,
  `college_name` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`college_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`department`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `university`.`department` ;

CREATE TABLE IF NOT EXISTS `university`.`department` (
  `department_id` INT NOT NULL,
  `department_name` VARCHAR(100) NOT NULL,
  `department_code` VARCHAR(45) NOT NULL,
  `college_id` INT NOT NULL,
  PRIMARY KEY (`department_id`, `college_id`),
  INDEX `fk_department_college1_idx` (`college_id` ASC) VISIBLE,
  CONSTRAINT `fk_department_college1`
    FOREIGN KEY (`college_id`)
    REFERENCES `university`.`college` (`college_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`course`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `university`.`course` ;

CREATE TABLE IF NOT EXISTS `university`.`course` (
  `course_id` INT NOT NULL,
  `course_title` VARCHAR(30) NOT NULL,
  `course_num` INT NOT NULL,
  `course_credit` INT NOT NULL,
  `department_id` INT NOT NULL,
  PRIMARY KEY (`course_id`, `department_id`),
  INDEX `fk_course_department1_idx` (`department_id` ASC) VISIBLE,
  CONSTRAINT `fk_course_department1`
    FOREIGN KEY (`department_id`)
    REFERENCES `university`.`department` (`department_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`faculty`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `university`.`faculty` ;

CREATE TABLE IF NOT EXISTS `university`.`faculty` (
  `faculty_id` INT NOT NULL,
  `faculty_fname` VARCHAR(45) NOT NULL,
  `faculty_lname` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`faculty_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`term`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `university`.`term` ;

CREATE TABLE IF NOT EXISTS `university`.`term` (
  `term_id` INT NOT NULL,
  `term_year` YEAR NOT NULL,
  `term_season` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`term_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`section`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `university`.`section` ;

CREATE TABLE IF NOT EXISTS `university`.`section` (
  `section_id` INT NOT NULL,
  `section_num` VARCHAR(45) NOT NULL,
  `faculty_id` INT NOT NULL,
  `course_id` INT NOT NULL,
  `term_id` INT NOT NULL,
  `capacity` INT NOT NULL,
  PRIMARY KEY (`section_id`, `faculty_id`, `course_id`, `term_id`),
  INDEX `fk_section_faculty1_idx` (`faculty_id` ASC) VISIBLE,
  INDEX `fk_section_course1_idx` (`course_id` ASC) VISIBLE,
  INDEX `fk_section_term1_idx` (`term_id` ASC) VISIBLE,
  CONSTRAINT `fk_section_faculty1`
    FOREIGN KEY (`faculty_id`)
    REFERENCES `university`.`faculty` (`faculty_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_section_course1`
    FOREIGN KEY (`course_id`)
    REFERENCES `university`.`course` (`course_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_section_term1`
    FOREIGN KEY (`term_id`)
    REFERENCES `university`.`term` (`term_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`student`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `university`.`student` ;

CREATE TABLE IF NOT EXISTS `university`.`student` (
  `student_id` INT NOT NULL,
  `fname` VARCHAR(30) NOT NULL,
  `lname` VARCHAR(45) NOT NULL,
  `city` VARCHAR(45) NOT NULL,
  `state` CHAR(2) NOT NULL,
  `gender` ENUM('F', 'M') NOT NULL,
  `dob` DATE NOT NULL,
  PRIMARY KEY (`student_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`enrollment`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `university`.`enrollment` ;

CREATE TABLE IF NOT EXISTS `university`.`enrollment` (
  `enrollment_id` INT NOT NULL,
  `student_id` INT NOT NULL,
  `section_id` INT NOT NULL,
  PRIMARY KEY (`enrollment_id`),
  INDEX `fk_student_has_course_student1_idx` (`student_id` ASC) VISIBLE,
  INDEX `fk_enrollment_section1_idx` (`section_id` ASC) VISIBLE,
  CONSTRAINT `fk_student_has_course_student1`
    FOREIGN KEY (`student_id`)
    REFERENCES `university`.`student` (`student_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_enrollment_section1`
    FOREIGN KEY (`section_id`)
    REFERENCES `university`.`section` (`section_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;


#INSERTs
-- Insert statements:
USE university;

INSERT INTO student
VALUES (1, 'Paul', 'Miller', 'Dallas', 'TX', 'M', '1996-02-22'),
	   (2, 'Katie', 'Smith', 'Provo', 'UT', 'F', '1995-07-22'),
       (3, 'Kelly', 'Jones', 'Provo', 'UT', 'F', '1998-06-22'),
       (4, 'Devon', 'Merril', 'Mesa', 'AZ', 'M', '2000-07-22'),
       (5, 'Mandy', 'Murdock', 'Topeka', 'KS', 'F', '1996-11-22'),
       (6, 'Alece', 'Adams', 'Rigby', 'ID', 'F', '1997-05-22'),
       (7, 'Bryce', 'Carlson', 'Bozeman', 'MT', 'M', '1997-11-22'),
       (8, 'Preston', 'Larsen', 'Decatur', 'TN', 'M', '1996-09-22'),
       (9, 'Julia', 'Madsen', 'Rexburg', 'ID', 'F', '1998-09-22'),
       (10, 'Susan', 'Sorensen', 'Mesa', 'AZ', 'F', '1998-08-09');

INSERT INTO college
VALUES (1, 'College of Physical Science and Engineering'),
	   (2, 'College of Business and Communication'),
       (3, 'College of Language and Letters');

INSERT INTO department
VALUES (1, 'Computer Information Technology', 'ITM', 1),
	   (2, 'Economics', 'ECON', 2),
       (3, 'Humanities and Philosophy', 'HUM', 3);
       
INSERT INTO course
VALUES (1, 'Intro to Databases', 111, 3, 1),
	   (2, 'Econometrics', 388, 4, 2), 
       (3, 'Micro Economics', 150, 3, 2), 
       (4, 'Classical Heritage', 376, 2, 3);
       
INSERT INTO term
VALUES (1, 2018, 'Winter'),
	   (2, 2019, 'Fall');
       
INSERT INTO faculty
VALUES (1, 'Marty ', 'Morring'),
	   (2, 'Nate', 'Norris'),
       (3, 'Ben', 'Barrus'),
       (4, 'John', 'Jensen'),
       (5, 'Bill', 'Barney');

INSERT INTO section
VALUES (1, '1', 1, 1, 2, 30),
	   (2, '1', 2, 3, 2, 50),
       (3, '2', 2, 3, 2, 50),
       (4, '1', 3, 2, 2, 35),
       (5, '1', 4, 4, 2, 30),
       (6, '2', 1, 1, 1, 30),
       (7, '3', 3, 1, 1, 35),
       (8, '1', 2, 3, 1, 50),
       (9, '2', 2, 3, 1, 50),
       (10, '1', 4, 4, 1, 30);
       
INSERT INTO enrollment
VALUES (1, 6, 7),
	   (2, 7, 6),
       (3, 7, 8),
       (4, 7, 10),
       (5, 4, 5),
       (6, 9, 9),
       (7, 2, 4),
       (8, 3, 4),
       (9, 5, 4),
       (10, 5, 5),
       (11, 1, 1),
       (12, 1, 3),
       (13, 8, 9),
       (14, 10, 6);
       
#Queries
-- First query:
SELECT fname, lname, DATE_FORMAT(dob, '%M %d, %Y') AS 'Sept Birthdays'
FROM student
WHERE MONTH(dob) = 9
ORDER BY lname;

-- Second query
SELECT lname, fname, FLOOR(DATEDIFF('2017-01-05', dob) / 365) AS 'age', DATEDIFF('2017-01-05', dob) % 365 AS 'days', 
CONCAT(FLOOR(DATEDIFF('2017-01-05', dob) / 365), ' Yrs, ', DATEDIFF('2017-01-05', dob) % 365, ' - Days') AS 'Years and Days'
FROM student
ORDER BY dob;

-- Third query
SELECT fname, lname
FROM student s
	JOIN enrollment e
    ON s.student_id = e.student_id
    JOIN section sec
    ON e.section_id = sec.section_id
WHERE faculty_id = 4
ORDER BY lname;

-- Fourth query
SELECT faculty_fname, faculty_lname 
FROM student s
	JOIN enrollment e
    ON s.student_id = e.student_id
    JOIN section sec
    ON e.section_id = sec.section_id
    JOIN faculty f
    ON sec.faculty_id = f.faculty_id
WHERE fname = 'Bryce' AND term_id = 1
ORDER BY faculty_lname;

-- Fifth query
SELECT fname, lname
FROM student s
	JOIN enrollment e
    ON s.student_id = e.student_id
    JOIN section sec
    ON e.section_id = sec.section_id
    JOIN course c
    ON sec.course_id = c.course_id
WHERE course_title = 'Econometrics'
ORDER BY lname;

-- Sixth query
SELECT department_code, course_num, course_title AS 'name'
FROM student s
	JOIN enrollment e
    ON s.student_id = e.student_id
    JOIN section sec
    ON e.section_id = sec.section_id
    JOIN course c
    ON sec.course_id = c.course_id
    JOIN department d
    ON c.department_id = d.department_id
WHERE fname = 'Bryce' AND term_id = 1
ORDER BY course_title;

-- Seventh query
SELECT term_season AS 'term', term_year AS 'year', COUNT(s.student_id) AS 'Enrollment'
FROM student s
	JOIN enrollment e
    ON s.student_id = e.student_id
    JOIN section sec
    ON e.section_id = sec.section_id
    JOIN term t
    ON sec.term_id = t.term_id
WHERE t.term_id = 2;

-- Eighth query
SELECT college_name AS 'Colleges', COUNT(course_title) AS 'Courses'
FROM course c
	JOIN department d
	ON c.department_id = d.department_id
    JOIN college co
    ON d.college_id = co.college_id
GROUP BY college_name
ORDER BY college_name;

-- Nineth query
SELECT faculty_fname AS 'fname', faculty_lname AS 'lname', SUM(capacity) AS 'TeachingCapacity'
FROM section s
	JOIN faculty f
    ON s.faculty_id = f.faculty_id
WHERE term_id = 1
GROUP BY faculty_fname, faculty_lname
ORDER BY SUM(capacity);

-- Tenth query
SELECT lname, fname, SUM(course_credit) AS 'Credits'
FROM student s
	JOIN enrollment e
    ON s.student_id = e.student_id
    JOIN section sec
    ON e.section_id = sec.section_id
    JOIN course c
    ON sec.course_id = c.course_id
WHERE term_id = 2
GROUP BY lname, fname
HAVING SUM(course_credit) > 3
ORDER BY SUM(course_credit) DESC;

