USE [Motel]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 2021/5/25 下午 12:41:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[RoomNumber] [varchar](10) NOT NULL,
	[RoomTypeId] [uniqueidentifier] NOT NULL,
	[Describe] [nvarchar](50) NULL,
	[Position] [nvarchar](50) NULL,
	[SysDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'425b3607-30de-4e4b-86e9-012c51134a45', N'1005', N'7c2906b8-82c1-475a-bbb7-15f2f51eb491', N'', N'', CAST(N'2021-04-25T22:28:17.393' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'11d0d9d7-3e9d-4c40-b90a-033cd2864963', N'0803', N'87b6c163-b07f-4745-af94-e94470d6791e', NULL, NULL, CAST(N'2021-04-25T22:28:17.390' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'7cd5e587-ee88-41da-9b04-056cecf5bc11', N'0811', N'87b6c163-b07f-4745-af94-e94470d6791e', NULL, NULL, CAST(N'2021-04-25T22:28:17.390' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'15755313-10d6-42ca-9677-081e86261405', N'0801', N'897d9b0b-bd8a-4344-96e3-176df2a2c1b3', NULL, NULL, CAST(N'2021-04-25T22:28:17.390' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'92447bb4-4686-4c2a-9679-0a3a7e5c32e8', N'1008', N'99ef3560-7f86-4324-ab06-35efa8f34066', NULL, NULL, CAST(N'2021-04-25T22:28:17.393' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'85951ddf-ca09-4adc-a67c-11b86d81eb94', N'0908', N'99ef3560-7f86-4324-ab06-35efa8f34066', NULL, NULL, CAST(N'2021-04-25T22:28:17.393' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'56b1f68a-7254-48bf-952c-1209400c8b49', N'0707', N'87b6c163-b07f-4745-af94-e94470d6791e', NULL, NULL, CAST(N'2021-04-25T22:28:17.387' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'cbd4e094-a1fe-4aa9-ad14-17d8b0b84370', N'0902', N'99ef3560-7f86-4324-ab06-35efa8f34066', NULL, NULL, CAST(N'2021-04-25T22:28:17.390' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'e93ddd52-bb63-4db7-a720-202c7a9191db', N'1006', N'99ef3560-7f86-4324-ab06-35efa8f34066', NULL, NULL, CAST(N'2021-04-25T22:28:17.393' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'e26ae2b6-605f-4eaa-aff2-24e64539d0da', N'0703', N'87b6c163-b07f-4745-af94-e94470d6791e', NULL, NULL, CAST(N'2021-04-25T22:28:17.387' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'e633e8be-6761-48eb-8c48-26c68e1d0fce', N'0702', N'99ef3560-7f86-4324-ab06-35efa8f34066', NULL, NULL, CAST(N'2021-04-25T22:28:17.387' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'cc27dc98-fd3b-4c74-82d8-27be3bc756f4', N'1003', N'87b6c163-b07f-4745-af94-e94470d6791e', NULL, NULL, CAST(N'2021-04-25T22:28:17.393' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'5df0a988-a760-4751-8826-3149be5747b3', N'0710', N'1bdf700a-41c0-4e80-a539-372f65e3adc7', NULL, NULL, CAST(N'2021-04-25T22:28:17.387' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'b9b52024-e278-4727-8845-3a864c1fd0b7', N'0806', N'ce26a140-e12f-4add-bfcb-952995ef0740', NULL, NULL, CAST(N'2021-04-25T22:28:17.390' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'2a424a8e-9587-4f58-92a8-42f5d1809821', N'1007', N'87b6c163-b07f-4745-af94-e94470d6791e', NULL, NULL, CAST(N'2021-04-25T22:28:17.393' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'22bb72b2-9817-4b3e-830b-4969c788ac04', N'0907', N'87b6c163-b07f-4745-af94-e94470d6791e', NULL, NULL, CAST(N'2021-04-25T22:28:17.393' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'64eaddd1-2f9c-449b-8fd8-4c675499fec9', N'0905', N'7c2906b8-82c1-475a-bbb7-15f2f51eb491', NULL, NULL, CAST(N'2021-04-25T22:28:17.393' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'dbce3cd8-0758-4c2b-8b7f-4d71692e1e6d', N'0701', N'897d9b0b-bd8a-4344-96e3-176df2a2c1b3', NULL, NULL, CAST(N'2021-04-25T22:28:17.380' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'6860c8a4-6032-4e29-ac3d-5b01bdc69db7', N'0708', N'99ef3560-7f86-4324-ab06-35efa8f34066', NULL, NULL, CAST(N'2021-04-25T22:28:17.387' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'6afdf7b7-d0c7-4b8f-9f7f-6e7fce5b4c0b', N'1001', N'99ef3560-7f86-4324-ab06-35efa8f34066', N'', N'', CAST(N'2021-04-25T22:28:17.393' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'bdf6483b-423d-4662-bfcd-751cf5d8c79d', N'0910', N'1bdf700a-41c0-4e80-a539-372f65e3adc7', NULL, NULL, CAST(N'2021-04-25T22:28:17.393' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'5860f449-f62d-4737-bc6c-83b982e4e5e6', N'0709', N'87b6c163-b07f-4745-af94-e94470d6791e', NULL, NULL, CAST(N'2021-04-25T22:28:17.387' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'c693619d-5647-4d9f-874b-8c9dedb1b5cc', N'0705', N'87b6c163-b07f-4745-af94-e94470d6791e', NULL, NULL, CAST(N'2021-04-25T22:28:17.387' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'8bc064b5-83bc-4517-a073-8e3cdfc00d0d', N'0802', N'99ef3560-7f86-4324-ab06-35efa8f34066', NULL, NULL, CAST(N'2021-04-25T22:28:17.390' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'f177ebc4-8497-4474-a744-981d57f516b4', N'0909', N'87b6c163-b07f-4745-af94-e94470d6791e', NULL, NULL, CAST(N'2021-04-25T22:28:17.393' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'eed4f658-8d1f-4614-952f-992b41320131', N'0711', N'87b6c163-b07f-4745-af94-e94470d6791e', NULL, NULL, CAST(N'2021-04-25T22:28:17.390' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'df0a3af7-454a-49a1-a75e-a7703fc46799', N'0809', N'87b6c163-b07f-4745-af94-e94470d6791e', NULL, NULL, CAST(N'2021-04-25T22:28:17.390' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'1c5ebe50-292a-4d9a-9bb0-aca51aa1abb9', N'1002', N'99ef3560-7f86-4324-ab06-35efa8f34066', N'', N'', CAST(N'2021-04-25T22:28:17.393' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'c0fa3ef9-cbb7-437c-a716-c32e03fa363d', N'1009', N'87b6c163-b07f-4745-af94-e94470d6791e', N'', N'', CAST(N'2021-04-25T22:28:17.393' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'6f2c081b-3f4a-450d-a80b-ce6899a53585', N'0901', N'99ef3560-7f86-4324-ab06-35efa8f34066', NULL, NULL, CAST(N'2021-04-25T22:28:17.390' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'63b211d4-6fa1-4382-9e4c-e05e2d6a79fc', N'0805', N'87b6c163-b07f-4745-af94-e94470d6791e', NULL, NULL, CAST(N'2021-04-25T22:28:17.390' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'9efedad0-d5da-433e-843b-e0b79e000668', N'0706', N'671f6ecc-19ec-4685-8d8a-9b02b8c29054', NULL, NULL, CAST(N'2021-04-25T22:28:17.387' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'cbf08d61-c410-471f-8773-e9dfc69ca3fc', N'0808', N'99ef3560-7f86-4324-ab06-35efa8f34066', NULL, NULL, CAST(N'2021-04-25T22:28:17.390' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'f2982717-f5d0-4200-8a36-f1dd5fff958d', N'0906', N'99ef3560-7f86-4324-ab06-35efa8f34066', N'', N'', CAST(N'2021-04-25T22:28:17.393' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'a2a32c5b-7e7d-49b0-bab3-f30aed49c66c', N'0807', N'87b6c163-b07f-4745-af94-e94470d6791e', NULL, NULL, CAST(N'2021-04-25T22:28:17.390' AS DateTime))
INSERT [dbo].[Room] ([Id], [RoomNumber], [RoomTypeId], [Describe], [Position], [SysDate]) VALUES (N'8fce236f-bc8d-4637-b1ed-fecb0cb7cfae', N'0903', N'87b6c163-b07f-4745-af94-e94470d6791e', NULL, NULL, CAST(N'2021-04-25T22:28:17.393' AS DateTime))
GO
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [DF_GuestRoom_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomType] FOREIGN KEY([RoomTypeId])
REFERENCES [dbo].[RoomType] ([Id])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_RoomType]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'房間號碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Room', @level2type=N'COLUMN',@level2name=N'RoomNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'指定房屋類別' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Room', @level2type=N'COLUMN',@level2name=N'RoomTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'房間位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Room', @level2type=N'COLUMN',@level2name=N'Describe'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'房間描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Room', @level2type=N'COLUMN',@level2name=N'Position'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系統日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Room', @level2type=N'COLUMN',@level2name=N'SysDate'
GO
