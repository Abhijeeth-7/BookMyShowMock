/****** Object:  Table [dbo].[Theater]    Script Date: 6/23/2021 9:16:37 PM ******/
DROP TABLE [dbo].[Theater]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Theater](
	[Id] [int] NOT NULL,
	[TheaterName] [nvarchar](50) NULL,
	[TotalSeats] [int] NULL,
	[price] [int] NULL
) ON [PRIMARY]
GO

