USE [Top2000]
GO
/****** Object:  StoredProcedure [dbo].[spSelectAllVotes]    Script Date: 28-6-2020 21:29:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spSelectAllVotes]
@year int,
@track int
AS
BEGIN
SELECT
*
FROM
Track_YearList_User
WHERE
YearList_YearListId LIKE @year AND Track_TrackId LIKE @track
END
GO
