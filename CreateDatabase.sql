# Alex Dixon, McKinsey Wilson, Ethen Holzapfel
# CSC 440 - Applied Software Engineering
# Team Project - Tutor Scheduler
# October 12, 2019


CREATE DATABASE IF NOT EXISTS `tutorscheduler`;

USE `tutorscheduler`;

CREATE TABLE IF NOT EXISTS `StudentWorker` (
	`studentID` INT PRIMARY KEY,
	`studentName` VARCHAR(255),
	`displayColor` INT,
	`jobPosition` VARCHAR(50)
);
	
CREATE TABLE IF NOT EXISTS `Manager` (
	`managerID` INT AUTO_INCREMENT PRIMARY KEY,
	`managerName` VARCHAR(255),
	`email` VARCHAR(320),
	`pword` VARCHAR(60),
	CONSTRAINT `unique_email` UNIQUE (email)
);
	
CREATE TABLE IF NOT EXISTS `ScheduleEvent` (
	`eventID` INT AUTO_INCREMENT PRIMARY KEY,
	`studentID` INT,
	`eventType` INT,
	`startHour` INT,
	`startMinute` INT,
	`endHour` INT,
	`endMinute` INT,
	`monday` TINYINT(1),
	`tuesday` TINYINT(1),
	`wednesday` TINYINT(1),
	`thursday` TINYINT(1),
	`friday` TINYINT(1),
	CONSTRAINT `ScheduleEvent_StudentWorker_fk` FOREIGN KEY (`studentID`) REFERENCES `StudentWorker` (`studentID`)
);
	
CREATE TABLE `Subject` (
	`subjectID` INT AUTO_INCREMENT PRIMARY KEY,
	`abbreviation` VARCHAR(10),
	`subNum` INT,
	`subName` VARCHAR(255)
);
	
CREATE TABLE `SubjectTutored` (
	`subjectID` INT,
	`studentID` INT,
	CONSTRAINT `subject_tutored_pk` PRIMARY KEY (`subjectID`, `studentID`)
);
