-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Gegenereerd op: 15 mei 2020 om 09:10
-- Serverversie: 10.4.11-MariaDB
-- PHP-versie: 7.4.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `javagameapi`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `achievement`
--

CREATE TABLE `achievement` (
  `ID` int(11) NOT NULL,
  `Name` longtext DEFAULT NULL,
  `Description` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `level`
--

CREATE TABLE `level` (
  `ID` int(11) NOT NULL,
  `Name` longtext DEFAULT NULL,
  `Description` longtext DEFAULT NULL,
  `Content` longtext DEFAULT NULL,
  `Creatorid` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Gegevens worden geëxporteerd voor tabel `level`
--

INSERT INTO `level` (`ID`, `Name`, `Description`, `Content`, `Creatorid`) VALUES
(1, 'LEVEL_1', 'SUPERTESTLEVEL', '{\"endpoint\":[13,6],\"name\":\"Jochem\'s playground\",\"ground\":[[1,1],[1,3],[1,4],[1,5],[1,6],[1,7],[1,9],[2,1],[2,3],[2,7],[2,8],[2,9],[3,1],[3,2],[3,3],[3,9],[4,9],[5,1],[5,2],[5,3],[5,9],[6,3],[6,7],[6,8],[6,9],[7,3],[7,7],[8,3],[8,4],[8,5],[8,6],[8,7],[8,8],[8,9],[8,10],[9,10],[10,6],[10,10],[11,6],[11,7],[11,8],[11,9],[11,10],[12,6],[13,6],[4,3],[4,2],[4,1],[8,2],[7,2],[6,2],[6,1],[7,1],[8,1],[9,1],[10,1],[11,1],[11,2],[11,3],[10,3],[10,4],[10,5],[10,7],[11,5],[11,4],[10,2],[12,2],[12,3],[12,4],[12,5],[13,5],[14,5],[14,4],[14,3],[13,3],[13,2],[12,1],[13,1],[14,1],[14,2],[13,4]],\"torches\":[],\"player\":[1,1]}', 1),
(2, 'AnderTestLevel', '123', '{\"endpoint\":[26,9],\"name\":\"Level 5\",\"ground\":[[1,18],[2,18],[3,18],[3,17],[2,17],[1,17],[1,16],[2,16],[3,16],[4,17],[5,17],[5,18],[6,18],[7,18],[7,17],[6,17],[6,16],[7,16],[5,16],[8,17],[9,17],[9,18],[10,18],[11,18],[11,17],[11,16],[10,16],[10,17],[9,16],[10,15],[10,14],[9,14],[9,13],[10,13],[10,12],[11,13],[11,14],[11,12],[9,12],[8,13],[7,13],[7,14],[6,14],[5,14],[5,13],[6,13],[6,12],[7,12],[5,12],[6,11],[6,10],[7,10],[5,10],[5,9],[6,9],[7,9],[7,8],[6,8],[5,8],[6,7],[7,6],[6,6],[5,6],[5,5],[5,4],[6,4],[6,5],[7,5],[7,4],[8,5],[9,5],[9,6],[10,6],[11,6],[11,5],[11,4],[10,4],[9,4],[10,5],[12,13],[13,13],[13,14],[14,14],[14,13],[14,12],[13,12],[15,12],[15,13],[15,14],[14,15],[14,16],[14,17],[14,18],[15,18],[15,17],[15,16],[13,17],[13,18],[13,16],[16,17],[17,17],[17,18],[18,18],[19,18],[19,17],[18,17],[18,16],[17,16],[19,16],[20,17],[21,17],[21,18],[22,18],[23,18],[23,17],[23,16],[22,16],[21,16],[22,17],[22,15],[22,14],[21,14],[23,14],[23,13],[23,12],[22,12],[21,12],[21,13],[22,13],[22,11],[22,10],[23,10],[23,9],[23,8],[22,8],[22,9],[21,9],[21,10],[21,8],[22,7],[22,6],[23,6],[23,5],[22,5],[22,4],[21,5],[21,6],[23,4],[21,4],[20,5],[19,5],[19,6],[18,6],[18,5],[18,4],[19,4],[17,5],[17,4],[17,6],[16,5],[14,5],[15,5],[15,6],[14,6],[14,4],[13,4],[15,4],[13,5],[13,6],[14,7],[13,8],[14,8],[15,8],[15,9],[14,9],[13,9],[14,10],[13,10],[15,10],[12,5],[16,13],[17,13],[18,13],[18,14],[19,14],[19,13],[19,12],[18,12],[17,12],[17,14],[18,11],[18,10],[19,10],[19,9],[19,8],[18,8],[18,9],[17,9],[17,10],[17,8],[8,9],[9,9],[9,10],[10,10],[11,10],[11,9],[11,8],[10,8],[9,8],[10,9],[24,17],[25,17],[25,18],[26,18],[27,18],[27,17],[26,16],[25,16],[26,17],[27,16],[24,5],[25,5],[25,6],[26,6],[27,5],[27,4],[26,4],[25,4],[26,5],[27,6],[4,5],[3,5],[3,6],[2,6],[1,6],[1,5],[1,4],[2,4],[3,4],[2,5],[26,7],[25,8],[25,9],[26,9],[26,10],[27,10],[27,9],[27,8],[26,8],[25,10],[2,15],[3,14],[2,14],[1,14],[1,13],[1,12],[2,12],[3,13],[2,13],[3,12],[3,8],[3,9],[2,9],[2,10],[1,10],[1,9],[1,8],[2,8],[3,10],[4,9],[26,15],[27,14],[26,14],[25,14],[25,13],[25,12],[26,12],[27,12],[27,13],[26,13]],\"torches\":[[4,16],[4,8],[12,6],[20,6],[26,11],[24,16],[16,16],[17,11]],\"player\":[2,13]}', 1),
(3, 'NogEenAnderTestLevel', '123123123123', '{\"endpoint\":[33,18],\"name\":\"Level 8\",\"ground\":[[35,18],[35,17],[35,16],[35,15],[35,14],[35,13],[35,12],[35,11],[35,10],[35,9],[35,8],[35,7],[35,6],[35,5],[35,3],[35,2],[35,1],[35,4],[34,1],[33,1],[32,1],[31,1],[30,1],[29,1],[28,1],[27,1],[26,1],[25,1],[24,1],[23,1],[22,1],[21,1],[20,1],[19,1],[18,1],[17,1],[16,1],[15,1],[14,1],[13,1],[12,1],[11,1],[10,1],[9,1],[8,1],[7,1],[6,1],[5,1],[4,1],[3,1],[2,1],[1,1],[1,3],[1,5],[1,6],[1,7],[1,10],[1,9],[1,11],[1,13],[1,14],[1,17],[1,18],[2,18],[3,18],[5,18],[6,18],[7,18],[9,18],[10,18],[11,18],[13,18],[14,18],[15,18],[17,18],[18,18],[19,18],[21,18],[22,18],[23,18],[25,18],[26,18],[27,18],[29,18],[30,18],[31,18],[33,18],[2,3],[3,3],[4,3],[5,3],[6,3],[7,3],[8,3],[9,3],[10,3],[11,3],[12,3],[13,3],[14,3],[15,3],[16,3],[17,3],[18,3],[19,3],[20,3],[21,3],[22,3],[23,3],[24,3],[25,3],[26,3],[27,3],[28,3],[29,3],[30,3],[31,3],[32,3],[33,3],[33,4],[33,5],[32,5],[31,5],[30,5],[29,5],[28,5],[27,5],[26,5],[25,5],[24,5],[23,5],[22,5],[21,5],[20,5],[19,5],[18,5],[17,5],[16,5],[15,5],[14,5],[13,5],[12,5],[11,5],[10,5],[9,5],[8,5],[7,5],[6,5],[5,5],[4,5],[3,5],[2,5],[2,7],[3,7],[4,7],[5,7],[6,7],[7,7],[8,7],[9,7],[10,7],[11,7],[12,7],[13,7],[14,7],[15,7],[16,7],[17,7],[18,7],[19,7],[20,7],[21,7],[22,7],[23,7],[24,7],[25,7],[26,7],[27,7],[28,7],[29,7],[30,7],[31,7],[32,7],[33,8],[33,7],[33,9],[31,9],[30,9],[29,9],[28,9],[27,9],[32,9],[26,9],[25,9],[24,9],[23,9],[22,9],[21,9],[20,9],[19,9],[18,9],[17,9],[16,9],[15,9],[14,9],[13,9],[12,9],[11,9],[10,9],[9,9],[8,9],[7,9],[6,9],[5,9],[4,9],[3,9],[2,9],[2,11],[3,11],[4,11],[5,11],[6,11],[7,11],[8,11],[9,11],[10,11],[11,11],[12,11],[13,11],[14,11],[15,11],[16,11],[17,11],[18,11],[19,11],[20,11],[21,11],[22,11],[23,11],[24,11],[25,11],[26,11],[27,11],[28,11],[29,11],[30,11],[31,11],[32,11],[32,13],[31,13],[30,13],[24,13],[23,13],[22,13],[21,13],[20,13],[25,13],[26,13],[27,13],[28,13],[29,13],[19,13],[18,13],[17,13],[16,13],[15,13],[14,13],[13,13],[12,13],[11,13],[10,13],[9,13],[8,13],[7,13],[6,13],[5,13],[4,13],[3,13],[2,13],[1,15],[3,15],[4,15],[7,15],[8,15],[9,15],[11,15],[12,15],[13,15],[15,15],[16,15],[17,15],[19,15],[20,15],[21,15],[23,15],[24,15],[25,15],[27,15],[28,15],[29,15],[31,15],[32,15],[33,15],[33,16],[33,17],[1,2],[1,16],[3,17],[3,16],[5,15],[5,16],[5,17],[7,17],[7,16],[9,16],[9,17],[11,16],[11,17],[13,16],[13,17],[15,16],[15,17],[17,16],[17,17],[19,16],[19,17],[21,16],[21,17],[23,16],[23,17],[25,16],[25,17],[27,16],[27,17],[29,16],[29,17],[31,16],[31,17],[33,13],[33,11],[33,12]],\"torches\":[[34,18]],\"player\":[35,18]}', 1),
(4, 'LEVEL_2123123123', 'SUPERTESTLEVEL1231231231231232132', '{\"endpoint\":[13,6],\"name\":\"Jochem\'s playground\",\"ground\":[[1,1],[1,3],[1,4],[1,5],[1,6],[1,7],[1,9],[2,1],[2,3],[2,7],[2,8],[2,9],[3,1],[3,2],[3,3],[3,9],[4,9],[5,1],[5,2],[5,3],[5,9],[6,3],[6,7],[6,8],[6,9],[7,3],[7,7],[8,3],[8,4],[8,5],[8,6],[8,7],[8,8],[8,9],[8,10],[9,10],[10,6],[10,10],[11,6],[11,7],[11,8],[11,9],[11,10],[12,6],[13,6],[4,3],[4,2],[4,1],[8,2],[7,2],[6,2],[6,1],[7,1],[8,1],[9,1],[10,1],[11,1],[11,2],[11,3],[10,3],[10,4],[10,5],[10,7],[11,5],[11,4],[10,2],[12,2],[12,3],[12,4],[12,5],[13,5],[14,5],[14,4],[14,3],[13,3],[13,2],[12,1],[13,1],[14,1],[14,2],[13,4]],\"torches\":[],\"player\":[1,1]}', 1),
(5, NULL, 'SUPERTESTLEVEL1231231231231232132', '{\"endpoint\":[13,6],\"name\":\"Jochem\'s playground\",\"ground\":[[1,1],[1,3],[1,4],[1,5],[1,6],[1,7],[1,9],[2,1],[2,3],[2,7],[2,8],[2,9],[3,1],[3,2],[3,3],[3,9],[4,9],[5,1],[5,2],[5,3],[5,9],[6,3],[6,7],[6,8],[6,9],[7,3],[7,7],[8,3],[8,4],[8,5],[8,6],[8,7],[8,8],[8,9],[8,10],[9,10],[10,6],[10,10],[11,6],[11,7],[11,8],[11,9],[11,10],[12,6],[13,6],[4,3],[4,2],[4,1],[8,2],[7,2],[6,2],[6,1],[7,1],[8,1],[9,1],[10,1],[11,1],[11,2],[11,3],[10,3],[10,4],[10,5],[10,7],[11,5],[11,4],[10,2],[12,2],[12,3],[12,4],[12,5],[13,5],[14,5],[14,4],[14,3],[13,3],[13,2],[12,1],[13,1],[14,1],[14,2],[13,4]],\"torches\":[],\"player\":[1,1]}', 1),
(6, NULL, 'SUPERTESTLEVEL1231231231231232132', '{\"endpoint\":[13,6],\"name\":\"Jochem\'s playground\",\"ground\":[[1,1],[1,3],[1,4],[1,5],[1,6],[1,7],[1,9],[2,1],[2,3],[2,7],[2,8],[2,9],[3,1],[3,2],[3,3],[3,9],[4,9],[5,1],[5,2],[5,3],[5,9],[6,3],[6,7],[6,8],[6,9],[7,3],[7,7],[8,3],[8,4],[8,5],[8,6],[8,7],[8,8],[8,9],[8,10],[9,10],[10,6],[10,10],[11,6],[11,7],[11,8],[11,9],[11,10],[12,6],[13,6],[4,3],[4,2],[4,1],[8,2],[7,2],[6,2],[6,1],[7,1],[8,1],[9,1],[10,1],[11,1],[11,2],[11,3],[10,3],[10,4],[10,5],[10,7],[11,5],[11,4],[10,2],[12,2],[12,3],[12,4],[12,5],[13,5],[14,5],[14,4],[14,3],[13,3],[13,2],[12,1],[13,1],[14,1],[14,2],[13,4]],\"torches\":[],\"player\":[1,1]}', 1),
(7, NULL, 'SUPERTESTLEVEL1231231231231232132', '{\"endpoint\":[13,6],\"name\":\"Jochem\'s playground\",\"ground\":[[1,1],[1,3],[1,4],[1,5],[1,6],[1,7],[1,9],[2,1],[2,3],[2,7],[2,8],[2,9],[3,1],[3,2],[3,3],[3,9],[4,9],[5,1],[5,2],[5,3],[5,9],[6,3],[6,7],[6,8],[6,9],[7,3],[7,7],[8,3],[8,4],[8,5],[8,6],[8,7],[8,8],[8,9],[8,10],[9,10],[10,6],[10,10],[11,6],[11,7],[11,8],[11,9],[11,10],[12,6],[13,6],[4,3],[4,2],[4,1],[8,2],[7,2],[6,2],[6,1],[7,1],[8,1],[9,1],[10,1],[11,1],[11,2],[11,3],[10,3],[10,4],[10,5],[10,7],[11,5],[11,4],[10,2],[12,2],[12,3],[12,4],[12,5],[13,5],[14,5],[14,4],[14,3],[13,3],[13,2],[12,1],[13,1],[14,1],[14,2],[13,4]],\"torches\":[],\"player\":[1,1]}', 1),
(8, 'LEVEL', 'SUPERTESTLEVEL1231231231231232132', '{\"endpoint\":[13,6],\"name\":\"LEVEL\",\"ground\":[[1,1],[1,3],[1,4],[1,5],[1,6],[1,7],[1,9],[2,1],[2,3],[2,7],[2,8],[2,9],[3,1],[3,2],[3,3],[3,9],[4,9],[5,1],[5,2],[5,3],[5,9],[6,3],[6,7],[6,8],[6,9],[7,3],[7,7],[8,3],[8,4],[8,5],[8,6],[8,7],[8,8],[8,9],[8,10],[9,10],[10,6],[10,10],[11,6],[11,7],[11,8],[11,9],[11,10],[12,6],[13,6],[4,3],[4,2],[4,1],[8,2],[7,2],[6,2],[6,1],[7,1],[8,1],[9,1],[10,1],[11,1],[11,2],[11,3],[10,3],[10,4],[10,5],[10,7],[11,5],[11,4],[10,2],[12,2],[12,3],[12,4],[12,5],[13,5],[14,5],[14,4],[14,3],[13,3],[13,2],[12,1],[13,1],[14,1],[14,2],[13,4]],\"torches\":[],\"player\":[1,1]}', 1);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `score`
--

CREATE TABLE `score` (
  `ID` int(11) NOT NULL,
  `ScoreAmount` double NOT NULL,
  `Timestamp` datetime(6) NOT NULL,
  `Userid` int(11) DEFAULT NULL,
  `ScoredOnID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Gegevens worden geëxporteerd voor tabel `score`
--

INSERT INTO `score` (`ID`, `ScoreAmount`, `Timestamp`, `Userid`, `ScoredOnID`) VALUES
(1, 77778888822, '1996-12-12 12:12:23.000000', 2, 1),
(3, 9999, '1996-12-12 00:00:00.000000', 1, 1),
(4, 1, '1996-12-12 00:00:00.000000', 1, 1),
(5, 123123, '1996-12-12 00:00:00.000000', 1, 1),
(6, 321, '2019-12-12 00:00:00.000000', 2, 1),
(7, 213, '2019-12-12 00:00:00.000000', 2, 1),
(8, 777, '2019-12-12 00:00:00.000000', 2, 1),
(9, 123, '1996-12-12 00:00:00.000000', 1, 1),
(10, 123, '1996-12-12 00:00:00.000000', 1, 1),
(11, 123, '1996-12-12 00:00:00.000000', 1, 1),
(12, 123, '1996-12-12 00:00:00.000000', 1, 1),
(13, 123, '1996-12-12 00:00:00.000000', 2, 1),
(14, 123, '1996-12-12 00:00:00.000000', 2, 1),
(15, 123, '1996-12-12 00:00:00.000000', 2, 1),
(16, 123, '1996-12-12 00:00:00.000000', 2, 1),
(17, 123, '1996-12-12 00:00:00.000000', 2, 1),
(18, 123, '1996-12-12 12:12:23.000000', 2, 1),
(19, 123, '1996-12-12 12:12:23.000000', 2, 1),
(20, 123, '1996-12-12 12:12:23.000000', 2, 1),
(21, 777788888, '1996-12-12 12:12:23.000000', 1, 1),
(22, 0, '1996-12-12 12:12:23.000000', 1, 1),
(23, 0, '1996-12-12 12:12:23.000000', 1, 1),
(24, 0, '1996-12-12 12:12:23.000000', NULL, NULL),
(25, 0, '1996-12-12 12:12:23.000000', NULL, NULL),
(26, 0, '1996-12-12 12:12:23.000000', NULL, NULL),
(27, 0, '1996-12-12 12:12:23.000000', NULL, NULL),
(28, 0, '1996-12-12 12:12:23.000000', NULL, NULL);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `UserName` longtext DEFAULT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `PasswordSalt` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Gegevens worden geëxporteerd voor tabel `user`
--

INSERT INTO `user` (`id`, `UserName`, `PasswordHash`, `PasswordSalt`) VALUES
(1, 'TEST', 'ABC', 'ABC'),
(2, 'JochemDev', 'TEST', 'TEST');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `userachievement`
--

CREATE TABLE `userachievement` (
  `UserID` int(11) NOT NULL,
  `AchievementID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Gegevens worden geëxporteerd voor tabel `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20200508210032_Init', '3.1.3'),
('20200511135103_scoredOn', '3.1.3'),
('20200511141425_UserAchievements', '3.1.3');

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `achievement`
--
ALTER TABLE `achievement`
  ADD PRIMARY KEY (`ID`);

--
-- Indexen voor tabel `level`
--
ALTER TABLE `level`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `IX_Level_Creatorid` (`Creatorid`);

--
-- Indexen voor tabel `score`
--
ALTER TABLE `score`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `IX_Score_Userid` (`Userid`),
  ADD KEY `IX_Score_ScoredOnID` (`ScoredOnID`);

--
-- Indexen voor tabel `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `userachievement`
--
ALTER TABLE `userachievement`
  ADD PRIMARY KEY (`UserID`,`AchievementID`),
  ADD KEY `IX_UserAchievement_AchievementID` (`AchievementID`);

--
-- Indexen voor tabel `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `achievement`
--
ALTER TABLE `achievement`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `level`
--
ALTER TABLE `level`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT voor een tabel `score`
--
ALTER TABLE `score`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT voor een tabel `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Beperkingen voor geëxporteerde tabellen
--

--
-- Beperkingen voor tabel `level`
--
ALTER TABLE `level`
  ADD CONSTRAINT `FK_Level_User_Creatorid` FOREIGN KEY (`Creatorid`) REFERENCES `user` (`id`);

--
-- Beperkingen voor tabel `score`
--
ALTER TABLE `score`
  ADD CONSTRAINT `FK_Score_Level_ScoredOnID` FOREIGN KEY (`ScoredOnID`) REFERENCES `level` (`ID`),
  ADD CONSTRAINT `FK_Score_User_Userid` FOREIGN KEY (`Userid`) REFERENCES `user` (`id`);

--
-- Beperkingen voor tabel `userachievement`
--
ALTER TABLE `userachievement`
  ADD CONSTRAINT `FK_UserAchievement_Achievement_AchievementID` FOREIGN KEY (`AchievementID`) REFERENCES `achievement` (`ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_UserAchievement_User_UserID` FOREIGN KEY (`UserID`) REFERENCES `user` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
