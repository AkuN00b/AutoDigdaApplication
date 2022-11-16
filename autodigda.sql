-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3307
-- 생성 시간: 22-11-16 01:47
-- 서버 버전: 10.4.11-MariaDB
-- PHP 버전: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- 데이터베이스: `autodigda`
--

DELIMITER $$
--
-- 프로시저
--
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
-- 테이블 구조 `login`
--

CREATE TABLE `login` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `id_perusahaan` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 테이블의 덤프 데이터 `login`
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
-- 테이블 구조 `perusahaan`
--

CREATE TABLE `perusahaan` (
  `id` int(11) NOT NULL,
  `nama` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 테이블의 덤프 데이터 `perusahaan`
--

INSERT INTO `perusahaan` (`id`, `nama`) VALUES
(1, 'Perusahaan A'),
(2, 'Perusahaan B');

--
-- 덤프된 테이블의 인덱스
--

--
-- 테이블의 인덱스 `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_perusahaan` (`id_perusahaan`);

--
-- 테이블의 인덱스 `perusahaan`
--
ALTER TABLE `perusahaan`
  ADD PRIMARY KEY (`id`);

--
-- 덤프된 테이블의 AUTO_INCREMENT
--

--
-- 테이블의 AUTO_INCREMENT `login`
--
ALTER TABLE `login`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- 테이블의 AUTO_INCREMENT `perusahaan`
--
ALTER TABLE `perusahaan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- 덤프된 테이블의 제약사항
--

--
-- 테이블의 제약사항 `login`
--
ALTER TABLE `login`
  ADD CONSTRAINT `login_ibfk_1` FOREIGN KEY (`id_perusahaan`) REFERENCES `perusahaan` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
