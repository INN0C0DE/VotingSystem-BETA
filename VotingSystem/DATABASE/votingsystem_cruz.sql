-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 12, 2022 at 03:50 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `votingsystem_cruz`
--

-- --------------------------------------------------------

--
-- Table structure for table `candidates`
--

CREATE TABLE `candidates` (
  `Candidate_number` int(11) NOT NULL,
  `Full_name` varchar(50) NOT NULL,
  `Position` varchar(50) NOT NULL,
  `Partylist_number` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `candidates`
--

INSERT INTO `candidates` (`Candidate_number`, `Full_name`, `Position`, `Partylist_number`) VALUES
(1, 'Rachelle Ann Dela Isla', 'President', 1),
(2, 'Ralph Arnolds', 'President', 3),
(5, 'Alexa', 'President', 2),
(8, 'Joseph Santos', 'Treasurer', 2),
(10, 'Jacob', 'Secretary', 2);

-- --------------------------------------------------------

--
-- Table structure for table `party_list`
--

CREATE TABLE `party_list` (
  `Partylist_number` int(11) NOT NULL,
  `Partylist_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `party_list`
--

INSERT INTO `party_list` (`Partylist_number`, `Partylist_name`) VALUES
(1, 'Students Party List'),
(2, 'Teachers Party List'),
(3, 'IT Party List ');

-- --------------------------------------------------------

--
-- Table structure for table `voters`
--

CREATE TABLE `voters` (
  `Student_number` int(11) NOT NULL,
  `First_name` varchar(50) NOT NULL,
  `Middle_name` varchar(50) NOT NULL,
  `Last_name` varchar(50) NOT NULL,
  `Course` varchar(50) NOT NULL,
  `Year_Section` varchar(50) NOT NULL,
  `Email` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `voters`
--

INSERT INTO `voters` (`Student_number`, `First_name`, `Middle_name`, `Last_name`, `Course`, `Year_Section`, `Email`) VALUES
(200119, 'Rachelle Ann', 'Hodulla', 'Dela Isa', 'BS Architecture', '1A', 'gmail'),
(200496, 'Ezekiel', 'Jacob', 'Blaze', 'BSIT', '2A', 'gmail'),
(200548, 'Mary', 'Avelino', 'Avena', 'BST', '2A', 'gmail'),
(200549, 'Raphael Arnaldo', 'Soliva', 'Cruz', 'BSIT', '2A', 'gmail'),
(200864, 'Lara Jean', 'M', 'San Jose', 'BS Social Studies', '2A', 'gmail');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `candidates`
--
ALTER TABLE `candidates`
  ADD PRIMARY KEY (`Candidate_number`),
  ADD KEY `Partylist_number` (`Partylist_number`);

--
-- Indexes for table `party_list`
--
ALTER TABLE `party_list`
  ADD PRIMARY KEY (`Partylist_number`,`Partylist_name`);

--
-- Indexes for table `voters`
--
ALTER TABLE `voters`
  ADD PRIMARY KEY (`Student_number`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `candidates`
--
ALTER TABLE `candidates`
  ADD CONSTRAINT `candidates_ibfk_1` FOREIGN KEY (`Partylist_number`) REFERENCES `party_list` (`Partylist_number`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
