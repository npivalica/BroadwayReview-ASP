USE [master]
GO

/****** Object:  Database [BroadwayReview]    Script Date: 07-Sep-22 4:36:37 PM ******/
CREATE DATABASE [BroadwayReview]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BroadwayReview', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BroadwayReview.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BroadwayReview_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BroadwayReview_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BroadwayReview].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [BroadwayReview] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [BroadwayReview] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [BroadwayReview] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [BroadwayReview] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [BroadwayReview] SET ARITHABORT OFF 
GO

ALTER DATABASE [BroadwayReview] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [BroadwayReview] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [BroadwayReview] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [BroadwayReview] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [BroadwayReview] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [BroadwayReview] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [BroadwayReview] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [BroadwayReview] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [BroadwayReview] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [BroadwayReview] SET  DISABLE_BROKER 
GO

ALTER DATABASE [BroadwayReview] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [BroadwayReview] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [BroadwayReview] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [BroadwayReview] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [BroadwayReview] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [BroadwayReview] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [BroadwayReview] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [BroadwayReview] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [BroadwayReview] SET  MULTI_USER 
GO

ALTER DATABASE [BroadwayReview] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [BroadwayReview] SET DB_CHAINING OFF 
GO

ALTER DATABASE [BroadwayReview] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [BroadwayReview] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [BroadwayReview] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [BroadwayReview] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [BroadwayReview] SET QUERY_STORE = OFF
GO

ALTER DATABASE [BroadwayReview] SET  READ_WRITE 
GO

