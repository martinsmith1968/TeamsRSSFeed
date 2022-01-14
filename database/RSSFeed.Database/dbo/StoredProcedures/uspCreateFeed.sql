CREATE PROCEDURE [dbo].[uspCreateFeed]
(
    @Title                              NVARCHAR(32),
    @Description                        NVARCHAR(200)
)
AS

DECLARE @Id                             UNIQUEIDENTIFIER    = NEWID();

-- CREATE
INSERT [Feed]
(
    [Id],
    [Title],
    [Description]
)
VALUES
(
    @Id,
    @Title,
    @Description
)

-- RETURN
SELECT  *
FROM    [Feed]
WHERE   [Id]                        = @Id;

RETURN 0
