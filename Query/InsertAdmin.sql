USE [OMS]
GO

INSERT INTO [dbo].[User_info]
           ([name]
           ,[mobile_no]
           ,[email]
           ,[password]
           ,[fname]
           ,[usertype]
           ,[date])
     VALUES
           ('','','','','','',GETDATE())
GO


