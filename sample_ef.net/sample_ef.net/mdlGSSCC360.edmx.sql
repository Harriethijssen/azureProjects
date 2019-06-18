
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/30/2019 08:52:00
-- Generated from EDMX file: F:\Projects\sample_ef.net\sample_ef.net\mdlGSSCC360.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClubMember_Club]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClubMember] DROP CONSTRAINT [FK_ClubMember_Club];
GO
IF OBJECT_ID(N'[dbo].[FK_ClubMember_Member]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClubMember] DROP CONSTRAINT [FK_ClubMember_Member];
GO
IF OBJECT_ID(N'[dbo].[FK_DoglutBreed]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dogs] DROP CONSTRAINT [FK_DoglutBreed];
GO
IF OBJECT_ID(N'[dbo].[FK_DogDog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dogs] DROP CONSTRAINT [FK_DogDog];
GO
IF OBJECT_ID(N'[dbo].[FK_DogDog1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dogs] DROP CONSTRAINT [FK_DogDog1];
GO
IF OBJECT_ID(N'[dbo].[FK_DogMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dogs] DROP CONSTRAINT [FK_DogMember];
GO
IF OBJECT_ID(N'[dbo].[FK_ClubTrialEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events_TrialEvent] DROP CONSTRAINT [FK_ClubTrialEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_TrialEntryDog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrialEntries] DROP CONSTRAINT [FK_TrialEntryDog];
GO
IF OBJECT_ID(N'[dbo].[FK_TrialEntryMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrialEntries] DROP CONSTRAINT [FK_TrialEntryMember];
GO
IF OBJECT_ID(N'[dbo].[FK_TrialEventTrialEntry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrialEntries] DROP CONSTRAINT [FK_TrialEventTrialEntry];
GO
IF OBJECT_ID(N'[dbo].[FK_DogDocument]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dogs] DROP CONSTRAINT [FK_DogDocument];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonNotification]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notifications] DROP CONSTRAINT [FK_PersonNotification];
GO
IF OBJECT_ID(N'[dbo].[FK_ClubNotification]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notifications] DROP CONSTRAINT [FK_ClubNotification];
GO
IF OBJECT_ID(N'[dbo].[FK_Member_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[People_Member] DROP CONSTRAINT [FK_Member_inherits_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_TrialEvent_inherits_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events_TrialEvent] DROP CONSTRAINT [FK_TrialEvent_inherits_Event];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[People]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People];
GO
IF OBJECT_ID(N'[dbo].[Clubs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clubs];
GO
IF OBJECT_ID(N'[dbo].[Dogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dogs];
GO
IF OBJECT_ID(N'[dbo].[lutBreeds]', 'U') IS NOT NULL
    DROP TABLE [dbo].[lutBreeds];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[TrialEntries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrialEntries];
GO
IF OBJECT_ID(N'[dbo].[Documents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Documents];
GO
IF OBJECT_ID(N'[dbo].[Notifications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notifications];
GO
IF OBJECT_ID(N'[dbo].[People_Member]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People_Member];
GO
IF OBJECT_ID(N'[dbo].[Events_TrialEvent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events_TrialEvent];
GO
IF OBJECT_ID(N'[dbo].[ClubMember]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClubMember];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EMail] nvarchar(max)  NOT NULL,
    [Firstname] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Address1] nvarchar(max)  NOT NULL,
    [Address2] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Province] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Clubs'
CREATE TABLE [dbo].[Clubs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [State] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Dogs'
CREATE TABLE [dbo].[Dogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(max)  NOT NULL,
    [Sex] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [Breed_Id] int  NOT NULL,
    [Sire_Id] int  NOT NULL,
    [Dam_Id] int  NOT NULL,
    [Member_Id] int  NOT NULL,
    [Pedigree_Id] int  NOT NULL
);
GO

-- Creating table 'lutBreeds'
CREATE TABLE [dbo].[lutBreeds] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateStart] nvarchar(max)  NOT NULL,
    [DateEnd] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TrialEntries'
CREATE TABLE [dbo].[TrialEntries] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ScoreA] nvarchar(max)  NOT NULL,
    [ScoreB] nvarchar(max)  NOT NULL,
    [TrialEventId] int  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [Dog_Id] int  NOT NULL,
    [Handler_Id] int  NOT NULL
);
GO

-- Creating table 'Documents'
CREATE TABLE [dbo].[Documents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Url] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Notifications'
CREATE TABLE [dbo].[Notifications] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PersonId] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Club_Id] int  NULL,
    [TrialEntry_Id] int  NULL
);
GO

-- Creating table 'People_Member'
CREATE TABLE [dbo].[People_Member] (
    [IdMember] int IDENTITY(1,1) NOT NULL,
    [GSSCCNumber] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Events_TrialEvent'
CREATE TABLE [dbo].[Events_TrialEvent] (
    [IdTrialEvent] int IDENTITY(1,1) NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL,
    [HostedBy_Id] int  NOT NULL
);
GO

-- Creating table 'ClubMember'
CREATE TABLE [dbo].[ClubMember] (
    [Clubs_Id] int  NOT NULL,
    [Members_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clubs'
ALTER TABLE [dbo].[Clubs]
ADD CONSTRAINT [PK_Clubs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Dogs'
ALTER TABLE [dbo].[Dogs]
ADD CONSTRAINT [PK_Dogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'lutBreeds'
ALTER TABLE [dbo].[lutBreeds]
ADD CONSTRAINT [PK_lutBreeds]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TrialEntries'
ALTER TABLE [dbo].[TrialEntries]
ADD CONSTRAINT [PK_TrialEntries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [PK_Documents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Notifications'
ALTER TABLE [dbo].[Notifications]
ADD CONSTRAINT [PK_Notifications]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'People_Member'
ALTER TABLE [dbo].[People_Member]
ADD CONSTRAINT [PK_People_Member]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Events_TrialEvent'
ALTER TABLE [dbo].[Events_TrialEvent]
ADD CONSTRAINT [PK_Events_TrialEvent]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Clubs_Id], [Members_Id] in table 'ClubMember'
ALTER TABLE [dbo].[ClubMember]
ADD CONSTRAINT [PK_ClubMember]
    PRIMARY KEY CLUSTERED ([Clubs_Id], [Members_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Clubs_Id] in table 'ClubMember'
ALTER TABLE [dbo].[ClubMember]
ADD CONSTRAINT [FK_ClubMember_Club]
    FOREIGN KEY ([Clubs_Id])
    REFERENCES [dbo].[Clubs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Members_Id] in table 'ClubMember'
ALTER TABLE [dbo].[ClubMember]
ADD CONSTRAINT [FK_ClubMember_Member]
    FOREIGN KEY ([Members_Id])
    REFERENCES [dbo].[People_Member]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClubMember_Member'
CREATE INDEX [IX_FK_ClubMember_Member]
ON [dbo].[ClubMember]
    ([Members_Id]);
GO

-- Creating foreign key on [Breed_Id] in table 'Dogs'
ALTER TABLE [dbo].[Dogs]
ADD CONSTRAINT [FK_DoglutBreed]
    FOREIGN KEY ([Breed_Id])
    REFERENCES [dbo].[lutBreeds]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoglutBreed'
CREATE INDEX [IX_FK_DoglutBreed]
ON [dbo].[Dogs]
    ([Breed_Id]);
GO

-- Creating foreign key on [Sire_Id] in table 'Dogs'
ALTER TABLE [dbo].[Dogs]
ADD CONSTRAINT [FK_DogDog]
    FOREIGN KEY ([Sire_Id])
    REFERENCES [dbo].[Dogs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DogDog'
CREATE INDEX [IX_FK_DogDog]
ON [dbo].[Dogs]
    ([Sire_Id]);
GO

-- Creating foreign key on [Dam_Id] in table 'Dogs'
ALTER TABLE [dbo].[Dogs]
ADD CONSTRAINT [FK_DogDog1]
    FOREIGN KEY ([Dam_Id])
    REFERENCES [dbo].[Dogs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DogDog1'
CREATE INDEX [IX_FK_DogDog1]
ON [dbo].[Dogs]
    ([Dam_Id]);
GO

-- Creating foreign key on [Member_Id] in table 'Dogs'
ALTER TABLE [dbo].[Dogs]
ADD CONSTRAINT [FK_DogMember]
    FOREIGN KEY ([Member_Id])
    REFERENCES [dbo].[People_Member]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DogMember'
CREATE INDEX [IX_FK_DogMember]
ON [dbo].[Dogs]
    ([Member_Id]);
GO

-- Creating foreign key on [HostedBy_Id] in table 'Events_TrialEvent'
ALTER TABLE [dbo].[Events_TrialEvent]
ADD CONSTRAINT [FK_ClubTrialEvent]
    FOREIGN KEY ([HostedBy_Id])
    REFERENCES [dbo].[Clubs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClubTrialEvent'
CREATE INDEX [IX_FK_ClubTrialEvent]
ON [dbo].[Events_TrialEvent]
    ([HostedBy_Id]);
GO

-- Creating foreign key on [Dog_Id] in table 'TrialEntries'
ALTER TABLE [dbo].[TrialEntries]
ADD CONSTRAINT [FK_TrialEntryDog]
    FOREIGN KEY ([Dog_Id])
    REFERENCES [dbo].[Dogs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrialEntryDog'
CREATE INDEX [IX_FK_TrialEntryDog]
ON [dbo].[TrialEntries]
    ([Dog_Id]);
GO

-- Creating foreign key on [Handler_Id] in table 'TrialEntries'
ALTER TABLE [dbo].[TrialEntries]
ADD CONSTRAINT [FK_TrialEntryMember]
    FOREIGN KEY ([Handler_Id])
    REFERENCES [dbo].[People_Member]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrialEntryMember'
CREATE INDEX [IX_FK_TrialEntryMember]
ON [dbo].[TrialEntries]
    ([Handler_Id]);
GO

-- Creating foreign key on [TrialEventId] in table 'TrialEntries'
ALTER TABLE [dbo].[TrialEntries]
ADD CONSTRAINT [FK_TrialEventTrialEntry]
    FOREIGN KEY ([TrialEventId])
    REFERENCES [dbo].[Events_TrialEvent]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrialEventTrialEntry'
CREATE INDEX [IX_FK_TrialEventTrialEntry]
ON [dbo].[TrialEntries]
    ([TrialEventId]);
GO

-- Creating foreign key on [Pedigree_Id] in table 'Dogs'
ALTER TABLE [dbo].[Dogs]
ADD CONSTRAINT [FK_DogDocument]
    FOREIGN KEY ([Pedigree_Id])
    REFERENCES [dbo].[Documents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DogDocument'
CREATE INDEX [IX_FK_DogDocument]
ON [dbo].[Dogs]
    ([Pedigree_Id]);
GO

-- Creating foreign key on [PersonId] in table 'Notifications'
ALTER TABLE [dbo].[Notifications]
ADD CONSTRAINT [FK_PersonNotification]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[People]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonNotification'
CREATE INDEX [IX_FK_PersonNotification]
ON [dbo].[Notifications]
    ([PersonId]);
GO

-- Creating foreign key on [Club_Id] in table 'Notifications'
ALTER TABLE [dbo].[Notifications]
ADD CONSTRAINT [FK_ClubNotification]
    FOREIGN KEY ([Club_Id])
    REFERENCES [dbo].[Clubs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClubNotification'
CREATE INDEX [IX_FK_ClubNotification]
ON [dbo].[Notifications]
    ([Club_Id]);
GO

-- Creating foreign key on [TrialEntry_Id] in table 'Notifications'
ALTER TABLE [dbo].[Notifications]
ADD CONSTRAINT [FK_TrialEntryNotification]
    FOREIGN KEY ([TrialEntry_Id])
    REFERENCES [dbo].[TrialEntries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrialEntryNotification'
CREATE INDEX [IX_FK_TrialEntryNotification]
ON [dbo].[Notifications]
    ([TrialEntry_Id]);
GO

-- Creating foreign key on [Id] in table 'People_Member'
ALTER TABLE [dbo].[People_Member]
ADD CONSTRAINT [FK_Member_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[People]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Events_TrialEvent'
ALTER TABLE [dbo].[Events_TrialEvent]
ADD CONSTRAINT [FK_TrialEvent_inherits_Event]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------