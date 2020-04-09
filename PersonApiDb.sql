-- --------------------------------------------------------
-- Host:                         localhost,1433
-- Server version:               Microsoft SQL Server 2019 (RTM-CU3) (KB4538853) - 15.0.4023.6
-- Server OS:                    Linux (Ubuntu 18.04.4 LTS) <X64>
-- HeidiSQL Version:             9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES  */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for People
CREATE DATABASE IF NOT EXISTS "People";
USE "People";

-- Dumping structure for table People.Groups
CREATE TABLE IF NOT EXISTS "Groups" (
	"Id" INT(10,0) NOT NULL,
	"Name" NVARCHAR(max) NOT NULL,
	"CreationDate" DATETIME2(7) NOT NULL DEFAULT (getdate()),
	PRIMARY KEY ("Id")
);

-- Dumping data for table People.Groups: -1 rows
/*!40000 ALTER TABLE "Groups" DISABLE KEYS */;
INSERT INTO "Groups" ("Id", "Name", "CreationDate") VALUES
	(1, 'Nurse', '2020-04-09 09:07:08.9100000'),
	(2, 'Doctor', '2020-04-09 09:07:08.9133333'),
	(3, 'Biologist', '2020-04-09 09:07:08.9166667');
/*!40000 ALTER TABLE "Groups" ENABLE KEYS */;

-- Dumping structure for table People.Persons
CREATE TABLE IF NOT EXISTS "Persons" (
	"Id" NVARCHAR(450) NOT NULL,
	"Name" NVARCHAR(450) NOT NULL,
	"GroupId" INT(10,0) NOT NULL,
	"CreationDate" DATETIME2(7) NOT NULL DEFAULT (getdate()),
	PRIMARY KEY ("Id")
);

-- Dumping data for table People.Persons: -1 rows
/*!40000 ALTER TABLE "Persons" DISABLE KEYS */;
INSERT INTO "Persons" ("Id", "Name", "GroupId", "CreationDate") VALUES
	('384b1855-c8e4-4641-a570-1a0dc6a08fe2', 'Henry Gray', 2, '2020-04-09 09:07:08.9266667'),
	('43a2abde-1902-4db6-96a4-0c6e9ad198cd', 'Florence Nightingale', 1, '2020-04-09 09:07:08.9266667'),
	('95119dc4-816c-4213-b86b-56c13045c22e', 'Walt Whitman', 1, '2020-04-09 09:07:08.9266667'),
	('af2bdcf0-7bc3-420d-b06f-9e780aaf01d0', 'Joseph Lister', 2, '2020-04-09 09:07:08.9266667'),
	('b7236db2-9513-4442-8fcb-fee7dead1aac', 'Alexander Fleming', 3, '2020-04-09 09:07:08.9266667');
/*!40000 ALTER TABLE "Persons" ENABLE KEYS */;

-- Dumping structure for table People.__EFMigrationsHistory
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
	"MigrationId" NVARCHAR(150) NOT NULL,
	"ProductVersion" NVARCHAR(32) NOT NULL,
	PRIMARY KEY ("MigrationId")
);

-- Dumping data for table People.__EFMigrationsHistory: -1 rows
/*!40000 ALTER TABLE "__EFMigrationsHistory" DISABLE KEYS */;
INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES
	('20200409090530_InitialMigrations', '3.1.3'),
	('20200409090609_Seeding', '3.1.3');
/*!40000 ALTER TABLE "__EFMigrationsHistory" ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
