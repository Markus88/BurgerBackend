USE [master]
GO
/****** Object:  Database [BurgerBackendDb]    Script Date: 27-11-2021 19:41:44 ******/
CREATE DATABASE [BurgerBackendDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BurgerBackendDb', FILENAME = N'X:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BurgerBackendDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BurgerBackendDb_log', FILENAME = N'X:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BurgerBackendDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BurgerBackendDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BurgerBackendDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BurgerBackendDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BurgerBackendDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BurgerBackendDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BurgerBackendDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BurgerBackendDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET RECOVERY FULL 
GO
ALTER DATABASE [BurgerBackendDb] SET  MULTI_USER 
GO
ALTER DATABASE [BurgerBackendDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BurgerBackendDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BurgerBackendDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BurgerBackendDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BurgerBackendDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BurgerBackendDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BurgerBackendDb', N'ON'
GO
ALTER DATABASE [BurgerBackendDb] SET QUERY_STORE = OFF
GO
USE [BurgerBackendDb]
GO
/****** Object:  Table [dbo].[BusinessTime]    Script Date: 27-11-2021 19:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessTime](
	[ID] [int] NOT NULL,
	[Day] [int] NOT NULL,
	[OpenTime] [date] NOT NULL,
	[CloseTime] [date] NOT NULL,
	[FK_Restaurant_ID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 27-11-2021 19:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[ZipCode] [int] NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restaurant]    Script Date: 27-11-2021 19:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurant](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Phone] [int] NULL,
	[Address] [varchar](255) NOT NULL,
	[FK_City_ID] [int] NOT NULL,
 CONSTRAINT [PK_Restaurant] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 27-11-2021 19:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](255) NULL,
	[Taste] [smallint] NOT NULL,
	[Texture] [smallint] NOT NULL,
	[VisualPresentation] [smallint] NOT NULL,
	[FK_User_ID] [int] NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoredFileInformation]    Script Date: 27-11-2021 19:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoredFileInformation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [varchar](100) NOT NULL,
	[FileLocation] [varchar](255) NOT NULL,
	[FK_Review_ID] [int] NOT NULL,
 CONSTRAINT [PK_StoredFileInformation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 27-11-2021 19:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[FK_City_ID] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BusinessTime]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_ID] FOREIGN KEY([FK_Restaurant_ID])
REFERENCES [dbo].[Restaurant] ([ID])
GO
ALTER TABLE [dbo].[BusinessTime] CHECK CONSTRAINT [FK_Restaurant_ID]
GO
ALTER TABLE [dbo].[Restaurant]  WITH CHECK ADD  CONSTRAINT [FK_Citys_ID] FOREIGN KEY([FK_City_ID])
REFERENCES [dbo].[City] ([ID])
GO
ALTER TABLE [dbo].[Restaurant] CHECK CONSTRAINT [FK_Citys_ID]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_User_ID] FOREIGN KEY([FK_User_ID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_User_ID]
GO
ALTER TABLE [dbo].[StoredFileInformation]  WITH CHECK ADD  CONSTRAINT [FK_Review_ID] FOREIGN KEY([FK_Review_ID])
REFERENCES [dbo].[Review] ([ID])
GO
ALTER TABLE [dbo].[StoredFileInformation] CHECK CONSTRAINT [FK_Review_ID]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_City_ID] FOREIGN KEY([FK_City_ID])
REFERENCES [dbo].[City] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_City_ID]
GO
USE [master]
GO
ALTER DATABASE [BurgerBackendDb] SET  READ_WRITE 
GO
