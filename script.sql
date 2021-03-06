USE [master]
GO
/****** Object:  Database [CakeDB]    Script Date: 23/01/2022 12:06:59 ******/
CREATE DATABASE [CakeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CakeDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CakeDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CakeDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CakeDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CakeDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CakeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CakeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CakeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CakeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CakeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CakeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CakeDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CakeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CakeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CakeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CakeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CakeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CakeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CakeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CakeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CakeDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CakeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CakeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CakeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CakeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CakeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CakeDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CakeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CakeDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CakeDB] SET  MULTI_USER 
GO
ALTER DATABASE [CakeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CakeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CakeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CakeDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CakeDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CakeDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CakeDB] SET QUERY_STORE = OFF
GO
USE [CakeDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 23/01/2022 12:06:59 ******/
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
/****** Object:  Table [dbo].[Addresses]    Script Date: 23/01/2022 12:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Addressid] [int] IDENTITY(1,1) NOT NULL,
	[Street_name] [nvarchar](50) NOT NULL,
	[House_number] [nvarchar](10) NOT NULL,
	[Zipcode] [nvarchar](20) NOT NULL,
	[City] [nvarchar](20) NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Addressid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cakes]    Script Date: 23/01/2022 12:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cakes](
	[CakeID] [int] IDENTITY(1,1) NOT NULL,
	[CakeName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CakePrice] [float] NOT NULL,
	[CakeType] [int] NOT NULL,
	[CakeSize] [int] NOT NULL,
	[orderID] [int] NOT NULL,
 CONSTRAINT [PK_Cakes] PRIMARY KEY CLUSTERED 
(
	[CakeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 23/01/2022 12:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[DelivryDate] [datetime2](7) NOT NULL,
	[OrderPreparedDate] [datetime2](7) NULL,
	[Address] [nvarchar](max) NOT NULL,
	[OrderUserID] [int] NOT NULL,
	[OrderPrice] [float] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 23/01/2022 12:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[EmailAddress] [nvarchar](20) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211218151429_tak1', N'5.0.12')
GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([Addressid], [Street_name], [House_number], [Zipcode], [City], [UserID]) VALUES (1, N'rabin', N'40', N'3300110', N'tel aviv', 1)
INSERT [dbo].[Addresses] ([Addressid], [Street_name], [House_number], [Zipcode], [City], [UserID]) VALUES (2, N'ben moshe', N'15', N'22000', N'tel aviv', 2)
INSERT [dbo].[Addresses] ([Addressid], [Street_name], [House_number], [Zipcode], [City], [UserID]) VALUES (3, N'weitzman', N'155', N'123123', N'nes tsiona', 3)
INSERT [dbo].[Addresses] ([Addressid], [Street_name], [House_number], [Zipcode], [City], [UserID]) VALUES (4, N'rabina', N'8', N'71700', N'arad', 4)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
GO
SET IDENTITY_INSERT [dbo].[Cakes] ON 

INSERT [dbo].[Cakes] ([CakeID], [CakeName], [Description], [CakePrice], [CakeType], [CakeSize], [orderID]) VALUES (1, N'Cheese S extra c', N'extra chocolate', 40, 2, 1, 1)
INSERT [dbo].[Cakes] ([CakeID], [CakeName], [Description], [CakePrice], [CakeType], [CakeSize], [orderID]) VALUES (2, N'Chocolate M extra ', N'extra cheese', 35, 1, 2, 2)
INSERT [dbo].[Cakes] ([CakeID], [CakeName], [Description], [CakePrice], [CakeType], [CakeSize], [orderID]) VALUES (3, N'Chocolate 5 call for forth', N'call for forther instructions', 65, 1, 5, 3)
INSERT [dbo].[Cakes] ([CakeID], [CakeName], [Description], [CakePrice], [CakeType], [CakeSize], [orderID]) VALUES (4, N'VegiChocolate S no', N'none', 70, 4, 1, 4)
SET IDENTITY_INSERT [dbo].[Cakes] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderID], [OrderDate], [DelivryDate], [OrderPreparedDate], [Address], [OrderUserID], [OrderPrice]) VALUES (1, CAST(N'2022-01-23T11:54:10.7514007' AS DateTime2), CAST(N'2025-10-22T00:00:00.0000000' AS DateTime2), NULL, N'rabin ,40,3300110,tel aviv', 1, 50)
INSERT [dbo].[Orders] ([OrderID], [OrderDate], [DelivryDate], [OrderPreparedDate], [Address], [OrderUserID], [OrderPrice]) VALUES (2, CAST(N'2022-01-23T11:55:14.2945298' AS DateTime2), CAST(N'2050-12-22T00:00:00.0000000' AS DateTime2), NULL, N'ben moshe ,15,22000,tel aviv', 2, 125)
INSERT [dbo].[Orders] ([OrderID], [OrderDate], [DelivryDate], [OrderPreparedDate], [Address], [OrderUserID], [OrderPrice]) VALUES (3, CAST(N'2022-01-23T11:56:29.8652875' AS DateTime2), CAST(N'2023-05-04T00:00:00.0000000' AS DateTime2), NULL, N'weitzman ,155,123123,nes tsiona', 3, 500)
INSERT [dbo].[Orders] ([OrderID], [OrderDate], [DelivryDate], [OrderPreparedDate], [Address], [OrderUserID], [OrderPrice]) VALUES (4, CAST(N'2022-01-23T11:57:41.7167554' AS DateTime2), CAST(N'2022-05-05T00:00:00.0000000' AS DateTime2), NULL, N'rabina ,8,71700,arad', 4, 500)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [EmailAddress], [PhoneNumber]) VALUES (1, N'Yonatan', N'Yeheskely', N'johnny@gmail.com', N'0553334445')
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [EmailAddress], [PhoneNumber]) VALUES (2, N'nir', N'cohen', N'nir@gmail.com', N'05542311023')
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [EmailAddress], [PhoneNumber]) VALUES (3, N'lior', N'benisty', N'lior', N'2200111344')
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [EmailAddress], [PhoneNumber]) VALUES (4, N'yael', N'glezer', N'yael@gmail.com', N'05511223')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Addresses_UserID]    Script Date: 23/01/2022 12:06:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Addresses_UserID] ON [dbo].[Addresses]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cakes_orderID]    Script Date: 23/01/2022 12:06:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Cakes_orderID] ON [dbo].[Cakes]
(
	[orderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_OrderUserID]    Script Date: 23/01/2022 12:06:59 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_OrderUserID] ON [dbo].[Orders]
(
	[OrderUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Users_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Users_UserID]
GO
ALTER TABLE [dbo].[Cakes]  WITH CHECK ADD  CONSTRAINT [FK_Cakes_Orders_orderID] FOREIGN KEY([orderID])
REFERENCES [dbo].[Orders] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cakes] CHECK CONSTRAINT [FK_Cakes_Orders_orderID]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users_OrderUserID] FOREIGN KEY([OrderUserID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users_OrderUserID]
GO
USE [master]
GO
ALTER DATABASE [CakeDB] SET  READ_WRITE 
GO
