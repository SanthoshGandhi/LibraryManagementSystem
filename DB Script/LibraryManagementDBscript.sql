USE [master]
GO
/****** Object:  Database [LMSystem]    Script Date: 23-02-2022 11:32:54 ******/
CREATE DATABASE [LMSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LMSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server 2017\MSSQL14.MSSQLSERVER\MSSQL\DATA\LMSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LMSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server 2017\MSSQL14.MSSQLSERVER\MSSQL\DATA\LMSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LMSystem] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LMSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LMSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LMSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LMSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LMSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LMSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [LMSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LMSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LMSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LMSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LMSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LMSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LMSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LMSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LMSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LMSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LMSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LMSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LMSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LMSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LMSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LMSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LMSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LMSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [LMSystem] SET  MULTI_USER 
GO
ALTER DATABASE [LMSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LMSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LMSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LMSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LMSystem] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LMSystem', N'ON'
GO
ALTER DATABASE [LMSystem] SET QUERY_STORE = OFF
GO
USE [LMSystem]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 23-02-2022 11:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookDetails]    Script Date: 23-02-2022 11:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookDetails](
	[ID] [varchar](20) NULL,
	[Title] [varchar](100) NULL,
	[Description] [varchar](100) NULL,
	[AuthorName] [varchar](50) NULL,
	[PublicationYear] [int] NULL,
	[Edition] [varchar](50) NULL,
	[Price] [int] NULL,
	[Count] [int] NULL,
	[EntryDate] [datetime] NULL,
	[Active] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookIssuedTable]    Script Date: 23-02-2022 11:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookIssuedTable](
	[MemberID] [varchar](50) NULL,
	[BookID] [varchar](10) NULL,
	[IsIssued] [bit] NULL,
	[IssusedDate] [datetime] NULL,
	[ReturnDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberDetails]    Script Date: 23-02-2022 11:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberDetails](
	[ID] [varchar](50) NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Age] [varchar](50) NULL,
	[Gender] [varchar](10) NULL,
	[JoiningDate] [datetime] NULL,
	[Active] [bit] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Admin] ([UserName], [Password]) VALUES (N'ADMIN1', N'123$')
GO
INSERT [dbo].[BookDetails] ([ID], [Title], [Description], [AuthorName], [PublicationYear], [Edition], [Price], [Count], [EntryDate], [Active]) VALUES (N'BNO22011', N'Harry Potter : Philosopher''s Stone', N'Book', N'J.K.Rowling', 1997, N'2000', 500, 20, CAST(N'2022-01-21T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[BookDetails] ([ID], [Title], [Description], [AuthorName], [PublicationYear], [Edition], [Price], [Count], [EntryDate], [Active]) VALUES (N'BNO22012', N'Harry Potter : Chamber of Secrets', N'Book', N'J.K.Rowling', 1998, N'2000', 500, 20, CAST(N'2022-01-21T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[BookDetails] ([ID], [Title], [Description], [AuthorName], [PublicationYear], [Edition], [Price], [Count], [EntryDate], [Active]) VALUES (N'BNO22013', N'Harry Potter : Prisoner of Azkaban', N'Book', N'J.K.Rowling', 1999, N'2000', 500, 20, CAST(N'2022-01-21T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[BookDetails] ([ID], [Title], [Description], [AuthorName], [PublicationYear], [Edition], [Price], [Count], [EntryDate], [Active]) VALUES (N'BNO22014', N'Harry Potter : Goblet of Fire', N'Book', N'J.K.Rowling', 2000, N'2000', 500, 20, CAST(N'2022-01-21T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[BookDetails] ([ID], [Title], [Description], [AuthorName], [PublicationYear], [Edition], [Price], [Count], [EntryDate], [Active]) VALUES (N'BNO22015', N'Harry Potter : Order of the Phoenix', N'Book', N'J.K.Rowling', 2003, N'2010', 500, 20, CAST(N'2022-01-21T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[BookDetails] ([ID], [Title], [Description], [AuthorName], [PublicationYear], [Edition], [Price], [Count], [EntryDate], [Active]) VALUES (N'BNO22016', N'Harry Potter : Half-Blood Prince', N'Book', N'J.K.Rowling', 2005, N'2010', 500, 20, CAST(N'2022-01-21T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[BookDetails] ([ID], [Title], [Description], [AuthorName], [PublicationYear], [Edition], [Price], [Count], [EntryDate], [Active]) VALUES (N'BNO22017', N'Harry Potter : Deathly Hallows', N'Book', N'J.K.Rowling', 2007, N'2010', 500, 20, CAST(N'2022-01-21T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[BookDetails] ([ID], [Title], [Description], [AuthorName], [PublicationYear], [Edition], [Price], [Count], [EntryDate], [Active]) VALUES (N'BNO22018', N'Rich Dad Poor Dad', N'Book', N'Robert Kiyosaki and Sharon Lechter', 1997, N'2020', 500, 20, CAST(N'2022-01-21T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[BookDetails] ([ID], [Title], [Description], [AuthorName], [PublicationYear], [Edition], [Price], [Count], [EntryDate], [Active]) VALUES (N'BNO22019', N'The Alchemist', N'Book', N'Paulo Coelho', 1988, N'2020', 500, 20, CAST(N'2022-01-21T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[BookIssuedTable] ([MemberID], [BookID], [IsIssued], [IssusedDate], [ReturnDate]) VALUES (N'MNO22011', N'BNO22012', 1, CAST(N'2022-02-23T00:00:00.000' AS DateTime), CAST(N'2022-03-25T00:00:00.000' AS DateTime))
INSERT [dbo].[BookIssuedTable] ([MemberID], [BookID], [IsIssued], [IssusedDate], [ReturnDate]) VALUES (N'MNO22011', N'BNO22013', 1, CAST(N'2022-02-23T00:00:00.000' AS DateTime), CAST(N'2022-03-25T00:00:00.000' AS DateTime))
INSERT [dbo].[BookIssuedTable] ([MemberID], [BookID], [IsIssued], [IssusedDate], [ReturnDate]) VALUES (N'MNO22011', N'BNO22014', 1, CAST(N'2022-02-23T00:00:00.000' AS DateTime), CAST(N'2022-03-25T00:00:00.000' AS DateTime))
INSERT [dbo].[BookIssuedTable] ([MemberID], [BookID], [IsIssued], [IssusedDate], [ReturnDate]) VALUES (N'MNO22011', N'BNO22015', 1, CAST(N'2022-02-23T00:00:00.000' AS DateTime), CAST(N'2022-03-25T00:00:00.000' AS DateTime))
INSERT [dbo].[BookIssuedTable] ([MemberID], [BookID], [IsIssued], [IssusedDate], [ReturnDate]) VALUES (N'MNO22011', N'BNO22016', 1, CAST(N'2022-02-23T00:00:00.000' AS DateTime), CAST(N'2022-03-25T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MemberDetails] ([ID], [UserName], [Password], [Age], [Gender], [JoiningDate], [Active]) VALUES (N'MNO22011', N'Santhosh Gandhi', N'1234', N'21', N'male', CAST(N'2022-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MemberDetails] ([ID], [UserName], [Password], [Age], [Gender], [JoiningDate], [Active]) VALUES (N'MNO22012', N'Thalif ', N'1234', N'25', N'male', CAST(N'2022-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MemberDetails] ([ID], [UserName], [Password], [Age], [Gender], [JoiningDate], [Active]) VALUES (N'MNO22018', N'Dinesh', N'1234', N'21', N'male', CAST(N'2022-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MemberDetails] ([ID], [UserName], [Password], [Age], [Gender], [JoiningDate], [Active]) VALUES (N'MNO22019', N'af', N'df', N'df', N'adsf', CAST(N'2022-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MemberDetails] ([ID], [UserName], [Password], [Age], [Gender], [JoiningDate], [Active]) VALUES (N'MNO22013', N'Ashraf Ali', N'1234', N'24', N'male', CAST(N'2022-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MemberDetails] ([ID], [UserName], [Password], [Age], [Gender], [JoiningDate], [Active]) VALUES (N'MNO22014', N'Santhosh1', N'1234', N'21', N'male', CAST(N'2022-01-01T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MemberDetails] ([ID], [UserName], [Password], [Age], [Gender], [JoiningDate], [Active]) VALUES (N'MNO22011', N'Santhosh12', N'1234', N'21', N'male', CAST(N'2022-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MemberDetails] ([ID], [UserName], [Password], [Age], [Gender], [JoiningDate], [Active]) VALUES (N'MNO22016', N'Santhosh123', N'123', N'21', N'Male', CAST(N'2022-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MemberDetails] ([ID], [UserName], [Password], [Age], [Gender], [JoiningDate], [Active]) VALUES (N'MNO22017', N'afaf', N'sdfsadfsadf', N'sadfaf', N'adsfadff', CAST(N'2022-01-01T00:00:00.000' AS DateTime), 1)
GO
USE [master]
GO
ALTER DATABASE [LMSystem] SET  READ_WRITE 
GO
