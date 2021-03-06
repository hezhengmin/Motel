USE [Motel]
GO
/****** Object:  Table [dbo].[OccupiedRoom]    Script Date: 2021/5/25 下午 12:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OccupiedRoom](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[RoomId] [uniqueidentifier] NOT NULL,
	[CheckInDate] [datetime] NULL,
	[CheckOutDate] [datetime] NULL,
	[Pay] [int] NULL,
	[SysDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Occupy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[OccupiedRoom] ([Id], [CustomerId], [RoomId], [CheckInDate], [CheckOutDate], [Pay], [SysDate]) VALUES (N'19e30561-a18c-4696-a773-335e6dd8bfdb', N'0f28f036-aeaa-46f4-a347-5da369fe2682', N'5df0a988-a760-4751-8826-3149be5747b3', CAST(N'2021-05-22T22:42:00.000' AS DateTime), CAST(N'2021-05-24T02:46:00.000' AS DateTime), 3760, CAST(N'2021-05-18T23:42:32.653' AS DateTime))
INSERT [dbo].[OccupiedRoom] ([Id], [CustomerId], [RoomId], [CheckInDate], [CheckOutDate], [Pay], [SysDate]) VALUES (N'c89072a7-f716-4d1f-8ebd-71afd1b52079', N'04453cb0-4bb5-4449-84cd-216cca0966f9', N'92447bb4-4686-4c2a-9679-0a3a7e5c32e8', CAST(N'2021-05-24T13:28:00.000' AS DateTime), NULL, NULL, CAST(N'2021-05-22T23:12:45.923' AS DateTime))
INSERT [dbo].[OccupiedRoom] ([Id], [CustomerId], [RoomId], [CheckInDate], [CheckOutDate], [Pay], [SysDate]) VALUES (N'adb71352-6e5c-4cc8-92a2-a97825e5db2f', N'04453cb0-4bb5-4449-84cd-216cca0966f9', N'b9b52024-e278-4727-8845-3a864c1fd0b7', NULL, NULL, NULL, CAST(N'2021-05-24T15:22:10.323' AS DateTime))
INSERT [dbo].[OccupiedRoom] ([Id], [CustomerId], [RoomId], [CheckInDate], [CheckOutDate], [Pay], [SysDate]) VALUES (N'6d428586-5c61-474a-9468-dd716bbae111', N'04453cb0-4bb5-4449-84cd-216cca0966f9', N'5df0a988-a760-4751-8826-3149be5747b3', CAST(N'2021-05-22T22:42:24.000' AS DateTime), NULL, NULL, CAST(N'2021-05-17T22:29:06.457' AS DateTime))
GO
ALTER TABLE [dbo].[OccupiedRoom] ADD  CONSTRAINT [DF_OccupiedRoom_SysDate]  DEFAULT (sysdatetime()) FOR [SysDate]
GO
ALTER TABLE [dbo].[OccupiedRoom]  WITH CHECK ADD  CONSTRAINT [FK_OccupiedRoom_Reservation] FOREIGN KEY([Id])
REFERENCES [dbo].[Reservation] ([Id])
GO
ALTER TABLE [dbo].[OccupiedRoom] CHECK CONSTRAINT [FK_OccupiedRoom_Reservation]
GO
ALTER TABLE [dbo].[OccupiedRoom]  WITH CHECK ADD  CONSTRAINT [FK_OccupiedRoom_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[OccupiedRoom] CHECK CONSTRAINT [FK_OccupiedRoom_Room]
GO
ALTER TABLE [dbo].[OccupiedRoom]  WITH CHECK ADD  CONSTRAINT [FK_Occupy_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[OccupiedRoom] CHECK CONSTRAINT [FK_Occupy_Customer]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'實際入住時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OccupiedRoom', @level2type=N'COLUMN',@level2name=N'CheckInDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'實際退房時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OccupiedRoom', @level2type=N'COLUMN',@level2name=N'CheckOutDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'結算金額' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OccupiedRoom', @level2type=N'COLUMN',@level2name=N'Pay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系統日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OccupiedRoom', @level2type=N'COLUMN',@level2name=N'SysDate'
GO
