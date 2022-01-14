CREATE PROCEDURE [dbo].[uspCreateFeedItem]
(
    @FeedId                             UNIQUEIDENTIFIER,
    @Text                               NVARCHAR(MAX)
)
AS

DECLARE @Id                             UNIQUEIDENTIFIER    = NEWID();
DECLARE @CreatedDate                    DATETIME2           = GETUTCDATE();

-- VALIDATE
IF NOT EXISTS (SELECT TOP 1 1 FROM [Feed] WHERE [Id] = @FeedId) BEGIN
    SELECT CONCAT('Feed does not exist:', @Id)
    RETURN 1
END

-- CREATE
INSERT [FeedItem]
(
    [Id],
    [FeedId],
    [Text],
    [CreatedDate]
)
VALUES
(
    @Id,
    @FeedId,
    @Text,
    @CreatedDate
)

-- MAINTAIN FEED STATS
UPDATE  [Feed]
SET     [PublishedDate]                 = @CreatedDate
WHERE   [Id]                            = @FeedId

-- RETURN
SELECT  *
FROM    [FeedItem]
WHERE   [Id]                            = @Id

RETURN 0
