USE SuperHerosDb


CREATE TABLE SuperHero (
	 Superhero_ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	 Name nvarchar(50) ,
	 Alias nvarchar(50) ,
	 Origin varchar(255) 
);

CREATE TABLE Assistant (
	Assistant_ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(50) 
);

CREATE TABLE Power (
	Power_ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(50) ,
	Description varchar(255) 
);
