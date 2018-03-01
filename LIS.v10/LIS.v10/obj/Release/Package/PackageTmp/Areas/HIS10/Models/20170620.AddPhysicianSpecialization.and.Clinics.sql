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
