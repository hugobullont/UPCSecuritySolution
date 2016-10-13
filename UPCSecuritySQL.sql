USE [master]
GO
/****** Object:  Database [UPCSecurity]    Script Date: 13/10/2016 18:20:39 ******/
CREATE DATABASE [UPCSecurity]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UPCSecurity', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.LOUDY\MSSQL\DATA\UPCSecurity.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UPCSecurity_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.LOUDY\MSSQL\DATA\UPCSecurity_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UPCSecurity] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UPCSecurity].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UPCSecurity] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UPCSecurity] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UPCSecurity] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UPCSecurity] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UPCSecurity] SET ARITHABORT OFF 
GO
ALTER DATABASE [UPCSecurity] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UPCSecurity] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UPCSecurity] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UPCSecurity] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UPCSecurity] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UPCSecurity] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UPCSecurity] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UPCSecurity] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UPCSecurity] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UPCSecurity] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UPCSecurity] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UPCSecurity] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UPCSecurity] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UPCSecurity] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UPCSecurity] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UPCSecurity] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UPCSecurity] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UPCSecurity] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UPCSecurity] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UPCSecurity] SET  MULTI_USER 
GO
ALTER DATABASE [UPCSecurity] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UPCSecurity] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UPCSecurity] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UPCSecurity] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UPCSecurity]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 13/10/2016 18:20:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customers](
	[idCustomer] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DNI] [int] NOT NULL,
	[CustomerType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[idCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 13/10/2016 18:20:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Documents](
	[idDocument] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FilePath] [varchar](200) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[DocType] [varchar](50) NOT NULL,
	[idIncidence] [int] NOT NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[idDocument] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Incidences]    Script Date: 13/10/2016 18:20:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Incidences](
	[idIncidence] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[Date] [date] NOT NULL,
	[State] [varchar](50) NOT NULL,
	[Environment] [varchar](50) NOT NULL,
	[Local] [varchar](50) NOT NULL,
	[idUser] [int] NOT NULL,
	[idCustomer] [int] NOT NULL,
 CONSTRAINT [PK_Incidences] PRIMARY KEY CLUSTERED 
(
	[idIncidence] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 13/10/2016 18:20:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[Password] [varchar](18) NOT NULL,
	[UserType] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_Documents_Incidences] FOREIGN KEY([idIncidence])
REFERENCES [dbo].[Incidences] ([idIncidence])
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_Documents_Incidences]
GO
ALTER TABLE [dbo].[Incidences]  WITH CHECK ADD  CONSTRAINT [FK_Incidences_Customers] FOREIGN KEY([idCustomer])
REFERENCES [dbo].[Customers] ([idCustomer])
GO
ALTER TABLE [dbo].[Incidences] CHECK CONSTRAINT [FK_Incidences_Customers]
GO
ALTER TABLE [dbo].[Incidences]  WITH CHECK ADD  CONSTRAINT [FK_Incidences_Users] FOREIGN KEY([idUser])
REFERENCES [dbo].[Users] ([idUser])
GO
ALTER TABLE [dbo].[Incidences] CHECK CONSTRAINT [FK_Incidences_Users]
GO
USE [master]
GO
ALTER DATABASE [UPCSecurity] SET  READ_WRITE 
GO
