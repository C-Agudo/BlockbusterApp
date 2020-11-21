CREATE DATABASE IF NOT EXISTS blockbusterapp;
use app;
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
	`id` varchar(40) COLLATE utf8mb4_unicode_ci NOT NULL,
	`email` varchar(60) COLLATE utf8mb4_unicode_ci NOT NULL,
	`password` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
	`first_name` varchar(15) COLLATE utf8mb4_unicode_ci NOT NULL,
	`last_name` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
	`country_code` varchar(5) COLLATE utf8mb4_unicode_ci NOT NULL,
	`role` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
	PRIMARY KEY (`id`),
	UNIQUE KEY `email` (`email`)
) ENGINE = InnodB DEFEAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `countries` (
	`code` varchar(10) COLLATE utf8mb4_unicode_ci NOT NULL,
	`tax` varchar(10) COLLATE utf8mb4_unicode_ci NOT NULL,
	PRIMARY KEY (`code`),
) ENGINE = InnodB DEFEAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;