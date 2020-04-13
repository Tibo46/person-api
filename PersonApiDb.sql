USE [master]
GO
/****** Object:  Database [People]    Script Date: 13/04/2020 11:19:14 ******/
CREATE DATABASE [People]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'People', FILENAME = N'/var/opt/mssql/data/People.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'People_log', FILENAME = N'/var/opt/mssql/data/People_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [People] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [People].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [People] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [People] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [People] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [People] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [People] SET ARITHABORT OFF 
GO
ALTER DATABASE [People] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [People] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [People] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [People] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [People] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [People] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [People] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [People] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [People] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [People] SET  ENABLE_BROKER 
GO
ALTER DATABASE [People] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [People] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [People] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [People] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [People] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [People] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [People] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [People] SET RECOVERY FULL 
GO
ALTER DATABASE [People] SET  MULTI_USER 
GO
ALTER DATABASE [People] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [People] SET DB_CHAINING OFF 
GO
ALTER DATABASE [People] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [People] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [People] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'People', N'ON'
GO
ALTER DATABASE [People] SET QUERY_STORE = OFF
GO
USE [People]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 13/04/2020 11:19:15 ******/
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
/****** Object:  Table [dbo].[Groups]    Script Date: 13/04/2020 11:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 13/04/2020 11:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[GroupId] [int] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[Photo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200409090530_InitialMigrations', N'3.1.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200409090609_Seeding', N'3.1.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200412213303_AddPersonsPhoto', N'3.1.3')
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([Id], [Name], [CreationDate]) VALUES (1, N'Nurse', CAST(N'2020-04-13T09:38:18.6166667' AS DateTime2))
INSERT [dbo].[Groups] ([Id], [Name], [CreationDate]) VALUES (2, N'Doctor', CAST(N'2020-04-13T09:38:18.6200000' AS DateTime2))
INSERT [dbo].[Groups] ([Id], [Name], [CreationDate]) VALUES (3, N'Biologist', CAST(N'2020-04-13T09:38:18.6233333' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
INSERT [dbo].[Persons] ([Id], [Name], [GroupId], [CreationDate], [Photo]) VALUES (N'384b1855-c8e4-4641-a570-1a0dc6a08fe2', N'Henry Gray', 2, CAST(N'2020-04-13T09:38:18.6333333' AS DateTime2), N'https://assets.cloudylab.co.uk/eintech/assets/henry-gray.jpg')
INSERT [dbo].[Persons] ([Id], [Name], [GroupId], [CreationDate], [Photo]) VALUES (N'43a2abde-1902-4db6-96a4-0c6e9ad198cd', N'Florence Nightingale', 1, CAST(N'2020-04-13T09:38:18.6333333' AS DateTime2), N'https://assets.cloudylab.co.uk/eintech/assets/florence-nightingale.jpg')
INSERT [dbo].[Persons] ([Id], [Name], [GroupId], [CreationDate], [Photo]) VALUES (N'95119dc4-816c-4213-b86b-56c13045c22e', N'Walt Whitman', 1, CAST(N'2020-04-13T09:38:18.6333333' AS DateTime2), N'https://assets.cloudylab.co.uk/eintech/assets/walt-whitman.jpg')
INSERT [dbo].[Persons] ([Id], [Name], [GroupId], [CreationDate], [Photo]) VALUES (N'af2bdcf0-7bc3-420d-b06f-9e780aaf01d0', N'Joseph Lister', 2, CAST(N'2020-04-13T09:38:18.6333333' AS DateTime2), N'https://assets.cloudylab.co.uk/eintech/assets/joseph-lister.jpg')
INSERT [dbo].[Persons] ([Id], [Name], [GroupId], [CreationDate], [Photo]) VALUES (N'b7236db2-9513-4442-8fcb-fee7dead1aac', N'Alexander Fleming', 3, CAST(N'2020-04-13T09:38:18.6333333' AS DateTime2), N'https://assets.cloudylab.co.uk/eintech/assets/alexander-fleming.jpg')
GO
/****** Object:  Index [IX_Persons_GroupId]    Script Date: 13/04/2020 11:19:15 ******/
CREATE NONCLUSTERED INDEX [IX_Persons_GroupId] ON [dbo].[Persons]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Persons_Name]    Script Date: 13/04/2020 11:19:15 ******/
CREATE NONCLUSTERED INDEX [IX_Persons_Name] ON [dbo].[Persons]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Groups] ADD  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Persons] ADD  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Groups_GroupId]
GO
USE [master]
GO
ALTER DATABASE [People] SET  READ_WRITE 
GO
