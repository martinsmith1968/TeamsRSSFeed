CREATE TABLE [dbo].[Feed]
(
    [Id]                                UNIQUEIDENTIFIER    NOT NULL    DEFAULT NEWID(),
    [Title]                             NVARCHAR(32)        NOT NULL,
    [Description]                       NVARCHAR(200)       NOT NULL,
    [CreatedDate]                       DATETIME2           NOT NULL    DEFAULT GETUTCDATE(),
    [ModifiedDate]                      DATETIME2           NULL,
    [PublishedDate]                     DATETIME2           NULL,

    CONSTRAINT [PK_Feed] PRIMARY KEY NONCLUSTERED ([Id]),

    CONSTRAINT [UQ_Feed_Title] UNIQUE ([Title]),
    CONSTRAINT [CK_Feed_Title] CHECK ([Title] NOT LIKE '% %'),
)
GO
