IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'TestKatanaDb')
DROP DATABASE [TestKatanaDb]

CREATE DATABASE [TestKatanaDb]
GO

USE [TestKatanaDb]
GO

CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED,
	[Name] [nvarchar](50) NOT NULL UNIQUE
)
GO
 