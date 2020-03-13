# Store Procedure


	CREATE PROCEDURE [dbo].[spProducts_GetAll]
		@PageIndex int = 1,
		@PageSize int = 10, 
		@OrderBy nvarchar(50) = 'Name',
		@OrderDir nvarchar(4) = 'asc',
		@SearchText nvarchar(250) = NULL,
		@TotalCount int OUTPUT,
		@FilteredCount int OUTPUT

	AS
	BEGIN
		Declare @sql nvarchar(MAX),
		@paramList nvarchar(MAX),
		@SearchValue nvarchar(250),
		@OrderDirValue nvarchar(4)

		SET NOCOUNT ON;
		SET @sql = 'SELECT Pro.Id as Id, Pro.Name as Name, Pro.Description as Description, 
					Pro.Price as Price FROM Products as Pro WHERE 1=1'
	
		IF @SearchText IS NOT NULL
		BEGIN
			SET @SearchValue = '%'+@SearchText+'%'
			SET @sql += ' AND LOWER(Pro.Name) LIKE LOWER(@SearchValue) OR LOWER(Pro.Description) LIKE LOWER(@SearchValue)'
		END

		IF @OrderDir = 'asc'
			SET @OrderDir = 'asc'
		ELSE
			SET @OrderDir = 'desc'

		IF @PageIndex < 1
			SET @PageIndex = 1
							
		IF @PageSize < 1
			SET @PageSize = 1
	
		SET @sql += ' ORDER BY Pro.' + QUOTENAME(@OrderBy) + ' ' + @OrderDir + ' OFFSET @PageSize * (@PageIndex - 1) 
		ROWS FETCH NEXT @PageSize ROWS ONLY'

		SELECT @paramlist = '@SearchValue nvarchar(250),
		@OrderDir nvarchar(4),
		@PageIndex int,
		@PageSize int' 

		exec sp_executesql @sql, @paramlist,
			@SearchValue,
			@OrderDir,
			@PageIndex,
			@PageSize

		-- exec for total count
		SET @TotalCount = (SELECT COUNT(*) FROM Products)
				
		-- exec for filtered count
		SET @FilteredCount = (SELECT COUNT(*) FROM Products WHERE 
				(@SearchValue IS NULL OR LOWER(Name) LIKE LOWER('%'+@SearchValue+'%') OR LOWER(Description) LIKE LOWER('%'+@SearchValue+'%')))
	
	END

