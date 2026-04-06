CREATE DATABASE AddressBookDB;
GO

USE AddressBookDB;
GO


CREATE TABLE Contacts (
    ContactId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    Address NVARCHAR(200),
    City NVARCHAR(100),
    State NVARCHAR(100),
    Zip NVARCHAR(20),
    PhoneNumber NVARCHAR(20),
    Email NVARCHAR(100),
    AddressBookId INT NOT NULL,

    FOREIGN KEY (AddressBookId)
    REFERENCES AddressBooks(AddressBookId)
    ON DELETE CASCADE
);





CREATE TABLE AddressBooks (
    AddressBookId INT PRIMARY KEY IDENTITY(1,1),
    BookName NVARCHAR(100) NOT NULL UNIQUE
);

select * from Contacts;
select * from AddressBooks;