/*
SQLyog Community v13.1.9 (64 bit)
MySQL - 10.4.32-MariaDB : Database - tqsystemdb
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`tqsystemdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `tqsystemdb`;

/*Table structure for table `assessmentinformation` */

DROP TABLE IF EXISTS `assessmentinformation`;

CREATE TABLE `assessmentinformation` (
  `assessment_id` int(11) NOT NULL AUTO_INCREMENT,
  `client_id` int(11) DEFAULT NULL,
  `beneficiary_id` int(11) DEFAULT NULL,
  `problem_presented` text DEFAULT NULL,
  `social_worker_assessment` text DEFAULT NULL,
  `client_category` varchar(255) DEFAULT NULL,
  `client_sub_category` varchar(255) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`assessment_id`),
  KEY `client_id` (`client_id`),
  KEY `beneficiary_id` (`beneficiary_id`),
  CONSTRAINT `assessmentinformation_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `clientinformation` (`client_id`),
  CONSTRAINT `assessmentinformation_ibfk_2` FOREIGN KEY (`beneficiary_id`) REFERENCES `beneficiaryinformation` (`beneficiary_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `assessmentinformation` */

/*Table structure for table `assistanceinformation` */

DROP TABLE IF EXISTS `assistanceinformation`;

CREATE TABLE `assistanceinformation` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `client_id` int(11) DEFAULT NULL,
  `beneficiary_id` int(11) DEFAULT NULL,
  `counselling` tinyint(1) DEFAULT NULL,
  `legal_assistance` tinyint(1) DEFAULT NULL,
  `referral_specify` text DEFAULT NULL,
  `other` text DEFAULT NULL,
  `amount` decimal(10,2) DEFAULT NULL,
  `mode_of_assistance` enum('Cash','GL') DEFAULT NULL,
  `financial_assistance` tinyint(1) DEFAULT NULL,
  `medical` tinyint(1) DEFAULT NULL,
  `burial` tinyint(1) DEFAULT NULL,
  `transpo` tinyint(1) DEFAULT NULL,
  `specify` text DEFAULT NULL,
  `value_pesos` decimal(10,2) DEFAULT NULL,
  `fund_source` text DEFAULT NULL,
  `fund_total` decimal(10,2) DEFAULT NULL,
  `material_assistance` tinyint(1) DEFAULT NULL,
  `food_pack` tinyint(1) DEFAULT NULL,
  `used_clothing` tinyint(1) DEFAULT NULL,
  `material_specify` text DEFAULT NULL,
  `material_value_pesos` decimal(10,2) DEFAULT NULL,
  `payee_name` text DEFAULT NULL,
  `payee_address` text DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `client_id` (`client_id`),
  KEY `beneficiary_id` (`beneficiary_id`),
  CONSTRAINT `assistanceinformation_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `clientinformation` (`client_id`),
  CONSTRAINT `assistanceinformation_ibfk_2` FOREIGN KEY (`beneficiary_id`) REFERENCES `beneficiaryinformation` (`beneficiary_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `assistanceinformation` */

/*Table structure for table `beneficiaryfamilycomposition` */

DROP TABLE IF EXISTS `beneficiaryfamilycomposition`;

CREATE TABLE `beneficiaryfamilycomposition` (
  `family_member_id` int(11) NOT NULL AUTO_INCREMENT,
  `beneficiary_id` int(11) DEFAULT NULL,
  `last_name` varchar(50) DEFAULT NULL,
  `first_name` varchar(50) DEFAULT NULL,
  `middle_name` varchar(50) DEFAULT NULL,
  `date_of_birth` date DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `sex` enum('Male','Female') DEFAULT NULL,
  `relationship` varchar(50) DEFAULT NULL,
  `civil_status` enum('Single','Married','Other') DEFAULT NULL,
  `civil_status_other` varchar(50) DEFAULT NULL,
  `occupation_id` int(11) NOT NULL,
  `income_range_id` int(11) NOT NULL,
  PRIMARY KEY (`family_member_id`),
  KEY `beneficiary_id` (`beneficiary_id`),
  KEY `fk_family_occupation` (`occupation_id`),
  KEY `fk_family_income` (`income_range_id`),
  CONSTRAINT `beneficiaryfamilycomposition_ibfk_1` FOREIGN KEY (`beneficiary_id`) REFERENCES `beneficiaryinformation` (`beneficiary_id`),
  CONSTRAINT `fk_family_income` FOREIGN KEY (`income_range_id`) REFERENCES `incomerange` (`income_range_id`),
  CONSTRAINT `fk_family_occupation` FOREIGN KEY (`occupation_id`) REFERENCES `occupation` (`occupation_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `beneficiaryfamilycomposition` */

/*Table structure for table `beneficiaryinformation` */

DROP TABLE IF EXISTS `beneficiaryinformation`;

CREATE TABLE `beneficiaryinformation` (
  `beneficiary_id` int(11) NOT NULL AUTO_INCREMENT,
  `client_id` int(11) DEFAULT NULL,
  `beneficiary_type` set('Youth','Fhona','SeniorCitizen','SoloParent','Pwd','4ps','Other') DEFAULT NULL,
  `other_beneficiary_type` varchar(50) DEFAULT NULL,
  `last_name` varchar(50) DEFAULT NULL,
  `first_name` varchar(50) DEFAULT NULL,
  `middle_name` varchar(50) DEFAULT NULL,
  `ext_name` varchar(10) DEFAULT NULL,
  `sex` enum('Male','Female') DEFAULT NULL,
  `date_of_birth` date DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `birth_place` varchar(100) DEFAULT NULL,
  `region` varchar(100) DEFAULT NULL,
  `province` varchar(100) DEFAULT NULL,
  `city_municipality` varchar(100) DEFAULT NULL,
  `district` varchar(100) DEFAULT NULL,
  `barangay` varchar(100) DEFAULT NULL,
  `street_purok` varchar(100) DEFAULT NULL,
  `contact_number` varchar(15) DEFAULT NULL,
  `civil_status` enum('Single','Married','Other') DEFAULT NULL,
  `civil_status_other` varchar(50) DEFAULT NULL,
  `last_assistance_date` date DEFAULT NULL,
  PRIMARY KEY (`beneficiary_id`),
  KEY `client_id` (`client_id`),
  CONSTRAINT `beneficiaryinformation_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `clientinformation` (`client_id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `beneficiaryinformation` */

insert  into `beneficiaryinformation`(`beneficiary_id`,`client_id`,`beneficiary_type`,`other_beneficiary_type`,`last_name`,`first_name`,`middle_name`,`ext_name`,`sex`,`date_of_birth`,`age`,`birth_place`,`region`,`province`,`city_municipality`,`district`,`barangay`,`street_purok`,`contact_number`,`civil_status`,`civil_status_other`,`last_assistance_date`) values 
(4,14,'Fhona,4ps',NULL,'Gomez','Selena','Pink','','Female','2024-09-07',0,'Sorsogon','V','Sorsogon','Prieto Diaz','2nd','Brillante','Purok 2','09111111111','Married','','2023-03-01'),
(5,15,'Pwd,Other',NULL,'Juan','Mang','Jojo','Jr','Male','1988-09-07',36,'Sorsogon City','V','Sorsogon','Irosin','2nd','Bacolod','Purok 2','09222222222','Other','Separate','2024-09-12'),
(6,16,'SeniorCitizen,Pwd',NULL,'Last','First','Middle','Sr','Male','1960-01-07',64,'Sorsogon City','V','Sorsogon','14','2nd','Bacolod','Purok 3','09333333333','Married','','2020-07-01'),
(13,21,'SoloParent',NULL,'Smith','William','James','Sr','Male','1975-01-03',49,'Sorsogon City','V','Sorsogon','Pilar','1st','Calpi','Purok 2','09111111111','Single','','2014-06-18'),
(15,23,'Other',NULL,'Carpenter','Sabrina','Her','','Female','1995-01-03',29,'Sorsogon City','V','Sorsogon','Casiguran','1st','Central','Purok 2 ','09989898989','Other','Separate','2020-07-21'),
(16,24,'Fhona',NULL,'Grande','Ariana','Whales','','Female','1992-01-03',32,'Sorsogon','V','Sorsogon','Juban','2nd','Catanagan','Purok 2','09334433443','Single','','2024-05-15'),
(17,25,'4ps',NULL,'Dalisay','Cardo','Cruz','','Male','1986-01-01',38,'Sorsogon City','V','Sorsogon','Prieto Diaz','2nd','Brillante','Purok 1','09676654648','Married','','2011-02-21'),
(18,26,'Youth',NULL,'Lopez','Joan','Janoras','','Female','2001-05-07',23,'Sorsogon','V','Sorsogon','Sorsogon City','1st','Cambulaga','5','09937561903','Single','','2018-03-21'),
(19,29,'Fhona',NULL,'Delacruz','Maria ','Santos',NULL,'Female','1995-07-20',28,'Manila','NCR','Metro Manila','Quezon City','1st','Brgy. 123','Street 10','09179876543','Other','Daugther','2024-10-01'),
(20,29,'SoloParent',NULL,'Delacruz','Larry','Santos',NULL,'Male','1995-07-28',NULL,'Manila','NCR','Metro Manila','Quezon City','1st','Brgy. 123','Street 10','09586847565','Single',NULL,'2024-10-01'),
(21,33,NULL,NULL,'JIMENEZ','MARIA','HAMOR','','Female','1930-02-24',95,'SORSOGON CITY','Region V (Bicol Region)','Sorsogon','Casiguran','1ST','Santa Cruz','3','0955 545 8874','Married',NULL,NULL);

/*Table structure for table `clientcategories` */

DROP TABLE IF EXISTS `clientcategories`;

CREATE TABLE `clientcategories` (
  `category_id` int(11) NOT NULL AUTO_INCREMENT,
  `category_name` varchar(255) NOT NULL,
  PRIMARY KEY (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `clientcategories` */

insert  into `clientcategories`(`category_id`,`category_name`) values 
(1,'Children in Need of Special Assistance'),
(2,'Youth in Need of Special Protection'),
(3,'Women in Specially Difficult Circumstances'),
(4,'Children with Disability'),
(5,'Senior Citizen'),
(6,'FHONA');

/*Table structure for table `clientinformation` */

DROP TABLE IF EXISTS `clientinformation`;

CREATE TABLE `clientinformation` (
  `client_id` int(11) NOT NULL AUTO_INCREMENT,
  `last_name` varchar(50) DEFAULT NULL,
  `first_name` varchar(50) DEFAULT NULL,
  `middle_name` varchar(50) DEFAULT NULL,
  `ext_name` varchar(10) DEFAULT NULL,
  `id_number` varchar(50) DEFAULT NULL,
  `sex` enum('Male','Female') DEFAULT NULL,
  `date_of_birth` date DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `birth_place` varchar(100) DEFAULT NULL,
  `region` varchar(100) DEFAULT NULL,
  `province` varchar(100) DEFAULT NULL,
  `city_municipality` varchar(100) DEFAULT NULL,
  `district` varchar(100) DEFAULT NULL,
  `barangay` varchar(100) DEFAULT NULL,
  `street_purok` varchar(100) DEFAULT NULL,
  `relationship_to_beneficiary` varchar(100) DEFAULT NULL,
  `civil_status` enum('Single','Married','Other') DEFAULT NULL,
  `civil_status_other` varchar(50) DEFAULT NULL,
  `nationality` varchar(50) DEFAULT NULL,
  `skills_occupation` varchar(100) DEFAULT NULL,
  `philhealth_no` varchar(50) DEFAULT NULL,
  `mode_of_admission` enum('Walk-in','Referral') DEFAULT NULL,
  `referring_party` varchar(100) DEFAULT NULL,
  `contact_number` varchar(15) DEFAULT NULL,
  `last_assistance_date` date DEFAULT NULL,
  `highest_educ_attainment` int(11) DEFAULT NULL,
  `id_type_id` int(11) DEFAULT NULL,
  `occupation_id` int(11) DEFAULT NULL,
  `income_range_id` int(11) DEFAULT NULL,
  `religion_id` int(11) DEFAULT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `clientinformation` */

insert  into `clientinformation`(`client_id`,`last_name`,`first_name`,`middle_name`,`ext_name`,`id_number`,`sex`,`date_of_birth`,`age`,`birth_place`,`region`,`province`,`city_municipality`,`district`,`barangay`,`street_purok`,`relationship_to_beneficiary`,`civil_status`,`civil_status_other`,`nationality`,`skills_occupation`,`philhealth_no`,`mode_of_admission`,`referring_party`,`contact_number`,`last_assistance_date`,`highest_educ_attainment`,`id_type_id`,`occupation_id`,`income_range_id`,`religion_id`) values 
(1,'Doe','John','Potter','Jr','123456789','Male','1990-02-05',34,'Sorsogon City','Region V (Bicol Region)','Sorsogon','Casiguran','1st','Amomonting','Purok 4','Self','Married','Single','Filipino','Driver','1234567890','Walk-in','','09123456789','2025-01-01',3,1,1,1,1),
(2,'Chan','Jakie','Yin','Sr','123456789','Male','1985-03-01',39,'Sorsogon City','Region V (Bicol Region)','Sorsogon','Castilla','1st','Amomonting','Purok 3','Father','Other','Married','Filipino','Actor','0987654321','Referral','','09112233445','2024-10-01',3,1,1,1,1),
(8,'Geronimo','Sarah','Cruz','','123456789','Female','2003-06-06',21,'Sorsogon City','Region V (Bicol Region)','Sorsogon','Casiguran','1st','Amomonting','Purok 4','Sibling','Other','Separate','Filipino','Student','0990909090','Referral','','09888887777','2018-01-01',3,1,1,1,1),
(12,'Swift','Taylor','Sample','','123456789','Female','2024-09-07',37,'Sorsogon City','Region V (Bicol Region)','Sorsogon','Barcelona','1st','Amomonting','Purok 3','Self','Other','','Filipino','','','Walk-in','','09999999999','2016-01-01',1,1,1,1,1),
(13,'Arroyo','Denise','Laurel','','123456789','Female','2024-09-07',0,'Sorsogon City','Region V (Bicol Region)','Sorsogon','Barcelona','1st','Amomonting','Purok 3','Self','Other','','Filipino','','','Referral','','09777777777','2024-12-27',1,1,1,1,1),
(14,'Gomez','Selena','Pink','','123456789','Female','2023-01-01',1,'Sorsogon City','Region V (Bicol Region)','Sorsogon','Prieto Diaz','2nd','Bacolod','Purok 2','Self','Married','','Filipino','C','1234','Walk-in','','09434332222','2023-03-01',3,1,2,1,1),
(15,'Juan','Mang','Jojo','Jr','123456789','Male','1988-09-07',36,'Sorsogon City','Region V (Bicol Region)','Sorsogon','Irosin','2nd','Bacolod','Purok 2','Self','Other','Separate','Filipino','Driver','0987','Referral','','09222222222','2022-01-01',3,1,2,1,1),
(16,'Last','First','Middle','Sr','123456789','Male','1960-01-07',64,'Sorsogon City','Region V (Bicol Region)','Sorsogon','Santa Magdalena','2nd','Barangay Poblacion I','Purok 3','Self','Married','','Filipino','None','2211','Walk-in','','09333333333','2020-07-01',1,1,2,2,1),
(20,'Zuckerberg','Mark','Andres','Jr','123456789','Male','1984-01-01',40,'Sorsogon City','Region V (Bicol Region)','Sorsogon','Gubat','2nd','Balud del Sur','Purok 5','Self','Married','','Filipino','Programmer','08987','Referral','','09887766554','2017-01-17',5,1,2,2,1),
(21,'Smith','William','James','','123456789','Male','1975-01-03',49,'Sorsogon City','Region V (Bicol Region)','Sorsogon','Pilar','1st','Calpi','Purok 2','Self','Single','','Filipino','Farmer','5634','Walk-in','','09111111111','2024-12-21',3,1,2,2,1),
(22,'Another','Sample','Mid','','123456789','Male','2003-01-01',21,'Sorsogon City','Region V (Bicol Region)','Sorsogon','Gubat','2nd','Bagacay','Purok 1','Brother','Single','','Filipino','asas','232','Walk-in','','09111111111','2012-01-17',3,1,2,2,1),
(23,'Carpenter','Sabrina','Her','','123456789','Female','1995-01-03',29,'Sorsogon City','Region V (Bicol Region)','Sorsogon','Casiguran','1st','Central','Purok 2 ','Self','Other','Separate','Filipino','Singer','3434','Walk-in','','09989898989','2017-07-26',5,1,2,2,1),
(24,'Grande','Ariana','Whales','','123456789','Female','1992-01-03',32,'Sorsogon','Region V (Bicol Region)','Sorsogon','Juban','2nd','Catanagan','Purok 2','Self','Single','','Filipino','Singer','787322','Walk-in','','09334433443','2017-11-06',5,1,2,2,1),
(25,'Dalisay','Cardo','Cruz','','123456789','Male','1986-01-01',38,'Sorsogon City','Region V (Bicol Region)','Sorsogon','Prieto Diaz','2nd','Brillante','Purok 1','Self','Married','','Filipino','Police','343','Walk-in','','09676654648','2018-01-17',3,1,2,2,1),
(26,'Lopez','Joan','Janoras','','123456789','Female','2001-05-07',23,'Sorsogon','Region V (Bicol Region)','Sorsogon','Sorsogon City','1st','Cambulaga','Purok 4 ','Self','Single','','Filipino','Student','','Walk-in','','09937561903','2020-03-17',5,1,2,2,1),
(29,'Delacruz','Juan','Santos','Sr','123456789','Male','1980-05-10',43,'Manila','NCR','Metro Manila','Quezon City','1st','Brgy. 123','Street 10','Father','Married',NULL,'Filipino',NULL,NULL,'Walk-in',NULL,'09171234567','2024-10-01',5,4,2,2,1),
(33,'JIMENEZ','MARIA','HAMOR','','123456789012','Female','1930-02-24',95,'SORSOGON CITY','Region V (Bicol Region)','Sorsogon','Casiguran','1ST','Santa Cruz','3','','Married',NULL,'FILIPINO',NULL,'2154548484','Walk-in','','0955 545 8874',NULL,5,1,1,5,1);

/*Table structure for table `educationalattainment` */

DROP TABLE IF EXISTS `educationalattainment`;

CREATE TABLE `educationalattainment` (
  `educational_id` int(11) NOT NULL AUTO_INCREMENT,
  `education_level` varchar(100) NOT NULL,
  PRIMARY KEY (`educational_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `educationalattainment` */

insert  into `educationalattainment`(`educational_id`,`education_level`) values 
(1,'No Formal Education'),
(2,'Elementary'),
(3,'High School'),
(4,'Vocational'),
(5,'College'),
(6,'Postgraduate');

/*Table structure for table `idtypes` */

DROP TABLE IF EXISTS `idtypes`;

CREATE TABLE `idtypes` (
  `id_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `id_name` varchar(100) NOT NULL,
  PRIMARY KEY (`id_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `idtypes` */

insert  into `idtypes`(`id_type_id`,`id_name`) values 
(1,'Philippine National ID'),
(2,'Passport'),
(3,'Driver\'s License'),
(4,'SSS UMID Card'),
(5,'PRC ID'),
(6,'Voter\'s ID'),
(7,'Senior Citizen ID'),
(8,'PWD ID'),
(9,'Philhealth ID'),
(10,'TIN Card'),
(11,'Postal ID'),
(12,'GSIS e-Card');

/*Table structure for table `incomerange` */

DROP TABLE IF EXISTS `incomerange`;

CREATE TABLE `incomerange` (
  `income_range_id` int(11) NOT NULL AUTO_INCREMENT,
  `income_range` varchar(50) NOT NULL,
  PRIMARY KEY (`income_range_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `incomerange` */

insert  into `incomerange`(`income_range_id`,`income_range`) values 
(1,'Below 2500'),
(2,'2500-5000'),
(3,'5000-7500'),
(4,'7500-10000'),
(5,'Above 10000');

/*Table structure for table `occupation` */

DROP TABLE IF EXISTS `occupation`;

CREATE TABLE `occupation` (
  `occupation_id` int(11) NOT NULL AUTO_INCREMENT,
  `occupation_name` varchar(100) NOT NULL,
  PRIMARY KEY (`occupation_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `occupation` */

insert  into `occupation`(`occupation_id`,`occupation_name`) values 
(1,'Gov\'t employee'),
(2,'Private sector employee'),
(3,'Business owner (sari-sari store)'),
(4,'Unemployed');

/*Table structure for table `queue` */

DROP TABLE IF EXISTS `queue`;

CREATE TABLE `queue` (
  `queue_id` int(11) NOT NULL AUTO_INCREMENT,
  `queue_number` int(11) NOT NULL,
  `step` int(11) NOT NULL,
  `status` enum('Waiting','Serving','Completed') DEFAULT 'Waiting',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`queue_id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `queue` */

insert  into `queue`(`queue_id`,`queue_number`,`step`,`status`,`created_at`) values 
(2,2,5,'Completed','2025-02-13 00:36:38'),
(3,3,5,'Completed','2025-02-13 00:38:18'),
(4,4,5,'Serving','2025-02-13 00:39:05'),
(7,5,4,'Completed','2025-02-13 03:17:37'),
(10,6,3,'Completed','2025-02-24 09:00:05'),
(11,7,2,'Waiting','2025-02-24 09:00:22');

/*Table structure for table `religions` */

DROP TABLE IF EXISTS `religions`;

CREATE TABLE `religions` (
  `religion_id` int(11) NOT NULL AUTO_INCREMENT,
  `religion_name` varchar(50) NOT NULL,
  PRIMARY KEY (`religion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `religions` */

insert  into `religions`(`religion_id`,`religion_name`) values 
(1,'Catholic'),
(2,'Christian'),
(3,'Muslim'),
(4,'Hindu'),
(5,'Buddhist'),
(6,'Iglesia ni Cristo'),
(7,'Baptist'),
(8,'Seventh-Day Adventist');

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(50) NOT NULL,
  `user_pass` varchar(50) NOT NULL,
  `user_role` enum('Admin','Admin Clerk 1','Admin Clerk 2','Admin Clerk 3','Social Worker','SDO') DEFAULT NULL,
  `last_login` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `UC_Username` (`user_name`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `users` */

insert  into `users`(`user_id`,`user_name`,`user_pass`,`user_role`,`last_login`,`first_name`,`last_name`) values 
(1,'administrator','Adminp@55','Admin','2025-02-24 12:36:09','John','Doe'),
(2,'socialworker1','Worker1p@55','Social Worker','2025-02-24 11:58:30','Lito','Ramos'),
(3,'socialworker2','Worker2p@55','Social Worker','2025-01-01 09:54:13','Joan','Lopez'),
(4,'socialworker3','Worker3p@55','Social Worker','2025-01-01 09:54:13','Sheila','Guantero'),
(5,'socialworker4','Worker4p@55','Social Worker','2025-01-01 10:28:17','Sarah Joy','Pino'),
(7,'clerk1','Cl3rk111','Admin Clerk 1','2025-02-24 08:53:48','Maria Clara','Santos'),
(8,'clerk2','Cl3rk222','Admin Clerk 2','2025-02-24 09:12:31','Jose','Garcia'),
(9,'clerk3','Cl3rk333','Admin Clerk 3','2025-02-24 13:28:18','Ana','Villanueva'),
(10,'disbursementofficer','D!55bursement','SDO','2025-02-24 12:03:41','Faye','Bonifacio');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
