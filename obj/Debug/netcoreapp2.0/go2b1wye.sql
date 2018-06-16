IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [events] (
    [EventId] int NOT NULL IDENTITY,
    [Coords] nvarchar(max) NOT NULL,
    [Data] datetime2 NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_events] PRIMARY KEY ([EventId])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180609224559_Initial', N'2.0.3-rtm-10026');

GO

ALTER TABLE [events] DROP CONSTRAINT [PK_events];

GO

EXEC sp_rename N'events', N'Events';

GO

EXEC sp_rename N'Events.Data', N'Date', N'COLUMN';

GO

ALTER TABLE [Events] ADD CONSTRAINT [PK_Events] PRIMARY KEY ([EventId]);

GO

CREATE TABLE [Users] (
    [UserId] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Surname] nvarchar(max) NOT NULL,
    [Username] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);

GO

CREATE TABLE [EventParticipants] (
    [EventParticipantsID] int NOT NULL IDENTITY,
    [EventID] int NOT NULL,
    [UserID] int NOT NULL,
    CONSTRAINT [PK_EventParticipants] PRIMARY KEY ([EventParticipantsID]),
    CONSTRAINT [FK_EventParticipants_Events_EventID] FOREIGN KEY ([EventID]) REFERENCES [Events] ([EventId]) ON DELETE CASCADE,
    CONSTRAINT [FK_EventParticipants_Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_EventParticipants_EventID] ON [EventParticipants] ([EventID]);

GO

CREATE INDEX [IX_EventParticipants_UserID] ON [EventParticipants] ([UserID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180609225454_Initial1', N'2.0.3-rtm-10026');

GO

ALTER TABLE [Events] ADD [PlaceId] int NOT NULL DEFAULT 0;

GO

CREATE TABLE [Places] (
    [PlaceId] int NOT NULL IDENTITY,
    [Adress] nvarchar(max) NOT NULL,
    [Lat] float NOT NULL,
    [Lng] float NOT NULL,
    CONSTRAINT [PK_Places] PRIMARY KEY ([PlaceId])
);

GO

CREATE INDEX [IX_Events_PlaceId] ON [Events] ([PlaceId]);

GO

ALTER TABLE [Events] ADD CONSTRAINT [FK_Events_Places_PlaceId] FOREIGN KEY ([PlaceId]) REFERENCES [Places] ([PlaceId]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180610174825_Adress Tabl', N'2.0.3-rtm-10026');

GO

ALTER TABLE [Events] DROP CONSTRAINT [FK_Events_Places_PlaceId];

GO

DROP TABLE [Places];

GO

DROP INDEX [IX_Events_PlaceId] ON [Events];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Events') AND [c].[name] = N'PlaceId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Events] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Events] DROP COLUMN [PlaceId];

GO

ALTER TABLE [Events] ADD [EventAdressId] int NULL;

GO

CREATE TABLE [EventAdress] (
    [EventAdressId] int NOT NULL IDENTITY,
    [Address] nvarchar(max) NOT NULL,
    [City] nvarchar(max) NOT NULL,
    [HouseNumber] nvarchar(max) NOT NULL,
    [Lat] float NOT NULL,
    [Lng] float NOT NULL,
    [PostCode] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_EventAdress] PRIMARY KEY ([EventAdressId])
);

GO

CREATE INDEX [IX_Events_EventAdressId] ON [Events] ([EventAdressId]);

GO

ALTER TABLE [Events] ADD CONSTRAINT [FK_Events_EventAdress_EventAdressId] FOREIGN KEY ([EventAdressId]) REFERENCES [EventAdress] ([EventAdressId]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180610175455_EvetAdrss', N'2.0.3-rtm-10026');

GO

EXEC sp_rename N'EventAdress.Address', N'Street', N'COLUMN';

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Events') AND [c].[name] = N'Coords');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Events] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Events] ALTER COLUMN [Coords] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180612182315_CoordsNotRequired', N'2.0.3-rtm-10026');

GO

ALTER TABLE [Events] DROP CONSTRAINT [FK_Events_EventAdress_EventAdressId];

GO

DROP INDEX [IX_Events_EventAdressId] ON [Events];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Events') AND [c].[name] = N'EventAdressId');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Events] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Events] DROP COLUMN [EventAdressId];

GO

ALTER TABLE [EventAdress] ADD [EventId] int NOT NULL DEFAULT 0;

GO

CREATE UNIQUE INDEX [IX_EventAdress_EventId] ON [EventAdress] ([EventId]);

GO

ALTER TABLE [EventAdress] ADD CONSTRAINT [FK_EventAdress_Events_EventId] FOREIGN KEY ([EventId]) REFERENCES [Events] ([EventId]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180612183241_EventAddressForeignKey', N'2.0.3-rtm-10026');

GO

ALTER TABLE [EventAdress] DROP CONSTRAINT [FK_EventAdress_Events_EventId];

GO

DROP INDEX [IX_EventAdress_EventId] ON [EventAdress];

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'EventAdress') AND [c].[name] = N'EventId');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [EventAdress] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [EventAdress] DROP COLUMN [EventId];

GO

ALTER TABLE [Events] ADD [EventAdressId] int NOT NULL DEFAULT 0;

GO

CREATE INDEX [IX_Events_EventAdressId] ON [Events] ([EventAdressId]);

GO

ALTER TABLE [Events] ADD CONSTRAINT [FK_Events_EventAdress_EventAdressId] FOREIGN KEY ([EventAdressId]) REFERENCES [EventAdress] ([EventAdressId]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180612183532_EventAddressForeignKey1', N'2.0.3-rtm-10026');

GO

ALTER TABLE [Events] DROP CONSTRAINT [FK_Events_EventAdress_EventAdressId];

GO

DROP INDEX [IX_Events_EventAdressId] ON [Events];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180612183731_EventAddressForeignKey12', N'2.0.3-rtm-10026');

GO

CREATE INDEX [IX_Events_EventAdressId] ON [Events] ([EventAdressId]);

GO

ALTER TABLE [Events] ADD CONSTRAINT [FK_Events_EventAdress_EventAdressId] FOREIGN KEY ([EventAdressId]) REFERENCES [EventAdress] ([EventAdressId]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180612183958_EventAddressForeignKey2', N'2.0.3-rtm-10026');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180612193004_aad222', N'2.0.3-rtm-10026');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180612193041_aad2222', N'2.0.3-rtm-10026');

GO

ALTER TABLE [Events] ADD [Coords1] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180612193110_aad222223', N'2.0.3-rtm-10026');

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Events') AND [c].[name] = N'Coords1');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Events] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Events] DROP COLUMN [Coords1];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180612193127_aad22222', N'2.0.3-rtm-10026');

GO

ALTER TABLE [Events] DROP CONSTRAINT [FK_Events_EventAdress_EventAdressId];

GO

DROP INDEX [IX_Events_EventAdressId] ON [Events];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180612193701_aad222221', N'2.0.3-rtm-10026');

GO

CREATE INDEX [IX_Events_EventAdressId] ON [Events] ([EventAdressId]);

GO

ALTER TABLE [Events] ADD CONSTRAINT [FK_Events_EventAdress_EventAdressId] FOREIGN KEY ([EventAdressId]) REFERENCES [EventAdress] ([EventAdressId]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180612193759_aad2222211', N'2.0.3-rtm-10026');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180612193909_aad22222111', N'2.0.3-rtm-10026');

GO

ALTER TABLE [Events] DROP CONSTRAINT [FK_Events_EventAdress_EventAdressId];

GO

DROP INDEX [IX_Events_EventAdressId] ON [Events];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180612193925_aad2222211111', N'2.0.3-rtm-10026');

GO

CREATE INDEX [IX_Events_EventAdressId] ON [Events] ([EventAdressId]);

GO

ALTER TABLE [Events] ADD CONSTRAINT [FK_Events_EventAdress_EventAdressId] FOREIGN KEY ([EventAdressId]) REFERENCES [EventAdress] ([EventAdressId]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180612193940_aad22222111111', N'2.0.3-rtm-10026');

GO

ALTER TABLE [Events] ADD [Description] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180615144123_descriptionAdd', N'2.0.3-rtm-10026');

GO

ALTER TABLE [Events] ADD [DisciplineId] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180615160327_DisciplineAdd', N'2.0.3-rtm-10026');

GO

CREATE TABLE [Disciplines] (
    [DieciplineId] int NOT NULL IDENTITY,
    [Discipline] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Disciplines] PRIMARY KEY ([DieciplineId])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180615160609_DisciplineTableAdded', N'2.0.3-rtm-10026');

GO

EXEC sp_rename N'Disciplines.Discipline', N'Name', N'COLUMN';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180615181242_discipline', N'2.0.3-rtm-10026');

GO

CREATE INDEX [IX_Events_DisciplineId] ON [Events] ([DisciplineId]);

GO

ALTER TABLE [Events] ADD CONSTRAINT [FK_Events_Disciplines_DisciplineId] FOREIGN KEY ([DisciplineId]) REFERENCES [Disciplines] ([DieciplineId]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180615211256_EventsModify', N'2.0.3-rtm-10026');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180615211642_EventsModify1', N'2.0.3-rtm-10026');

GO

