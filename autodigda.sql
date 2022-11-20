-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3307
-- Generation Time: Nov 20, 2022 at 07:00 AM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `autodigda`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetHardware` ()  BEGIN
	SELECT * FROM hardware;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetMonitoring` (IN `Pid_hardware` INT)  BEGIN
	SELECT * FROM monitoring WHERE id_hardware = Pid_hardware;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetPerusahaanByID` (IN `PkodePerusahaan` INT(11))  BEGIN
	SELECT * FROM perusahaan WHERE id = PkodePerusahaan;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Login` (IN `Pusername` VARCHAR(255), IN `Ppassword` VARCHAR(255), IN `PkodePerusahaan` INT(11))  BEGIN
	SELECT l.id, l.username, l.password, l.id_perusahaan, p.nama
    FROM login l
    INNER JOIN perusahaan p ON p.id = l.id_perusahaan
    WHERE l.username = Pusername AND l.password = Ppassword AND l.id_perusahaan = PkodePerusahaan;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_RegistrasiAkun` (IN `Pusername` VARCHAR(255), IN `Ppassword` VARCHAR(255), IN `PkodePerusahaan` INT(11))  BEGIN
	INSERT INTO login (username, password, id_perusahaan) VALUES (Pusername, Ppassword, PkodePerusahaan);
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `hardware`
--

CREATE TABLE `hardware` (
  `id` int(11) NOT NULL,
  `nama` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `hardware`
--

INSERT INTO `hardware` (`id`, `nama`) VALUES
(1, 'agv001'),
(2, 'agv002'),
(3, 'agv003'),
(4, 'agv004'),
(5, 'agv005');

-- --------------------------------------------------------

--
-- Table structure for table `line_monitoring`
--

CREATE TABLE `line_monitoring` (
  `id_hardware` int(11) NOT NULL,
  `sensor` int(11) NOT NULL,
  `time` int(11) NOT NULL,
  `value` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `line_monitoring`
--

INSERT INTO `line_monitoring` (`id_hardware`, `sensor`, `time`, `value`) VALUES
(1, 1, 1, 10),
(1, 1, 2, 20),
(1, 1, 3, 30),
(1, 1, 4, 40),
(1, 1, 5, 50),
(1, 1, 6, 60),
(1, 1, 7, 70);

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `id_perusahaan` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`id`, `username`, `password`, `id_perusahaan`) VALUES
(1, 'username1', 'password1', 1),
(2, 'username2', 'password2', 2),
(4, 'username3', 'password3', 1),
(5, 'username4', 'password4', 2),
(6, 'username5', 'password5', 2),
(7, 'username6', 'password6', 1);

-- --------------------------------------------------------

--
-- Table structure for table `monitoring`
--

CREATE TABLE `monitoring` (
  `id_hardware` int(11) NOT NULL,
  `sensor1` float NOT NULL,
  `sensor2` float NOT NULL,
  `sensor3` float NOT NULL,
  `sensor4` float NOT NULL,
  `sensor5` float NOT NULL,
  `sensor6` float NOT NULL,
  `sensor7` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `monitoring`
--

INSERT INTO `monitoring` (`id_hardware`, `sensor1`, `sensor2`, `sensor3`, `sensor4`, `sensor5`, `sensor6`, `sensor7`) VALUES
(1, 10, 10, 10, 10, 10, 10, 10),
(2, 20, 20, 20, 20, 20, 20, 20),
(3, 30, 30, 30, 30, 30, 30, 30),
(4, 40, 40, 40, 40, 40, 40, 40),
(5, 50, 50, 50, 50, 50, 50, 50);

-- --------------------------------------------------------

--
-- Table structure for table `perusahaan`
--

CREATE TABLE `perusahaan` (
  `id` int(11) NOT NULL,
  `nama` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `perusahaan`
--

INSERT INTO `perusahaan` (`id`, `nama`) VALUES
(1, 'Perusahaan A'),
(2, 'Perusahaan B');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `hardware`
--
ALTER TABLE `hardware`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `line_monitoring`
--
ALTER TABLE `line_monitoring`
  ADD KEY `id_hardware` (`id_hardware`);

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_perusahaan` (`id_perusahaan`);

--
-- Indexes for table `monitoring`
--
ALTER TABLE `monitoring`
  ADD KEY `id_hardware` (`id_hardware`);

--
-- Indexes for table `perusahaan`
--
ALTER TABLE `perusahaan`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `hardware`
--
ALTER TABLE `hardware`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `login`
--
ALTER TABLE `login`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `perusahaan`
--
ALTER TABLE `perusahaan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `line_monitoring`
--
ALTER TABLE `line_monitoring`
  ADD CONSTRAINT `line_monitoring_ibfk_1` FOREIGN KEY (`id_hardware`) REFERENCES `hardware` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `login`
--
ALTER TABLE `login`
  ADD CONSTRAINT `login_ibfk_1` FOREIGN KEY (`id_perusahaan`) REFERENCES `perusahaan` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `monitoring`
--
ALTER TABLE `monitoring`
  ADD CONSTRAINT `monitoring_ibfk_1` FOREIGN KEY (`id_hardware`) REFERENCES `hardware` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
