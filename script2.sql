USE [LibraryDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14/4/2025 20:58:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shoes]    Script Date: 14/4/2025 20:58:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Model] [nvarchar](300) NOT NULL,
	[Release] [date] NOT NULL,
	[Size] [int] NOT NULL,
	[SportHouseId] [int] NOT NULL,
 CONSTRAINT [PK_Shoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SportHouses]    Script Date: 14/4/2025 20:58:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SportHouses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Addres] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SportHouses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250409144056_InitialCatalog', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250409145251_ModifyingOpensTable', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250409152107_SetSportHouseTableIndex', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250409154414_PopulateSportHousesTable', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250411144153_ShoesTable', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250411152502_ShoesTable', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250411183116_ModifyShoesTable', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250411183618_PopulateShoes', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250411185007_AnotherPopulationShoesTable', N'9.0.4')
GO
SET IDENTITY_INSERT [dbo].[Shoes] ON 

INSERT [dbo].[Shoes] ([Id], [Model], [Release], [Size], [SportHouseId]) VALUES (6, N'Reebok Classic Leather', CAST(N'2006-10-30' AS Date), 44, 1)
INSERT [dbo].[Shoes] ([Id], [Model], [Release], [Size], [SportHouseId]) VALUES (7, N'Converse Chuck Taylor All Star', CAST(N'1970-10-10' AS Date), 42, 1)
INSERT [dbo].[Shoes] ([Id], [Model], [Release], [Size], [SportHouseId]) VALUES (8, N'Nike Air Force', CAST(N'1982-01-01' AS Date), 44, 1)
INSERT [dbo].[Shoes] ([Id], [Model], [Release], [Size], [SportHouseId]) VALUES (9, N'Adidas Superstar', CAST(N'1969-01-01' AS Date), 32, 2)
INSERT [dbo].[Shoes] ([Id], [Model], [Release], [Size], [SportHouseId]) VALUES (10, N'Jordan 1 Retro High OG', CAST(N'1985-01-01' AS Date), 48, 3)
INSERT [dbo].[Shoes] ([Id], [Model], [Release], [Size], [SportHouseId]) VALUES (11, N'New Balance 550', CAST(N'1989-01-01' AS Date), 40, 4)
INSERT [dbo].[Shoes] ([Id], [Model], [Release], [Size], [SportHouseId]) VALUES (12, N'Puma Suede Classic XXI', CAST(N'1968-01-01' AS Date), 36, 5)
SET IDENTITY_INSERT [dbo].[Shoes] OFF
GO
SET IDENTITY_INSERT [dbo].[SportHouses] ON 

INSERT [dbo].[SportHouses] ([Id], [Name], [Addres]) VALUES (3, N'All-Star Athletics', N'Bradbury')
INSERT [dbo].[SportHouses] ([Id], [Name], [Addres]) VALUES (4, N'Champion''s Outfitters', N'Dick')
INSERT [dbo].[SportHouses] ([Id], [Name], [Addres]) VALUES (5, N'Game On Sports', N'Le Guin')
INSERT [dbo].[SportHouses] ([Id], [Name], [Addres]) VALUES (2, N'hhhhhhhhhhh', N'HHHHHHHHHH')
INSERT [dbo].[SportHouses] ([Id], [Name], [Addres]) VALUES (1, N'Iron Will Sports', N'Asimov')
INSERT [dbo].[SportHouses] ([Id], [Name], [Addres]) VALUES (7, N'Open Sport', N'Bs As')
SET IDENTITY_INSERT [dbo].[SportHouses] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Shoes_Model_SportHousesId]    Script Date: 14/4/2025 20:58:52 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Shoes_Model_SportHousesId] ON [dbo].[Shoes]
(
	[Model] ASC,
	[SportHouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Shoes_SportHouseId]    Script Date: 14/4/2025 20:58:52 ******/
CREATE NONCLUSTERED INDEX [IX_Shoes_SportHouseId] ON [dbo].[Shoes]
(
	[SportHouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SportHouses_Name_Addres]    Script Date: 14/4/2025 20:58:52 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_SportHouses_Name_Addres] ON [dbo].[SportHouses]
(
	[Name] ASC,
	[Addres] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Shoes]  WITH CHECK ADD  CONSTRAINT [FK_Shoes_SportHouses_SportHouseId] FOREIGN KEY([SportHouseId])
REFERENCES [dbo].[SportHouses] ([Id])
GO
ALTER TABLE [dbo].[Shoes] CHECK CONSTRAINT [FK_Shoes_SportHouses_SportHouseId]
GO
