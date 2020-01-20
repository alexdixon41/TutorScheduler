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
	`username` VARCHAR(320),
	`pword` VARCHAR(60),
	CONSTRAINT `unique_user` UNIQUE (`username`)
);

CREATE TABLE IF NOT EXISTS `Schedule` (
	`ScheduleID` INT AUTO_INCREMENT PRIMARY KEY,
	`Name` VARCHAR(255));	
	
CREATE TABLE IF NOT EXISTS `StudentWorkerSchedule` (
	`StudentWorkerID` INT NOT NULL,
	`ScheduleID` INT NOT NULL,
	CONSTRAINT `SWSchedule_SW_fk` FOREIGN KEY (`StudentWorkerID`) REFERENCES `StudentWorker`(`studentID`),
	CONSTRAINT `SWSchedule_Schedule_fk` FOREIGN KEY (`ScheduleID`) REFERENCES `Schedule`(`ScheduleID`));
	
CREATE TABLE IF NOT EXISTS `CurrentSchedule` (
	`CurrentScheduleID` INT NOT NULL,
	`ScheduleID` INT NOT NULL,
	CONSTRAINT `Current_Schedule_fk` FOREIGN KEY (`ScheduleID`) REFERENCES `Schedule`(`ScheduleID`));
	
CREATE TABLE IF NOT EXISTS `EventDetails` (
	`EventDetailsID` INT AUTO_INCREMENT PRIMARY KEY,
	`EventName` VARCHAR(255)
);
	
CREATE TABLE IF NOT EXISTS `ScheduleEvent` (
	`eventID` INT AUTO_INCREMENT PRIMARY KEY,
	`studentID` INT,
	`eventType` INT,
	`startHour` INT,
	`startMinute` INT,
	`endHour` INT,
	`endMinute` INT,
	`day` INT,
	`Details` INT NOT NULL,
	`ScheduleID` INT NOT NULL,
	CONSTRAINT `ScheduleEvent_EventDetails_fk` FOREIGN KEY (`Details`) REFERENCES `EventDetails` (`EventDetailsID`),
	CONSTRAINT `ScheduleEvent_StudentWorker_fk` FOREIGN KEY (`studentID`) REFERENCES `StudentWorker` (`studentID`),
	CONSTRAINT `ScheduleEvent_Schedule_fk` FOREIGN KEY (`ScheduleID`) REFERENCES `Schedule` (`ScheduleID`)
);
	
CREATE TABLE IF NOT EXISTS `Subject` (
	`subjectID` INT AUTO_INCREMENT PRIMARY KEY,
	`abbreviation` VARCHAR(10),
	`subNum` VARCHAR(50),
	`subName` VARCHAR(255)
);
	
CREATE TABLE IF NOT EXISTS `SubjectTutored` (
	`subjectID` INT,
	`studentID` INT,
	CONSTRAINT `subject_tutored_pk` PRIMARY KEY (`subjectID`, `studentID`)
);

INSERT INTO `Manager` (`managerName`, `username`, `pword`)
VALUES ('Lara Vance', 'lara1', PASSWORD('password'));

INSERT INTO `Schedule` (`Name`)
VALUES ('Fall 2019');

INSERT INTO `CurrentSchedule` (`CurrentScheduleID`, `ScheduleID`)
VALUES (1, 1);
