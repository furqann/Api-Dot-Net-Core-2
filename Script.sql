IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Issues] (
    [Id] int NOT NULL IDENTITY,
    [CreatedAt] datetime2 NULL,
    [Description] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_Issues] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180321081421_InitialCreate', N'2.0.2-rtm-10011');

GO

