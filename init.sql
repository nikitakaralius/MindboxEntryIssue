CREATE DATABASE Storehouse
GO


USE [Storehouse]
GO

CREATE TABLE [dbo].[Products](
    [Id] [int] IDENTITY(1, 1),
    [Name] [nvarchar](256) NOT NULL)
GO

ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [PK_Products_Id] PRIMARY KEY CLUSTERED (Id)
    GO


USE [Storehouse]
GO

CREATE TABLE [dbo].[Categories](
    [Id] [int] IDENTITY(1, 1),
    [Name] [nvarchar](256) NOT NULL
    )
    GO

ALTER TABLE [dbo].[Categories]
    ADD CONSTRAINT [PK_Categories_Id] PRIMARY KEY CLUSTERED (Id)
    GO

ALTER TABLE [dbo].[Categories]
    ADD CONSTRAINT [Unique_Categories_Name] UNIQUE ([Name])
    GO


USE [Storehouse]
GO

CREATE TABLE [dbo].[ProductCategories](
    [Id] [int] IDENTITY(1, 1),
    [ProductId] [int] NOT NULL,
    [CategoryId] [int] NULL
    )
    GO

ALTER TABLE [dbo].[ProductCategories]
    ADD CONSTRAINT [PK_ProductCategories_Id] PRIMARY KEY CLUSTERED (Id)
    GO

ALTER TABLE [dbo].[ProductCategories]
WITH CHECK ADD CONSTRAINT [FK_ProductCategories_ProductId] FOREIGN KEY (ProductId)
REFERENCES [dbo].[Products] (Id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ProductCategories]
WITH CHECK ADD CONSTRAINT [FK_ProductCategories_CategoryId] FOREIGN KEY (CategoryId)
REFERENCES [dbo].[Categories] (Id)
ON UPDATE CASCADE
ON DELETE SET NULL
GO
