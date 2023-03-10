-- Create table 'Schedules"
CREATE TABLE [DBO].[Schedules](
	[Id] int IDENTITY (1,1) NOT NULL,
	[Address] nvarchar (max) NOT NULL,
	[CollectionDay] nvarchar (max) NOT NULL,
	[NextWaste] datetime NOT NULL,
	[NextRecycle] datetime NOT NULL,
	[NextGreen] datetime NOT NULL
	PRIMARY KEY (Id)
	);
GO
