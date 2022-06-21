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
-- Table structure for table `Leki_Pacjent`
--

DROP TABLE IF EXISTS `Leki_Pacjent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Leki_Pacjent` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Pacjent_ID` int NOT NULL,
  `Lek_ID` int NOT NULL,
  `Ilosc_dawek` int NOT NULL,
  `Jednostka` varchar(45) NOT NULL,
  `Data_przypisania` date NOT NULL,
  `Wizyta_ID` int NOT NULL,
  `Uwagi` varchar(45) DEFAULT NULL,
  `Harmonogram` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `this-pacjent_idx` (`Pacjent_ID`),
  KEY `this-wizyta_idx` (`Wizyta_ID`),
  KEY `this-leki_idx` (`Lek_ID`),
  CONSTRAINT `this-leki` FOREIGN KEY (`Lek_ID`) REFERENCES `Leki` (`ID`),
  CONSTRAINT `this-pacjent` FOREIGN KEY (`Pacjent_ID`) REFERENCES `Pacjenci` (`ID`),
  CONSTRAINT `this-wizyta` FOREIGN KEY (`Wizyta_ID`) REFERENCES `Wizyty_Arch` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Leki_Pacjent`
--

LOCK TABLES `Leki_Pacjent` WRITE;
/*!40000 ALTER TABLE `Leki_Pacjent` DISABLE KEYS */;
INSERT INTO `Leki_Pacjent` VALUES (1,9,4,3,'blunt','2022-05-24',7,NULL,'daily'),(2,1,2,1,'pills','2022-04-02',4,NULL,'daily'),(3,5,1,0,'ml','2022-06-11',36,'','a day'),(4,5,2,0,'ml','2022-06-11',36,'','a day'),(5,5,3,0,'ml','2022-06-11',36,'','a day'),(6,3,1,0,'ml','2022-06-11',34,'','a day'),(7,3,2,0,'ml','2022-06-11',34,'','a day'),(8,3,3,0,'ml','2022-06-11',34,'','a day'),(9,6,2,10,'ml','2022-06-11',37,'','a day'),(10,4,2,10,'ml','2022-06-11',35,'','a day'),(11,4,3,20,'ml','2022-06-11',35,'','a week'),(12,13,5,20,'ml','2022-06-13',45,'','a day'),(13,13,6,10,'ml','2022-06-13',45,'','a week'),(14,11,7,10,'ml','2022-06-19',47,'','a month'),(15,11,6,5,'ml','2022-06-19',47,'','a day'),(16,9,3,6,'ml','2022-06-19',48,'','a day'),(17,9,5,5,'cm','2022-06-19',48,'','a day'),(18,9,8,4,'ml','2022-06-19',48,'','a day');
/*!40000 ALTER TABLE `Leki_Pacjent` ENABLE KEYS */;
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

-- Dump completed on 2022-06-21 22:42:22
