USE [Motel]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2021/5/25 下午 12:38:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[IdentityNum] [varchar](10) NOT NULL,
	[Gender] [int] NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
	[Address] [nvarchar](256) NULL,
	[Tel] [varchar](20) NOT NULL,
	[SysDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'60acd28b-1902-44a0-8575-0e500a67f67f', N'J155222957', 0, N'鄭宗霖', N'新竹縣芎林鄉福昌街82巷4號7樓', N'09-60787067', CAST(N'2021-04-22T22:49:45.423' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'bf29a224-8ca3-49f1-a92f-0f5e840a83c6', N'E166724404', 0, N'林孟聖', N'高雄市前鎮區漁港中二路125巷18號', N'09-60472022', CAST(N'2021-04-22T22:49:45.420' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'a69fb103-cbf9-496d-b336-15e11f991df4', N'F115297048', 0, N'葉政勳', N'新北市三重區安和路93號', N'09-20722837', CAST(N'2021-04-22T22:49:45.420' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'eef140b3-9137-49bf-822a-199f91f1bc45', N'L212879339', 1, N'韓雅惠', N'台中市清水區高美路87號', N'09-54462545', CAST(N'2021-04-22T22:49:45.423' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'04453cb0-4bb5-4449-84cd-216cca0966f9', N'H148503884', 0, N'張佳博', N'桃園市平鎮區洪圳路69巷7號7樓', N'09-30367352', CAST(N'2021-04-22T22:49:45.427' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'03025488-dbd5-4d6f-ace7-3fba9334d5c9', N'M229721689', 1, N'王郁苓', N'南投縣草屯鎮富林路一段280號', N'09-60688227', CAST(N'2021-04-22T22:49:45.423' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'3f018f83-542c-4b4a-8cd8-53a5b8200848', N'W174192967', 0, N'謝冠儒', N'金門縣金城鎮金山路170巷27號5樓', N'09-14948672', CAST(N'2021-04-22T22:49:45.423' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'0f28f036-aeaa-46f4-a347-5da369fe2682', N'D272416254', 1, N'郭惠珍', N'台南市北區公園南路23巷4號7樓', N'09-89242572', CAST(N'2021-04-22T22:49:45.427' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'bf5be814-e021-48a5-89fa-734088fe5ba2', N'L202291565', 1, N'陳佳慧', N'台中市西屯區漢翔路190號', N'09-54928277', CAST(N'2021-04-22T22:49:45.420' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'ea55dba1-0289-47d4-a7c8-7e7af789996a', N'A290228848', 1, N'吳雅萍', N'台北市大安區建國南路一段62巷17號', N'09-68961405', CAST(N'2021-04-22T22:49:45.420' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'b9464cf6-7792-4a57-8d82-a0dc12cea03d', N'L297441160', 1, N'劉育芸', N'台中市南區五權南一路113號', N'09-82412616', CAST(N'2021-04-22T22:49:45.420' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'c1262ad2-f1dc-41e6-9007-b2c49b6c8943', N'A242762759', 1, N'施羽如', N'台北市北投區西安街二段52巷8號', N'09-54070471', CAST(N'2021-04-22T22:49:45.423' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'70ceba4d-5375-4ee3-bb4b-b705748c6cc1', N'F265675665', 1, N'溫馨儀', N'新北市三重區重新路五段90巷12號', N'09-26272896', CAST(N'2021-04-22T22:49:45.427' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'93b27cb0-793d-41e7-98c5-b8fc845bb5da', N'P187665668', 0, N'王翠陽', N'雲林縣斗六市西平路118巷19號', N'09-12594372', CAST(N'2021-04-22T22:49:45.427' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'0cdd4a24-dae7-4a15-b4ca-bc6bf94f4d2c', N'L197441588', 0, N'陳杰英', N'台中市南區美村路二段45巷9號2樓', N'09-61632141', CAST(N'2021-04-22T22:49:45.420' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'f2f6d1ad-166b-4faa-af2e-c24ae68dd8e4', N'L167942581', 0, N'陳承恩', N'台中市沙鹿區興安路126號', N'09-25018799', CAST(N'2021-04-22T22:49:45.427' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'c8833d6a-df76-4923-9d29-d41a82e87f54', N'A192068679', 0, N'張勝傑', N'台北市北投區中央南路二段3巷28號', N'09-36763630', CAST(N'2021-04-22T22:49:45.420' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'1e0363cf-59eb-40a9-aa8e-e394307f9764', N'N255746573', 1, N'陳雯婷', N'彰化縣芳苑鄉斗苑路三合段59號', N'09-63426774', CAST(N'2021-04-22T22:49:45.420' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'9d472644-86f0-4cf3-a0ce-eec829c181cc', N'A126735876', 0, N'陳馥南', N'台北市信義區忠孝東路五段241號', N'09-63607954', CAST(N'2021-04-22T22:49:45.420' AS DateTime))
INSERT [dbo].[Customer] ([Id], [IdentityNum], [Gender], [Name], [Address], [Tel], [SysDate]) VALUES (N'28e6698e-ca7e-4054-9aa7-f9536fec6af1', N'G272297896', 1, N'李欣海', N'宜蘭縣羅東鎮純精路一段89巷2號', N'09-26729905', CAST(N'2021-04-22T22:49:45.427' AS DateTime))
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_Id]  DEFAULT (newid()) FOR [Id]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份證字號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'IdentityNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性別' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客戶姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客戶住址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客戶電話' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'Tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系統日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'SysDate'
GO
