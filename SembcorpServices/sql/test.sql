-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Aug 18, 2017 at 05:41 AM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `test`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin_alert`
--

CREATE TABLE IF NOT EXISTS `admin_alert` (
  `id` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `creation_date` datetime NOT NULL,
  `lat` double NOT NULL,
  `longi` double NOT NULL,
  `alert` text NOT NULL,
  `parent_id` varchar(100) NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',
  `child_id` varchar(100) NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin_alert`
--

INSERT INTO `admin_alert` (`id`, `email`, `creation_date`, `lat`, `longi`, `alert`, `parent_id`, `child_id`) VALUES
('ad3af573-3a0f-4c91-86b4-1ab72ae617ef', 'marcus.lee.2015@smu.edu.sg', '2017-08-08 05:11:13', 1.0909, 2.123123, 'Come back now', '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000'),
('f2388c41-c720-46ab-892e-fc3dca2c7e9f', 'marcus.lee', '2017-08-09 07:15:15', 1.2323, 2.43434, 'TEST', '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000'),
('d371f72d-b17c-458d-8823-d70ae35d5ce2', 'marcus.lee.2015@smu.edu.sg', '2017-08-08 05:11:13', 1.0909, 2.123123, 'Come back now', '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000'),
('517b6b34-4b9a-4599-bb32-d0ac7baf6474', 'marcus.lee.2015@smu.edu.sg', '2017-08-08 05:11:13', 1.0909, 2.123123, 'Come back now', '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000');

-- --------------------------------------------------------

--
-- Table structure for table `emergency_contact`
--

CREATE TABLE IF NOT EXISTS `emergency_contact` (
  `location_name` varchar(100) NOT NULL,
  `region_code` int(3) NOT NULL,
  `contact_number` int(15) NOT NULL,
  `lat` double NOT NULL,
  `longi` double NOT NULL,
  `desc` text NOT NULL,
  PRIMARY KEY (`region_code`,`contact_number`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `emergency_contact`
--

INSERT INTO `emergency_contact` (`location_name`, `region_code`, `contact_number`, `lat`, `longi`, `desc`) VALUES
('Sembcorp Singapore', 65, 94561238, 1.00021545, 2.32326613, 'This is the head office in Singapore near to SMU'),
('Sembcorp Malaysia', 60, 95462368, 1.22, 3.6265656, 'The office of sembcorp in Malaysia'),
('Sembcorp India', 89, 55525288, 3.66696, 6.33232955, 'The is the office in sembcorp');

-- --------------------------------------------------------

--
-- Table structure for table `isos_alert_response`
--

CREATE TABLE IF NOT EXISTS `isos_alert_response` (
  `modified` varchar(100) NOT NULL,
  `globals` varchar(100) NOT NULL,
  `regions` varchar(100) NOT NULL,
  `countires` varchar(100) NOT NULL,
  PRIMARY KEY (`modified`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `isos_category`
--

CREATE TABLE IF NOT EXISTS `isos_category` (
  `id` int(255) NOT NULL,
  `desc` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `isos_country_alert`
--

CREATE TABLE IF NOT EXISTS `isos_country_alert` (
  `modified` varchar(100) NOT NULL,
  `country` varchar(100) NOT NULL,
  `lang` varchar(50) NOT NULL,
  `name` varchar(100) NOT NULL,
  `update` int(100) NOT NULL,
  PRIMARY KEY (`modified`,`country`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `isos_global_alert`
--

CREATE TABLE IF NOT EXISTS `isos_global_alert` (
  `modified` varchar(100) NOT NULL,
  `lang` varchar(50) NOT NULL,
  `update` int(100) NOT NULL,
  PRIMARY KEY (`modified`,`lang`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `isos_region_alert`
--

CREATE TABLE IF NOT EXISTS `isos_region_alert` (
  `modified` varchar(100) NOT NULL,
  `id` int(100) NOT NULL,
  `lang` varchar(50) NOT NULL,
  `name` varchar(100) NOT NULL,
  `update` int(100) NOT NULL,
  PRIMARY KEY (`modified`,`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `isos_update`
--

CREATE TABLE IF NOT EXISTS `isos_update` (
  `herf` varchar(100) NOT NULL,
  `title` varchar(100) NOT NULL,
  `summary` text NOT NULL,
  `created` varchar(100) NOT NULL,
  `modified` varchar(100) NOT NULL,
  `longi` int(11) NOT NULL,
  `lat` int(11) NOT NULL,
  `id` int(50) NOT NULL,
  `version` int(11) NOT NULL,
  `special_advisory` tinyint(1) NOT NULL,
  `body` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `isos_update_cat`
--

CREATE TABLE IF NOT EXISTS `isos_update_cat` (
  `id` int(50) NOT NULL,
  `cat` int(255) NOT NULL,
  PRIMARY KEY (`id`,`cat`),
  KEY `cat` (`cat`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sos_message`
--

CREATE TABLE IF NOT EXISTS `sos_message` (
  `uuid` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `lat` double NOT NULL,
  `long` double NOT NULL,
  `initialisationDate` datetime NOT NULL,
  `message` text,
  `is_resloved` tinyint(1) NOT NULL DEFAULT '0',
  `last_update` datetime NOT NULL,
  PRIMARY KEY (`uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sos_message`
--

INSERT INTO `sos_message` (`uuid`, `email`, `lat`, `long`, `initialisationDate`, `message`, `is_resloved`, `last_update`) VALUES
('b932d34b-cd55-485a-8f56-b0ffc75eb716', 'marcus.lee.2015@smu.edu.sg', 1.29027, 103.851959, '2017-08-05 10:00:00', 'I need help I am trapped in school!', 0, '2017-08-05 10:03:00');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `email` varchar(100) NOT NULL,
  `name` varchar(100) NOT NULL,
  `contact_num` int(15) DEFAULT NULL,
  `region_code` int(3) DEFAULT NULL,
  `is_admin` tinyint(1) NOT NULL,
  `is_male` tinyint(1) NOT NULL,
  `lat` double DEFAULT NULL,
  `longi` double DEFAULT NULL,
  PRIMARY KEY (`email`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`email`, `name`, `contact_num`, `region_code`, `is_admin`, `is_male`, `lat`, `longi`) VALUES
('marcus.lee.2015@smu.edu.sg', 'Marcus Lee', 98567423, 65, 0, 1, 1.29027, 103.851959),
('jaren.lim.2015@smu.edu.sg', 'Jaren Lim', 97856412, 65, 1, 1, 1.29027, 103.851959);

-- --------------------------------------------------------

--
-- Table structure for table `user_reg`
--

CREATE TABLE IF NOT EXISTS `user_reg` (
  `email` varchar(100) NOT NULL,
  `reg_id` varchar(100) NOT NULL,
  PRIMARY KEY (`email`,`reg_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
