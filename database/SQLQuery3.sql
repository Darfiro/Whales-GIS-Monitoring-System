USE [gisWhales]
GO

/****** Object:  Table [dbo].[species_whale]    Script Date: 15.03.2019 15:03:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[species_whale](
	[id] [int] NOT NULL,
	[latin_name] [nchar](50) NULL,
	[specie_name] [nchar](50) NULL,
	[areal] [nchar](100) NULL,
	[population] [int] NULL,
	[status] [nchar](50) NULL,
	[dangers] [nchar](1000) NULL,
	[color] [nchar](10) NULL,
 CONSTRAINT [PK_species_whale] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

delete from species_whale

BULK INSERT species_whale FROM 'C:\Users\dvfir\Documents\3 курс\Базы данных\курсовая\бд\species_whale.csv' WITH (FIELDTERMINATOR = ',')
GO

Select *
From species_whale
Go