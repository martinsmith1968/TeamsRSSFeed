CREATE FUNCTION [dbo].[Base64Decode]
(
    @Base64                             NVARCHAR(MAX)
)
RETURNS
    NVARCHAR(MAX)
AS
BEGIN

DECLARE @Result NVARCHAR(MAX)
    = (CAST( CAST( @Base64 as XML ).value('.','varbinary(max)') AS NVARCHAR(MAX) ));

    RETURN @Result
END
