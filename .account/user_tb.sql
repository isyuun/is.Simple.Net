-- phpMyAdmin SQL Dump
-- version 4.2.9
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Jun 20, 2017 at 05:54 PM
-- Server version: 5.6.20
-- PHP Version: 5.6.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `game_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `user_tb`
--

CREATE TABLE IF NOT EXISTS `user_tb` (
  `id` varchar(255)  NOT NULL COMMENT '유저아이디',
  `pw` varchar(255) NOT NULL COMMENT '유저패스워드',
  `best_click_count` int(11) NOT NULL DEFAULT '0' COMMENT '최고클릭횟수',
  `total_click_count` int(11) NOT NULL DEFAULT '0' COMMENT '전체클릭횟수',
  `ctype` int(11) NOT NULL DEFAULT '0' COMMENT '캐릭터타입'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='유저게임데이터';

--
-- Dumping data for table `user_tb`
--

INSERT INTO `user_tb` (`id`, `pw`, `best_click_count`, `total_click_count`, `ctype`) VALUES
('Dele1', '1234', 0, 0, 0),
('Test1', '4567', 100, 1000, 2),
('User1', '1234', 11, 110, 5),
('User2', '1234', 22, 220, 4),
('User3', '1234', 33, 3330, 3),
('User4', '1234', 44, 440, 2),
('User5', '1234', 55, 550, 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `user_tb`
--
ALTER TABLE `user_tb`
 ADD PRIMARY KEY (`id`);

-- ALTER TABLE `user_tb`
-- ADD `id` varchar(256) NOT NULL CHECK (id <> '')

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
