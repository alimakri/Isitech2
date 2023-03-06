use master;
CREATE DATABASE [BD1] ON PRIMARY
	( 
	NAME = N'BD1', 
	FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BD1.mdf' , 
	SIZE = 8192KB , 
	FILEGROWTH = 65536KB 
	)
 LOG ON 
	( 
	NAME = N'BD1_log', 
	FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BD1_log.ldf' , 
	SIZE = 8192KB , 
	FILEGROWTH = 65536KB 
	)
GO
USE [BD1]
GO
CREATE TABLE [dbo].Ville
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Libelle] [nvarchar](max) NOT NULL,
	CONSTRAINT [PK_Ville] PRIMARY KEY CLUSTERED (Id ASC)
) 
GO
CREATE TABLE [dbo].[Personne]
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Libelle] [nvarchar](max) NOT NULL,
	[Ville] [bigint] NOT NULL,
	CONSTRAINT [PK_Personne] PRIMARY KEY CLUSTERED (Id ASC)
) 
GO
ALTER TABLE [dbo].[Personne]  WITH CHECK ADD  CONSTRAINT [FK_Personne_Ville] FOREIGN KEY([Ville]) REFERENCES [dbo].[Ville] ([Id])
ALTER TABLE [dbo].[Personne] CHECK CONSTRAINT [FK_Personne_Ville]
GO


