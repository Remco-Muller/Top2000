USE [master]
GO
/****** Object:  Database [Top2000]    Script Date: 28-6-2020 21:29:10 ******/
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
ALTER DATABASE [Top2000] SET  READ_WRITE 
GO
