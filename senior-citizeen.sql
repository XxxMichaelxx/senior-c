-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 07, 2023 at 06:45 AM
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
-- Database: `senior-citizeen`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id` int(10) NOT NULL,
  `name` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id`, `name`, `username`, `password`) VALUES
(1, 'administrator', 'admin', 'admin123');

-- --------------------------------------------------------

--
-- Table structure for table `tblseniorcitizen`
--

CREATE TABLE `tblseniorcitizen` (
  `ID` int(5) NOT NULL,
  `RegistrationNumber` int(10) DEFAULT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `DateofBirth` date DEFAULT NULL,
  `ContactNumber` bigint(10) DEFAULT NULL,
  `CommunicationAddress` mediumtext DEFAULT NULL,
  `ProfilePic` varchar(250) DEFAULT NULL,
  `EmergencyAddress` mediumtext DEFAULT NULL,
  `EmergencyContactnumber` bigint(10) DEFAULT NULL,
  `AddedBy` varchar(100) DEFAULT NULL,
  `RegitrationDate` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblseniorcitizen`
--

INSERT INTO `tblseniorcitizen` (`ID`, `RegistrationNumber`, `Name`, `DateofBirth`, `ContactNumber`, `CommunicationAddress`, `ProfilePic`, `EmergencyAddress`, `EmergencyContactnumber`, `AddedBy`, `RegitrationDate`) VALUES
(6, 965451600, 'Jane Merrymae Uban', '1950-01-02', 912345678, 'Hakdog', '9a78d4e4966e44eb7e2d32a6e7f90d1a1688387949.jpg', 'Hakdog', 912345678, 'admin', '2023-07-03 12:39:09'),
(7, 999023137, 'Bakulaw', '1960-01-01', 1234567890, 'Hakdooog', '794e98dc9540fb8db4f6a52459ee2ffd1688389260.jpg', 'Hakdooog', 1234567890, 'admin', '2023-07-03 13:01:00'),
(8, 2147483647, 'aaaaaa', '2023-07-03', 1231231, 'aaaa12', NULL, '1231231', NULL, NULL, '2023-07-03 15:57:39'),
(9, 2147483647, 'bbbbbbb', '2023-07-04', 1231231231, 'bbbbbb', NULL, 'bbbbbb', 1231231231, NULL, '2023-07-03 16:10:08');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tblseniorcitizen`
--
ALTER TABLE `tblseniorcitizen`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tblseniorcitizen`
--
ALTER TABLE `tblseniorcitizen`
  MODIFY `ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
