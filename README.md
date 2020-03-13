# Store Procedure


	
	ALTER PROCEDURE [dbo].[spProducts_GetAll]
		@PageIndex int = 1,
		@PageSize int = 10, 
		@OrderBy nvarchar(50),
		@SearchText nvarchar(250) = '%',
		@TotalCount int OUTPUT,
		@FilteredCount int OUTPUT

		AS
		BEGIN
			Declare @sql nvarchar(MAX),
			@paramList nvarchar(MAX),
			@countSql nvarchar(MAX),
			@countParamList nvarchar(MAX),
			@conditionSql nvarchar(MAX)

			SET NOCOUNT ON;

			SET @sql = 'SELECT Pro.Id as Id, Pro.Name as Name, Pro.Description as Description, 
						Pro.Price as Price FROM Products as Pro'

			SET @countSql = 'SELECT @FilteredCount = COUNT(*) FROM Products as Pro'
			
			SET @conditionSql = ' WHERE LOWER(Pro.Name) LIKE LOWER(''%''+@SearchText+''%'') 
								OR LOWER(Pro.Description) LIKE LOWER(''%''+@SearchText+''%'')'

			IF @PageIndex < 1
				SET @PageIndex = 1
							
			IF @PageSize < 1
				SET @PageSize = 10

			SET @sql += @conditionSql
			SET @countSql += @conditionSql
	
			SET @sql += ' ORDER BY Pro.' + @OrderBy + ' OFFSET @PageSize * (@PageIndex - 1) 
						ROWS FETCH NEXT @PageSize ROWS ONLY'

			SELECT @paramlist = '@SearchText nvarchar(250),
					@PageIndex int,
					@PageSize int' 

			exec sp_executesql @sql, @paramlist,
					@SearchText,
					@PageIndex,
					@PageSize
				
			-- exec for total count
			SELECT @TotalCount = COUNT(*) FROM Products;

			-- exec for filtered count
			SELECT @countParamlist = '@SearchText nvarchar(250),
					@FilteredCount int OUTPUT' 

			exec sp_executesql @countSql, @countParamlist,
					@SearchText,
					@FilteredCount = @FilteredCount OUTPUT
	
		END


