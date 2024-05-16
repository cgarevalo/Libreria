USE [Libreria_DB]
GO
/****** Object:  Table [dbo].[Generos]    Script Date: 16/5/2024 19:49:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Generos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
 CONSTRAINT [PK_Generos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idiomas]    Script Date: 16/5/2024 19:49:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idiomas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
 CONSTRAINT [PK_Idiomas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libros]    Script Date: 16/5/2024 19:49:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libros](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](100) NULL,
	[Autor] [varchar](100) NULL,
	[Editorial] [varchar](100) NULL,
	[FechaPublicacion] [date] NULL,
	[Descripcion] [varchar](300) NULL,
	[NumeroPaginas] [int] NULL,
	[Lsbn] [varchar](300) NULL,
	[IdGenero] [int] NULL,
	[IdIdioma] [int] NULL,
	[Activo] [bit] NULL,
	[ImagenPortada] [varchar](500) NULL,
	[OrigenImagen] [varchar](10) NULL,
 CONSTRAINT [PK_Libros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 16/5/2024 19:49:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NULL,
	[Contraseña] [varchar](100) NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[FechaNacimiento] [date] NULL,
	[Jerarquia] [bit] NULL,
	[ImagenPerfil] [varchar](500) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Libros]  WITH CHECK ADD  CONSTRAINT [FK_Libros_Generos] FOREIGN KEY([IdGenero])
REFERENCES [dbo].[Generos] ([Id])
GO
ALTER TABLE [dbo].[Libros] CHECK CONSTRAINT [FK_Libros_Generos]
GO
ALTER TABLE [dbo].[Libros]  WITH CHECK ADD  CONSTRAINT [FK_Libros_Idiomas] FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idiomas] ([Id])
GO
ALTER TABLE [dbo].[Libros] CHECK CONSTRAINT [FK_Libros_Idiomas]
GO
