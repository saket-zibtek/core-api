USE [Skycop]

GO
/****** Object:  StoredProcedure [dbo].[usp_GetRoles] Script Date: 11/24/2017 16:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[usp_GetRoles]
AS    
BEGIN    
   SELECT * FROM Roles  Where IsActive = 1
End  

GO

USE [Skycop]

GO
/****** Object:  StoredProcedure [dbo].[usp_GetUsers] Script Date: 11/24/2017 16:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[usp_GetUsers]
AS    
BEGIN    
   SELECT * FROM Users  Where IsActive = 1
End  

GO


USE [Skycop]

GO
/****** Object:  StoredProcedure [dbo].[usp_GetDevices] Script Date: 11/24/2017 16:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[usp_GetDevices]
AS    
BEGIN    
   SELECT * FROM Devices 
End  

GO

USE [Skycop]

GO

/****** Object:  StoredProcedure [dbo].[usp_AddUser]  Script Date: 11/24/2017 21:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_AddUser]  
(  
   @Prefix varchar(10),
   @FirstName varchar(50),
   @MiddleName varchar(50),
   @LastName varchar(50),
   @Suffix varchar(10),
   @Email varchar(100),
   @Gender varchar(10),
   @UserName varchar(50),
   @Password varchar(20),
   @IsActive bit,
   @DateOfBirth DateTime,
   @CreatedDate DateTime,
   @ModifiedDate DateTime,
   @ID int output
)  
AS  
BEGIN  
   SET NOCOUNT ON;
   INSERT INTO Users(FirstName,LastName,MiddleName,Prefix,Suffix,Email,Gender,UserName,Password,IsActive,DateOfBirth,CreatedDate,ModifiedDate) VALUES (@FirstName,@LastName,@MiddleName,@Prefix,@Suffix,@Email,@Gender,@UserName,@Password,@IsActive,@DateOfBirth,@CreatedDate,@ModifiedDate) 
   SET @ID = SCOPE_IDENTITY()
      RETURN  @ID
END  

GO