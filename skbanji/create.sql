CREATE DATABASE IF NOT EXISTS skbanji;

USE skbanji;

CREATE TABLE IF NOT EXISTS user
(
    id INT NOT NULL AUTO_INCREMENT,
    username VARCHAR(40) NOT NULL,
    password VARCHAR(20) NOT NULL,
    email VARCHAR(60) NOT NULL,
	PRIMARY KEY(id),
    UNIQUE (username)
);

CREATE TABLE IF NOT EXISTS test_constraint
(
    id INT NOT NULL AUTO_INCREMENT,
    user_id INT NOT NULL,
    FOREIGN KEY(user_id)
    REFERENCES user (id), 
	PRIMARY KEY(id)
);
