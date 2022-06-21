-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: prozesp2.czdgfvvhp5xb.us-east-1.rds.amazonaws.com    Database: ProZesp
-- ------------------------------------------------------
-- Server version	8.0.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
SET @MYSQLDUMP_TEMP_LOG_BIN = @@SESSION.SQL_LOG_BIN;
SET @@SESSION.SQL_LOG_BIN= 0;

--
-- GTID state at the beginning of the backup 
--

SET @@GLOBAL.GTID_PURGED=/*!80000 '+'*/ '';

--
-- Table structure for table `Wizyty`
--

DROP TABLE IF EXISTS `Wizyty`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Wizyty` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Data_utworzenia` datetime NOT NULL,
  `Data_wizyty` datetime NOT NULL,
  `Pacjent_ID` int NOT NULL,
  `Gabinet_ID` int NOT NULL,
  `Uzytkownik_ID` int NOT NULL,
  `Czas_trwania` int NOT NULL DEFAULT '30',
  `Organizacja_ID` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`),
  KEY `Wizyta-Pacjent_idx` (`Pacjent_ID`),
  KEY `Wizyta-Gabinet_idx` (`Gabinet_ID`),
  KEY `Wizyta-User_idx` (`Uzytkownik_ID`),
  KEY `wizyta-org_idx` (`Organizacja_ID`),
  CONSTRAINT `Wizyta-Gabinet` FOREIGN KEY (`Gabinet_ID`) REFERENCES `Gabinety` (`ID`),
  CONSTRAINT `Wizyta-Pacjent` FOREIGN KEY (`Pacjent_ID`) REFERENCES `Pacjenci` (`ID`),
  CONSTRAINT `Wizyta-User` FOREIGN KEY (`Uzytkownik_ID`) REFERENCES `Uzytkownicy` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Wizyty`
--

LOCK TABLES `Wizyty` WRITE;
/*!40000 ALTER TABLE `Wizyty` DISABLE KEYS */;
INSERT INTO `Wizyty` VALUES (20,'0001-01-01 00:00:00','2022-05-18 14:37:58',1,1,3,60,1),(21,'0001-01-01 00:00:00','2022-05-19 14:37:58',1,1,3,60,1),(22,'0001-01-01 00:00:00','2022-05-19 10:37:58',1,1,3,60,1),(23,'0001-01-01 00:00:00','2022-05-17 10:37:58',1,1,3,60,1),(24,'0001-01-01 00:00:00','2022-05-17 16:37:58',1,1,3,60,1),(25,'2022-05-20 15:52:59','2022-05-20 15:52:59',1,1,3,20,1),(26,'2022-05-20 15:52:59','2022-05-21 15:52:59',1,1,3,20,1),(27,'2022-05-20 15:52:59','2022-05-20 15:52:59',1,1,2,20,1),(29,'2022-05-26 13:00:00','2022-05-29 11:00:00',9,1,3,25,1),(30,'2022-05-26 12:00:00','2022-05-30 13:00:00',8,1,3,20,1),(31,'2022-06-01 08:00:00','2022-06-01 10:00:00',8,1,3,30,1),(32,'2022-06-01 08:00:00','2022-06-01 11:00:00',9,1,4,30,1),(39,'2022-06-10 16:38:44','2022-06-15 14:00:00',3,2,24,60,0),(40,'2022-06-11 06:53:30','2022-06-11 09:00:00',2,1,3,60,0),(41,'2022-06-11 07:11:05','2022-06-12 09:00:00',3,2,3,60,0),(42,'2022-06-11 07:50:50','2022-06-12 08:00:00',4,3,14,60,0),(46,'2022-06-13 17:12:13','2022-06-17 11:00:00',14,3,3,20,0);
/*!40000 ALTER TABLE `Wizyty` ENABLE KEYS */;
UNLOCK TABLES;
SET @@SESSION.SQL_LOG_BIN = @MYSQLDUMP_TEMP_LOG_BIN;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-06-21 22:42:50
