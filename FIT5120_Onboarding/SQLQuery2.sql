-- Create table 'Garbages'
CREATE TABLE [DBO].[Garbages](
	[Id] int IDENTITY (1,1) NOT NULL,
	[GarbageName] nvarchar (max) NOT NULL,
	[DisposalMethod] nvarchar (max) NOT NULL,
	[Color] nvarchar (max) NOT NULL
	PRIMARY KEY (Id)
	);
GO