USE [master]
GO
/****** Object:  Database [CatalogoDB]    Script Date: 9/04/2023 1:27:13 a. m. ******/
CREATE DATABASE [CatalogoDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CatalogoDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CatalogoDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CatalogoDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CatalogoDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CatalogoDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CatalogoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CatalogoDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CatalogoDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CatalogoDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CatalogoDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CatalogoDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CatalogoDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CatalogoDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CatalogoDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CatalogoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CatalogoDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CatalogoDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CatalogoDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CatalogoDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CatalogoDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CatalogoDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CatalogoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CatalogoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CatalogoDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CatalogoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CatalogoDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CatalogoDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CatalogoDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CatalogoDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CatalogoDB] SET  MULTI_USER 
GO
ALTER DATABASE [CatalogoDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CatalogoDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CatalogoDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CatalogoDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CatalogoDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CatalogoDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CatalogoDB] SET QUERY_STORE = OFF
GO
USE [CatalogoDB]
GO
/****** Object:  User [catalog]    Script Date: 9/04/2023 1:27:13 a. m. ******/
CREATE USER [catalog] FOR LOGIN [catalog] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [admin]    Script Date: 9/04/2023 1:27:13 a. m. ******/
CREATE USER [admin] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [catalog]
GO
ALTER ROLE [db_datareader] ADD MEMBER [catalog]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [catalog]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 9/04/2023 1:27:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 9/04/2023 1:27:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[Imagen] [nvarchar](max) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (2, N'Laptop')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (3, N'SmartTV')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (7, N'SmartPhone')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (8, N'Gadget')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (10, N'Accesorio')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (21, N'Categoria Fake')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [CategoriaId], [Imagen]) VALUES (2, N'Lenovo Ideapad 3', N'Laptop Gamer by Lenovo with i7', 2, N'https://www.alkosto.com/medias/196380555879-001-750Wx750H?context=bWFzdGVyfGltYWdlc3wxOTI5Mzh8aW1hZ2UvanBlZ3xoZDEvaGZmLzEzNDYxNzYwMTgwMjU0LzE5NjM4MDU1NTg3OV8wMDFfNzUwV3g3NTBIfDdiYzFjNmQ0OTM3ZjVhZmRkNjM5NjI5YmU1MTUwMzdiMWE3NDMwZTRhOGU5ZGRhZTkxMTc1ODdkNzA1N2FmNWU')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [CategoriaId], [Imagen]) VALUES (3, N'Tv Xiaomi 32"', N'El TV XIAOMI 32 " P1 ofrece un diseño sin biseles en tres lados para que puedas tener una visualización única, su diseño sofisticado y su base de alta calidad refuerza el concepto visual de alta definición con una experiencia visual más clara, envolvente y agradable, que te permitirán vivir experiencias únicas en el lugar donde estes. Gracias a la cómoda interfaz de Android TV 9, simplifica tu experiencia de entretenimiento, además, cuenta con control remoto con conectividad Bluetooth, activado por voz para un uso simple, vive la experiencia Xiaomi. ¡Ven por el tuyo!', 3, N'https://www.alkosto.com/medias/1400Wx1400H-master-hotfolder-transfer-incoming-deposit-hybris-interfaces-IN-media-product-6971408155507-001.jpg?context=bWFzdGVyfGltYWdlc3wzNjc2MzB8aW1hZ2UvanBlZ3xoODEvaGU0LzEzNzA0ODE1MjgwMTU4LzE0MDBXeDE0MDBIX21hc3Rlci9ob3Rmb2xkZXIvdHJhbnNmZXIvaW5jb21pbmcvZGVwb3NpdC9oeWJyaXMtaW50ZXJmYWNlcy9JTi9tZWRpYS9wcm9kdWN0LzY5NzE0MDgxNTU1MDdfMDAxLmpwZ3wxYzk0ZGFmMmM3Y2JhNGY2ODQxY2UzYzMxMjVhYWZlNzM2NzZiMWZlNzhlZDlkMzViYjU1NjBmOGI2NmZjYWMw')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [CategoriaId], [Imagen]) VALUES (9, N'LG Smart Tv 60"', N'TV OLED LG', 3, N'lg60Kbl.jpg')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [CategoriaId], [Imagen]) VALUES (10, N'Kalley TV 55"', N'Smart Tv Kalley de 55"', 3, N'smarttvkalley.jpg')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [CategoriaId], [Imagen]) VALUES (11, N'Acer Gamer Laptop i5', N'Laptop de Acer Gamer i5 de 512 GB ssD y 12 GB de Ram', 2, N'https://www.alkosto.com/medias/750Wx750H-master-hotfolder-transfer-incoming-deposit-hybris-interfaces-IN-media-product-4711121120718-001.jpg?context=bWFzdGVyfGltYWdlc3wzODkzMzd8aW1hZ2UvanBlZ3xoMjQvaGVjLzEzNTI5NjU4NjU0NzUwLzc1MFd4NzUwSF9tYXN0ZXIvaG90Zm9sZGVyL3RyYW5zZmVyL2luY29taW5nL2RlcG9zaXQvaHlicmlzLWludGVyZmFjZXMvSU4vbWVkaWEvcHJvZHVjdC80NzExMTIxMTIwNzE4XzAwMS5qcGd8YjU3MDA2ZGMzNjM1MjFmN2Y1YjRmMWY2ZmNmOWE5MDZiNzVjY2YyZGNhOTIzZmE0Zjg2MDQ5MjFkN2NhNGU5NQ')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [CategoriaId], [Imagen]) VALUES (12, N'Dell Laptop 13"', N'Portatil Dell para Oficina', 2, N'Dell.jpg')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [CategoriaId], [Imagen]) VALUES (29, N'msi laptop', N'msi gamer laptop', 2, N'msiLaptop.jpg')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [CategoriaId], [Imagen]) VALUES (33, N'HP Pavilion', N'Laptop Gamer HP', 2, N'hppavilion.jpg')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [CategoriaId], [Imagen]) VALUES (47, N'Palm LifeDrive', N'Palm', 8, N'lifedrive.jpg')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [CategoriaId], [Imagen]) VALUES (48, N'Airpods 12 Gen', N'Airpods by Apple', 10, N'https://www.alkosto.com/medias/190199098435-001-750Wx750H?context=bWFzdGVyfGltYWdlc3w2NzQ3M3xpbWFnZS9qcGVnfGltYWdlcy9oZjgvaDU3LzkxMjU0MTY1OTk1ODIuanBnfDc0MWJhMjUzNGM4OTU1ZjFiNDA1ZmViZjljMWIxMTJjMzQ4MzUwMzU3ZTI1ZWJkNGM2NGU2Njc2OTgwMjYyMmI')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [CategoriaId], [Imagen]) VALUES (50, N'Prueba 4', N'Prueba 4', 2, N'prueba4.jpg')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [CategoriaId], [Imagen]) VALUES (51, N'Prueba 4', N'Prueba 4', 2, N'prueba4.jpg')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [CategoriaId], [Imagen]) VALUES (52, N'Msi Bravo 15 Laptop', N'Latop de Msi', 2, N'https://teratech.com.co/wp-content/uploads/2022/12/WhatsApp-Image-2022-12-21-at-3.23.25-PM-600x600.jpeg')
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
USE [master]
GO
ALTER DATABASE [CatalogoDB] SET  READ_WRITE 
GO
