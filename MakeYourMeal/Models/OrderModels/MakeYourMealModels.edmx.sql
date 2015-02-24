
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/22/2015 19:09:55
-- Generated from EDMX file: C:\Users\iah10_000\Documents\Visual Studio 2013\Projects\MakeYourMeal\MakeYourMeal\Models\OrderModels\MakeYourMealModels.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-MakeYourMeal-20150221123729];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FoodItemHasIngredients_FoodItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FoodItemHasIngredients] DROP CONSTRAINT [FK_FoodItemHasIngredients_FoodItem];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderItem_FoodItemName]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderItems] DROP CONSTRAINT [FK_OrderItem_FoodItemName];
GO
IF OBJECT_ID(N'[dbo].[FK_FoodItemHasIngredients_Ingredient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FoodItemHasIngredients] DROP CONSTRAINT [FK_FoodItemHasIngredients_Ingredient];
GO
IF OBJECT_ID(N'[dbo].[FK_ExtraIngredients_Ingredient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExtraIngredients] DROP CONSTRAINT [FK_ExtraIngredients_Ingredient];
GO
IF OBJECT_ID(N'[dbo].[FK_ExtraIngredients_OrderItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExtraIngredients] DROP CONSTRAINT [FK_ExtraIngredients_OrderItem];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderHasOrderItems_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderHasOrderItems] DROP CONSTRAINT [FK_OrderHasOrderItems_Order];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderHasOrderItems_OrderItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderHasOrderItems] DROP CONSTRAINT [FK_OrderHasOrderItems_OrderItem];
GO
IF OBJECT_ID(N'[dbo].[FK_WithoutIngredients_Ingredient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WithoutIngredients] DROP CONSTRAINT [FK_WithoutIngredients_Ingredient];
GO
IF OBJECT_ID(N'[dbo].[FK_WithoutIngredients_OrderItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WithoutIngredients] DROP CONSTRAINT [FK_WithoutIngredients_OrderItem];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FoodItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FoodItems];
GO
IF OBJECT_ID(N'[dbo].[Ingredients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ingredients];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[OrderItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderItems];
GO
IF OBJECT_ID(N'[dbo].[FoodItemHasIngredients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FoodItemHasIngredients];
GO
IF OBJECT_ID(N'[dbo].[ExtraIngredients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExtraIngredients];
GO
IF OBJECT_ID(N'[dbo].[OrderHasOrderItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderHasOrderItems];
GO
IF OBJECT_ID(N'[dbo].[WithoutIngredients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WithoutIngredients];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'FoodItems'
CREATE TABLE [dbo].[FoodItems] (
    [Name] nchar(20)  NOT NULL,
    [Category] nchar(20)  NOT NULL,
    [Price] decimal(10,4)  NOT NULL,
    [ImagePath] nchar(100)  NOT NULL
);
GO

-- Creating table 'Ingredients'
CREATE TABLE [dbo].[Ingredients] (
    [Name] nchar(20)  NOT NULL,
    [ImagePath] nchar(100)  NULL,
    [AdditionalCharge] decimal(10,4)  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderId] int  NOT NULL,
    [OrderedAt] binary(8)  NOT NULL,
    [TableNumber] int  NOT NULL,
    [TotalCost] decimal(10,4)  NOT NULL,
    [State] int  NOT NULL
);
GO

-- Creating table 'OrderItems'
CREATE TABLE [dbo].[OrderItems] (
    [OrderItemId] int  NOT NULL,
    [FoodItemName] nchar(20)  NOT NULL
);
GO

-- Creating table 'FoodItemHasIngredients'
CREATE TABLE [dbo].[FoodItemHasIngredients] (
    [FoodItemName] nchar(20)  NOT NULL,
    [Ingredient] nchar(20)  NOT NULL,
    [Quantity] int  NOT NULL
);
GO

-- Creating table 'ExtraIngredients'
CREATE TABLE [dbo].[ExtraIngredients] (
    [ExtraIngredients_Name] nchar(20)  NOT NULL,
    [ExtraOrderItems_OrderItemId] int  NOT NULL
);
GO

-- Creating table 'OrderHasOrderItems'
CREATE TABLE [dbo].[OrderHasOrderItems] (
    [Orders_OrderId] int  NOT NULL,
    [OrderItems_OrderItemId] int  NOT NULL
);
GO

-- Creating table 'WithoutIngredients'
CREATE TABLE [dbo].[WithoutIngredients] (
    [WithoutIngredients_Name] nchar(20)  NOT NULL,
    [WithoutOrderItems_OrderItemId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Name] in table 'FoodItems'
ALTER TABLE [dbo].[FoodItems]
ADD CONSTRAINT [PK_FoodItems]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- Creating primary key on [Name] in table 'Ingredients'
ALTER TABLE [dbo].[Ingredients]
ADD CONSTRAINT [PK_Ingredients]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- Creating primary key on [OrderId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderId] ASC);
GO

-- Creating primary key on [OrderItemId] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [PK_OrderItems]
    PRIMARY KEY CLUSTERED ([OrderItemId] ASC);
GO

-- Creating primary key on [FoodItemName], [Ingredient], [Quantity] in table 'FoodItemHasIngredients'
ALTER TABLE [dbo].[FoodItemHasIngredients]
ADD CONSTRAINT [PK_FoodItemHasIngredients]
    PRIMARY KEY CLUSTERED ([FoodItemName], [Ingredient], [Quantity] ASC);
GO

-- Creating primary key on [ExtraIngredients_Name], [ExtraOrderItems_OrderItemId] in table 'ExtraIngredients'
ALTER TABLE [dbo].[ExtraIngredients]
ADD CONSTRAINT [PK_ExtraIngredients]
    PRIMARY KEY CLUSTERED ([ExtraIngredients_Name], [ExtraOrderItems_OrderItemId] ASC);
GO

-- Creating primary key on [Orders_OrderId], [OrderItems_OrderItemId] in table 'OrderHasOrderItems'
ALTER TABLE [dbo].[OrderHasOrderItems]
ADD CONSTRAINT [PK_OrderHasOrderItems]
    PRIMARY KEY CLUSTERED ([Orders_OrderId], [OrderItems_OrderItemId] ASC);
GO

-- Creating primary key on [WithoutIngredients_Name], [WithoutOrderItems_OrderItemId] in table 'WithoutIngredients'
ALTER TABLE [dbo].[WithoutIngredients]
ADD CONSTRAINT [PK_WithoutIngredients]
    PRIMARY KEY CLUSTERED ([WithoutIngredients_Name], [WithoutOrderItems_OrderItemId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FoodItemName] in table 'FoodItemHasIngredients'
ALTER TABLE [dbo].[FoodItemHasIngredients]
ADD CONSTRAINT [FK_FoodItemHasIngredients_FoodItem]
    FOREIGN KEY ([FoodItemName])
    REFERENCES [dbo].[FoodItems]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [FoodItemName] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [FK_OrderItem_FoodItemName]
    FOREIGN KEY ([FoodItemName])
    REFERENCES [dbo].[FoodItems]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderItem_FoodItemName'
CREATE INDEX [IX_FK_OrderItem_FoodItemName]
ON [dbo].[OrderItems]
    ([FoodItemName]);
GO

-- Creating foreign key on [Ingredient] in table 'FoodItemHasIngredients'
ALTER TABLE [dbo].[FoodItemHasIngredients]
ADD CONSTRAINT [FK_FoodItemHasIngredients_Ingredient]
    FOREIGN KEY ([Ingredient])
    REFERENCES [dbo].[Ingredients]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FoodItemHasIngredients_Ingredient'
CREATE INDEX [IX_FK_FoodItemHasIngredients_Ingredient]
ON [dbo].[FoodItemHasIngredients]
    ([Ingredient]);
GO

-- Creating foreign key on [ExtraIngredients_Name] in table 'ExtraIngredients'
ALTER TABLE [dbo].[ExtraIngredients]
ADD CONSTRAINT [FK_ExtraIngredients_Ingredient]
    FOREIGN KEY ([ExtraIngredients_Name])
    REFERENCES [dbo].[Ingredients]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ExtraOrderItems_OrderItemId] in table 'ExtraIngredients'
ALTER TABLE [dbo].[ExtraIngredients]
ADD CONSTRAINT [FK_ExtraIngredients_OrderItem]
    FOREIGN KEY ([ExtraOrderItems_OrderItemId])
    REFERENCES [dbo].[OrderItems]
        ([OrderItemId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExtraIngredients_OrderItem'
CREATE INDEX [IX_FK_ExtraIngredients_OrderItem]
ON [dbo].[ExtraIngredients]
    ([ExtraOrderItems_OrderItemId]);
GO

-- Creating foreign key on [Orders_OrderId] in table 'OrderHasOrderItems'
ALTER TABLE [dbo].[OrderHasOrderItems]
ADD CONSTRAINT [FK_OrderHasOrderItems_Order]
    FOREIGN KEY ([Orders_OrderId])
    REFERENCES [dbo].[Orders]
        ([OrderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [OrderItems_OrderItemId] in table 'OrderHasOrderItems'
ALTER TABLE [dbo].[OrderHasOrderItems]
ADD CONSTRAINT [FK_OrderHasOrderItems_OrderItem]
    FOREIGN KEY ([OrderItems_OrderItemId])
    REFERENCES [dbo].[OrderItems]
        ([OrderItemId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderHasOrderItems_OrderItem'
CREATE INDEX [IX_FK_OrderHasOrderItems_OrderItem]
ON [dbo].[OrderHasOrderItems]
    ([OrderItems_OrderItemId]);
GO

-- Creating foreign key on [WithoutIngredients_Name] in table 'WithoutIngredients'
ALTER TABLE [dbo].[WithoutIngredients]
ADD CONSTRAINT [FK_WithoutIngredients_Ingredient]
    FOREIGN KEY ([WithoutIngredients_Name])
    REFERENCES [dbo].[Ingredients]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [WithoutOrderItems_OrderItemId] in table 'WithoutIngredients'
ALTER TABLE [dbo].[WithoutIngredients]
ADD CONSTRAINT [FK_WithoutIngredients_OrderItem]
    FOREIGN KEY ([WithoutOrderItems_OrderItemId])
    REFERENCES [dbo].[OrderItems]
        ([OrderItemId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WithoutIngredients_OrderItem'
CREATE INDEX [IX_FK_WithoutIngredients_OrderItem]
ON [dbo].[WithoutIngredients]
    ([WithoutOrderItems_OrderItemId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------