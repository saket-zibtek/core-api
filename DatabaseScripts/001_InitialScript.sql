-- Create new database for Skycop project

CREATE DATABASE Skycop

GO

-- Create new table for User
Use [Skycop]

CREATE TABLE Users (
    [ID] [bigint] IDENTITY(1,1) NOT NULL Primary Key,
	[Prefix] [varchar](10) NULL,
	[FirstName] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Suffix] [varchar](10) NULL,
	[Email] [varchar](100) NULL,
	[DateOfBirth] [smalldatetime] NULL,
	[Gender] [varchar](10) NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](20) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [smalldatetime] NOT NULL,
	[ModifiedDate] [smalldatetime] NULL
);

Select * from Users

Create Table Roles
( 
  ID BigInt IDENTITY(1,1) Not Null Primary Key,
  Name Varchar(50),
  Description Varchar(Max),
  IsActive Bit
)

Select * from Roles

Create Table UserRoles
(
 ID BigInt IDENTITY(1,1) Not Null Primary Key,
 UserID BigInt Not Null FOREIGN KEY REFERENCES [dbo].[Users](ID), 
 RoleID BigInt Not Null FOREIGN KEY REFERENCES [dbo].[Roles](ID)
)

Select * from UserRoles

Create Table Permissions
(
ID BigInt IDENTITY(1,1) Not Null Primary Key,
Name Varchar(100),
Description Varchar(max),
IsActive Bit
)

Select * from Permissions

Create Table RolesPermissions
(
 ID BigInt IDENTITY(1,1) Not Null Primary Key,
 PermissionID BigInt Not Null FOREIGN KEY REFERENCES [dbo].[Permissions](ID),
 RoleID BigInt Not Null FOREIGN KEY REFERENCES [dbo].[Roles](ID)
) 

Select * from RolesPermissions


Create Table AuthTokens
(
 ID BigInt IDENTITY(1,1) Not Null Primary Key,
 UserID BigInt Not Null FOREIGN KEY REFERENCES [dbo].[Users](ID),
 AuthToken Varchar(100) Not Null,
 IssuedOn DateTime,
 ExpiresOn DateTime
)

Select * from AuthTokens