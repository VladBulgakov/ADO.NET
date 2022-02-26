USE MyShop;

ALTER TABLE Customers ADD LastName NVARCHAR(30) NULL;
EXEC sp_rename @objname = 'Customers.Name', @newname = 'FirstName';