CREATE PROCEDURE ReadAbsents
	@SubjectId VARCHAR(36),
	@StudentId VARCHAR(36),
	@IsConfirmed BIT,
	@DateAbsent DATETIME2
	AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE @query NVARCHAR(4000) = 'select * from Absent ',
			@key NVARCHAR(1000) = ''

	IF @SubjectId IS NOT NULL SELECT @key = 'SubjectId = ''' + REPLACE(@SubjectId, '''', '') + ''''
	IF @StudentId IS NOT NULL SELECT @key = @key + CASE WHEN @key = '' THEN '' ELSE ' and ' END + 'StudentId = ''' + REPLACE(@StudentId, '''', '') + ''''
	IF @DateAbsent IS NOT NULL SELECT @key = @key + CASE WHEN @key = '' THEN '' ELSE ' and ' END + 'DateAbsent = ''' + REPLACE(@DateAbsent, '''', '') + ''''
	IF @IsConfirmed IS NOT NULL SELECT @key = @key + CASE WHEN @key = '' THEN '' ELSE ' and ' END + 'IsConfirmed = ' + CAST(@IsConfirmed AS VARCHAR(1))
	SELECT @query = @query + CASE WHEN @key = '' THEN '' ELSE ' where ' + @key END
	EXEC sp_executesql @query

	SET NOCOUNT OFF
END

GO
