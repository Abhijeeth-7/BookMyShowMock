/****** Object:  Table [dbo].[Seat]    Script Date: 6/23/2021 9:15:45 PM ******/
DROP TABLE [dbo].[Seat]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Seat](
	[Id] [int] NOT NULL,
	[IsAvailable] [bit] NULL
) ON [PRIMARY]
GO

