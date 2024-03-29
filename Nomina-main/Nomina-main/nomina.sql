USE [master]
GO
/****** Object:  Database [Nomina]    Script Date: 20/4/2023 16:31:09 ******/
CREATE DATABASE [Nomina]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Nomina', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Nomina.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Nomina_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Nomina_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Nomina] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Nomina].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Nomina] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Nomina] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Nomina] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Nomina] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Nomina] SET ARITHABORT OFF 
GO
ALTER DATABASE [Nomina] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Nomina] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Nomina] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Nomina] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Nomina] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Nomina] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Nomina] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Nomina] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Nomina] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Nomina] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Nomina] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Nomina] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Nomina] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Nomina] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Nomina] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Nomina] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Nomina] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Nomina] SET RECOVERY FULL 
GO
ALTER DATABASE [Nomina] SET  MULTI_USER 
GO
ALTER DATABASE [Nomina] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Nomina] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Nomina] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Nomina] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Nomina] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Nomina] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Nomina', N'ON'
GO
ALTER DATABASE [Nomina] SET QUERY_STORE = OFF
GO
USE [Nomina]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 20/4/2023 16:31:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Telefono] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Cargo] [nvarchar](50) NOT NULL,
	[Departamento] [nvarchar](50) NOT NULL,
	[Salario] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TablaNominas]    Script Date: 20/4/2023 16:31:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TablaNominas](
	[idNomina] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Cargo] [varchar](50) NOT NULL,
	[SueldoBruto] [int] NOT NULL,
	[HorasExtra] [int] NOT NULL,
	[PrecioXHora] [int] NOT NULL,
	[BonoTransporte] [int] NOT NULL,
	[TotalAsignacion] [int] NOT NULL,
	[Seguro] [int] NOT NULL,
	[Adelanto] [int] NOT NULL,
	[TotalDeduccion] [int] NOT NULL,
	[SueldoNeto] [int] NOT NULL,
	[ExtraHours] [int] NOT NULL,
	[Fecha] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TablaNominas] PRIMARY KEY CLUSTERED 
(
	[idNomina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogs]    Script Date: 20/4/2023 16:31:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogs](
	[IDLog] [int] IDENTITY(1,1) NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Rol] [nvarchar](50) NOT NULL,
	[Accion] [nvarchar](50) NOT NULL,
	[Fecha] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserLogs] PRIMARY KEY CLUSTERED 
(
	[IDLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 20/4/2023 16:31:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Contraseña] [nvarchar](50) NOT NULL,
	[Rol] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Nomina] SET  READ_WRITE 
GO
