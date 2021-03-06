USE [Top2000]
GO
/****** Object:  Table [dbo].[Track_YearList_User]    Script Date: 28-6-2020 21:29:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Track_YearList_User](
	[Track_TrackId] [int] NULL,
	[Users_UserName] [nvarchar](max) NULL,
	[YearList_YearListId] [int] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Track_YearList_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Track_YearList_User]  WITH CHECK ADD  CONSTRAINT [FK_Track_YearList_User_Tracks] FOREIGN KEY([Track_TrackId])
REFERENCES [dbo].[Tracks] ([trackId])
GO
ALTER TABLE [dbo].[Track_YearList_User] CHECK CONSTRAINT [FK_Track_YearList_User_Tracks]
GO
ALTER TABLE [dbo].[Track_YearList_User]  WITH CHECK ADD  CONSTRAINT [FK_Track_YearList_User_YearList] FOREIGN KEY([YearList_YearListId])
REFERENCES [dbo].[YearList] ([YearListId])
GO
ALTER TABLE [dbo].[Track_YearList_User] CHECK CONSTRAINT [FK_Track_YearList_User_YearList]
GO
