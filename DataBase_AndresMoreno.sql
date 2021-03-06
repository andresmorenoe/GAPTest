USE [master]
GO
/****** Object:  Database [SegurosAndresMorenoDB]    Script Date: 06/07/2020 19:15:53 ******/
CREATE DATABASE [SegurosAndresMorenoDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SegurosAndresMorenoDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SegurosAndresMorenoDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SegurosAndresMorenoDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SegurosAndresMorenoDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SegurosAndresMorenoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET  MULTI_USER 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET QUERY_STORE = OFF
GO
USE [SegurosAndresMorenoDB]
GO
/****** Object:  User [pruebas]    Script Date: 06/07/2020 19:15:53 ******/
CREATE USER [pruebas] FOR LOGIN [pruebas] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[AsignacionPoliza]    Script Date: 06/07/2020 19:15:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsignacionPoliza](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[PolizaId] [int] NOT NULL,
 CONSTRAINT [PK_AsignacionPoliza] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 06/07/2020 19:15:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipoDocumentoId] [int] NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Documento] [varchar](10) NOT NULL,
	[Email] [varchar](100) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Cliente] UNIQUE NONCLUSTERED 
(
	[Documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Poliza]    Script Date: 06/07/2020 19:15:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Poliza](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipoRiesgoId] [int] NOT NULL,
	[TipoCubrimientoId] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](70) NOT NULL,
	[InicioVigencia] [date] NOT NULL,
	[PeriodoCobertura] [smallint] NOT NULL,
	[PorcentajeCobertura] [smallint] NOT NULL,
	[Precio] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_Poliza] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 06/07/2020 19:15:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleUsuario]    Script Date: 06/07/2020 19:15:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleUsuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
 CONSTRAINT [PK_RoleUsuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCubrimiento]    Script Date: 06/07/2020 19:15:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCubrimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoCubrimiento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 06/07/2020 19:15:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDocumento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoDocumento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoRiesgo]    Script Date: 06/07/2020 19:15:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoRiesgo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoRiesgo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 06/07/2020 19:15:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Email] [varchar](70) NOT NULL,
	[Contraseña] [varchar](12) NOT NULL,
	[Token] [varchar](max) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_AsignacionPoliza]    Script Date: 06/07/2020 19:15:53 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_AsignacionPoliza] ON [dbo].[AsignacionPoliza]
(
	[ClienteId] ASC,
	[PolizaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Poliza]    Script Date: 06/07/2020 19:15:53 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Poliza] ON [dbo].[Poliza]
(
	[TipoRiesgoId] ASC,
	[TipoCubrimientoId] ASC,
	[PeriodoCobertura] ASC,
	[PorcentajeCobertura] ASC,
	[InicioVigencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleUsuario]    Script Date: 06/07/2020 19:15:53 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_RoleUsuario] ON [dbo].[RoleUsuario]
(
	[RoleId] ASC,
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuario]    Script Date: 06/07/2020 19:15:53 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Usuario] ON [dbo].[Usuario]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AsignacionPoliza]  WITH CHECK ADD  CONSTRAINT [FK_AsignacionPoliza_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[AsignacionPoliza] CHECK CONSTRAINT [FK_AsignacionPoliza_Cliente]
GO
ALTER TABLE [dbo].[AsignacionPoliza]  WITH CHECK ADD  CONSTRAINT [FK_AsignacionPoliza_Poliza] FOREIGN KEY([PolizaId])
REFERENCES [dbo].[Poliza] ([Id])
GO
ALTER TABLE [dbo].[AsignacionPoliza] CHECK CONSTRAINT [FK_AsignacionPoliza_Poliza]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_TipoDocumento] FOREIGN KEY([TipoDocumentoId])
REFERENCES [dbo].[TipoDocumento] ([Id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_TipoDocumento]
GO
ALTER TABLE [dbo].[Poliza]  WITH CHECK ADD  CONSTRAINT [FK_Poliza_TipoCubrimiento] FOREIGN KEY([TipoCubrimientoId])
REFERENCES [dbo].[TipoCubrimiento] ([Id])
GO
ALTER TABLE [dbo].[Poliza] CHECK CONSTRAINT [FK_Poliza_TipoCubrimiento]
GO
ALTER TABLE [dbo].[Poliza]  WITH CHECK ADD  CONSTRAINT [FK_Poliza_TipoRiesgo] FOREIGN KEY([TipoRiesgoId])
REFERENCES [dbo].[TipoRiesgo] ([Id])
GO
ALTER TABLE [dbo].[Poliza] CHECK CONSTRAINT [FK_Poliza_TipoRiesgo]
GO
ALTER TABLE [dbo].[RoleUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RoleUsuario_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[RoleUsuario] CHECK CONSTRAINT [FK_RoleUsuario_Role]
GO
ALTER TABLE [dbo].[RoleUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RoleUsuario_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[RoleUsuario] CHECK CONSTRAINT [FK_RoleUsuario_Usuario]
GO
USE [master]
GO
ALTER DATABASE [SegurosAndresMorenoDB] SET  READ_WRITE 
GO
