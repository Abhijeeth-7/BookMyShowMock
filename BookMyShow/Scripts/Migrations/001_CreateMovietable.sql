/****** Object:  Table [dbo].[Movie]    Script Date: 6/23/2021 9:15:07 PM ******/
DROP TABLE [dbo].[Movie]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movie](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[Genre] [int] NULL,
	[Duration] [time](7) NULL
) ON [PRIMARY]
GO

