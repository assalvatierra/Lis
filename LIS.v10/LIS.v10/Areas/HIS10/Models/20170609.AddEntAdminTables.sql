-- Creating table 'HisAdmins'
CREATE TABLE [dbo].[HisAdmins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AccntUserId] nvarchar(max)  NOT NULL,
    [Remarks] nvarchar(80)  NULL
);
GO

-- Creating table 'HisEntAdmins'
CREATE TABLE [dbo].[HisEntAdmins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HisAdminId] int  NOT NULL,
    [HisEntityId] int  NOT NULL
);
GO

-- Creating primary key on [Id] in table 'HisAdmins'
ALTER TABLE [dbo].[HisAdmins]
ADD CONSTRAINT [PK_HisAdmins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HisEntAdmins'
ALTER TABLE [dbo].[HisEntAdmins]
ADD CONSTRAINT [PK_HisEntAdmins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO
-- Creating foreign key on [HisAdminId] in table 'HisEntAdmins'
ALTER TABLE [dbo].[HisEntAdmins]
ADD CONSTRAINT [FK_HisAdminHisEntAdmin]
    FOREIGN KEY ([HisAdminId])
    REFERENCES [dbo].[HisAdmins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HisAdminHisEntAdmin'
CREATE INDEX [IX_FK_HisAdminHisEntAdmin]
ON [dbo].[HisEntAdmins]
    ([HisAdminId]);
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
