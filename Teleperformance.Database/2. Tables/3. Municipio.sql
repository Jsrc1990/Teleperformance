CREATE TABLE Municipio
(
Id VARCHAR(36) PRIMARY KEY NOT NULL DEFAULT CONVERT(VARCHAR(36), NEWID(), 0),
Name VARCHAR(100) UNIQUE NOT NULL,
Description VARCHAR(1000)
)