CREATE DATABASE KingAcademy2022;
GO

USE KingAcademy2022;
GO

CREATE TABLE Academy (
    Id int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255)
);

INSERT INTO Academy(Name) VALUES ('KingICT ljetna akademija 2022');

