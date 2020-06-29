USE [Top2000]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteTracks]    Script Date: 28-6-2020 21:29:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDeleteTracks]
@YearID Int
AS
DELETE FROM Tracks_YearList WHERE YearList_YearListId LIKE @YearID
GO
