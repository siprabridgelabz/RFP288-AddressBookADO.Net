CREATE PROCEDURE SPAddingNewData(
@FirstName VARCHAR(30),
@LastName VARCHAR(30),
@Address VARCHAR(100),
@City VARCHAR(20),
@State VARCHAR(20) ,
@Zip INT,
@PhoneNumber BIGINT,
@EmailID VARCHAR(50))
AS BEGIN 
INSERT INTO AddressBookDB(FirstName,LastName,Address,City,State,Zip,PhoneNumber
,EmailID)
VALUES(@FirstName,@LastName,@Address,@City,@State,@Zip,@PhoneNumber
,@EmailID)
END

