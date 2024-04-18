-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Feb 29. 13:55
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `futar.accdb`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `cim`
--

CREATE TABLE `cim` (
  `cím` varchar(255) NOT NULL,
  `elnevezés` varchar(255) NOT NULL,
  `kerület` varchar(255) NOT NULL,
  `utca` varchar(255) NOT NULL,
  `hszám` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `cim`
--

INSERT INTO `cim` (`cím`, `elnevezés`, `kerület`, `utca`, `hszám`) VALUES
('1011 Budapest', 'Hilton Hotel', 'I.', 'Budai Vár', 1),
('1012 Budapest', 'Hotel Palazzo Zichy', 'I.', 'Lőrinc pap tér', 2),
('1023 Budapest', 'Mammut Bevásárlóközpont', 'II.', 'Lövőház utca', 2),
('1024 Budapest', 'MOM Sport', 'II.', 'Csörsz utca', 14),
('1027 Budapest', 'Mom Beach', 'II.', 'Árpád fejedelem útja', 94),
('1033 Budapest', 'Flórián Üzletközpont', 'III.', 'Nagy Lajos király útja', 158),
('1037 Budapest', 'Dunakeszi Plaza', 'III.', 'Fóti út', 57),
('1046 Budapest', 'EuroCenter', 'IV.', 'Szentmihályi út', 171),
('1052 Budapest', 'Váci utca 1.', 'V.', 'Váci utca', 1),
('1062 Budapest', 'MOM Park', 'VI.', 'Alkotás utca', 53),
('1066 Budapest', 'WestEnd Offices', 'VI.', 'Váci út', 19),
('1077 Budapest', 'Arena Plaza', 'VII.', 'Kerepesi út', 9),
('1093 Budapest', 'Corvin Plaza', 'IX.', 'Futó utca', 37),
('1095 Budapest', 'Lurdy Ház Bevásárlóközpont', 'IX.', 'Könyves Kálmán körút', 12),
('1106 Budapest', 'Örs Vezér tere', 'X.', 'Könyves Kálmán körút', 12),
('1117 Budapest', 'Allee Bevásárlóközpont', 'XI.', 'Október huszonharmadika utca', 8),
('1123 Budapest', 'EuroPark Bevásárlóközpont', 'XII.', 'Nagytétényi út', 37),
('1132 Budapest', 'Duna Plaza', 'XIII.', 'Váci út', 178),
('1133 Budapest', 'Lehel Csarnok', 'XIII.', 'Váci út', 96),
('1137 Budapest', 'Westend City Center', 'XIII.', 'Váci út', 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `futár`
--

CREATE TABLE `futár` (
  `f_szám` varchar(255) NOT NULL,
  `f_név` varchar(255) NOT NULL,
  `f_tel` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `futár`
--

INSERT INTO `futár` (`f_szám`, `f_név`, `f_tel`) VALUES
('F001', 'Kovács János', '+36 30 123 4567'),
('F002', 'Nagy Emília', '+36 20 987 6543'),
('F003', 'Kiss Péter', '+36 70 555 1234'),
('F004', 'Varga Anna', '+36 30 444 7890'),
('F005', 'Tóth Gábor', '+36 20 333 2222'),
('F006', 'Molnár Ágnes', '+36 70 111 9999'),
('F007', 'Szabó István', '+36 30 777 8888'),
('F008', 'Horváth Éva', '+36 20 222 3333'),
('F009', 'Fekete Tamás', '+36 70 666 5555'),
('F010', 'Balogh Zsolt', '+36 30 999 1111'),
('F011', 'Király Orsolya', '+36 20 333 2222'),
('F012', 'Takács László', '+36 70 555 4444'),
('F013', 'Németh Krisztina', '+36 30 888 7777'),
('F014', 'Papp Csaba', '+36 20 777 8888'),
('F015', 'Gál Mária', '+36 70 222 3333'),
('F016', 'Bíró Attila', '+36 30 111 9999'),
('F017', 'Juhász Viktória', '+36 20 666 5555'),
('F018', 'Simon Balázs', '+36 70 333 2222'),
('F019', 'Szűcs Anna', '+36 30 444 7890'),
('F020', 'Török András', '+36 20 999 1111');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `küldemény`
--

CREATE TABLE `küldemény` (
  `azonosító` int(11) NOT NULL,
  `kelt` datetime NOT NULL,
  `időpont` datetime NOT NULL,
  `kitől` varchar(255) NOT NULL,
  `kinek` varchar(255) NOT NULL,
  `f_szám` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `küldemény`
--

INSERT INTO `küldemény` (`azonosító`, `kelt`, `időpont`, `kitől`, `kinek`, `f_szám`) VALUES
(1, '2024-02-29 08:00:00', '2024-02-29 12:00:00', 'Kovács János', 'Nagy Emília', 'F001'),
(2, '2024-02-29 08:30:00', '2024-02-29 12:30:00', 'Nagy Emília', 'Kiss Péter', 'F002'),
(3, '2024-02-29 09:00:00', '2024-02-29 13:00:00', 'Kiss Péter', 'Varga Anna', 'F003'),
(4, '2024-02-29 09:30:00', '2024-02-29 13:30:00', 'Varga Anna', 'Tóth Gábor', 'F004'),
(5, '2024-02-29 10:00:00', '2024-02-29 14:00:00', 'Tóth Gábor', 'Molnár Ágnes', 'F005'),
(6, '2024-02-29 10:30:00', '2024-02-29 14:30:00', 'Molnár Ágnes', 'Szabó István', 'F006'),
(7, '2024-02-29 11:00:00', '2024-02-29 15:00:00', 'Szabó István', 'Horváth Éva', 'F007'),
(8, '2024-02-29 11:30:00', '2024-02-29 15:30:00', 'Horváth Éva', 'Fekete Tamás', 'F008'),
(9, '2024-02-29 12:00:00', '2024-02-29 16:00:00', 'Fekete Tamás', 'Balogh Zsolt', 'F009'),
(10, '2024-02-29 12:30:00', '2024-02-29 16:30:00', 'Balogh Zsolt', 'Király Orsolya', 'F010'),
(11, '2024-02-29 13:00:00', '2024-02-29 17:00:00', 'Király Orsolya', 'Takács László', 'F011'),
(12, '2024-02-29 13:30:00', '2024-02-29 17:30:00', 'Takács László', 'Németh Krisztina', 'F012'),
(13, '2024-02-29 14:00:00', '2024-02-29 18:00:00', 'Németh Krisztina', 'Papp Csaba', 'F013'),
(14, '2024-02-29 14:30:00', '2024-02-29 18:30:00', 'Papp Csaba', 'Gál Mária', 'F014'),
(15, '2024-02-29 15:00:00', '2024-02-29 19:00:00', 'Gál Mária', 'Bíró Attila', 'F015'),
(16, '2024-02-29 15:30:00', '2024-02-29 19:30:00', 'Bíró Attila', 'Juhász Viktória', 'F016'),
(17, '2024-02-29 16:00:00', '2024-02-29 20:00:00', 'Juhász Viktória', 'Simon Balázs', 'F017'),
(18, '2024-02-29 16:30:00', '2024-02-29 20:30:00', 'Simon Balázs', 'Szűcs Anna', 'F018'),
(19, '2024-02-29 17:00:00', '2024-02-29 21:00:00', 'Szűcs Anna', 'Török András', 'F019'),
(20, '2024-02-29 17:30:00', '2024-02-29 21:30:00', 'Török András', 'Kovács János', 'F020');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `partner`
--

CREATE TABLE `partner` (
  `kód` varchar(255) NOT NULL,
  `név` varchar(255) NOT NULL,
  `telefon` varchar(255) NOT NULL,
  `cím` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `partner`
--

INSERT INTO `partner` (`kód`, `név`, `telefon`, `cím`) VALUES
('P001', 'ABC Kft.', '+36 1 123 4567', '1011 Budapest'),
('P002', 'DEF Zrt.', '+36 1 234 5678', '1137 Budapest'),
('P003', 'GHI Bt.', '+36 1 345 6789', '1093 Budapest'),
('P004', 'JKL Kft.', '+36 1 456 7890', '1066 Budapest'),
('P005', 'MNO Zrt.', '+36 1 567 8901', '1117 Budapest'),
('P006', 'PQR Bt.', '+36 1 678 9012', '1023 Budapest'),
('P007', 'STU Kft.', '+36 1 789 0123', '1052 Budapest'),
('P008', 'VWX Zrt.', '+36 1 890 1234', '1077 Budapest'),
('P009', 'YZA Bt.', '+36 1 901 2345', '1095 Budapest'),
('P010', 'BCD Kft.', '+36 1 012 3456', '1012 Budapest'),
('P011', 'EFG Zrt.', '+36 1 123 4567', '1133 Budapest'),
('P012', 'HIJ Bt.', '+36 1 234 5678', '1062 Budapest'),
('P013', 'KLM Kft.', '+36 1 345 6789', '1132 Budapest'),
('P014', 'NOP Zrt.', '+36 1 456 7890', '1033 Budapest'),
('P015', 'QRS Bt.', '+36 1 567 8901', '1106 Budapest'),
('P016', 'STU Kft.', '+36 1 678 9012', '1037 Budapest'),
('P017', 'VWX Zrt.', '+36 1 789 0123', '1046 Budapest'),
('P018', 'YZA Bt.', '+36 1 890 1234', '1123 Budapest'),
('P019', 'BCD Kft.', '+36 1 901 2345', '1027 Budapest'),
('P020', 'EFG Zrt.', '+36 1 012 3456', '1024 Budapest');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `cim`
--
ALTER TABLE `cim`
  ADD PRIMARY KEY (`cím`);

--
-- A tábla indexei `futár`
--
ALTER TABLE `futár`
  ADD PRIMARY KEY (`f_szám`);

--
-- A tábla indexei `küldemény`
--
ALTER TABLE `küldemény`
  ADD PRIMARY KEY (`azonosító`),
  ADD KEY `f_szám` (`f_szám`);

--
-- A tábla indexei `partner`
--
ALTER TABLE `partner`
  ADD PRIMARY KEY (`kód`),
  ADD KEY `fk_partner_cím` (`cím`);

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `küldemény`
--
ALTER TABLE `küldemény`
  ADD CONSTRAINT `küldemény_ibfk_1` FOREIGN KEY (`f_szám`) REFERENCES `futár` (`f_szám`);

--
-- Megkötések a táblához `partner`
--
ALTER TABLE `partner`
  ADD CONSTRAINT `fk_partner_cím` FOREIGN KEY (`cím`) REFERENCES `cim` (`cím`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
