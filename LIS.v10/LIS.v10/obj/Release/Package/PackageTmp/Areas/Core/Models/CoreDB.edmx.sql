
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/18/2017 14:42:30
-- Generated from EDMX file: D:\Data\Real\Apps\GitHub\Lis\LIS.v10\LIS.v10\Areas\Core\Models\CoreDB.edmx
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

IF OBJECT_ID(N'[dbo].[FK_userGroupuserGroupAdmin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[userGroupAdmins] DROP CONSTRAINT [FK_userGroupuserGroupAdmin];
GO
IF OBJECT_ID(N'[dbo].[FK_userTypeuserUserType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[userUserTypes] DROP CONSTRAINT [FK_userTypeuserUserType];
GO
IF OBJECT_ID(N'[dbo].[FK_useruserUserType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[userUserTypes] DROP CONSTRAINT [FK_useruserUserType];
GO
IF OBJECT_ID(N'[dbo].[FK_userGroupuserUserGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[userUserGroups] DROP CONSTRAINT [FK_userGroupuserUserGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_useruserUserGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[userUserGroups] DROP CONSTRAINT [FK_useruserUserGroup];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ModInformations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ModInformations];
GO
IF OBJECT_ID(N'[dbo].[userGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[userGroups];
GO
IF OBJECT_ID(N'[dbo].[userGroupAdmins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[userGroupAdmins];
GO
IF OBJECT_ID(N'[dbo].[users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[users];
GO
IF OBJECT_ID(N'[dbo].[userTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[userTypes];
GO
IF OBJECT_ID(N'[dbo].[userUserTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[userUserTypes];
GO
IF OBJECT_ID(N'[dbo].[userUserGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[userUserGroups];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ModInformations'
CREATE TABLE [dbo].[ModInformations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Version] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'userGroups'
CREATE TABLE [dbo].[userGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'userGroupAdmins'
CREATE TABLE [dbo].[userGroupAdmins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [userGroupId] int  NOT NULL,
    [UserId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'users'
CREATE TABLE [dbo].[users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(max)  NOT NULL,
    [Fullname] nvarchar(max)  NOT NULL,
    [Remarks] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'userTypes'
CREATE TABLE [dbo].[userTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'userUserTypes'
CREATE TABLE [dbo].[userUserTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [userTypeId] int  NOT NULL,
    [userId] int  NOT NULL
);
GO

-- Creating table 'userUserGroups'
CREATE TABLE [dbo].[userUserGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [userGroupId] int  NOT NULL,
    [userId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ModInformations'
ALTER TABLE [dbo].[ModInformations]
ADD CONSTRAINT [PK_ModInformations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'userGroups'
ALTER TABLE [dbo].[userGroups]
ADD CONSTRAINT [PK_userGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'userGroupAdmins'
ALTER TABLE [dbo].[userGroupAdmins]
ADD CONSTRAINT [PK_userGroupAdmins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [PK_users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'userTypes'
ALTER TABLE [dbo].[userTypes]
ADD CONSTRAINT [PK_userTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'userUserTypes'
ALTER TABLE [dbo].[userUserTypes]
ADD CONSTRAINT [PK_userUserTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'userUserGroups'
ALTER TABLE [dbo].[userUserGroups]
ADD CONSTRAINT [PK_userUserGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [userGroupId] in table 'userGroupAdmins'
ALTER TABLE [dbo].[userGroupAdmins]
ADD CONSTRAINT [FK_userGroupuserGroupAdmin]
    FOREIGN KEY ([userGroupId])
    REFERENCES [dbo].[userGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_userGroupuserGroupAdmin'
CREATE INDEX [IX_FK_userGroupuserGroupAdmin]
ON [dbo].[userGroupAdmins]
    ([userGroupId]);
GO

-- Creating foreign key on [userTypeId] in table 'userUserTypes'
ALTER TABLE [dbo].[userUserTypes]
ADD CONSTRAINT [FK_userTypeuserUserType]
    FOREIGN KEY ([userTypeId])
    REFERENCES [dbo].[userTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_userTypeuserUserType'
CREATE INDEX [IX_FK_userTypeuserUserType]
ON [dbo].[userUserTypes]
    ([userTypeId]);
GO

-- Creating foreign key on [userId] in table 'userUserTypes'
ALTER TABLE [dbo].[userUserTypes]
ADD CONSTRAINT [FK_useruserUserType]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_useruserUserType'
CREATE INDEX [IX_FK_useruserUserType]
ON [dbo].[userUserTypes]
    ([userId]);
GO

-- Creating foreign key on [userGroupId] in table 'userUserGroups'
ALTER TABLE [dbo].[userUserGroups]
ADD CONSTRAINT [FK_userGroupuserUserGroup]
    FOREIGN KEY ([userGroupId])
    REFERENCES [dbo].[userGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_userGroupuserUserGroup'
CREATE INDEX [IX_FK_userGroupuserUserGroup]
ON [dbo].[userUserGroups]
    ([userGroupId]);
GO

-- Creating foreign key on [userId] in table 'userUserGroups'
ALTER TABLE [dbo].[userUserGroups]
ADD CONSTRAINT [FK_useruserUserGroup]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_useruserUserGroup'
CREATE INDEX [IX_FK_useruserUserGroup]
ON [dbo].[userUserGroups]
    ([userId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------