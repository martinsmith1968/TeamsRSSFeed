CREATE FUNCTION [dbo].[Base64Encode]
(
    @Text                               NVARCHAR(MAX)
)
RETURNS
    NVARCHAR(MAX)
AS
BEGIN

DECLARE @Result NVARCHAR(MAX)
    = (SELECT CAST(@Text as varbinary(max)) FOR XML PATH(''), BINARY BASE64);

    RETURN @Result
END
