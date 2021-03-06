USE [db_ecommerce_project]
GO
/****** Object:  Table [dbo].[tbl_categoria]    Script Date: 14/08/2020 1:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_categoria](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[descripcion] [varchar](100) NULL,
	[estado] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_negocio]    Script Date: 14/08/2020 1:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_negocio](
	[idNegocio] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NULL,
	[nombreNegocio] [varchar](150) NULL,
	[descripcion] [text] NULL,
	[imagen] [varchar](200) NULL,
	[fechaRegistro] [datetime] NULL,
	[estado] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[idNegocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_persona]    Script Date: 14/08/2020 1:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_persona](
	[idPersona] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[apellido] [varchar](100) NULL,
	[sexo] [tinyint] NULL,
	[telefono] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_producto]    Script Date: 14/08/2020 1:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_producto](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[idNegocio] [int] NULL,
	[idCategoria] [int] NULL,
	[nombre] [varchar](100) NULL,
	[descripcion] [varchar](200) NULL,
	[precio] [decimal](12, 3) NULL,
	[fechaRegistro] [datetime] NULL,
	[estado] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_usuario]    Script Date: 14/08/2020 1:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[idTipoUsuario] [int] NULL,
	[email] [varchar](100) NULL,
	[password] [varchar](100) NULL,
	[estado] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_categoria] ON 

INSERT [dbo].[tbl_categoria] ([idCategoria], [nombre], [descripcion], [estado]) VALUES (1, N'Electrodomestico', N'Electrodomestico Desc', 1)
INSERT [dbo].[tbl_categoria] ([idCategoria], [nombre], [descripcion], [estado]) VALUES (2, N'dqw', N'dqwdqw', 1)
SET IDENTITY_INSERT [dbo].[tbl_categoria] OFF
SET IDENTITY_INSERT [dbo].[tbl_usuario] ON 

INSERT [dbo].[tbl_usuario] ([idUsuario], [idTipoUsuario], [email], [password], [estado]) VALUES (1, 1, N'demo@gmail.com', N'123123', 1)
SET IDENTITY_INSERT [dbo].[tbl_usuario] OFF
