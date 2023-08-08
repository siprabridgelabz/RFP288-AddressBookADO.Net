CREATE PROCEDURE SPUpdateData
@FirstName VARCHAR(30),
@LastName VARCHAR(30),
@City VARCHAR(30)
AS BEGIN
UPDATE AddressBookDB SET LastName=@LastName,City=@City WHERE FirstName=@FirstName
END