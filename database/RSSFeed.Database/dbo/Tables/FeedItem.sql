CREATE TABLE [dbo].[FeedItem]
(
    [Id]                                UNIQUEIDENTIFIER    NOT NULL    DEFAULT NEWID(),
    [FeedId]                            UNIQUEIDENTIFIER    NOT NULL,
    [Text]                              NVARCHAR(MAX)       NOT NULL,
    [IsPublished]                       BIT                 NOT NULL    DEFAULT 1,
    [CreatedDate]                       DATETIME2           NOT NULL    DEFAULT GETUTCDATE(),
    [ModifiedDate]                      DATETIME2           NULL,

    CONSTRAINT [PK_FeedItem] PRIMARY KEY NONCLUSTERED ([Id]),

    CONSTRAINT [FK_FeedItem_FeedId] FOREIGN KEY ([FeedId]) REFERENCES [Feed]([Id]),
)
GO

CREATE INDEX [IX_FeedItem_FeedId]
ON [FeedItem]
(
    [FeedId]
)
INCLUDE
(
    [IsPublished],
    [CreatedDate]
)
GO
