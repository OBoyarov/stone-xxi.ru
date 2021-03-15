USE [db]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cbr_data](
	[datereq] [date] NOT NULL,
	[charcode] [nvarchar](3) NOT NULL,
	[value] [float] NOT NULL
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cbr_items](
	[Name] [nvarchar](50) NOT NULL,
	[EngName] [nvarchar](50) NOT NULL,
	[Nominal] [int] NOT NULL,
	[ParentCode] [nvarchar](10) NOT NULL,
	[ISO_Num_Code] [int] NOT NULL,
	[ISO_Char_Code] [nvarchar](3) NOT NULL
) ON [PRIMARY]
GO
