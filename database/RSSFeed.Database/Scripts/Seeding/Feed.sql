MERGE INTO [Feed] AS [target]
USING
    (
    VALUES
        ( 'Sample', 'A Sample Feed' )
    )
    AS [source]
    (
        [Title],
        [Description]
    )
ON [source].[Title] = [target].[Title]

WHEN MATCHED THEN
    UPDATE SET
        [Description] = [source].[Description]
WHEN NOT MATCHED BY TARGET THEN
    INSERT
    (
        [Title],
        [Description]
    )
    VALUES
    (
        [source].[Title],
        [source].[Description]
    )
;
