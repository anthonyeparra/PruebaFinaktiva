USE [master]
GO
/****** Object:  Database [FinaktivaTwo]    Script Date: 6/03/2022 1:28:58 p. m. ******/
CREATE DATABASE [FinaktivaTwo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FinaktivaTwo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FinaktivaTwo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FinaktivaTwo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FinaktivaTwo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FinaktivaTwo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FinaktivaTwo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FinaktivaTwo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET ARITHABORT OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FinaktivaTwo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FinaktivaTwo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FinaktivaTwo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FinaktivaTwo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FinaktivaTwo] SET  MULTI_USER 
GO
ALTER DATABASE [FinaktivaTwo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FinaktivaTwo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FinaktivaTwo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FinaktivaTwo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FinaktivaTwo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FinaktivaTwo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FinaktivaTwo] SET QUERY_STORE = OFF
GO
USE [FinaktivaTwo]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 6/03/2022 1:28:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nameModule] [varchar](50) NOT NULL,
	[status] [tinyint] NOT NULL,
	[creationDate] [date] NOT NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModuleRolePermission]    Script Date: 6/03/2022 1:28:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModuleRolePermission](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idRol] [int] NOT NULL,
	[idModule] [int] NOT NULL,
	[idPermission] [int] NOT NULL,
 CONSTRAINT [PK_ModuleRolePermission] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 6/03/2022 1:28:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[status] [tinyint] NOT NULL,
	[creationDate] [date] NOT NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/03/2022 1:28:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nameRole] [varchar](50) NOT NULL,
	[status] [tinyint] NOT NULL,
	[creationDate] [date] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/03/2022 1:28:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[status] [tinyint] NOT NULL,
	[creationDate] [date] NOT NULL,
	[idRole] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Module] ADD  CONSTRAINT [DF_Module_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Module] ADD  CONSTRAINT [DF_Module_creationDate]  DEFAULT (getdate()) FOR [creationDate]
GO
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permission_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permission_creationDate]  DEFAULT (getdate()) FOR [creationDate]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_creationDate]  DEFAULT (getdate()) FOR [creationDate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_creationDate]  DEFAULT (getdate()) FOR [creationDate]
GO
ALTER TABLE [dbo].[ModuleRolePermission]  WITH CHECK ADD  CONSTRAINT [FK_ModuleRolePermission_Module] FOREIGN KEY([idModule])
REFERENCES [dbo].[Module] ([id])
GO
ALTER TABLE [dbo].[ModuleRolePermission] CHECK CONSTRAINT [FK_ModuleRolePermission_Module]
GO
ALTER TABLE [dbo].[ModuleRolePermission]  WITH CHECK ADD  CONSTRAINT [FK_ModuleRolePermission_Permission] FOREIGN KEY([idPermission])
REFERENCES [dbo].[Permission] ([id])
GO
ALTER TABLE [dbo].[ModuleRolePermission] CHECK CONSTRAINT [FK_ModuleRolePermission_Permission]
GO
ALTER TABLE [dbo].[ModuleRolePermission]  WITH CHECK ADD  CONSTRAINT [FK_ModuleRolePermission_Role1] FOREIGN KEY([idRol])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[ModuleRolePermission] CHECK CONSTRAINT [FK_ModuleRolePermission_Role1]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([idRole])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [FinaktivaTwo] SET  READ_WRITE 
GO
