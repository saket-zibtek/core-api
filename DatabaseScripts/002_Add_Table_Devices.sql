Use [Skycop]

GO

CREATE TABLE Devices (
    [ID] [bigint] IDENTITY(1000,1) NOT NULL Primary Key,
	[Name] [varchar](100) NULL,
	[IP] [varchar](20) NULL,
	[Port] [varchar](10) NULL,
	[HardDrive] [varchar](100) NULL,
	[CameraNumber] [bigint] NULL,
	[Recording] [varchar](100) NULL,
	[VideoLoss] [varchar](100) NULL,
	[Date] DATETIME NULL,
	[DeviceType] [varchar](100) NULL,
	[Version] [varchar](100) NULL,
	[Web] [bigint] NULL,
	[DVRTime] DATETIME NULL
);

GO