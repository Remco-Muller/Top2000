USE [Top2000]
GO
/****** Object:  StoredProcedure [dbo].[spSelectTop10ListingOnYear]    Script Date: 28-6-2020 21:29:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spSelectTop10ListingOnYear]
@year int
AS
BEGIN
SELECT TOP 10
*
FROM
Tracks_YearList
WHERE
YearList_YearListId LIKE @year
END
GO
