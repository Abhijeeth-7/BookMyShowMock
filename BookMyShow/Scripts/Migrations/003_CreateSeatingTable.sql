/****** Object:  Table [dbo].[Seating]    Script Date: 6/23/2021 9:16:04 PM ******/
DROP TABLE [dbo].[Seating]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Seating](
	[Id] [int] NOT NULL,
	[ShowId] [int] NOT NULL,
	[TheaterId] [int] NOT NULL,
	[SeatingData] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

