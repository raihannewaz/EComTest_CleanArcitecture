use EComTestDB
go

CREATE PROCEDURE GetOrdersQuery
AS
BEGIN
    SELECT o.OrderId, o.Quantity, o.Total, p.ProductId, p.ProductName, p.Price, c.CategoryId, c.CategoryName
    FROM Orders o
    INNER JOIN Products p ON o.ProductId = p.ProductId
    INNER JOIN Categories c ON p.CategoryId = c.CategoryId;
END
GO

EXEC GetOrdersQuery
GO

CREATE PROCEDURE GetOrderById
    @OrdId INT
AS
BEGIN
    SELECT o.OrderId, o.Quantity, o.Total, p.ProductId, p.ProductName, p.Price, c.CategoryId, c.CategoryName
    FROM Orders o
    INNER JOIN Products p ON o.ProductId = p.ProductId
    INNER JOIN Categories c ON p.CategoryId = c.CategoryId
    WHERE o.OrderId = @OrdId;
END
GO

EXEC GetOrderById 3
Go


CREATE PROCEDURE GetProduct
AS
BEGIN
	SELECT * FROM Products
END
GO

EXEC GetProduct
GO


CREATE PROCEDURE GetProductById
	@id int
AS
BEGIN
	Select * From Products
	Where ProductId= @id
END
GO

EXEC GetProductById 2
GO


CREATE PROCEDURE GetCategoryById
	@id int
AS
BEGIN
	Select * From Categories
	Where CategoryId= @id
END
GO

CREATE PROCEDURE GetCategories
AS
BEGIN
	Select * From Categories
END
GO