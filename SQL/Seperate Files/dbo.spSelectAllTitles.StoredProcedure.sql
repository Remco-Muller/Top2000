USE [Top2000]
GO
/****** Object:  StoredProcedure [dbo].[spSelectAllTitles]    Script Date: 28-6-2020 21:29:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spSelectAllTitles]
@Year int
AS
BEGIN
SELECT TOP 100
*
FROM
Tracks_YearList
WHERE
YearList_YearListId LIKE @Year
END
GO
