USE [master]
GO
/****** Object:  Database [Top2000]    Script Date: 29-6-2020 14:10:38 ******/
CREATE DATABASE [Top2000]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'testdb', FILENAME = N'D:\SQL SERVER\MSSQL14.MSSQLSERVER\MSSQL\DATA\testdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'testdb_log', FILENAME = N'D:\SQL SERVER\MSSQL14.MSSQLSERVER\MSSQL\DATA\testdb_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Top2000] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Top2000].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Top2000] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Top2000] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Top2000] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Top2000] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Top2000] SET ARITHABORT OFF 
GO
ALTER DATABASE [Top2000] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Top2000] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Top2000] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Top2000] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Top2000] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Top2000] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Top2000] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Top2000] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Top2000] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Top2000] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Top2000] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Top2000] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Top2000] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Top2000] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Top2000] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Top2000] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Top2000] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Top2000] SET RECOVERY FULL 
GO
ALTER DATABASE [Top2000] SET  MULTI_USER 
GO
ALTER DATABASE [Top2000] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Top2000] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Top2000] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Top2000] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Top2000] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Top2000', N'ON'
GO
ALTER DATABASE [Top2000] SET QUERY_STORE = OFF
GO
USE [Top2000]
GO
/****** Object:  Table [dbo].[Track_YearList_User]    Script Date: 29-6-2020 14:10:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Track_YearList_User](
	[Track_TrackId] [int] NULL,
	[Users_UserName] [nvarchar](max) NULL,
	[YearList_YearListId] [int] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Track_YearList_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tracks]    Script Date: 29-6-2020 14:10:38 ******/
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
/****** Object:  Table [dbo].[Tracks_YearList]    Script Date: 29-6-2020 14:10:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tracks_YearList](
	[Tracks_TrackId] [int] NOT NULL,
	[YearList_YearListId] [int] NOT NULL,
 CONSTRAINT [PK_Tracks_YearList] PRIMARY KEY CLUSTERED 
(
	[Tracks_TrackId] ASC,
	[YearList_YearListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YearList]    Script Date: 29-6-2020 14:10:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YearList](
	[YearListId] [int] IDENTITY(1,1) NOT NULL,
	[YearListYear] [datetime] NOT NULL,
 CONSTRAINT [PK_YearList] PRIMARY KEY CLUSTERED 
(
	[YearListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Track_YearList_User]  WITH CHECK ADD  CONSTRAINT [FK_Track_YearList_User_Tracks] FOREIGN KEY([Track_TrackId])
REFERENCES [dbo].[Tracks] ([trackId])
GO
ALTER TABLE [dbo].[Track_YearList_User] CHECK CONSTRAINT [FK_Track_YearList_User_Tracks]
GO
ALTER TABLE [dbo].[Track_YearList_User]  WITH CHECK ADD  CONSTRAINT [FK_Track_YearList_User_YearList] FOREIGN KEY([YearList_YearListId])
REFERENCES [dbo].[YearList] ([YearListId])
GO
ALTER TABLE [dbo].[Track_YearList_User] CHECK CONSTRAINT [FK_Track_YearList_User_YearList]
GO
ALTER TABLE [dbo].[Tracks_YearList]  WITH CHECK ADD  CONSTRAINT [FK_Tracks_YearList_Tracks] FOREIGN KEY([Tracks_TrackId])
REFERENCES [dbo].[Tracks] ([trackId])
GO
ALTER TABLE [dbo].[Tracks_YearList] CHECK CONSTRAINT [FK_Tracks_YearList_Tracks]
GO
ALTER TABLE [dbo].[Tracks_YearList]  WITH CHECK ADD  CONSTRAINT [FK_Tracks_YearList_YearList] FOREIGN KEY([YearList_YearListId])
REFERENCES [dbo].[YearList] ([YearListId])
GO
ALTER TABLE [dbo].[Tracks_YearList] CHECK CONSTRAINT [FK_Tracks_YearList_YearList]
GO
/****** Object:  StoredProcedure [dbo].[spCheckUserVote]    Script Date: 29-6-2020 14:10:38 ******/
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
/****** Object:  StoredProcedure [dbo].[spDeleteTracks]    Script Date: 29-6-2020 14:10:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDeleteTracks]
@YearID Int
AS
DELETE FROM Tracks_YearList WHERE YearList_YearListId LIKE @YearID
GO
/****** Object:  StoredProcedure [dbo].[spDeleteVotes]    Script Date: 29-6-2020 14:10:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDeleteVotes]
@YearID Int
AS
DELETE FROM Track_YearList_User WHERE YearList_YearListId LIKE @YearID
GO
/****** Object:  StoredProcedure [dbo].[spNumberOfSongsOfArtist]    Script Date: 29-6-2020 14:10:38 ******/
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
/****** Object:  StoredProcedure [dbo].[spSelectAllArtists]    Script Date: 29-6-2020 14:10:38 ******/
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
/****** Object:  StoredProcedure [dbo].[spSelectAllTitles]    Script Date: 29-6-2020 14:10:38 ******/
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
/****** Object:  StoredProcedure [dbo].[spSelectAllVotes]    Script Date: 29-6-2020 14:10:38 ******/
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
/****** Object:  StoredProcedure [dbo].[spSelectListingOnYear]    Script Date: 29-6-2020 14:10:38 ******/
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
/****** Object:  StoredProcedure [dbo].[spSelectTop10ListingOnYear]    Script Date: 29-6-2020 14:10:38 ******/
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
USE [master]
GO
ALTER DATABASE [Top2000] SET  READ_WRITE 
GO
