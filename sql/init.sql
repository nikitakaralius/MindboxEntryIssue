BEGIN TRANSACTION;

GO

CREATE SCHEMA [Storehouse];

GO

CREATE TABLE [Storehouse].[Products]
(
    [Id]   INT IDENTITY (1, 1) PRIMARY KEY,
    [Name] NVARCHAR(128) NOT NULL
);

CREATE TABLE [Storehouse].[Categories]
(
    [Id]   INT IDENTITY (1, 1) PRIMARY KEY,
    [Name] NVARCHAR(128) NOT NULL
);

CREATE TABLE [Storehouse].[ProductCategories]
(
    [ProductId]  INT NOT NULL REFERENCES [Storehouse].[Products] ([Id])
        ON UPDATE CASCADE
        ON DELETE CASCADE,
    [CategoryId] INT NOT NULL REFERENCES [Storehouse].[Categories] ([Id])
        ON UPDATE CASCADE
        ON DELETE CASCADE,
    PRIMARY KEY ([ProductId], [CategoryId])
);

GO

INSERT INTO [Storehouse].[Products] ([Name])
VALUES ('iPhone'),
       ('MacBook'),
       ('Pineapple'),
       ('IDE Subscription');


INSERT INTO [Storehouse].[Categories] ([Name])
VALUES ('Electronics'),
       ('Phones'),
       ('Groceries'),
       ('Health');

INSERT INTO [Storehouse].[ProductCategories] ([ProductId], [CategoryId])
VALUES (1, 1),
       (1, 2),
       (2, 1),
       (3, 3);

GO

COMMIT TRANSACTION;
