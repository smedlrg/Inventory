﻿CREATE TABLE [dbo].[Item]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(50) NOT NULL,
	[Count] INT NOT NULL,
	[Price] DECIMAL NOT NULL
)