
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/10/2017 11:09:43
-- Generated from EDMX file: D:\Data\Real\Apps\GitHub\Lis\LIS.v10\LIS.v10\Models\LisDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-LIS.v10-20170509105835];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AppInformations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AppInformations];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AppInformations'
CREATE TABLE [dbo].[AppInformations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Key] nvarchar(10)  NOT NULL,
    [Data] nvarchar(250)  NOT NULL,
    [Remarks] nvarchar(250)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AppInformations'
ALTER TABLE [dbo].[AppInformations]
ADD CONSTRAINT [PK_AppInformations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------