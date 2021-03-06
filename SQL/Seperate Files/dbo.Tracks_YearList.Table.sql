USE [Top2000]
GO
/****** Object:  Table [dbo].[Tracks_YearList]    Script Date: 28-6-2020 21:29:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tracks_YearList](
	[Tracks_TrackId] [int] NOT NULL,
	[YearList_YearListId] [int] NOT NULL,
 CONSTRAINT [PK_Tracks_YearList] PRIMARY KEY CLUSTERED 
(
	[Tracks_TrackId] ASC,
	[YearList_YearListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tracks_YearList]  WITH CHECK ADD  CONSTRAINT [FK_Tracks_YearList_Tracks] FOREIGN KEY([Tracks_TrackId])
REFERENCES [dbo].[Tracks] ([trackId])
GO
ALTER TABLE [dbo].[Tracks_YearList] CHECK CONSTRAINT [FK_Tracks_YearList_Tracks]
GO
ALTER TABLE [dbo].[Tracks_YearList]  WITH CHECK ADD  CONSTRAINT [FK_Tracks_YearList_YearList] FOREIGN KEY([YearList_YearListId])
REFERENCES [dbo].[YearList] ([YearListId])
GO
ALTER TABLE [dbo].[Tracks_YearList] CHECK CONSTRAINT [FK_Tracks_YearList_YearList]
GO
