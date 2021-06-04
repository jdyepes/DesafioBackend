CREATE SCHEMA IF NOT EXISTS `ingreso_aspirante` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `ingreso_aspirante` ;

CREATE TABLE IF NOT EXISTS `ingreso_aspirante`.`Aspirante` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `identificacion` int(10) NOT NULL,
  `nombre` VARCHAR(20) NOT NULL,
  `apellido` VARCHAR(20) NOT NULL,
  `edad` int(2) NOT NULL,
  `nombre_casa` VARCHAR(100) NOT NULL,
  `fecha_creacion` DATETIME NOT NULL,
  `fecha_modificacion` DATETIME NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `idAspirante_UNIQUE` (`id` ASC) VISIBLE)
ENGINE = InnoDB