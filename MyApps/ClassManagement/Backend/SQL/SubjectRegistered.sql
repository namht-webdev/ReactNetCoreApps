CREATE PROCEDURE ReadSubjectsRegistered
	@ClassId VARCHAR(36),
	@SubjectId VARCHAR(36),
	@TeacherId VARCHAR(36),
	@Semester INT,
	@Year INT
	AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE @query NVARCHAR(4000) = 'select * from SubjectRegistered ',
			@key NVARCHAR(1000) = ''

	IF @ClassId IS NOT NULL SELECT @key = 'ClassId = ''' + REPLACE(@ClassId, '''', '') + ''''
	IF @SubjectId IS NOT NULL SELECT @key = @key + CASE WHEN @key = '' THEN '' ELSE ' and ' END + 'SubjectId = ''' + REPLACE(@SubjectId, '''', '') + ''''
	IF @TeacherId IS NOT NULL SELECT @key = @key + CASE WHEN @key = '' THEN '' ELSE ' and ' END + 'TeacherId = ''' + REPLACE(@TeacherId, '''', '') + ''''
	IF @Semester <> 0 SELECT @key = @key + CASE WHEN @key = '' THEN '' ELSE ' and ' END + 'Semester = ' + CAST(@Semester AS VARCHAR(2))
	IF @Year <> 0 SELECT @key = @key + CASE WHEN @key = '' THEN '' ELSE ' and ' END + 'Year = ' + CAST(@Year AS VARCHAR(4))
	SELECT @query = @query + CASE WHEN @key = '' THEN '' ELSE ' where ' + @key END
	EXEC sp_executesql @query

	SET NOCOUNT OFF
END

GO

