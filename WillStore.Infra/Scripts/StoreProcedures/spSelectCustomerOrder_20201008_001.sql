CREATE PROCEDURE spSelectCustomerOrder
	@Id UNIQUEIDENTIFIER
AS
Select * FROM [Order] 
		WHERE
			[Id] = @Id