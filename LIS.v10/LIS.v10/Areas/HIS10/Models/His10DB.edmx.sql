
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/28/2017 07:24:37
-- Generated from EDMX file: C:\Data\ABEL\Projects\GitHubApps\Lis\LIS.v10\LIS.v10\Areas\HIS10\Models\His10DB.edmx
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

IF OBJECT_ID(N'[dbo].[FK_HisPhysicianHisEntPhysician]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisEntPhysicians] DROP CONSTRAINT [FK_HisPhysicianHisEntPhysician];
GO
IF OBJECT_ID(N'[dbo].[FK_HisOrderTypeHisOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisOrders] DROP CONSTRAINT [FK_HisOrderTypeHisOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_HisProfileHisOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisOrders] DROP CONSTRAINT [FK_HisProfileHisOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_HisPhysicianHisOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisOrders] DROP CONSTRAINT [FK_HisPhysicianHisOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_HisInstrumentHisOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisOrders] DROP CONSTRAINT [FK_HisInstrumentHisOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_HisEntityHisInstrument]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisInstruments] DROP CONSTRAINT [FK_HisEntityHisInstrument];
GO
IF OBJECT_ID(N'[dbo].[FK_HisCategoryHisEntCat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisEntCats] DROP CONSTRAINT [FK_HisCategoryHisEntCat];
GO
IF OBJECT_ID(N'[dbo].[FK_HisEntityHisEntCat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisEntCats] DROP CONSTRAINT [FK_HisEntityHisEntCat];
GO
IF OBJECT_ID(N'[dbo].[FK_HisEntityHisEntPhysician]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisEntPhysicians] DROP CONSTRAINT [FK_HisEntityHisEntPhysician];
GO
IF OBJECT_ID(N'[dbo].[FK_HisOrderHisResult]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisResults] DROP CONSTRAINT [FK_HisOrderHisResult];
GO
IF OBJECT_ID(N'[dbo].[FK_HisOrderTypeHisResultField]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisResultFields] DROP CONSTRAINT [FK_HisOrderTypeHisResultField];
GO
IF OBJECT_ID(N'[dbo].[FK_HisResultFieldHisResult]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisResults] DROP CONSTRAINT [FK_HisResultFieldHisResult];
GO
IF OBJECT_ID(N'[dbo].[FK_HisResultFieldHisInsResultRange]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisResultRanges] DROP CONSTRAINT [FK_HisResultFieldHisInsResultRange];
GO
IF OBJECT_ID(N'[dbo].[FK_HisOrderHisOrderRemarks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisOrderRemarks] DROP CONSTRAINT [FK_HisOrderHisOrderRemarks];
GO
IF OBJECT_ID(N'[dbo].[FK_HisProfileHisProfileDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisProfileDetails] DROP CONSTRAINT [FK_HisProfileHisProfileDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_HisPhysicianHisPhysicianProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisPhysicianProfiles] DROP CONSTRAINT [FK_HisPhysicianHisPhysicianProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_HisProfileHisPhysicianProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisPhysicianProfiles] DROP CONSTRAINT [FK_HisProfileHisPhysicianProfile];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[HisEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisEntities];
GO
IF OBJECT_ID(N'[dbo].[HisProfiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisProfiles];
GO
IF OBJECT_ID(N'[dbo].[HisCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisCategories];
GO
IF OBJECT_ID(N'[dbo].[HisEntCats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisEntCats];
GO
IF OBJECT_ID(N'[dbo].[HisOrders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisOrders];
GO
IF OBJECT_ID(N'[dbo].[HisOrderTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisOrderTypes];
GO
IF OBJECT_ID(N'[dbo].[HisPhysicians]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisPhysicians];
GO
IF OBJECT_ID(N'[dbo].[HisEntPhysicians]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisEntPhysicians];
GO
IF OBJECT_ID(N'[dbo].[HisInstruments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisInstruments];
GO
IF OBJECT_ID(N'[dbo].[HisResultFields]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisResultFields];
GO
IF OBJECT_ID(N'[dbo].[HisResults]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisResults];
GO
IF OBJECT_ID(N'[dbo].[HisResultRanges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisResultRanges];
GO
IF OBJECT_ID(N'[dbo].[HisOrderRemarks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisOrderRemarks];
GO
IF OBJECT_ID(N'[dbo].[HisProfileDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisProfileDetails];
GO
IF OBJECT_ID(N'[dbo].[HisPhysicianProfiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisPhysicianProfiles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'HisEntities'
CREATE TABLE [dbo].[HisEntities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Remarks] nvarchar(250)  NULL,
    [userGroupId] int  NOT NULL
);
GO

-- Creating table 'HisProfiles'
CREATE TABLE [dbo].[HisProfiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Remarks] nvarchar(200)  NULL,
    [AccntUserId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'HisCategories'
CREATE TABLE [dbo].[HisCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Remarks] nvarchar(250)  NULL,
    [SeqNo] int  NOT NULL
);
GO

-- Creating table 'HisEntCats'
CREATE TABLE [dbo].[HisEntCats] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisCategoryId] int  NOT NULL,
    [HisEntityId] int  NOT NULL
);
GO

-- Creating table 'HisOrders'
CREATE TABLE [dbo].[HisOrders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SpecimenId] nvarchar(200)  NOT NULL,
    [HisOrderTypeId] int  NOT NULL,
    [HisProfileId] int  NOT NULL,
    [HisPhysicianId] int  NOT NULL,
    [HisInstrumentId] int  NOT NULL,
    [dtRequest] datetime  NULL,
    [dtProcessed] datetime  NULL,
    [dtReleased] datetime  NULL
);
GO

-- Creating table 'HisOrderTypes'
CREATE TABLE [dbo].[HisOrderTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(200)  NOT NULL,
    [Remarks] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'HisPhysicians'
CREATE TABLE [dbo].[HisPhysicians] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Remarks] nvarchar(200)  NULL
);
GO

-- Creating table 'HisEntPhysicians'
CREATE TABLE [dbo].[HisEntPhysicians] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisPhysicianId] int  NOT NULL,
    [HisEntityId] int  NOT NULL
);
GO

-- Creating table 'HisInstruments'
CREATE TABLE [dbo].[HisInstruments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisEntityId] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [InsCode] nvarchar(20)  NULL,
    [Description] nvarchar(200)  NULL,
    [Specification] nvarchar(max)  NOT NULL,
    [Remarks] nvarchar(200)  NULL,
    [Status] nvarchar(5)  NOT NULL
);
GO

-- Creating table 'HisResultFields'
CREATE TABLE [dbo].[HisResultFields] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisOrderTypeId] int  NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Desc] nvarchar(200)  NOT NULL,
    [SeqNo] int  NOT NULL,
    [minValue] nvarchar(20)  NULL,
    [minUm] nvarchar(10)  NULL,
    [maxValue] nvarchar(10)  NULL,
    [maxUm] nvarchar(10)  NULL
);
GO

-- Creating table 'HisResults'
CREATE TABLE [dbo].[HisResults] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisOrderId] int  NOT NULL,
    [HisResultFieldId] int  NOT NULL,
    [Value1] nvarchar(10)  NULL,
    [Value2] nvarchar(10)  NULL,
    [Value3] nvarchar(10)  NULL,
    [Remarks] nvarchar(200)  NULL
);
GO

-- Creating table 'HisResultRanges'
CREATE TABLE [dbo].[HisResultRanges] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisResultFieldId] int  NOT NULL,
    [Value1] nvarchar(10)  NULL,
    [umval1] nvarchar(10)  NULL,
    [Value2] nvarchar(10)  NULL,
    [umVal2] nvarchar(10)  NULL,
    [Value3] nvarchar(10)  NULL,
    [umVal3] nvarchar(10)  NULL,
    [InstrumentId] int  NULL
);
GO

-- Creating table 'HisOrderRemarks'
CREATE TABLE [dbo].[HisOrderRemarks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisOrderId] int  NOT NULL,
    [dtAdded] datetime  NOT NULL,
    [Remarks] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'HisProfileDetails'
CREATE TABLE [dbo].[HisProfileDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisProfileId] int  NOT NULL
);
GO

-- Creating table 'HisPhysicianProfiles'
CREATE TABLE [dbo].[HisPhysicianProfiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisPhysicianId] int  NOT NULL,
    [HisProfileId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'HisEntities'
ALTER TABLE [dbo].[HisEntities]
ADD CONSTRAINT [PK_HisEntities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisProfiles'
ALTER TABLE [dbo].[HisProfiles]
ADD CONSTRAINT [PK_HisProfiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisCategories'
ALTER TABLE [dbo].[HisCategories]
ADD CONSTRAINT [PK_HisCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisEntCats'
ALTER TABLE [dbo].[HisEntCats]
ADD CONSTRAINT [PK_HisEntCats]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisOrders'
ALTER TABLE [dbo].[HisOrders]
ADD CONSTRAINT [PK_HisOrders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisOrderTypes'
ALTER TABLE [dbo].[HisOrderTypes]
ADD CONSTRAINT [PK_HisOrderTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisPhysicians'
ALTER TABLE [dbo].[HisPhysicians]
ADD CONSTRAINT [PK_HisPhysicians]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisEntPhysicians'
ALTER TABLE [dbo].[HisEntPhysicians]
ADD CONSTRAINT [PK_HisEntPhysicians]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisInstruments'
ALTER TABLE [dbo].[HisInstruments]
ADD CONSTRAINT [PK_HisInstruments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisResultFields'
ALTER TABLE [dbo].[HisResultFields]
ADD CONSTRAINT [PK_HisResultFields]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisResults'
ALTER TABLE [dbo].[HisResults]
ADD CONSTRAINT [PK_HisResults]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisResultRanges'
ALTER TABLE [dbo].[HisResultRanges]
ADD CONSTRAINT [PK_HisResultRanges]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisOrderRemarks'
ALTER TABLE [dbo].[HisOrderRemarks]
ADD CONSTRAINT [PK_HisOrderRemarks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisProfileDetails'
ALTER TABLE [dbo].[HisProfileDetails]
ADD CONSTRAINT [PK_HisProfileDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisPhysicianProfiles'
ALTER TABLE [dbo].[HisPhysicianProfiles]
ADD CONSTRAINT [PK_HisPhysicianProfiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [HisPhysicianId] in table 'HisEntPhysicians'
ALTER TABLE [dbo].[HisEntPhysicians]
ADD CONSTRAINT [FK_HisPhysicianHisEntPhysician]
    FOREIGN KEY ([HisPhysicianId])
    REFERENCES [dbo].[HisPhysicians]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisPhysicianHisEntPhysician'
CREATE INDEX [IX_FK_HisPhysicianHisEntPhysician]
ON [dbo].[HisEntPhysicians]
    ([HisPhysicianId]);
GO

-- Creating foreign key on [HisOrderTypeId] in table 'HisOrders'
ALTER TABLE [dbo].[HisOrders]
ADD CONSTRAINT [FK_HisOrderTypeHisOrder]
    FOREIGN KEY ([HisOrderTypeId])
    REFERENCES [dbo].[HisOrderTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisOrderTypeHisOrder'
CREATE INDEX [IX_FK_HisOrderTypeHisOrder]
ON [dbo].[HisOrders]
    ([HisOrderTypeId]);
GO

-- Creating foreign key on [HisProfileId] in table 'HisOrders'
ALTER TABLE [dbo].[HisOrders]
ADD CONSTRAINT [FK_HisProfileHisOrder]
    FOREIGN KEY ([HisProfileId])
    REFERENCES [dbo].[HisProfiles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisProfileHisOrder'
CREATE INDEX [IX_FK_HisProfileHisOrder]
ON [dbo].[HisOrders]
    ([HisProfileId]);
GO

-- Creating foreign key on [HisPhysicianId] in table 'HisOrders'
ALTER TABLE [dbo].[HisOrders]
ADD CONSTRAINT [FK_HisPhysicianHisOrder]
    FOREIGN KEY ([HisPhysicianId])
    REFERENCES [dbo].[HisPhysicians]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisPhysicianHisOrder'
CREATE INDEX [IX_FK_HisPhysicianHisOrder]
ON [dbo].[HisOrders]
    ([HisPhysicianId]);
GO

-- Creating foreign key on [HisInstrumentId] in table 'HisOrders'
ALTER TABLE [dbo].[HisOrders]
ADD CONSTRAINT [FK_HisInstrumentHisOrder]
    FOREIGN KEY ([HisInstrumentId])
    REFERENCES [dbo].[HisInstruments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisInstrumentHisOrder'
CREATE INDEX [IX_FK_HisInstrumentHisOrder]
ON [dbo].[HisOrders]
    ([HisInstrumentId]);
GO

-- Creating foreign key on [HisEntityId] in table 'HisInstruments'
ALTER TABLE [dbo].[HisInstruments]
ADD CONSTRAINT [FK_HisEntityHisInstrument]
    FOREIGN KEY ([HisEntityId])
    REFERENCES [dbo].[HisEntities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisEntityHisInstrument'
CREATE INDEX [IX_FK_HisEntityHisInstrument]
ON [dbo].[HisInstruments]
    ([HisEntityId]);
GO

-- Creating foreign key on [HisCategoryId] in table 'HisEntCats'
ALTER TABLE [dbo].[HisEntCats]
ADD CONSTRAINT [FK_HisCategoryHisEntCat]
    FOREIGN KEY ([HisCategoryId])
    REFERENCES [dbo].[HisCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisCategoryHisEntCat'
CREATE INDEX [IX_FK_HisCategoryHisEntCat]
ON [dbo].[HisEntCats]
    ([HisCategoryId]);
GO

-- Creating foreign key on [HisEntityId] in table 'HisEntCats'
ALTER TABLE [dbo].[HisEntCats]
ADD CONSTRAINT [FK_HisEntityHisEntCat]
    FOREIGN KEY ([HisEntityId])
    REFERENCES [dbo].[HisEntities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisEntityHisEntCat'
CREATE INDEX [IX_FK_HisEntityHisEntCat]
ON [dbo].[HisEntCats]
    ([HisEntityId]);
GO

-- Creating foreign key on [HisEntityId] in table 'HisEntPhysicians'
ALTER TABLE [dbo].[HisEntPhysicians]
ADD CONSTRAINT [FK_HisEntityHisEntPhysician]
    FOREIGN KEY ([HisEntityId])
    REFERENCES [dbo].[HisEntities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisEntityHisEntPhysician'
CREATE INDEX [IX_FK_HisEntityHisEntPhysician]
ON [dbo].[HisEntPhysicians]
    ([HisEntityId]);
GO

-- Creating foreign key on [HisOrderId] in table 'HisResults'
ALTER TABLE [dbo].[HisResults]
ADD CONSTRAINT [FK_HisOrderHisResult]
    FOREIGN KEY ([HisOrderId])
    REFERENCES [dbo].[HisOrders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisOrderHisResult'
CREATE INDEX [IX_FK_HisOrderHisResult]
ON [dbo].[HisResults]
    ([HisOrderId]);
GO

-- Creating foreign key on [HisOrderTypeId] in table 'HisResultFields'
ALTER TABLE [dbo].[HisResultFields]
ADD CONSTRAINT [FK_HisOrderTypeHisResultField]
    FOREIGN KEY ([HisOrderTypeId])
    REFERENCES [dbo].[HisOrderTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisOrderTypeHisResultField'
CREATE INDEX [IX_FK_HisOrderTypeHisResultField]
ON [dbo].[HisResultFields]
    ([HisOrderTypeId]);
GO

-- Creating foreign key on [HisResultFieldId] in table 'HisResults'
ALTER TABLE [dbo].[HisResults]
ADD CONSTRAINT [FK_HisResultFieldHisResult]
    FOREIGN KEY ([HisResultFieldId])
    REFERENCES [dbo].[HisResultFields]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisResultFieldHisResult'
CREATE INDEX [IX_FK_HisResultFieldHisResult]
ON [dbo].[HisResults]
    ([HisResultFieldId]);
GO

-- Creating foreign key on [HisResultFieldId] in table 'HisResultRanges'
ALTER TABLE [dbo].[HisResultRanges]
ADD CONSTRAINT [FK_HisResultFieldHisInsResultRange]
    FOREIGN KEY ([HisResultFieldId])
    REFERENCES [dbo].[HisResultFields]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisResultFieldHisInsResultRange'
CREATE INDEX [IX_FK_HisResultFieldHisInsResultRange]
ON [dbo].[HisResultRanges]
    ([HisResultFieldId]);
GO

-- Creating foreign key on [HisOrderId] in table 'HisOrderRemarks'
ALTER TABLE [dbo].[HisOrderRemarks]
ADD CONSTRAINT [FK_HisOrderHisOrderRemarks]
    FOREIGN KEY ([HisOrderId])
    REFERENCES [dbo].[HisOrders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisOrderHisOrderRemarks'
CREATE INDEX [IX_FK_HisOrderHisOrderRemarks]
ON [dbo].[HisOrderRemarks]
    ([HisOrderId]);
GO

-- Creating foreign key on [HisProfileId] in table 'HisProfileDetails'
ALTER TABLE [dbo].[HisProfileDetails]
ADD CONSTRAINT [FK_HisProfileHisProfileDetails]
    FOREIGN KEY ([HisProfileId])
    REFERENCES [dbo].[HisProfiles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisProfileHisProfileDetails'
CREATE INDEX [IX_FK_HisProfileHisProfileDetails]
ON [dbo].[HisProfileDetails]
    ([HisProfileId]);
GO

-- Creating foreign key on [HisPhysicianId] in table 'HisPhysicianProfiles'
ALTER TABLE [dbo].[HisPhysicianProfiles]
ADD CONSTRAINT [FK_HisPhysicianHisPhysicianProfile]
    FOREIGN KEY ([HisPhysicianId])
    REFERENCES [dbo].[HisPhysicians]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisPhysicianHisPhysicianProfile'
CREATE INDEX [IX_FK_HisPhysicianHisPhysicianProfile]
ON [dbo].[HisPhysicianProfiles]
    ([HisPhysicianId]);
GO

-- Creating foreign key on [HisProfileId] in table 'HisPhysicianProfiles'
ALTER TABLE [dbo].[HisPhysicianProfiles]
ADD CONSTRAINT [FK_HisProfileHisPhysicianProfile]
    FOREIGN KEY ([HisProfileId])
    REFERENCES [dbo].[HisProfiles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisProfileHisPhysicianProfile'
CREATE INDEX [IX_FK_HisProfileHisPhysicianProfile]
ON [dbo].[HisPhysicianProfiles]
    ([HisProfileId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------