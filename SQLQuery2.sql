CREATE PROCEDURE SPUpdateDatainDataBase
@FirstName VARCHAR(30),
@LastName VARCHAR(30),
@City VARCHAR(30)
AS BEGIN
UPDATE AddressBookDB SET LastName=@LastName,City=@City WHERE FirstName=@FirstName
END
SELECT*FROM AddressBookDB

CREATE PROCEDURE SPDeleteDataFromDB
(@FirstName VARCHAR(30))
AS BEGIN
DELETE FROM AddressBookDB WHERE FirstName=@FirstName
END
