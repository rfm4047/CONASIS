USE [Asistencia2025]
GO

/****** Object:  Table [dbo].[TelfPlantel]    Script Date: 19/09/2025 22:29:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TelfPlantel](
	[idtelef] [int] IDENTITY(1,1) NOT NULL,
	[telffijo] [numeric](10, 0) NULL,
	[telfcelular] [numeric](10, 0) NOT NULL,
	[idplantelf] [int] NOT NULL,
 CONSTRAINT [pk_telfplantel] PRIMARY KEY CLUSTERED 
(
	[idtelef] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [u_telfcel] UNIQUE NONCLUSTERED 
(
	[telfcelular] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TelfPlantel]  WITH CHECK ADD  CONSTRAINT [FK_telfplantel_plantel] FOREIGN KEY([idplantelf])
REFERENCES [dbo].[Plantel] ([codplantel])
GO

ALTER TABLE [dbo].[TelfPlantel] CHECK CONSTRAINT [FK_telfplantel_plantel]
GO


