USE [Motel]
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 2021/5/25 下午 12:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomType](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Area] [float] NOT NULL,
	[BedQuantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[HPrice] [int] NOT NULL,
	[AirCondition] [bit] NOT NULL,
	[TV] [bit] NOT NULL,
	[SysDate] [datetime] NOT NULL,
 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[RoomType] ([Id], [Name], [Area], [BedQuantity], [Price], [HPrice], [AirCondition], [TV], [SysDate]) VALUES (N'7c2906b8-82c1-475a-bbb7-15f2f51eb491', N'東方卡莫', 6, 2, 950, 1280, 1, 1, CAST(N'2021-04-25T16:31:51.843' AS DateTime))
INSERT [dbo].[RoomType] ([Id], [Name], [Area], [BedQuantity], [Price], [HPrice], [AirCondition], [TV], [SysDate]) VALUES (N'897d9b0b-bd8a-4344-96e3-176df2a2c1b3', N'經濟房', 5, 1, 650, 780, 1, 1, CAST(N'2021-04-25T16:31:51.837' AS DateTime))
INSERT [dbo].[RoomType] ([Id], [Name], [Area], [BedQuantity], [Price], [HPrice], [AirCondition], [TV], [SysDate]) VALUES (N'99ef3560-7f86-4324-ab06-35efa8f34066', N'浪漫滿屋', 6, 2, 850, 1080, 1, 1, CAST(N'2021-04-25T16:31:51.840' AS DateTime))
INSERT [dbo].[RoomType] ([Id], [Name], [Area], [BedQuantity], [Price], [HPrice], [AirCondition], [TV], [SysDate]) VALUES (N'1bdf700a-41c0-4e80-a539-372f65e3adc7', N'秘密花園', 8, 2, 1000, 1380, 1, 1, CAST(N'2021-04-25T16:31:51.843' AS DateTime))
INSERT [dbo].[RoomType] ([Id], [Name], [Area], [BedQuantity], [Price], [HPrice], [AirCondition], [TV], [SysDate]) VALUES (N'ce26a140-e12f-4add-bfcb-952995ef0740', N'水雲澗', 6, 2, 950, 1280, 1, 1, CAST(N'2021-04-25T16:31:51.843' AS DateTime))
INSERT [dbo].[RoomType] ([Id], [Name], [Area], [BedQuantity], [Price], [HPrice], [AirCondition], [TV], [SysDate]) VALUES (N'671f6ecc-19ec-4685-8d8a-9b02b8c29054', N'典雅雙人房', 6, 2, 950, 1280, 1, 1, CAST(N'2021-04-25T16:31:51.843' AS DateTime))
INSERT [dbo].[RoomType] ([Id], [Name], [Area], [BedQuantity], [Price], [HPrice], [AirCondition], [TV], [SysDate]) VALUES (N'87b6c163-b07f-4745-af94-e94470d6791e', N'精緻雙人房', 5, 2, 750, 980, 1, 1, CAST(N'2021-04-25T16:31:51.840' AS DateTime))
GO
ALTER TABLE [dbo].[RoomType] ADD  CONSTRAINT [DF_RoomType_Id]  DEFAULT (newid()) FOR [Id]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'類型名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoomType', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'房間面積' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoomType', @level2type=N'COLUMN',@level2name=N'Area'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配備床數' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoomType', @level2type=N'COLUMN',@level2name=N'BedQuantity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平日價' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoomType', @level2type=N'COLUMN',@level2name=N'Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'假日價' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoomType', @level2type=N'COLUMN',@level2name=N'HPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否有空調' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoomType', @level2type=N'COLUMN',@level2name=N'AirCondition'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否有電視' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoomType', @level2type=N'COLUMN',@level2name=N'TV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系統日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoomType', @level2type=N'COLUMN',@level2name=N'SysDate'
GO
