USE [Hbsis_Teste]
GO

/****** Object:  Table [dbo].[Cliente]    Script Date: 26/07/2017 08:09:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Cliente](
	[Codigo] [int] NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Documento] [varchar](14) NOT NULL,
	[Telefone] [varchar](11) NOT NULL,
	[Excluido] [bit] NOT NULL,
	[IsCpf] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


