CREATE SCHEMA `novenyek` 
DEFAULT CHARACTER SET utf8 
COLLATE utf8_hungarian_ci ;

CREATE TABLE `novenyek`.`gyumolcsok_table` (
  `id_table` INT NOT NULL,
  `nev` VARCHAR(45) NULL,
  `fajta` VARCHAR(45) NULL,
  `ar` INT NULL,
  `megjegyzes` VARCHAR(45) NULL,
  `darabszam` INT NULL,
  PRIMARY KEY (`id_table`));

INSERT INTO `novenyek`.`gyumolcsok_table` (`idnew_table`, `nev`, `fajta`, `ar`, `megjegyzes`, `darabszam`) VALUES ('1', 'almma', 'h', '800', 'honos', '5');
INSERT INTO `novenyek`.`gyumolcsok_table` (`idnew_table`, `nev`, `fajta`, `ar`, `megjegyzes`, `darabszam`) VALUES ('2', 'banán', 'd', '500', 'déli', '3');
INSERT INTO `novenyek`.`gyumolcsok_table` (`idnew_table`, `nev`, `fajta`, `ar`, `megjegyzes`, `darabszam`) VALUES ('3', 'narancs', 'd', '1200', 'déli', '7');
INSERT INTO `novenyek`.`gyumolcsok_table` (`idnew_table`, `nev`, `fajta`, `ar`, `megjegyzes`, `darabszam`) VALUES ('4', 'körte', 'h', '900', 'honos', '4');

SELECT * FROM novenyek.gyumolcsok_table;

SELECT * FROM `novenyek`.`gyumolcsok_table` WHERE `fajta`='h';

SELECT (`nev`,`ar`,`darabszam`) FROM `novenyek`.`gyumolcsok_table` WHERE `ar`>300;

SELECT max(ar) FROM `novenyek`.`gyumolcsok_table`;

SELECT * FROM `novenyek`.`gyumolcsok_table` WHERE `fajta`='d' ORDER BY `ar` DESC;

DELETE FROM `novenyek`.`gyumolcsok_table` WHERE MAX(ar);

UPDATE `novenyek`.`gyumolcsok_table` SET `nev`='alma' WHERE `idnew_table`='1';
