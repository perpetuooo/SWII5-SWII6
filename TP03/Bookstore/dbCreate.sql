CREATE DATABASE Bookstore;
USE Bookstore;
 
CREATE TABLE `book` (
  `book_id` INT(11) NOT NULL AUTO_INCREMENT,
  `title` VARCHAR(128) NOT NULL,
  `author` VARCHAR(45) NOT NULL,
  `price` DECIMAL(10, 2) NOT NULL,
  PRIMARY KEY (`book_id`),
  UNIQUE KEY `title_UNIQUE` (`title`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4;
