USE [master]
GO

/****** Object:  Database [PhotoStore]    Script Date: 30-Aug-22 8:03:25 PM ******/
CREATE DATABASE [PhotoStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PhotoStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PhotoStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PhotoStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PhotoStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PhotoStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [PhotoStore] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [PhotoStore] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [PhotoStore] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [PhotoStore] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [PhotoStore] SET ARITHABORT OFF 
GO

ALTER DATABASE [PhotoStore] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [PhotoStore] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [PhotoStore] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [PhotoStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [PhotoStore] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [PhotoStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [PhotoStore] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [PhotoStore] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [PhotoStore] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [PhotoStore] SET  DISABLE_BROKER 
GO

ALTER DATABASE [PhotoStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [PhotoStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [PhotoStore] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [PhotoStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [PhotoStore] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [PhotoStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [PhotoStore] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [PhotoStore] SET RECOVERY FULL 
GO

ALTER DATABASE [PhotoStore] SET  MULTI_USER 
GO

ALTER DATABASE [PhotoStore] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [PhotoStore] SET DB_CHAINING OFF 
GO

ALTER DATABASE [PhotoStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [PhotoStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [PhotoStore] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [PhotoStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [PhotoStore] SET QUERY_STORE = OFF
GO

ALTER DATABASE [PhotoStore] SET  READ_WRITE 
GO

