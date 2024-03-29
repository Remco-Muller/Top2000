USE [Top2000]
GO
/****** Object:  Table [dbo].[Tracks]    Script Date: 28-6-2020 21:29:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tracks](
	[trackId] [int] IDENTITY(1,1) NOT NULL,
	[trackName] [nvarchar](50) NOT NULL,
	[trackYear] [datetime] NOT NULL,
	[trackArtist] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tracks] PRIMARY KEY CLUSTERED 
(
	[trackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
