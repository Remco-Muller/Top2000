USE [Top2000]
GO
/****** Object:  StoredProcedure [dbo].[spCheckUserVote]    Script Date: 28-6-2020 21:29:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spCheckUserVote]
@year int,
@track int,
@user varchar(MAX)
AS
BEGIN
SELECT
*
FROM
Track_YearList_User
WHERE
YearList_YearListId LIKE @year AND Track_TrackId LIKE @track AND Users_UserName LIKE @user
END
GO
