USE [Motel]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 2021/5/25 下午 12:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[RoomId] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[BeginDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Days] [int] NOT NULL,
	[Expense] [int] NOT NULL,
	[SysDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Reservation] ([Id], [RoomId], [CustomerId], [BeginDate], [EndDate], [Days], [Expense], [SysDate]) VALUES (N'19e30561-a18c-4696-a773-335e6dd8bfdb', N'5df0a988-a760-4751-8826-3149be5747b3', N'0f28f036-aeaa-46f4-a347-5da369fe2682', CAST(N'2021-05-18T00:00:00.000' AS DateTime), CAST(N'2021-05-18T00:00:00.000' AS DateTime), 1, 1000, CAST(N'2021-05-18T23:42:32.360' AS DateTime))
INSERT [dbo].[Reservation] ([Id], [RoomId], [CustomerId], [BeginDate], [EndDate], [Days], [Expense], [SysDate]) VALUES (N'c89072a7-f716-4d1f-8ebd-71afd1b52079', N'92447bb4-4686-4c2a-9679-0a3a7e5c32e8', N'04453cb0-4bb5-4449-84cd-216cca0966f9', CAST(N'2021-05-22T00:00:00.000' AS DateTime), CAST(N'2021-05-22T00:00:00.000' AS DateTime), 1, 1080, CAST(N'2021-05-22T23:12:45.553' AS DateTime))
INSERT [dbo].[Reservation] ([Id], [RoomId], [CustomerId], [BeginDate], [EndDate], [Days], [Expense], [SysDate]) VALUES (N'adb71352-6e5c-4cc8-92a2-a97825e5db2f', N'b9b52024-e278-4727-8845-3a864c1fd0b7', N'04453cb0-4bb5-4449-84cd-216cca0966f9', CAST(N'2021-05-24T00:00:00.000' AS DateTime), CAST(N'2021-05-24T00:00:00.000' AS DateTime), 1, 950, CAST(N'2021-05-24T15:22:10.173' AS DateTime))
INSERT [dbo].[Reservation] ([Id], [RoomId], [CustomerId], [BeginDate], [EndDate], [Days], [Expense], [SysDate]) VALUES (N'6d428586-5c61-474a-9468-dd716bbae111', N'5df0a988-a760-4751-8826-3149be5747b3', N'04453cb0-4bb5-4449-84cd-216cca0966f9', CAST(N'2021-05-17T00:00:00.000' AS DateTime), CAST(N'2021-05-17T00:00:00.000' AS DateTime), 1, 1000, CAST(N'2021-05-17T22:29:05.273' AS DateTime))
GO
ALTER TABLE [dbo].[Reservation] ADD  CONSTRAINT [DF_Reservation_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Customer]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Room]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Reservation', @level2type=N'COLUMN',@level2name=N'RoomId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'預訂入住日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Reservation', @level2type=N'COLUMN',@level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'預訂退房時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Reservation', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'天數' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Reservation', @level2type=N'COLUMN',@level2name=N'Days'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'住宿費' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Reservation', @level2type=N'COLUMN',@level2name=N'Expense'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系統日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Reservation', @level2type=N'COLUMN',@level2name=N'SysDate'
GO
