USE [Top2000]
GO
/****** Object:  StoredProcedure [dbo].[spSelectAllArtists]    Script Date: 28-6-2020 21:29:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROC [dbo].[spSelectAllArtists]
	AS
	BEGIN
	SELECT
	trackArtist
	FROM
	Tracks
	END
GO
