USE [master]
GO
/****** Object:  Database [CompanyDb]    Script Date: 4/3/2023 1:46:16 AM ******/
CREATE DATABASE [CompanyDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CompanyDb', FILENAME = N'D:\Databases\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CompanyDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CompanyDb_log', FILENAME = N'D:\Databases\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CompanyDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CompanyDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CompanyDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CompanyDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CompanyDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CompanyDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CompanyDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CompanyDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [CompanyDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CompanyDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CompanyDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CompanyDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CompanyDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CompanyDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CompanyDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CompanyDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CompanyDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CompanyDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CompanyDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CompanyDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CompanyDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CompanyDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CompanyDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CompanyDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CompanyDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CompanyDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CompanyDb] SET  MULTI_USER 
GO
ALTER DATABASE [CompanyDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CompanyDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CompanyDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CompanyDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CompanyDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CompanyDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CompanyDb] SET QUERY_STORE = OFF
GO
USE [CompanyDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/3/2023 1:46:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 4/3/2023 1:46:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Age] [int] NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[JobTitle] [nvarchar](50) NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mail]    Script Date: 4/3/2023 1:46:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Body] [nvarchar](max) NULL,
	[AddresseeId] [int] NULL,
	[SenderId] [int] NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [Age], [FirstName], [MiddleName], [LastName], [JobTitle], [rowguid]) VALUES (1, 27, N'Natalya', N'Vasilievna', N'Ivanova', N'Accountant', N'82f12cfe-7360-4718-a490-e839511b67b7')
INSERT [dbo].[Employee] ([Id], [Age], [FirstName], [MiddleName], [LastName], [JobTitle], [rowguid]) VALUES (2, 32, N'Savelii', N'Yaroslavovich', N'Gromov', N'Engineer', N'57061bce-e7f6-4fd6-ac09-266b79e4d4c0')
INSERT [dbo].[Employee] ([Id], [Age], [FirstName], [MiddleName], [LastName], [JobTitle], [rowguid]) VALUES (3, 30, N'Taras', N'Frolovich', N'Fokin', N'Manager', N'bc831cd8-2895-4d5c-aff3-6628643009e5')
INSERT [dbo].[Employee] ([Id], [Age], [FirstName], [MiddleName], [LastName], [JobTitle], [rowguid]) VALUES (4, 41, N'Denis', N'Vladimirovich', N'Gulyaev', N'CEO', N'27bab180-2d06-4c06-b058-ff6baedc4aa8')
INSERT [dbo].[Employee] ([Id], [Age], [FirstName], [MiddleName], [LastName], [JobTitle], [rowguid]) VALUES (5, 25, N'Ivan', N'Igorevich', N'Tarasov', N'Programmer', N'1be04afb-a214-4bb8-a81c-0ac5f118f327')
INSERT [dbo].[Employee] ([Id], [Age], [FirstName], [MiddleName], [LastName], [JobTitle], [rowguid]) VALUES (6, 29, N'Vladimir', N'Sergeevich', N'Romanov', N'Programmer', N'7f81b0b6-17f5-46a1-b8d4-2b37b10156c6')
INSERT [dbo].[Employee] ([Id], [Age], [FirstName], [MiddleName], [LastName], [JobTitle], [rowguid]) VALUES (7, 36, N'Aleksandr', N'Timofeevich', N'Lukin', N'HR', N'4be238f1-261c-40aa-b3b6-5ab2dbe8ba1e')
INSERT [dbo].[Employee] ([Id], [Age], [FirstName], [MiddleName], [LastName], [JobTitle], [rowguid]) VALUES (8, 26, N'Yurii', N'Nikolaevich', N'Yakovlev', N'Cleaner', N'e3aef2cb-cf8e-492a-a298-e91eeedb7305')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Mail] ON 

INSERT [dbo].[Mail] ([Id], [Name], [Date], [Body], [AddresseeId], [SenderId], [rowguid]) VALUES (2, N'Test mail from acc to hr', CAST(N'2023-03-29T00:00:00.000' AS DateTime), N'Hello! How''s it going?', 7, 1, N'2ac62369-b172-4788-a0ef-1d36ea8b9891')
INSERT [dbo].[Mail] ([Id], [Name], [Date], [Body], [AddresseeId], [SenderId], [rowguid]) VALUES (4, N'test post method again', CAST(N'2023-03-30T18:37:02.053' AS DateTime), N'message body blah blah', 1, 4, N'6f353171-fb95-4324-8caf-c7c853fd5a73')
INSERT [dbo].[Mail] ([Id], [Name], [Date], [Body], [AddresseeId], [SenderId], [rowguid]) VALUES (10, N'ghfghbfgh', CAST(N'2023-04-01T17:44:21.020' AS DateTime), N'fghhtrhfgh', 3, 1, N'7edcf6e9-916b-4b54-9053-d1bc09eab5cb')
INSERT [dbo].[Mail] ([Id], [Name], [Date], [Body], [AddresseeId], [SenderId], [rowguid]) VALUES (11, N'iurtoeirtuoieur', CAST(N'2023-04-01T17:47:40.263' AS DateTime), N'retiuretypoirueyop', 1, 3, N'9f727923-2fc4-4a36-b419-bbfc404c79f1')
INSERT [dbo].[Mail] ([Id], [Name], [Date], [Body], [AddresseeId], [SenderId], [rowguid]) VALUES (14, N'12354 mod', CAST(N'2023-04-01T18:09:12.157' AS DateTime), N'test modify', 7, 8, N'dda44205-3367-4e13-8707-012beef1d463')
SET IDENTITY_INSERT [dbo].[Mail] OFF
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ((18)) FOR [Age]
GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_rowguid]  DEFAULT (newid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[Mail] ADD  CONSTRAINT [DF_Mail_rowguid]  DEFAULT (newid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[Mail]  WITH CHECK ADD FOREIGN KEY([AddresseeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Mail]  WITH CHECK ADD FOREIGN KEY([SenderId])
REFERENCES [dbo].[Employee] ([Id])
GO
USE [master]
GO
ALTER DATABASE [CompanyDb] SET  READ_WRITE 
GO
