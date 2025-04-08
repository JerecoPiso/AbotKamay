CREATE DATABASE  IF NOT EXISTS `tqsystemdb` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `tqsystemdb`;
-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: localhost    Database: tqsystemdb
-- ------------------------------------------------------
-- Server version	8.0.39

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

--
-- Table structure for table `assessmentinformation`
--

DROP TABLE IF EXISTS `assessmentinformation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `assessmentinformation` (
  `assessment_id` int NOT NULL AUTO_INCREMENT,
  `client_id` int DEFAULT NULL,
  `beneficiary_id` int DEFAULT NULL,
  `problem_presented` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci,
  `social_worker_assessment` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci,
  `client_category` int NOT NULL,
  `client_sub_category` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`assessment_id`),
  KEY `client_id` (`client_id`),
  KEY `beneficiary_id` (`beneficiary_id`),
  KEY `assessmentinformation_ibfk_3_idx` (`client_category`),
  CONSTRAINT `assessmentinformation_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `clientinformation` (`client_id`),
  CONSTRAINT `assessmentinformation_ibfk_2` FOREIGN KEY (`beneficiary_id`) REFERENCES `beneficiaryinformation` (`beneficiary_id`),
  CONSTRAINT `assessmentinformation_ibfk_3` FOREIGN KEY (`client_category`) REFERENCES `clientcategories` (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assessmentinformation`
--

LOCK TABLES `assessmentinformation` WRITE;
/*!40000 ALTER TABLE `assessmentinformation` DISABLE KEYS */;
INSERT INTO `assessmentinformation` VALUES (8,1,1,'7','767',2,'67','2025-03-16 07:39:11'),(9,2,2,'rt','rtert',2,'4545','2025-03-16 07:48:06'),(10,2,2,'xxgfdf','dfgdfg',2,'dfgdfg','2025-03-16 11:36:17'),(12,1,1,'rwewer','erwer',2,'4545','2025-03-23 10:35:20'),(13,2,2,'rterte','ertert',1,'56565','2025-03-23 10:35:56'),(14,2,2,'rterte','ertert',1,'56565','2025-03-23 10:36:02'),(15,2,2,'dasd','sdasd',1,'345345','2025-03-23 10:42:47'),(16,1,1,'efds','fsdf',3,'sfdc','2025-03-23 10:46:38'),(17,1,1,'ERWERWER','WEREWRT',2,'454','2025-03-23 10:48:43'),(18,1,1,'WETRF','RETER',1,'656','2025-03-23 10:50:17'),(19,1,1,'43','3434',1,'45','2025-03-23 10:51:03'),(20,2,2,'sewrwe','wer',2,'45','2025-03-23 10:53:00'),(21,2,2,'43tergdf','dfgdfg',3,'45','2025-03-23 10:54:08'),(23,1,1,'fs','sdfsdf',5,'dfsdfsdf','2025-03-23 11:03:39'),(25,1,1,'wqsard','rfwedsf',1,'1','2025-03-23 11:04:58'),(26,1,1,'454','45',1,'1','2025-03-23 11:05:47'),(27,1,1,'sd','asdfsdf',1,'111','2025-03-23 11:06:33'),(28,1,1,'easdrfsd','sdf',1,'4545','2025-03-23 11:08:10'),(29,1,1,'rte','ert',2,'4545','2025-03-23 11:09:48'),(30,2,2,'sdfsdfsdf','fsdfsdf',1,'5656','2025-03-23 11:12:27'),(31,1,1,'sdfs','fsdf',1,'545','2025-03-23 11:39:54'),(32,1,1,'wasdfds','sdfsdf',1,'4545','2025-03-23 12:13:16'),(33,1,1,'45','5345',2,'345345','2025-03-23 12:17:00'),(34,1,1,'NA','NA',2,'RTRTRT','2025-03-23 12:25:18'),(35,1,1,'NANANANA','RTERT',2,'56','2025-03-23 12:26:08'),(36,1,1,'erw','werwe',1,'wer','2025-03-23 12:27:57'),(37,1,1,'dfs','fsdfsdf',4,'sfd','2025-03-23 12:31:08'),(38,1,1,'asd','asd',2,'dsa','2025-03-23 12:31:42'),(39,1,1,'dsfsd','sdgfb v',4,'567','2025-03-23 12:37:15'),(40,1,1,'dfs','fsdf',3,'ert','2025-03-23 12:41:36'),(41,2,2,'45','45',4,'45','2025-03-30 11:07:42'),(42,2,2,'wer','wer',2,'5','2025-03-30 11:09:23'),(43,2,2,'erw','wer',5,'34','2025-03-30 11:10:32'),(44,2,2,'rtert','ert',3,'45','2025-03-30 11:11:34'),(45,2,2,'sdsd','45345',2,'5','2025-03-30 11:18:11'),(46,2,2,'sdsd','assd',2,'65','2025-03-30 11:19:19'),(47,2,2,'sfsdf','df',4,'656','2025-03-30 11:19:59'),(48,2,2,'sfsdf','df',4,'656','2025-03-30 11:20:05');
/*!40000 ALTER TABLE `assessmentinformation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `assistanceinformation`
--

DROP TABLE IF EXISTS `assistanceinformation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `assistanceinformation` (
  `id` int NOT NULL AUTO_INCREMENT,
  `client_id` int DEFAULT NULL,
  `beneficiary_id` int DEFAULT NULL,
  `counselling` tinyint(1) DEFAULT NULL,
  `legal_assistance` tinyint(1) DEFAULT NULL,
  `referral_specify` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci,
  `other` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci,
  `amount` decimal(10,2) DEFAULT NULL,
  `mode_of_assistance` enum('Cash','GL') CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `financial_assistance` tinyint(1) DEFAULT NULL,
  `medical` tinyint(1) DEFAULT NULL,
  `burial` tinyint(1) DEFAULT NULL,
  `transpo` tinyint(1) DEFAULT NULL,
  `specify` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci,
  `value_pesos` decimal(10,2) DEFAULT NULL,
  `fund_source` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci,
  `fund_total` decimal(10,2) DEFAULT NULL,
  `material_assistance` tinyint(1) DEFAULT NULL,
  `food_pack` tinyint(1) DEFAULT NULL,
  `used_clothing` tinyint(1) DEFAULT NULL,
  `material_specify` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci,
  `material_value_pesos` decimal(10,2) DEFAULT NULL,
  `payee_name` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci,
  `payee_address` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci,
  PRIMARY KEY (`id`),
  KEY `client_id` (`client_id`),
  CONSTRAINT `assistanceinformation_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `clientinformation` (`client_id`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assistanceinformation`
--

LOCK TABLES `assistanceinformation` WRITE;
/*!40000 ALTER TABLE `assistanceinformation` DISABLE KEYS */;
INSERT INTO `assistanceinformation` VALUES (1,1,0,1,0,NULL,NULL,5656.00,'GL',0,0,0,0,'',0.00,'',NULL,1,0,0,'RTRT',0.00,'GGGG GGGGGGGG','TRT'),(2,1,0,1,0,NULL,NULL,767.00,'Cash',1,0,0,0,'767',67.00,'76767',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG','6767'),(3,1,0,1,0,NULL,NULL,767.00,'Cash',1,0,0,0,'767',67.00,'76767',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG','6767'),(4,1,0,1,0,NULL,NULL,767.00,'Cash',1,0,0,0,'6767',7.00,'767667',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG','6767'),(5,1,0,1,0,NULL,NULL,667.00,'Cash',1,0,0,0,'trt',0.00,'rtr',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(6,1,0,1,0,NULL,NULL,667.00,'Cash',1,0,0,0,'trt',0.00,'rtr',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(7,1,1,1,0,NULL,NULL,67.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(8,2,2,1,0,NULL,NULL,54545.00,'Cash',1,0,0,0,'45',5.00,'5',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(9,2,2,1,0,NULL,NULL,546756.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(10,1,1,1,0,NULL,NULL,565656.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(11,2,2,0,1,NULL,NULL,457888.00,'Cash',1,1,0,0,'ytytyty',676.00,'7676',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(12,2,2,1,0,NULL,NULL,78765.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(13,1,1,1,0,NULL,NULL,11111.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(14,1,1,1,0,NULL,NULL,2222.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(15,1,1,1,0,NULL,NULL,44444444.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(16,1,1,1,0,NULL,NULL,55555555.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(17,2,2,1,0,NULL,NULL,5000.00,'GL',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(18,2,2,1,0,NULL,NULL,3500.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(19,1,1,1,0,NULL,NULL,4500.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(20,1,1,1,0,NULL,NULL,1500.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(21,1,1,1,0,NULL,NULL,1200.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(22,1,1,1,0,NULL,NULL,1100.00,'GL',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(23,1,1,0,1,NULL,NULL,1650.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(24,1,1,1,0,NULL,NULL,500.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(25,2,2,1,0,NULL,NULL,656.00,'GL',1,1,0,0,'dfgdfg',56.00,'6556',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(26,1,1,1,0,NULL,NULL,7800.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(27,1,1,1,0,NULL,NULL,99999999.99,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(28,1,1,1,0,NULL,NULL,150.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(29,1,1,1,0,NULL,NULL,565656.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(30,1,1,1,0,NULL,NULL,99999999.99,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(31,1,1,1,0,NULL,NULL,454.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(32,1,1,1,0,NULL,NULL,111.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(33,1,1,1,0,NULL,NULL,111.00,'GL',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(34,1,1,1,0,NULL,NULL,676.00,'GL',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(35,1,1,1,0,NULL,NULL,55.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(36,2,2,1,0,NULL,NULL,545.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(37,2,2,1,0,NULL,NULL,45454545.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(38,2,2,1,0,NULL,NULL,45.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(39,2,2,1,0,NULL,NULL,45.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(40,2,2,1,0,NULL,NULL,3500.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(41,2,2,1,0,NULL,NULL,45.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG',''),(42,2,2,1,0,NULL,NULL,6.00,'Cash',0,0,0,0,'',0.00,'',NULL,0,0,0,'',0.00,'GGGG GGGGGGGG','');
/*!40000 ALTER TABLE `assistanceinformation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `beneficiaryfamilycomposition`
--

DROP TABLE IF EXISTS `beneficiaryfamilycomposition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `beneficiaryfamilycomposition` (
  `family_member_id` int NOT NULL AUTO_INCREMENT,
  `beneficiary_id` int DEFAULT NULL,
  `last_name` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `first_name` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `middle_name` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `date_of_birth` date DEFAULT NULL,
  `age` int DEFAULT NULL,
  `sex` enum('Male','Female') CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `relationship` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `civil_status` enum('Single','Married','Other') CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `civil_status_other` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `occupation_id` int NOT NULL,
  `income_range_id` int NOT NULL,
  `created_timestamp` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`family_member_id`),
  KEY `beneficiary_id` (`beneficiary_id`),
  KEY `fk_family_occupation` (`occupation_id`),
  KEY `fk_family_income` (`income_range_id`),
  CONSTRAINT `beneficiaryfamilycomposition_ibfk_1` FOREIGN KEY (`beneficiary_id`) REFERENCES `beneficiaryinformation` (`beneficiary_id`),
  CONSTRAINT `fk_family_income` FOREIGN KEY (`income_range_id`) REFERENCES `incomerange` (`income_range_id`),
  CONSTRAINT `fk_family_occupation` FOREIGN KEY (`occupation_id`) REFERENCES `occupation` (`occupation_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `beneficiaryfamilycomposition`
--

LOCK TABLES `beneficiaryfamilycomposition` WRITE;
/*!40000 ALTER TABLE `beneficiaryfamilycomposition` DISABLE KEYS */;
INSERT INTO `beneficiaryfamilycomposition` VALUES (1,2,'GGGG','GGGG','','2025-03-16',0,'Male','455','Single',NULL,1,2,'2025-03-30 10:43:34');
/*!40000 ALTER TABLE `beneficiaryfamilycomposition` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `beneficiaryinformation`
--

DROP TABLE IF EXISTS `beneficiaryinformation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `beneficiaryinformation` (
  `beneficiary_id` int NOT NULL AUTO_INCREMENT,
  `client_id` int DEFAULT NULL,
  `beneficiary_type` set('FHONA','Solo Parent','PWD','4Ps','Others') CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `other_beneficiary_type` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `youth_senior` set('Youth','Senior Citizen') CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `last_name` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `first_name` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `middle_name` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `ext_name` varchar(10) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `sex` enum('Male','Female') CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `date_of_birth` date DEFAULT NULL,
  `age` int DEFAULT NULL,
  `birth_place` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `region` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `province` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `city_municipality` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `district` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `barangay` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `street_purok` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `contact_number` varchar(15) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `civil_status` enum('Single','Married','Other') CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `civil_status_other` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `last_assistance_date` date DEFAULT NULL,
  PRIMARY KEY (`beneficiary_id`),
  KEY `client_id` (`client_id`),
  CONSTRAINT `beneficiaryinformation_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `clientinformation` (`client_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `beneficiaryinformation`
--

LOCK TABLES `beneficiaryinformation` WRITE;
/*!40000 ALTER TABLE `beneficiaryinformation` DISABLE KEYS */;
INSERT INTO `beneficiaryinformation` VALUES (1,1,'Others','Other','Youth','GGGG','GGGGGGGG','GGGGGGG','','Male','2025-03-16',0,'GGGGGGGG','Region V (Bicol Region)','Albay','Legazpi City (Capital)','1','Bgy. 66 - Banquerohan (Bgy. 43)','1','','Other',NULL,NULL),(2,2,'Solo Parent','','Youth','GGGG','GGGGGGGG','GGGGGGG','','Male','2025-03-16',0,'GGGGGGGG','Region V (Bicol Region)','Albay','Malinao','546','Quinarabasahan','1','','Married',NULL,NULL);
/*!40000 ALTER TABLE `beneficiaryinformation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientcategories`
--

DROP TABLE IF EXISTS `clientcategories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `clientcategories` (
  `category_id` int NOT NULL AUTO_INCREMENT,
  `category_name` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientcategories`
--

LOCK TABLES `clientcategories` WRITE;
/*!40000 ALTER TABLE `clientcategories` DISABLE KEYS */;
INSERT INTO `clientcategories` VALUES (1,'Children in Need of Special Assistance'),(2,'Youth in Need of Special Protection'),(3,'Women in Specially Difficult Circumstances'),(4,'Children with Disability'),(5,'Senior Citizen'),(6,'FHONA');
/*!40000 ALTER TABLE `clientcategories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientinformation`
--

DROP TABLE IF EXISTS `clientinformation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `clientinformation` (
  `client_id` int NOT NULL AUTO_INCREMENT,
  `last_name` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `first_name` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `middle_name` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `ext_name` varchar(10) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `id_number` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `sex` enum('Male','Female') CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `date_of_birth` date DEFAULT NULL,
  `age` int DEFAULT NULL,
  `birth_place` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `region` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `province` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `city_municipality` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `district` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `barangay` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `street_purok` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `relationship_to_beneficiary` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `civil_status` enum('Single','Married','Other') CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `civil_status_other` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `nationality` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `skills_occupation` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `philhealth_no` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `mode_of_admission` enum('Walk-in','Referral') CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `referring_party` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `contact_number` varchar(15) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `last_assistance_date` date DEFAULT NULL,
  `highest_educ_attainment` int DEFAULT NULL,
  `id_type_id` int DEFAULT NULL,
  `occupation_id` int DEFAULT NULL,
  `income_range_id` int DEFAULT NULL,
  `religion_id` int DEFAULT NULL,
  PRIMARY KEY (`client_id`),
  KEY `fk_id_type` (`id_type_id`),
  KEY `fk_occupation_id` (`occupation_id`),
  KEY `fk_client_religion` (`religion_id`),
  KEY `fk_income_range` (`income_range_id`),
  KEY `fk_highest_educ_attainment` (`highest_educ_attainment`),
  CONSTRAINT `fk_client_religion` FOREIGN KEY (`religion_id`) REFERENCES `religions` (`religion_id`) ON DELETE SET NULL,
  CONSTRAINT `fk_highest_educ_attainment` FOREIGN KEY (`highest_educ_attainment`) REFERENCES `educationalattainment` (`educational_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `fk_id_type` FOREIGN KEY (`id_type_id`) REFERENCES `idtypes` (`id_type_id`),
  CONSTRAINT `fk_income_range` FOREIGN KEY (`income_range_id`) REFERENCES `incomerange` (`income_range_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `fk_income_range_id` FOREIGN KEY (`income_range_id`) REFERENCES `incomerange` (`income_range_id`),
  CONSTRAINT `fk_occupation_id` FOREIGN KEY (`occupation_id`) REFERENCES `occupation` (`occupation_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientinformation`
--

LOCK TABLES `clientinformation` WRITE;
/*!40000 ALTER TABLE `clientinformation` DISABLE KEYS */;
INSERT INTO `clientinformation` VALUES (1,'GGGG','GGGGGGGG','GGGGGGG','','','Male','2025-03-16',0,'GGGGGGGG','Region V (Bicol Region)','Albay','Legazpi City (Capital)','1','Bgy. 66 - Banquerohan (Bgy. 43)','1','GGGGGG','Other',NULL,'',NULL,'','Referral','','0978655676',NULL,NULL,NULL,NULL,1,NULL),(2,'GGGG','GGGGGGGG','GGGGGGG','','','Male','2025-03-16',0,'GGGGGGGG','Region V (Bicol Region)','Albay','Malinao','546','Quinarabasahan','1','GGGGGG','Married',NULL,'',NULL,'','Referral','','0978655676','2025-04-07',NULL,NULL,NULL,1,NULL);
/*!40000 ALTER TABLE `clientinformation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `disbursementinformation`
--

DROP TABLE IF EXISTS `disbursementinformation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `disbursementinformation` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `client_id` int NOT NULL,
  `client_name` varchar(255) COLLATE utf8_general_ci NOT NULL,
  `address` varchar(255) COLLATE utf8_general_ci NOT NULL,
  `filepath` varchar(255) COLLATE utf8_general_ci NOT NULL,
  `last_assistance_date` date DEFAULT NULL,
  `archive` tinyint NOT NULL DEFAULT '0',
  `created_timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `disbursementinformation`
--

LOCK TABLES `disbursementinformation` WRITE;
/*!40000 ALTER TABLE `disbursementinformation` DISABLE KEYS */;
INSERT INTO `disbursementinformation` VALUES (1,2,'sdsd','sd','C:\\Users\\Jereco\\Pictures\\CapturedImages/Screenshot 2025-03-05 180500.png','2025-04-07',0,'2025-04-07 09:40:39'),(2,2,'sdxcx','cxcxc','C:\\Users\\Jereco\\Pictures\\CapturedImages/Screenshot 2025-03-05 180500.png','2025-04-07',0,'2025-04-07 11:31:41');
/*!40000 ALTER TABLE `disbursementinformation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `educationalattainment`
--

DROP TABLE IF EXISTS `educationalattainment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `educationalattainment` (
  `educational_id` int NOT NULL AUTO_INCREMENT,
  `education_level` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`educational_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `educationalattainment`
--

LOCK TABLES `educationalattainment` WRITE;
/*!40000 ALTER TABLE `educationalattainment` DISABLE KEYS */;
INSERT INTO `educationalattainment` VALUES (1,'No Formal Education'),(2,'Elementary'),(3,'High School'),(4,'Vocational'),(5,'College'),(6,'Postgraduate');
/*!40000 ALTER TABLE `educationalattainment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `idtypes`
--

DROP TABLE IF EXISTS `idtypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `idtypes` (
  `id_type_id` int NOT NULL AUTO_INCREMENT,
  `id_name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`id_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `idtypes`
--

LOCK TABLES `idtypes` WRITE;
/*!40000 ALTER TABLE `idtypes` DISABLE KEYS */;
INSERT INTO `idtypes` VALUES (1,'Philippine National ID'),(2,'Passport'),(3,'Driver\'s License'),(4,'SSS UMID Card'),(5,'PRC ID'),(6,'Voter\'s ID'),(7,'Senior Citizen ID'),(8,'PWD ID'),(9,'Philhealth ID'),(10,'TIN Card'),(11,'Postal ID'),(12,'GSIS e-Card');
/*!40000 ALTER TABLE `idtypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `incomerange`
--

DROP TABLE IF EXISTS `incomerange`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `incomerange` (
  `income_range_id` int NOT NULL AUTO_INCREMENT,
  `income_range` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`income_range_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `incomerange`
--

LOCK TABLES `incomerange` WRITE;
/*!40000 ALTER TABLE `incomerange` DISABLE KEYS */;
INSERT INTO `incomerange` VALUES (1,'Below 2500'),(2,'2500-5000'),(3,'5000-7500'),(4,'7500-10000'),(5,'Above 10000');
/*!40000 ALTER TABLE `incomerange` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `occupation`
--

DROP TABLE IF EXISTS `occupation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `occupation` (
  `occupation_id` int NOT NULL AUTO_INCREMENT,
  `occupation_name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`occupation_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `occupation`
--

LOCK TABLES `occupation` WRITE;
/*!40000 ALTER TABLE `occupation` DISABLE KEYS */;
INSERT INTO `occupation` VALUES (1,'Gov\'t employee'),(2,'Private sector employee'),(3,'Business owner (sari-sari store)'),(4,'Unemployed');
/*!40000 ALTER TABLE `occupation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `queue`
--

DROP TABLE IF EXISTS `queue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `queue` (
  `queue_id` int NOT NULL AUTO_INCREMENT,
  `queue_number` int NOT NULL,
  `step` int NOT NULL,
  `status` enum('Waiting','Serving','Completed') CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT 'Waiting',
  `hold` tinyint NOT NULL DEFAULT '0',
  `done` tinyint NOT NULL DEFAULT '0',
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`queue_id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `queue`
--

LOCK TABLES `queue` WRITE;
/*!40000 ALTER TABLE `queue` DISABLE KEYS */;
INSERT INTO `queue` VALUES (17,4,4,'Serving',1,0,'2025-04-01 06:15:40');
/*!40000 ALTER TABLE `queue` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `religions`
--

DROP TABLE IF EXISTS `religions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `religions` (
  `religion_id` int NOT NULL AUTO_INCREMENT,
  `religion_name` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`religion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `religions`
--

LOCK TABLES `religions` WRITE;
/*!40000 ALTER TABLE `religions` DISABLE KEYS */;
INSERT INTO `religions` VALUES (1,'Catholic'),(2,'Christian'),(3,'Muslim'),(4,'Hindu'),(5,'Buddhist'),(6,'Iglesia ni Cristo'),(7,'Baptist'),(8,'Seventh-Day Adventist');
/*!40000 ALTER TABLE `religions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `user_name` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `user_pass` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `user_role` enum('Admin','Admin Clerk 1','Admin Clerk 2','Admin Clerk 3','Social Worker','SDO') CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `last_login` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `first_name` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `last_name` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `UC_Username` (`user_name`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'administrator','Adminp@55','Admin','2025-04-07 19:32:17','John','Doe'),(2,'socialworker1','Worker1p@55','Social Worker','2025-04-01 08:49:26','Lito','Ramos'),(3,'socialworker2','Worker2p@55','Social Worker','2025-01-01 09:54:13','Joan','Lopez'),(4,'socialworker3','Worker3p@55','Social Worker','2025-04-05 10:12:10','Sheilaa','Guantero'),(5,'socialworker4','Worker4p@55','Social Worker','2025-04-01 14:59:47','Sarah Joy','Pino'),(7,'clerk1','Cl3rk111','Admin Clerk 1','2025-04-01 12:41:14','Maria Clara','Santos'),(8,'clerk2','Cl3rk222','Admin Clerk 2','2025-04-01 12:38:18','Jose','Garcia'),(9,'clerk3','Cl3rk333','Admin Clerk 3','2025-04-01 12:42:25','Ana','Villanueva'),(10,'disbursementofficer','D!55bursement','SDO','2025-04-01 13:00:48','Faye','Bonifacio');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-04-08 17:15:22
