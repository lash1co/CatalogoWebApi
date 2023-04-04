USE [CatalogoDB]
GO
/****** Object:  User [catalog]    Script Date: 3/04/2023 2:21:46 p. m. ******/
CREATE USER [catalog] FOR LOGIN [catalog] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [catalog]
GO
ALTER ROLE [db_datareader] ADD MEMBER [catalog]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [catalog]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 3/04/2023 2:21:47 p. m. ******/
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
/****** Object:  Table [dbo].[Producto]    Script Date: 3/04/2023 2:21:47 p. m. ******/
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
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
