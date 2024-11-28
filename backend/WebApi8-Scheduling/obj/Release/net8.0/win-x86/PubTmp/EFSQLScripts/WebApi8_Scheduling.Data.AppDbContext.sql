IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126175602_teste'
)
BEGIN
    CREATE TABLE [Clients] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126175602_teste'
)
BEGIN
    CREATE TABLE [Services] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Services] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126175602_teste'
)
BEGIN
    CREATE TABLE [Scheduling] (
        [Id] int NOT NULL IDENTITY,
        [DateHour] datetime2 NOT NULL,
        [ClientModelId] int NULL,
        [ServiceModelId] int NULL,
        CONSTRAINT [PK_Scheduling] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Scheduling_Clients_ClientModelId] FOREIGN KEY ([ClientModelId]) REFERENCES [Clients] ([Id]),
        CONSTRAINT [FK_Scheduling_Services_ServiceModelId] FOREIGN KEY ([ServiceModelId]) REFERENCES [Services] ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126175602_teste'
)
BEGIN
    CREATE INDEX [IX_Scheduling_ClientModelId] ON [Scheduling] ([ClientModelId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126175602_teste'
)
BEGIN
    CREATE INDEX [IX_Scheduling_ServiceModelId] ON [Scheduling] ([ServiceModelId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126175602_teste'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241126175602_teste', N'9.0.0');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126194124_addServicesAndScheduling'
)
BEGIN
    ALTER TABLE [Scheduling] DROP CONSTRAINT [FK_Scheduling_Clients_ClientModelId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126194124_addServicesAndScheduling'
)
BEGIN
    ALTER TABLE [Scheduling] DROP CONSTRAINT [FK_Scheduling_Services_ServiceModelId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126194124_addServicesAndScheduling'
)
BEGIN
    DROP INDEX [IX_Scheduling_ClientModelId] ON [Scheduling];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126194124_addServicesAndScheduling'
)
BEGIN
    DROP INDEX [IX_Scheduling_ServiceModelId] ON [Scheduling];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126194124_addServicesAndScheduling'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Scheduling]') AND [c].[name] = N'ClientModelId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Scheduling] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Scheduling] DROP COLUMN [ClientModelId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126194124_addServicesAndScheduling'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Scheduling]') AND [c].[name] = N'ServiceModelId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Scheduling] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Scheduling] DROP COLUMN [ServiceModelId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126194124_addServicesAndScheduling'
)
BEGIN
    ALTER TABLE [Scheduling] ADD [ClientId] int NOT NULL DEFAULT 0;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126194124_addServicesAndScheduling'
)
BEGIN
    ALTER TABLE [Scheduling] ADD [Observation] nvarchar(max) NOT NULL DEFAULT N'';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126194124_addServicesAndScheduling'
)
BEGIN
    ALTER TABLE [Scheduling] ADD [ServiceId] int NOT NULL DEFAULT 0;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126194124_addServicesAndScheduling'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Services]'))
        SET IDENTITY_INSERT [Services] ON;
    EXEC(N'INSERT INTO [Services] ([Id], [Description], [Name], [Price])
    VALUES (1, N''Penteado pétala, contendo taltal'', N''Penteado Pétala'', 1099.99),
    (2, N''Penteado rosa, contendo taltal'', N''Penteado Rosa'', 1199.99),
    (3, N''Penteado bouquet, contendo taltal'', N''Penteado Bouquet'', 1299.99),
    (4, N''Penteado premium, contendo taltal'', N''Penteado Premium'', 1399.99)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Services]'))
        SET IDENTITY_INSERT [Services] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126194124_addServicesAndScheduling'
)
BEGIN
    CREATE INDEX [IX_Scheduling_ClientId] ON [Scheduling] ([ClientId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126194124_addServicesAndScheduling'
)
BEGIN
    CREATE INDEX [IX_Scheduling_ServiceId] ON [Scheduling] ([ServiceId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126194124_addServicesAndScheduling'
)
BEGIN
    ALTER TABLE [Scheduling] ADD CONSTRAINT [FK_Scheduling_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126194124_addServicesAndScheduling'
)
BEGIN
    ALTER TABLE [Scheduling] ADD CONSTRAINT [FK_Scheduling_Services_ServiceId] FOREIGN KEY ([ServiceId]) REFERENCES [Services] ([Id]) ON DELETE CASCADE;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126194124_addServicesAndScheduling'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241126194124_addServicesAndScheduling', N'9.0.0');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126195601_addTelClient'
)
BEGIN
    ALTER TABLE [Clients] ADD [Tel] nvarchar(max) NOT NULL DEFAULT N'';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241126195601_addTelClient'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241126195601_addTelClient', N'9.0.0');
END;

COMMIT;
GO

