
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/07/2018 09:12:18
-- Generated from EDMX file: D:\Data\Real\Apps\GitHub\Lis\LIS.v10\LIS.v10\Areas\HIS10\Models\His10DB.edmx
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
IF OBJECT_ID(N'[dbo].[FK_HisOperatorHisEntOperator]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisEntOperators] DROP CONSTRAINT [FK_HisOperatorHisEntOperator];
GO
IF OBJECT_ID(N'[dbo].[FK_HisEntityHisEntOperator]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisEntOperators] DROP CONSTRAINT [FK_HisEntityHisEntOperator];
GO
IF OBJECT_ID(N'[dbo].[FK_HisEntityHisEntAdmin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisEntAdmins] DROP CONSTRAINT [FK_HisEntityHisEntAdmin];
GO
IF OBJECT_ID(N'[dbo].[FK_HisSpecializationHisPhysicianSpecialization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisPhysicianSpecializations] DROP CONSTRAINT [FK_HisSpecializationHisPhysicianSpecialization];
GO
IF OBJECT_ID(N'[dbo].[FK_HisPhysicianHisPhysicianSpecialization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisPhysicianSpecializations] DROP CONSTRAINT [FK_HisPhysicianHisPhysicianSpecialization];
GO
IF OBJECT_ID(N'[dbo].[FK_HisPhysicianHisPhysicianClinic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisPhysicianClinics] DROP CONSTRAINT [FK_HisPhysicianHisPhysicianClinic];
GO
IF OBJECT_ID(N'[dbo].[FK_HisProfileHisProfileGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisProfileGroups] DROP CONSTRAINT [FK_HisProfileHisProfileGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_HisGroupingHisProfileGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisProfileGroups] DROP CONSTRAINT [FK_HisGroupingHisProfileGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_HisProfileHisProfileIncharge]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisProfileIncharges] DROP CONSTRAINT [FK_HisProfileHisProfileIncharge];
GO
IF OBJECT_ID(N'[dbo].[FK_HisInchargeHisProfileIncharge]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisProfileIncharges] DROP CONSTRAINT [FK_HisInchargeHisProfileIncharge];
GO
IF OBJECT_ID(N'[dbo].[FK_HisProfileHisProfileReq]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisProfileReqs] DROP CONSTRAINT [FK_HisProfileHisProfileReq];
GO
IF OBJECT_ID(N'[dbo].[FK_HisRequestHisProfileReq]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisProfileReqs] DROP CONSTRAINT [FK_HisRequestHisProfileReq];
GO
IF OBJECT_ID(N'[dbo].[FK_HisTemplateRequestHisTemplateReqItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisTemplateReqItems1] DROP CONSTRAINT [FK_HisTemplateRequestHisTemplateReqItems];
GO
IF OBJECT_ID(N'[dbo].[FK_HisRequestHisTemplateReqItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisTemplateReqItems1] DROP CONSTRAINT [FK_HisRequestHisTemplateReqItems];
GO
IF OBJECT_ID(N'[dbo].[FK_HisReqCategoryHisReqCat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisReqCats] DROP CONSTRAINT [FK_HisReqCategoryHisReqCat];
GO
IF OBJECT_ID(N'[dbo].[FK_HisRequestHisReqCat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisReqCats] DROP CONSTRAINT [FK_HisRequestHisReqCat];
GO
IF OBJECT_ID(N'[dbo].[FK_HisNotificationHisNotificationRecipient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisNotificationRecipients] DROP CONSTRAINT [FK_HisNotificationHisNotificationRecipient];
GO
IF OBJECT_ID(N'[dbo].[FK_HisNotificationRecipientHisNotificationLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisNotificationLogs] DROP CONSTRAINT [FK_HisNotificationRecipientHisNotificationLog];
GO
IF OBJECT_ID(N'[dbo].[FK_HisPhysicianHisProfileReq]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisProfileReqs] DROP CONSTRAINT [FK_HisPhysicianHisProfileReq];
GO
IF OBJECT_ID(N'[dbo].[FK_HisInchargeHisProfileReq]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HisProfileReqs] DROP CONSTRAINT [FK_HisInchargeHisProfileReq];
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
IF OBJECT_ID(N'[dbo].[HisOperators]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisOperators];
GO
IF OBJECT_ID(N'[dbo].[HisEntOperators]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisEntOperators];
GO
IF OBJECT_ID(N'[dbo].[HisEntAdmins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisEntAdmins];
GO
IF OBJECT_ID(N'[dbo].[HisSpecializations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisSpecializations];
GO
IF OBJECT_ID(N'[dbo].[HisPhysicianSpecializations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisPhysicianSpecializations];
GO
IF OBJECT_ID(N'[dbo].[HisPhysicianClinics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisPhysicianClinics];
GO
IF OBJECT_ID(N'[dbo].[HisGroupings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisGroupings];
GO
IF OBJECT_ID(N'[dbo].[HisProfileGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisProfileGroups];
GO
IF OBJECT_ID(N'[dbo].[HisIncharges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisIncharges];
GO
IF OBJECT_ID(N'[dbo].[HisProfileIncharges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisProfileIncharges];
GO
IF OBJECT_ID(N'[dbo].[HisRequests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisRequests];
GO
IF OBJECT_ID(N'[dbo].[HisProfileReqs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisProfileReqs];
GO
IF OBJECT_ID(N'[dbo].[HisTemplateRequests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisTemplateRequests];
GO
IF OBJECT_ID(N'[dbo].[HisTemplateReqItems1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisTemplateReqItems1];
GO
IF OBJECT_ID(N'[dbo].[HisReqCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisReqCategories];
GO
IF OBJECT_ID(N'[dbo].[HisReqCats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisReqCats];
GO
IF OBJECT_ID(N'[dbo].[HisNotifications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisNotifications];
GO
IF OBJECT_ID(N'[dbo].[HisNotificationLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisNotificationLogs];
GO
IF OBJECT_ID(N'[dbo].[HisNotificationRecipients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HisNotificationRecipients];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'HisEntities'
CREATE TABLE [dbo].[HisEntities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Remarks] nvarchar(250)  NULL,
    [userGroupId] int  NOT NULL,
    [Address] nvarchar(250)  NULL,
    [Contact] nvarchar(180)  NULL
);
GO

-- Creating table 'HisProfiles'
CREATE TABLE [dbo].[HisProfiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Remarks] nvarchar(200)  NULL,
    [AccntUserId] nvarchar(max)  NULL,
    [ContactInfo] nvarchar(30)  NULL
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
    [Remarks] nvarchar(200)  NULL,
    [AccntUserId] nvarchar(max)  NULL,
    [ContactInfo] nvarchar(30)  NULL
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
    [AddForType] int  NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Desc] nvarchar(200)  NOT NULL,
    [SeqNo] int  NOT NULL,
    [minValue] nvarchar(20)  NULL,
    [maxValue] nvarchar(10)  NULL,
    [Uom] nvarchar(10)  NULL
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

-- Creating table 'HisOperators'
CREATE TABLE [dbo].[HisOperators] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Remarks] nvarchar(200)  NULL,
    [AccntUserId] nvarchar(max)  NULL
);
GO

-- Creating table 'HisEntOperators'
CREATE TABLE [dbo].[HisEntOperators] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisOperatorId] int  NOT NULL,
    [HisEntityId] int  NOT NULL
);
GO

-- Creating table 'HisEntAdmins'
CREATE TABLE [dbo].[HisEntAdmins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisEntityId] int  NOT NULL,
    [AccntUserId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'HisSpecializations'
CREATE TABLE [dbo].[HisSpecializations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Desc] nvarchar(150)  NOT NULL,
    [Code] nvarchar(20)  NULL
);
GO

-- Creating table 'HisPhysicianSpecializations'
CREATE TABLE [dbo].[HisPhysicianSpecializations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisSpecializationId] int  NOT NULL,
    [HisPhysicianId] int  NOT NULL
);
GO

-- Creating table 'HisPhysicianClinics'
CREATE TABLE [dbo].[HisPhysicianClinics] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisPhysicianId] int  NOT NULL,
    [Location] nvarchar(250)  NOT NULL,
    [Days] nvarchar(120)  NOT NULL,
    [Time] nvarchar(120)  NOT NULL,
    [Remarks] nvarchar(250)  NULL,
    [Telephone] nvarchar(120)  NULL
);
GO

-- Creating table 'HisGroupings'
CREATE TABLE [dbo].[HisGroupings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(80)  NOT NULL,
    [Description] nvarchar(250)  NULL
);
GO

-- Creating table 'HisProfileGroups'
CREATE TABLE [dbo].[HisProfileGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisProfileId] int  NOT NULL,
    [HisGroupingId] int  NOT NULL
);
GO

-- Creating table 'HisIncharges'
CREATE TABLE [dbo].[HisIncharges] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(80)  NOT NULL,
    [Remarks] nvarchar(250)  NULL,
    [AccntUserId] nvarchar(50)  NULL,
    [ContactInfo] nvarchar(30)  NULL
);
GO

-- Creating table 'HisProfileIncharges'
CREATE TABLE [dbo].[HisProfileIncharges] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisProfileId] int  NOT NULL,
    [HisInchargeId] int  NOT NULL
);
GO

-- Creating table 'HisRequests'
CREATE TABLE [dbo].[HisRequests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(80)  NOT NULL,
    [Description] nvarchar(250)  NULL
);
GO

-- Creating table 'HisProfileReqs'
CREATE TABLE [dbo].[HisProfileReqs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisProfileId] int  NOT NULL,
    [HisRequestId] int  NOT NULL,
    [dtRequested] datetime  NULL,
    [dtSchedule] datetime  NULL,
    [dtPerformed] datetime  NULL,
    [Remarks] nvarchar(250)  NULL,
    [HisPhysicianId] int  NOT NULL,
    [HisInchargeId] int  NOT NULL
);
GO

-- Creating table 'HisTemplateRequests'
CREATE TABLE [dbo].[HisTemplateRequests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(80)  NOT NULL,
    [Remarks] nvarchar(250)  NULL
);
GO

-- Creating table 'HisTemplateReqItems1'
CREATE TABLE [dbo].[HisTemplateReqItems1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisTemplateRequestId] int  NOT NULL,
    [HisRequestId] int  NOT NULL,
    [Sort] int  NOT NULL,
    [RefDay] int  NOT NULL
);
GO

-- Creating table 'HisReqCategories'
CREATE TABLE [dbo].[HisReqCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(80)  NOT NULL
);
GO

-- Creating table 'HisReqCats'
CREATE TABLE [dbo].[HisReqCats] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisReqCategoryId] int  NOT NULL,
    [HisRequestId] int  NOT NULL
);
GO

-- Creating table 'HisNotifications'
CREATE TABLE [dbo].[HisNotifications] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RecType] nvarchar(10)  NOT NULL,
    [Recipient] nvarchar(30)  NOT NULL,
    [Message] nvarchar(255)  NOT NULL,
    [DtSending] datetime  NOT NULL,
    [RefId] int  NULL,
    [RefTable] nvarchar(40)  NULL
);
GO

-- Creating table 'HisNotificationLogs'
CREATE TABLE [dbo].[HisNotificationLogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisNotificationRecipientId] int  NOT NULL,
    [DtSending] datetime  NOT NULL,
    [Status] nvarchar(10)  NOT NULL,
    [Remarks] nvarchar(200)  NULL
);
GO

-- Creating table 'HisNotificationRecipients'
CREATE TABLE [dbo].[HisNotificationRecipients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisNotificationId] int  NOT NULL,
    [ContactInfo] nvarchar(30)  NOT NULL
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

-- Creating primary key on [Id] in table 'HisOperators'
ALTER TABLE [dbo].[HisOperators]
ADD CONSTRAINT [PK_HisOperators]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisEntOperators'
ALTER TABLE [dbo].[HisEntOperators]
ADD CONSTRAINT [PK_HisEntOperators]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisEntAdmins'
ALTER TABLE [dbo].[HisEntAdmins]
ADD CONSTRAINT [PK_HisEntAdmins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisSpecializations'
ALTER TABLE [dbo].[HisSpecializations]
ADD CONSTRAINT [PK_HisSpecializations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisPhysicianSpecializations'
ALTER TABLE [dbo].[HisPhysicianSpecializations]
ADD CONSTRAINT [PK_HisPhysicianSpecializations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisPhysicianClinics'
ALTER TABLE [dbo].[HisPhysicianClinics]
ADD CONSTRAINT [PK_HisPhysicianClinics]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisGroupings'
ALTER TABLE [dbo].[HisGroupings]
ADD CONSTRAINT [PK_HisGroupings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisProfileGroups'
ALTER TABLE [dbo].[HisProfileGroups]
ADD CONSTRAINT [PK_HisProfileGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisIncharges'
ALTER TABLE [dbo].[HisIncharges]
ADD CONSTRAINT [PK_HisIncharges]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisProfileIncharges'
ALTER TABLE [dbo].[HisProfileIncharges]
ADD CONSTRAINT [PK_HisProfileIncharges]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisRequests'
ALTER TABLE [dbo].[HisRequests]
ADD CONSTRAINT [PK_HisRequests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisProfileReqs'
ALTER TABLE [dbo].[HisProfileReqs]
ADD CONSTRAINT [PK_HisProfileReqs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisTemplateRequests'
ALTER TABLE [dbo].[HisTemplateRequests]
ADD CONSTRAINT [PK_HisTemplateRequests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisTemplateReqItems1'
ALTER TABLE [dbo].[HisTemplateReqItems1]
ADD CONSTRAINT [PK_HisTemplateReqItems1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisReqCategories'
ALTER TABLE [dbo].[HisReqCategories]
ADD CONSTRAINT [PK_HisReqCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisReqCats'
ALTER TABLE [dbo].[HisReqCats]
ADD CONSTRAINT [PK_HisReqCats]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisNotifications'
ALTER TABLE [dbo].[HisNotifications]
ADD CONSTRAINT [PK_HisNotifications]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisNotificationLogs'
ALTER TABLE [dbo].[HisNotificationLogs]
ADD CONSTRAINT [PK_HisNotificationLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisNotificationRecipients'
ALTER TABLE [dbo].[HisNotificationRecipients]
ADD CONSTRAINT [PK_HisNotificationRecipients]
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

-- Creating foreign key on [HisOperatorId] in table 'HisEntOperators'
ALTER TABLE [dbo].[HisEntOperators]
ADD CONSTRAINT [FK_HisOperatorHisEntOperator]
    FOREIGN KEY ([HisOperatorId])
    REFERENCES [dbo].[HisOperators]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisOperatorHisEntOperator'
CREATE INDEX [IX_FK_HisOperatorHisEntOperator]
ON [dbo].[HisEntOperators]
    ([HisOperatorId]);
GO

-- Creating foreign key on [HisEntityId] in table 'HisEntOperators'
ALTER TABLE [dbo].[HisEntOperators]
ADD CONSTRAINT [FK_HisEntityHisEntOperator]
    FOREIGN KEY ([HisEntityId])
    REFERENCES [dbo].[HisEntities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisEntityHisEntOperator'
CREATE INDEX [IX_FK_HisEntityHisEntOperator]
ON [dbo].[HisEntOperators]
    ([HisEntityId]);
GO

-- Creating foreign key on [HisEntityId] in table 'HisEntAdmins'
ALTER TABLE [dbo].[HisEntAdmins]
ADD CONSTRAINT [FK_HisEntityHisEntAdmin]
    FOREIGN KEY ([HisEntityId])
    REFERENCES [dbo].[HisEntities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisEntityHisEntAdmin'
CREATE INDEX [IX_FK_HisEntityHisEntAdmin]
ON [dbo].[HisEntAdmins]
    ([HisEntityId]);
GO

-- Creating foreign key on [HisSpecializationId] in table 'HisPhysicianSpecializations'
ALTER TABLE [dbo].[HisPhysicianSpecializations]
ADD CONSTRAINT [FK_HisSpecializationHisPhysicianSpecialization]
    FOREIGN KEY ([HisSpecializationId])
    REFERENCES [dbo].[HisSpecializations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisSpecializationHisPhysicianSpecialization'
CREATE INDEX [IX_FK_HisSpecializationHisPhysicianSpecialization]
ON [dbo].[HisPhysicianSpecializations]
    ([HisSpecializationId]);
GO

-- Creating foreign key on [HisPhysicianId] in table 'HisPhysicianSpecializations'
ALTER TABLE [dbo].[HisPhysicianSpecializations]
ADD CONSTRAINT [FK_HisPhysicianHisPhysicianSpecialization]
    FOREIGN KEY ([HisPhysicianId])
    REFERENCES [dbo].[HisPhysicians]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisPhysicianHisPhysicianSpecialization'
CREATE INDEX [IX_FK_HisPhysicianHisPhysicianSpecialization]
ON [dbo].[HisPhysicianSpecializations]
    ([HisPhysicianId]);
GO

-- Creating foreign key on [HisPhysicianId] in table 'HisPhysicianClinics'
ALTER TABLE [dbo].[HisPhysicianClinics]
ADD CONSTRAINT [FK_HisPhysicianHisPhysicianClinic]
    FOREIGN KEY ([HisPhysicianId])
    REFERENCES [dbo].[HisPhysicians]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisPhysicianHisPhysicianClinic'
CREATE INDEX [IX_FK_HisPhysicianHisPhysicianClinic]
ON [dbo].[HisPhysicianClinics]
    ([HisPhysicianId]);
GO

-- Creating foreign key on [HisProfileId] in table 'HisProfileGroups'
ALTER TABLE [dbo].[HisProfileGroups]
ADD CONSTRAINT [FK_HisProfileHisProfileGroup]
    FOREIGN KEY ([HisProfileId])
    REFERENCES [dbo].[HisProfiles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisProfileHisProfileGroup'
CREATE INDEX [IX_FK_HisProfileHisProfileGroup]
ON [dbo].[HisProfileGroups]
    ([HisProfileId]);
GO

-- Creating foreign key on [HisGroupingId] in table 'HisProfileGroups'
ALTER TABLE [dbo].[HisProfileGroups]
ADD CONSTRAINT [FK_HisGroupingHisProfileGroup]
    FOREIGN KEY ([HisGroupingId])
    REFERENCES [dbo].[HisGroupings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisGroupingHisProfileGroup'
CREATE INDEX [IX_FK_HisGroupingHisProfileGroup]
ON [dbo].[HisProfileGroups]
    ([HisGroupingId]);
GO

-- Creating foreign key on [HisProfileId] in table 'HisProfileIncharges'
ALTER TABLE [dbo].[HisProfileIncharges]
ADD CONSTRAINT [FK_HisProfileHisProfileIncharge]
    FOREIGN KEY ([HisProfileId])
    REFERENCES [dbo].[HisProfiles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisProfileHisProfileIncharge'
CREATE INDEX [IX_FK_HisProfileHisProfileIncharge]
ON [dbo].[HisProfileIncharges]
    ([HisProfileId]);
GO

-- Creating foreign key on [HisInchargeId] in table 'HisProfileIncharges'
ALTER TABLE [dbo].[HisProfileIncharges]
ADD CONSTRAINT [FK_HisInchargeHisProfileIncharge]
    FOREIGN KEY ([HisInchargeId])
    REFERENCES [dbo].[HisIncharges]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisInchargeHisProfileIncharge'
CREATE INDEX [IX_FK_HisInchargeHisProfileIncharge]
ON [dbo].[HisProfileIncharges]
    ([HisInchargeId]);
GO

-- Creating foreign key on [HisProfileId] in table 'HisProfileReqs'
ALTER TABLE [dbo].[HisProfileReqs]
ADD CONSTRAINT [FK_HisProfileHisProfileReq]
    FOREIGN KEY ([HisProfileId])
    REFERENCES [dbo].[HisProfiles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisProfileHisProfileReq'
CREATE INDEX [IX_FK_HisProfileHisProfileReq]
ON [dbo].[HisProfileReqs]
    ([HisProfileId]);
GO

-- Creating foreign key on [HisRequestId] in table 'HisProfileReqs'
ALTER TABLE [dbo].[HisProfileReqs]
ADD CONSTRAINT [FK_HisRequestHisProfileReq]
    FOREIGN KEY ([HisRequestId])
    REFERENCES [dbo].[HisRequests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisRequestHisProfileReq'
CREATE INDEX [IX_FK_HisRequestHisProfileReq]
ON [dbo].[HisProfileReqs]
    ([HisRequestId]);
GO

-- Creating foreign key on [HisTemplateRequestId] in table 'HisTemplateReqItems1'
ALTER TABLE [dbo].[HisTemplateReqItems1]
ADD CONSTRAINT [FK_HisTemplateRequestHisTemplateReqItems]
    FOREIGN KEY ([HisTemplateRequestId])
    REFERENCES [dbo].[HisTemplateRequests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisTemplateRequestHisTemplateReqItems'
CREATE INDEX [IX_FK_HisTemplateRequestHisTemplateReqItems]
ON [dbo].[HisTemplateReqItems1]
    ([HisTemplateRequestId]);
GO

-- Creating foreign key on [HisRequestId] in table 'HisTemplateReqItems1'
ALTER TABLE [dbo].[HisTemplateReqItems1]
ADD CONSTRAINT [FK_HisRequestHisTemplateReqItems]
    FOREIGN KEY ([HisRequestId])
    REFERENCES [dbo].[HisRequests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisRequestHisTemplateReqItems'
CREATE INDEX [IX_FK_HisRequestHisTemplateReqItems]
ON [dbo].[HisTemplateReqItems1]
    ([HisRequestId]);
GO

-- Creating foreign key on [HisReqCategoryId] in table 'HisReqCats'
ALTER TABLE [dbo].[HisReqCats]
ADD CONSTRAINT [FK_HisReqCategoryHisReqCat]
    FOREIGN KEY ([HisReqCategoryId])
    REFERENCES [dbo].[HisReqCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisReqCategoryHisReqCat'
CREATE INDEX [IX_FK_HisReqCategoryHisReqCat]
ON [dbo].[HisReqCats]
    ([HisReqCategoryId]);
GO

-- Creating foreign key on [HisRequestId] in table 'HisReqCats'
ALTER TABLE [dbo].[HisReqCats]
ADD CONSTRAINT [FK_HisRequestHisReqCat]
    FOREIGN KEY ([HisRequestId])
    REFERENCES [dbo].[HisRequests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisRequestHisReqCat'
CREATE INDEX [IX_FK_HisRequestHisReqCat]
ON [dbo].[HisReqCats]
    ([HisRequestId]);
GO

-- Creating foreign key on [HisNotificationId] in table 'HisNotificationRecipients'
ALTER TABLE [dbo].[HisNotificationRecipients]
ADD CONSTRAINT [FK_HisNotificationHisNotificationRecipient]
    FOREIGN KEY ([HisNotificationId])
    REFERENCES [dbo].[HisNotifications]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisNotificationHisNotificationRecipient'
CREATE INDEX [IX_FK_HisNotificationHisNotificationRecipient]
ON [dbo].[HisNotificationRecipients]
    ([HisNotificationId]);
GO

-- Creating foreign key on [HisNotificationRecipientId] in table 'HisNotificationLogs'
ALTER TABLE [dbo].[HisNotificationLogs]
ADD CONSTRAINT [FK_HisNotificationRecipientHisNotificationLog]
    FOREIGN KEY ([HisNotificationRecipientId])
    REFERENCES [dbo].[HisNotificationRecipients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisNotificationRecipientHisNotificationLog'
CREATE INDEX [IX_FK_HisNotificationRecipientHisNotificationLog]
ON [dbo].[HisNotificationLogs]
    ([HisNotificationRecipientId]);
GO

-- Creating foreign key on [HisPhysicianId] in table 'HisProfileReqs'
ALTER TABLE [dbo].[HisProfileReqs]
ADD CONSTRAINT [FK_HisPhysicianHisProfileReq]
    FOREIGN KEY ([HisPhysicianId])
    REFERENCES [dbo].[HisPhysicians]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisPhysicianHisProfileReq'
CREATE INDEX [IX_FK_HisPhysicianHisProfileReq]
ON [dbo].[HisProfileReqs]
    ([HisPhysicianId]);
GO

-- Creating foreign key on [HisInchargeId] in table 'HisProfileReqs'
ALTER TABLE [dbo].[HisProfileReqs]
ADD CONSTRAINT [FK_HisInchargeHisProfileReq]
    FOREIGN KEY ([HisInchargeId])
    REFERENCES [dbo].[HisIncharges]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisInchargeHisProfileReq'
CREATE INDEX [IX_FK_HisInchargeHisProfileReq]
ON [dbo].[HisProfileReqs]
    ([HisInchargeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------