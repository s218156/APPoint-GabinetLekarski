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
-- Table structure for table `Uzytkownicy`
--

DROP TABLE IF EXISTS `Uzytkownicy`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Uzytkownicy` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Login` varchar(20) NOT NULL,
  `Haslo` varchar(60) NOT NULL,
  `Typ_ID` int NOT NULL,
  `Imie` varchar(12) NOT NULL,
  `Nazwisko` varchar(25) NOT NULL,
  `Specjalizacja_ID` int DEFAULT NULL,
  `Organizacja_ID` int DEFAULT NULL,
  `refreshtoken` varchar(70) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `User-Organizacja_idx` (`Organizacja_ID`),
  KEY `User-Typ_idx` (`Typ_ID`),
  KEY `user-specjalizacja_idx` (`Specjalizacja_ID`),
  CONSTRAINT `User-Org-3` FOREIGN KEY (`Organizacja_ID`) REFERENCES `Organizacje` (`ID`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `user-specjalizacja` FOREIGN KEY (`Specjalizacja_ID`) REFERENCES `Specjalizacje` (`ID`),
  CONSTRAINT `User-Typ-2` FOREIGN KEY (`Typ_ID`) REFERENCES `Typy_uzytkownikow` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Uzytkownicy`
--

LOCK TABLES `Uzytkownicy` WRITE;
/*!40000 ALTER TABLE `Uzytkownicy` DISABLE KEYS */;
INSERT INTO `Uzytkownicy` VALUES (2,'test','KJuf5FjGRDk+42s6mAy8RyPgpuooOgeSABn9Y4TLr1s=',1,'Tescik','Testowy',NULL,1,'s9bxL5lVCizNLgKXy8hIZaQxOvNv0EU5cBtff3uC7dE='),(3,'lekarz','tfejURj1zyw6t0PvE3vwc2SmCggDdv8UwxK2nwtKfak=',2,'Jan','Kowalski',2,1,'NUqH/cJEN9vZz4oaCpCmEDGlvo5CxTXYXmj6wP+r+C4='),(4,'lekarz2','tfejURj1zyw6t0PvE3vwc2SmCggDdv8UwxK2nwtKfak=',2,'Piotr','Nowak',2,1,'2JfoA0TXAbCLyl4cUsbooZZjh4TGAVZwqUQbUNXN83g='),(5,'rej','tfejURj1zyw6t0PvE3vwc2SmCggDdv8UwxK2nwtKfak=',3,'Anna','Kowalska',NULL,1,'2JfoA0TXAbCLyl4cUsbooZZjh4TGAVZwqUQbUNXN83g='),(14,'jan','tNwK3G8hK/nRBgdqXwlIj7wYuBc9eZCCjZ2iQZETkmM=',2,'Jan','Piotrowski',8,1,'RQT7vFfQq/sbiGGd27t3OO5l8qdq++9z2TpbzQ0gvcY='),(15,'jan','ZJGkMlUUnfLbvJ8UJNltP7hYXlSUPudrb63JJuPAk1o=',2,'Jan','Nowak',3,1,''),(24,'andrzej','M5nqCnR0GOOcnew0Wp/MdNfrOgEwISvJIBo6dk/6k2s=',2,'Andrzej','Nowak',3,1,'TzJeUEw0V7Vu90hUuNFvAXaPSpH+VgvS64F39wXeRZw=');
/*!40000 ALTER TABLE `Uzytkownicy` ENABLE KEYS */;
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

-- Dump completed on 2022-06-21 22:42:25
