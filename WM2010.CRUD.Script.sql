USE [WM2010]
GO
/****** Object:  Table [dbo].[FussballWM]    Script Date: 06/08/2010 19:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FussballWM](
	[FussballWMId] [int] IDENTITY(1,1) NOT NULL,
	[Land] [varchar](50) NULL,
	[SpielJahr] [datetime] NULL,
 CONSTRAINT [PK__FussballWM__00551192] PRIMARY KEY CLUSTERED 
(
	[FussballWMId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mannschaft]    Script Date: 06/08/2010 19:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mannschaft](
	[MannschaftId] [int] IDENTITY(1,1) NOT NULL,
	[Land] [nvarchar](255) NOT NULL,
	[Fahne] [varbinary](max) NULL,
	[Tore] [int] NULL,
	[GegenTore] [int] NULL,
	[Punkte] [int] NULL,
	[GruppeID] [int] NOT NULL,
 CONSTRAINT [PK__Mannschaft__7E6CC920] PRIMARY KEY CLUSTERED 
(
	[MannschaftId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SpielOrt]    Script Date: 06/08/2010 19:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SpielOrt](
	[SpielOrtId] [int] IDENTITY(1,1) NOT NULL,
	[Ort] [nvarchar](255) NOT NULL,
	[StadionName] [nvarchar](255) NOT NULL,
	[StadionBild] [varbinary](max) NULL,
 CONSTRAINT [PK__SpielOrt__023D5A04] PRIMARY KEY CLUSTERED 
(
	[SpielOrtId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SpielPosition]    Script Date: 06/08/2010 19:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpielPosition](
	[SpielPositionId] [int] IDENTITY(1,1) NOT NULL,
	[Position] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK__SpielPosition__060DEAE8] PRIMARY KEY CLUSTERED 
(
	[SpielPositionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gruppe]    Script Date: 06/08/2010 19:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gruppe](
	[GruppeId] [int] IDENTITY(1,1) NOT NULL,
	[Gruppe] [nchar](1) NOT NULL,
 CONSTRAINT [PK_Gruppe] PRIMARY KEY CLUSTERED 
(
	[GruppeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Spieler]    Script Date: 06/08/2010 19:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spieler](
	[SpielerId] [int] IDENTITY(1,1) NOT NULL,
	[MannschaftId] [int] NOT NULL,
	[SpielPositionId] [int] NOT NULL,
	[Vorname] [nvarchar](255) NOT NULL,
	[Nachname] [nvarchar](255) NOT NULL,
	[SpielerNummer] [int] NOT NULL,
 CONSTRAINT [PK__Spieler__0425A276] PRIMARY KEY CLUSTERED 
(
	[SpielerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Spiel]    Script Date: 06/08/2010 19:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spiel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SpielOrtId] [int] NOT NULL,
	[DatumUhrzeit] [datetime] NULL,
	[Mannschaft1Id] [int] NULL,
	[Mannschaft2Id] [int] NULL,
	[ToreMannschaft1] [int] NULL,
	[ToreMannschaft2] [int] NULL,
	[ToreMannschaft1Halbzeit] [int] NULL,
	[ToreMannschaft2Halbzeit] [int] NULL,
	[IsVerlaengerung] [bit] NULL,
	[IsElfMeter] [bit] NULL,
 CONSTRAINT [PK__Spiel__7C8480AE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Spiel_SpielOrt]    Script Date: 06/08/2010 19:19:27 ******/
ALTER TABLE [dbo].[Spiel]  WITH CHECK ADD  CONSTRAINT [FK_Spiel_SpielOrt] FOREIGN KEY([SpielOrtId])
REFERENCES [dbo].[SpielOrt] ([SpielOrtId])
GO
ALTER TABLE [dbo].[Spiel] CHECK CONSTRAINT [FK_Spiel_SpielOrt]
GO
/****** Object:  ForeignKey [FK_Spieler_Mannschaft]    Script Date: 06/08/2010 19:19:27 ******/
ALTER TABLE [dbo].[Spieler]  WITH CHECK ADD  CONSTRAINT [FK_Spieler_Mannschaft] FOREIGN KEY([MannschaftId])
REFERENCES [dbo].[Mannschaft] ([MannschaftId])
GO
ALTER TABLE [dbo].[Spieler] CHECK CONSTRAINT [FK_Spieler_Mannschaft]
GO
/****** Object:  ForeignKey [FK_Spieler_SpielPosition]    Script Date: 06/08/2010 19:19:27 ******/
ALTER TABLE [dbo].[Spieler]  WITH CHECK ADD  CONSTRAINT [FK_Spieler_SpielPosition] FOREIGN KEY([SpielPositionId])
REFERENCES [dbo].[SpielPosition] ([SpielPositionId])
GO
ALTER TABLE [dbo].[Spieler] CHECK CONSTRAINT [FK_Spieler_SpielPosition]
GO
