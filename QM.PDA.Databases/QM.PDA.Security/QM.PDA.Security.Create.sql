USE [QM.PDA.Security]
GO
/****** Object:  Table [dbo].[Security]    Script Date: 02/27/2008 11:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Security](
	[PDAUserName] [nvarchar](50) NOT NULL,
	[PDAPassword] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[StudyID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
	[Version] [nvarchar](50) NOT NULL,
	[DefaultSiteID] [int] NULL,
	[Order] [int] NOT NULL,
CONSTRAINT [PK_Security] PRIMARY KEY CLUSTERED 
(
	[PDAUserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Currently using 3 digit code from 001 to 999 for each user.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Security', @level2type=N'COLUMN',@level2name=N'PDAUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Password for user' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Security', @level2type=N'COLUMN',@level2name=N'PDAPassword'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Full name of the user in format "First Name Second Name First Last Name Second Last Name" ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Security', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID of the Study.  At the moment only ViCo = 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Security', @level2type=N'COLUMN',@level2name=N'StudyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID of the Role the user fulfils.  At the moment only one role per user.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Security', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Role name in text of the user.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Security', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Version of the data and configuration' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Security', @level2type=N'COLUMN',@level2name=N'Version'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier of the Site at which the user usually works.  Can be null for supervisors, scientists or admin.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Security', @level2type=N'COLUMN',@level2name=N'DefaultSiteID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Order in which the list of users will appear in the Login screen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Security', @level2type=N'COLUMN',@level2name=N'Order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores one row per each user allowed to use the PDA.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Security'
GO
