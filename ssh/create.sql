use duoduo_test;
if exists(select * from sysobjects where name='Uuser') drop table Uuser 
CREATE TABLE Uuser
(
	id int not null primary key identity(1,1),
	name varchar(255) not null unique,   
    password varchar(255) not null,   
    userEmail varchar(255)   
);