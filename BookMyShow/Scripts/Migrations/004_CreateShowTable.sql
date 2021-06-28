/****** Object:  Table [dbo].[Show]    Script Date: 6/23/2021 9:16:18 PM ******/
DROP TABLE [dbo].[Show]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Show](
	[Id] [int] NOT NULL,
	[TheaterId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[SeatingId] [int] NULL
) ON [PRIMARY]
GO

