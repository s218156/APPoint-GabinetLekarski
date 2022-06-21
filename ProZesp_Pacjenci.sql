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
-- Table structure for table `Pacjenci`
--

DROP TABLE IF EXISTS `Pacjenci`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Pacjenci` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Imie` varchar(45) NOT NULL,
  `Nazwisko` varchar(45) NOT NULL,
  `Nr_tel` varchar(14) NOT NULL,
  `Organizacja_ID` int NOT NULL,
  `Plec` varchar(1) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `pacjent-org_idx` (`Organizacja_ID`),
  CONSTRAINT `pacjent-org` FOREIGN KEY (`Organizacja_ID`) REFERENCES `Organizacje` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Pacjenci`
--

LOCK TABLES `Pacjenci` WRITE;
/*!40000 ALTER TABLE `Pacjenci` DISABLE KEYS */;
INSERT INTO `Pacjenci` VALUES (1,'Testo','Testo-Testingowy','123456789',1,'F'),(2,'Jan','Kowalski','123456789',1,'M'),(3,'Bob','Marley','698594169',1,'M'),(4,'Bobby','Burger','4352473179',1,'M'),(5,'Przemek','Grabarek','777777777',1,'M'),(6,'Marcin','Pacjent','888777666',1,'M'),(7,'Test','Maj','19052022',1,'M'),(8,'Test z API','TiruRiru','123456789',1,'F'),(9,'Robert','Maklowicz','000000000',1,'M'),(11,'Piotr','Adamowski','333444555',1,'M'),(12,'Mariusz','Go?ota','123456789',1,'M'),(13,'Joanna','Brzozowska','987654321',1,'F'),(14,'Ewa','Maj','123456788956',1,'F'),(15,'test','test','12345678909876',1,'F'),(16,'Andrzej','Nowak','123456789',1,'M'),(17,'Andrzej','Nowak','+48123456789',1,'M'),(18,'Andrzej','Nowak','223456789',1,'M'),(19,'Hanna','Wola','480000000',1,'F'),(20,'Maria','Turek','480000000',1,'F');
/*!40000 ALTER TABLE `Pacjenci` ENABLE KEYS */;
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

-- Dump completed on 2022-06-21 22:42:53
