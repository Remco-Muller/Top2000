USE [Top2000]
GO
/****** Object:  StoredProcedure [dbo].[spSelectListingOnYear]    Script Date: 28-6-2020 21:29:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spSelectListingOnYear]
@Yearid int
AS
BEGIN
SELECT
*
FROM
Tracks_YearList
WHERE
YearList_YearListId LIKE @Yearid
END
GO
