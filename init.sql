﻿CREATE TABLE Companies
(
CompanyId int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
CompanyName varchar(255) NOT NULL
)

CREATE TABLE Cars
(
CarId int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
CarName varchar(255) NOT NULL,
CompanyId int FOREIGN KEY REFERENCES Companies(CompanyId) ON DELETE CASCADE
)
