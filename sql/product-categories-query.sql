SELECT p.[Name] AS [ProductName],
       c.[Name] AS [CategoryName]
FROM [Storehouse].[Products] p
LEFT JOIN [Storehouse].[ProductCategories] pc ON p.[Id] = pc.[ProductId]
LEFT JOIN [Storehouse].[Categories] c ON pc.[CategoryId] = c.[Id];
