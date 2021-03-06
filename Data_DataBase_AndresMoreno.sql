USE [SegurosAndresMorenoDB]
GO
SET IDENTITY_INSERT [dbo].[TipoCubrimiento] ON 

INSERT [dbo].[TipoCubrimiento] ([Id], [Nombre]) VALUES (1, N'Terremoto')
INSERT [dbo].[TipoCubrimiento] ([Id], [Nombre]) VALUES (2, N'Incendio')
INSERT [dbo].[TipoCubrimiento] ([Id], [Nombre]) VALUES (3, N'Robo')
INSERT [dbo].[TipoCubrimiento] ([Id], [Nombre]) VALUES (4, N'Perdida')
INSERT [dbo].[TipoCubrimiento] ([Id], [Nombre]) VALUES (5, N'Desastre Natural')
SET IDENTITY_INSERT [dbo].[TipoCubrimiento] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoDocumento] ON 

INSERT [dbo].[TipoDocumento] ([Id], [Nombre]) VALUES (1, N'Cedula')
INSERT [dbo].[TipoDocumento] ([Id], [Nombre]) VALUES (2, N'NIT')
INSERT [dbo].[TipoDocumento] ([Id], [Nombre]) VALUES (3, N'Cedula Extranjeria')
SET IDENTITY_INSERT [dbo].[TipoDocumento] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoRiesgo] ON 

INSERT [dbo].[TipoRiesgo] ([Id], [Nombre]) VALUES (1, N'Bajo')
INSERT [dbo].[TipoRiesgo] ([Id], [Nombre]) VALUES (2, N'Medio')
INSERT [dbo].[TipoRiesgo] ([Id], [Nombre]) VALUES (3, N'Medio-Alto')
INSERT [dbo].[TipoRiesgo] ([Id], [Nombre]) VALUES (4, N'Alto')
SET IDENTITY_INSERT [dbo].[TipoRiesgo] OFF
GO
