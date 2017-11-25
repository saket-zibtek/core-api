USE Skycop

Create Table DeviceLog
(
 ID BigInt IDENTITY(1,1) Not Null Primary Key,
 UserID BigInt Not Null FOREIGN KEY REFERENCES [dbo].[Users](ID), 
 DeviceID BigInt Not Null FOREIGN KEY REFERENCES [dbo].[Devices](ID)
) 