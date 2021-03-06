USE [Motel]
GO
/****** Object:  Table [dbo].[RoomState]    Script Date: 2021/5/25 下午 12:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomState](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[StateType] [int] NOT NULL,
 CONSTRAINT [PK_RoomState] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'425b3607-30de-4e4b-86e9-012c51134a45', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'11d0d9d7-3e9d-4c40-b90a-033cd2864963', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'7cd5e587-ee88-41da-9b04-056cecf5bc11', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'15755313-10d6-42ca-9677-081e86261405', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'92447bb4-4686-4c2a-9679-0a3a7e5c32e8', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'85951ddf-ca09-4adc-a67c-11b86d81eb94', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'56b1f68a-7254-48bf-952c-1209400c8b49', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'cbd4e094-a1fe-4aa9-ad14-17d8b0b84370', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'e93ddd52-bb63-4db7-a720-202c7a9191db', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'e26ae2b6-605f-4eaa-aff2-24e64539d0da', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'e633e8be-6761-48eb-8c48-26c68e1d0fce', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'cc27dc98-fd3b-4c74-82d8-27be3bc756f4', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'5df0a988-a760-4751-8826-3149be5747b3', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'b9b52024-e278-4727-8845-3a864c1fd0b7', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'2a424a8e-9587-4f58-92a8-42f5d1809821', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'22bb72b2-9817-4b3e-830b-4969c788ac04', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'64eaddd1-2f9c-449b-8fd8-4c675499fec9', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'dbce3cd8-0758-4c2b-8b7f-4d71692e1e6d', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'6860c8a4-6032-4e29-ac3d-5b01bdc69db7', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'6afdf7b7-d0c7-4b8f-9f7f-6e7fce5b4c0b', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'bdf6483b-423d-4662-bfcd-751cf5d8c79d', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'5860f449-f62d-4737-bc6c-83b982e4e5e6', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'c693619d-5647-4d9f-874b-8c9dedb1b5cc', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'8bc064b5-83bc-4517-a073-8e3cdfc00d0d', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'f177ebc4-8497-4474-a744-981d57f516b4', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'eed4f658-8d1f-4614-952f-992b41320131', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'df0a3af7-454a-49a1-a75e-a7703fc46799', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'1c5ebe50-292a-4d9a-9bb0-aca51aa1abb9', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'c0fa3ef9-cbb7-437c-a716-c32e03fa363d', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'6f2c081b-3f4a-450d-a80b-ce6899a53585', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'63b211d4-6fa1-4382-9e4c-e05e2d6a79fc', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'9efedad0-d5da-433e-843b-e0b79e000668', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'cbf08d61-c410-471f-8773-e9dfc69ca3fc', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'f2982717-f5d0-4200-8a36-f1dd5fff958d', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'a2a32c5b-7e7d-49b0-bab3-f30aed49c66c', 0)
INSERT [dbo].[RoomState] ([Id], [StateType]) VALUES (N'8fce236f-bc8d-4637-b1ed-fecb0cb7cfae', 0)
GO
ALTER TABLE [dbo].[RoomState]  WITH CHECK ADD  CONSTRAINT [FK_RoomState_Room] FOREIGN KEY([Id])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[RoomState] CHECK CONSTRAINT [FK_RoomState_Room]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'房間狀態' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoomState', @level2type=N'COLUMN',@level2name=N'StateType'
GO
