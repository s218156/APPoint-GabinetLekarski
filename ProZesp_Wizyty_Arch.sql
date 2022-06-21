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
-- Table structure for table `Wizyty_Arch`
--

DROP TABLE IF EXISTS `Wizyty_Arch`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Wizyty_Arch` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Data_utworzenia` datetime NOT NULL,
  `Data_wizyty` datetime NOT NULL,
  `Czy_sie_odbyla` tinyint(1) NOT NULL,
  `Czas_trwania` int NOT NULL DEFAULT '10',
  `Czy_byla_konieczna` tinyint(1) DEFAULT NULL,
  `Uwagi` varchar(45) DEFAULT NULL,
  `Pacjent_ID` int NOT NULL,
  `Lekarz_ID` int NOT NULL,
  `Gabinet_ID` int NOT NULL,
  `Czy_wystawiono_recepte` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `WyzytyA-Pacjent_idx` (`Pacjent_ID`),
  KEY `WizytyA-Gabinet_idx` (`Gabinet_ID`),
  KEY `WizytyA-Uzytkownik_idx` (`Lekarz_ID`),
  CONSTRAINT `WizytyA-Gabinet` FOREIGN KEY (`Gabinet_ID`) REFERENCES `Gabinety` (`ID`),
  CONSTRAINT `WizytyA-Uzytkownik` FOREIGN KEY (`Lekarz_ID`) REFERENCES `Uzytkownicy` (`ID`),
  CONSTRAINT `WyzytyA-Pacjent` FOREIGN KEY (`Pacjent_ID`) REFERENCES `Pacjenci` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Wizyty_Arch`
--

LOCK TABLES `Wizyty_Arch` WRITE;
/*!40000 ALTER TABLE `Wizyty_Arch` DISABLE KEYS */;
INSERT INTO `Wizyty_Arch` VALUES (4,'2022-04-02 10:21:42','2022-04-02 10:21:42',1,60,1,'remarks',1,2,1,1),(5,'2022-05-19 15:10:00','2022-05-19 15:00:00',1,30,1,'Why do you need it?!',2,3,1,0),(6,'2022-05-19 16:15:00','2022-05-19 16:00:00',1,20,0,'...',6,3,1,0),(7,'2022-05-20 00:00:00','2022-05-20 15:00:00',1,20,1,'food poisoning via self pastries',9,3,1,1),(34,'0001-01-01 00:00:00','2022-06-10 11:00:00',1,20,1,'fdasdsa\n',3,3,1,1),(35,'0001-01-01 00:00:00','2022-06-10 13:00:00',1,60,1,'Wizyta przebiegla pomyslnie',4,3,1,1),(36,'0001-01-01 00:00:00','2022-06-10 13:00:00',1,60,1,'Prescribed a phat 10 cm CBD blunt for patient',5,3,1,1),(37,'0001-01-01 00:00:00','2022-06-10 08:00:00',1,60,1,'Visit finished quick',6,3,1,1),(38,'2022-06-10 08:21:02','2022-06-10 08:00:00',1,30,1,'',6,3,1,1),(45,'2022-06-13 17:09:06','2022-06-17 10:00:00',1,20,1,'',13,3,3,1),(47,'2022-06-19 14:28:14','2022-06-20 10:00:00',1,60,0,'',11,3,3,1),(48,'2022-06-19 16:04:25','2022-06-20 10:00:00',1,60,1,'',9,3,3,1);
/*!40000 ALTER TABLE `Wizyty_Arch` ENABLE KEYS */;
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

-- Dump completed on 2022-06-21 22:42:47
