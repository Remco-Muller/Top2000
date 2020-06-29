USE [Top2000]
GO
/****** Object:  StoredProcedure [dbo].[spNumberOfSongsOfArtist]    Script Date: 28-6-2020 21:29:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROC [dbo].[spNumberOfSongsOfArtist]
	@Name VARCHAR(MAX)
	AS
	BEGIN
	SELECT
	*
	FROM
	Tracks
	WHERE
	trackArtist LIKE '%' + @Name + '%'
	END
GO
