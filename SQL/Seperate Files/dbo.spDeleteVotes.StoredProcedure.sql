USE [Top2000]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteVotes]    Script Date: 28-6-2020 21:29:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDeleteVotes]
@YearID Int
AS
DELETE FROM Track_YearList_User WHERE YearList_YearListId LIKE @YearID
GO
