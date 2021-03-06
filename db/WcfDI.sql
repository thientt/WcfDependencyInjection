USE [WcfDependecyInjection]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 5/15/2017 8:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Contents] [nvarchar](max) NOT NULL,
	[Author] [nvarchar](50) NOT NULL,
	[URL] [nvarchar](200) NOT NULL,
	[BlogID] [int] NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Blog]    Script Date: 5/15/2017 8:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Url] [nvarchar](200) NOT NULL,
	[Owner] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Article] ([ID], [Title], [Contents], [Author], [URL], [BlogID]) VALUES (1, N'WCF Dependency Injection', N'Dependency injection is a software design pattern that implements..', N'Christos Sakellarios', N'https://chsakell.com/2015/07/03/dependency-injection-in-wcf/', 1)
INSERT [dbo].[Blog] ([Id], [Name], [Url], [Owner]) VALUES (1, N'chsakells blog', N'http://chsakell.com', N'Chris Sakellarios')
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_Article_Blog] FOREIGN KEY([BlogID])
REFERENCES [dbo].[Blog] ([Id])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_Article_Blog]
GO
