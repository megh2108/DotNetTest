USE [TestDB]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoles]') AND type in (N'U'))
ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT IF EXISTS [CK__UserRoles__Role__37A5467C]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskStatusHistory]') AND type in (N'U'))
ALTER TABLE [dbo].[TaskStatusHistory] DROP CONSTRAINT IF EXISTS [CK__TaskStatu__NewSt__5070F446]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT IF EXISTS [CK__Tasks__Status__44FF419A]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT IF EXISTS [CK__Tasks__Priority__440B1D61]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT IF EXISTS [FK__Users__UserRoleI__3B75D760]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskStatusHistory]') AND type in (N'U'))
ALTER TABLE [dbo].[TaskStatusHistory] DROP CONSTRAINT IF EXISTS [FK__TaskStatu__TaskI__4F7CD00D]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskStatusHistory]') AND type in (N'U'))
ALTER TABLE [dbo].[TaskStatusHistory] DROP CONSTRAINT IF EXISTS [FK__TaskStatu__Chang__52593CB8]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT IF EXISTS [FK__Tasks__ProjectId__4316F928]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT IF EXISTS [FK__Tasks__CreatedBy__47DBAE45]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT IF EXISTS [FK__Tasks__AssignedT__45F365D3]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskComments]') AND type in (N'U'))
ALTER TABLE [dbo].[TaskComments] DROP CONSTRAINT IF EXISTS [FK__TaskComme__UserI__4BAC3F29]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskComments]') AND type in (N'U'))
ALTER TABLE [dbo].[TaskComments] DROP CONSTRAINT IF EXISTS [FK__TaskComme__TaskI__4AB81AF0]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Projects]') AND type in (N'U'))
ALTER TABLE [dbo].[Projects] DROP CONSTRAINT IF EXISTS [FK__Projects__Create__403A8C7D]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ErrorLogs]') AND type in (N'U'))
ALTER TABLE [dbo].[ErrorLogs] DROP CONSTRAINT IF EXISTS [FK__ErrorLogs__UserI__5629CD9C]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT IF EXISTS [DF__Users__CreatedAt__3C69FB99]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskStatusHistory]') AND type in (N'U'))
ALTER TABLE [dbo].[TaskStatusHistory] DROP CONSTRAINT IF EXISTS [DF__TaskStatu__Chang__5165187F]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT IF EXISTS [DF__Tasks__CreatedAt__46E78A0C]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskComments]') AND type in (N'U'))
ALTER TABLE [dbo].[TaskComments] DROP CONSTRAINT IF EXISTS [DF__TaskComme__Creat__4CA06362]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Projects]') AND type in (N'U'))
ALTER TABLE [dbo].[Projects] DROP CONSTRAINT IF EXISTS [DF__Projects__Create__3F466844]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ErrorLogs]') AND type in (N'U'))
ALTER TABLE [dbo].[ErrorLogs] DROP CONSTRAINT IF EXISTS [DF__ErrorLogs__Logge__5535A963]
GO
/****** Object:  Index [UQ__Users__A9D10534B41ACB97]    Script Date: 11/5/2024 10:31:04 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT IF EXISTS [UQ__Users__A9D10534B41ACB97]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/5/2024 10:31:04 AM ******/
DROP TABLE IF EXISTS [dbo].[Users]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 11/5/2024 10:31:04 AM ******/
DROP TABLE IF EXISTS [dbo].[UserRoles]
GO
/****** Object:  Table [dbo].[TaskStatusHistory]    Script Date: 11/5/2024 10:31:04 AM ******/
DROP TABLE IF EXISTS [dbo].[TaskStatusHistory]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 11/5/2024 10:31:04 AM ******/
DROP TABLE IF EXISTS [dbo].[Tasks]
GO
/****** Object:  Table [dbo].[TaskComments]    Script Date: 11/5/2024 10:31:04 AM ******/
DROP TABLE IF EXISTS [dbo].[TaskComments]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 11/5/2024 10:31:04 AM ******/
DROP TABLE IF EXISTS [dbo].[Projects]
GO
/****** Object:  Table [dbo].[ErrorLogs]    Script Date: 11/5/2024 10:31:04 AM ******/
DROP TABLE IF EXISTS [dbo].[ErrorLogs]
GO
/****** Object:  Table [dbo].[ErrorLogs]    Script Date: 11/5/2024 10:31:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLogs](
	[ErrorId] [int] IDENTITY(1,1) NOT NULL,
	[ErrorMessage] [nvarchar](1000) NULL,
	[StackTrace] [nvarchar](max) NULL,
	[LoggedAt] [datetime] NULL,
	[UserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ErrorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 11/5/2024 10:31:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Deadline] [datetime] NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskComments]    Script Date: 11/5/2024 10:31:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskComments](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[TaskId] [int] NULL,
	[UserId] [int] NULL,
	[CommentText] [nvarchar](500) NOT NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 11/5/2024 10:31:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Priority] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[DueDate] [datetime] NULL,
	[AssignedTo] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskStatusHistory]    Script Date: 11/5/2024 10:31:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskStatusHistory](
	[StatusHistoryId] [int] IDENTITY(1,1) NOT NULL,
	[TaskId] [int] NULL,
	[OldStatus] [nvarchar](50) NULL,
	[NewStatus] [nvarchar](50) NOT NULL,
	[ChangedAt] [datetime] NULL,
	[ChangedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 11/5/2024 10:31:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/5/2024 10:31:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[UserRoleId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK__Users__1788CC4C5F2DB390] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Projects] ON 
GO
INSERT [dbo].[Projects] ([ProjectId], [ProjectName], [Description], [Deadline], [CreatedAt], [CreatedBy]) VALUES (1, N'Website Redesign', N'Redesigning the company website.', CAST(N'2024-12-15T00:00:00.000' AS DateTime), CAST(N'2024-10-01T09:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Projects] ([ProjectId], [ProjectName], [Description], [Deadline], [CreatedAt], [CreatedBy]) VALUES (2, N'Mobile App Dev', N'Development of mobile application.', CAST(N'2025-03-20T00:00:00.000' AS DateTime), CAST(N'2024-10-05T14:00:00.000' AS DateTime), 2)
GO
INSERT [dbo].[Projects] ([ProjectId], [ProjectName], [Description], [Deadline], [CreatedAt], [CreatedBy]) VALUES (3, N'Marketing Strategy', N'Create a marketing plan for Q1.', CAST(N'2024-11-30T00:00:00.000' AS DateTime), CAST(N'2024-10-07T10:30:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Projects] OFF
GO
SET IDENTITY_INSERT [dbo].[Tasks] ON 
GO
INSERT [dbo].[Tasks] ([TaskId], [ProjectId], [Title], [Description], [Priority], [Status], [DueDate], [AssignedTo], [CreatedAt], [CreatedBy]) VALUES (1, 1, N'Wireframe Homepage', N'Create initial wireframe for homepage.', N'High', N'To Do', CAST(N'2024-10-30T00:00:00.000' AS DateTime), 3, CAST(N'2024-10-30T10:09:30.283' AS DateTime), 1)
GO
INSERT [dbo].[Tasks] ([TaskId], [ProjectId], [Title], [Description], [Priority], [Status], [DueDate], [AssignedTo], [CreatedAt], [CreatedBy]) VALUES (2, 2, N'Task 1', N'Description 1', N'Medium', N'In Progress', CAST(N'2024-11-08T00:00:00.000' AS DateTime), 5, CAST(N'2024-11-05T09:11:19.490' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Tasks] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [Role]) VALUES (1, N'Admin')
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [Role]) VALUES (2, N'Manager')
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [Role]) VALUES (3, N'Employee')
GO
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [UserRoleId], [CreatedAt]) VALUES (1, N'meghshah', 0x998E1285FC6251140290BE44261B35F2113CB66E6BFEA4EBDB6352BF8344E636E1C5F73044EFCFEE78BF4E30FD0D118CD71EB2CCBC7BD76F556B340022B934FC1D68A4F99B21C82D0D464F82ADD8ABB9BD9560AFA24E692BB65262F7281B2852A517525CEEC7CC56D326CC151CAACA0637F0EA3D32DB063794E6D79CD0D96BF1, 0x2F1A592DC39C84C3631A3E501B1D27760B225881188F95370B47D30DA823A403D5D2D836D60CB58717B8D95B24FEADAECEAF89A2C67F2114643F7851C9BCD7B9, N'meghshah@gmail.com', 1, CAST(N'2024-10-28T17:05:09.330' AS DateTime))
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [UserRoleId], [CreatedAt]) VALUES (2, N'dhruvishah', 0x207972A9ABA7B78949061A6A536FD300616ADDF9FAAB4C9F8276C9A83082E5CE56CC509D4D844399A2962991D9FD1BBC50FE35AE14719F85EA9A02FAF43B2CF417AF0A76B88F4A7D905EAAD2822C3B4D840BD846DE55FA32ED878924B569F22DD71DEE4E39799231F70673575769B5CF41E467B1714A869CFCEB61E37E901A58, 0x1585F57C1C4234B490F380E79EA2186D79B3A4EDDDF42FBE0B809391AEE7B5F4CD2751C79C6278F7ABD8334E48D32007C8ACD719B6617E66B79FC6284BFC0B4E, N'dhruvishah@gmail.com', 1, CAST(N'2024-10-30T10:02:35.093' AS DateTime))
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [UserRoleId], [CreatedAt]) VALUES (3, N'tilak', 0xC1CBA2702D829EF97EA7665F3445F7C0F679009E48090ADB5B7599D7E322A9E031163B96031BC091585F841C8DF115D897ABBCFC1897F638D3C96E21A9019D22F4C9783D9CC6153294415CFBCFC765D9442E9B7499A3F699BD16831113BAA37710B1003A7E344EF5ECA2E260BA08149CB92F60693C627EFAD838335A7E9F9D2D, 0x6F23476D7B3D947613535AA85D9ECA0B3F6E6E642012A88FD0AFC3524874479906DB110994C8BB46EF68BD4069922E25F70E23C793E558094D907F9F3FF0A080, N'tilak@gmail.com', 3, CAST(N'2024-10-30T10:08:27.747' AS DateTime))
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [UserRoleId], [CreatedAt]) VALUES (4, N'shrey', 0xC92DEA4B9B89E2A71B72383835E12666640301EB8F8755AD43FEE862D9DB05E95510B90E3BCD84D2FDA261CBA24E942FA9FF02FA105A34E627FE82FDE124CC23BAF5F5EEF2AC4C9F91075F09D214979B7982F3AE9DD03E5E1D5789DB0754AB651307A3E6359386F0F3768DAD99CC8199F7185B8959AF042812E2440EADF798FF, 0xBD09D13003EAF16C939D606E27F6FF317617350D16805951BBCA8CC347C7E4D8AD3F82CD7F4E5C74249BB8BC242012124499634EAE915355EF1E6544AA5AE821, N'shrey@gmail.com', 3, CAST(N'2024-10-31T10:56:07.553' AS DateTime))
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [UserRoleId], [CreatedAt]) VALUES (5, N'pooja', 0xC680DB7AF3EFFB82ADA00D946B8C53EC8535DC3807BFCFAA3267F0CB87B68615FE9284D04C97BCB2A5CF95A67849E427990BC135B0380B62A4EA7ED81ADEEE0A776667E448B3F7B9B089F5830ADBD578E50E903FDD957BB7416785B5AB0BB5FBCE4FB854A24F7B17ECAA902A546266DAB067968F9AFC703D1EAF139859704BB0, 0x2AF9D0CDAFB1B4B11732A11ED162D2517FD7D26707D052D80AF9388A5E1D1A6348B2B9345D39035031EBDD89F7A05BBFCC7CEA3CEAC683911A9583DD46E27BA4, N'pooja@gmail.com', 3, CAST(N'2024-10-31T10:57:22.430' AS DateTime))
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [UserRoleId], [CreatedAt]) VALUES (7, N'admin', 0x8FC6A9660BCF52E43AEF0ED33B06EE52212FD1BB2316E541CC34FB08BA27ACAF0C7EA9907355C4EF17CC78098EA38E3FD421A8C22BB6BD0CCFCE42436C25BEA7F0CD98C8647644359AEBA0F5F74C632E0FEF0378C25AE43E5150240BD5EBF22EB3BBC661CE8AE630369381939F34CB46D3BD69538D5A08C02DA67CC5E5334F77, 0xD94E27D132FBD4B1F2DFE7D93497D9C9A15BBC697CD70559B568E71CF5F776513E79A0F7839EBA597F83D4D2979FAEF25CFE09D08BC9DAAFC22599D0989AEE8F, N'admin@gmail.com', 1, CAST(N'2024-11-05T10:24:09.617' AS DateTime))
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [UserRoleId], [CreatedAt]) VALUES (8, N'manager', 0xC285A077B0DDDB36C1605FB83383ADB7E4ABAC448E804D2F21C909D03EB722ABA6A7B535B19FBA0EE29E97E0F967550212E82CF9EE315567FE33E3E26834904F6D5310B5B5C7FD2557D645A5FC1905E7417C72E0ED9140C8FC67426C6C148CE3A6133C6387D4D6F8444346B3F956B5208B016D9AAC67490A117FE1516D0652EE, 0x3EFE1A0472C6421F0AB8E25BB270F9AB9E330AB7640A7391C1D89AA72A3744BC4A5538F595D5B64F219ECDB0969078D8C554F1EA8A1E7864BF171E073D4D44C7, N'manager@gmail.com', 2, CAST(N'2024-11-05T10:24:48.187' AS DateTime))
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [UserRoleId], [CreatedAt]) VALUES (9, N'employee', 0x23A9FC01EBB3BAA89F2B2C4346FB4BF0DED9F297892B1E2D3D6852C928E70F2D1B89412F011E4FEA8DF55449E01D398F4D3D3EDDA053E32B8F3A368C4A3D7DE0C47FC8331FA8E19D3943D842F506D1F0FC384E1A873F5115FDFD2C06EE345956D5E1E723ACA4D93047135ABFACECF805E90F51F0E23A78AC1DC541C60A93B2F2, 0x046E3D1E6821CA3DD861EDC819B51BCC2781BE08F69524ECD2F031F2D41C3164196B59F0643430EA4A650C841EE7A06BFB26EEF53CD0570642B872DA16330245, N'employee@gmail.com', 3, CAST(N'2024-11-05T10:25:21.273' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D10534B41ACB97]    Script Date: 11/5/2024 10:31:04 AM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__A9D10534B41ACB97] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ErrorLogs] ADD  DEFAULT (getdate()) FOR [LoggedAt]
GO
ALTER TABLE [dbo].[Projects] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[TaskComments] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Tasks] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[TaskStatusHistory] ADD  DEFAULT (getdate()) FOR [ChangedAt]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__CreatedAt__3C69FB99]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ErrorLogs]  WITH CHECK ADD  CONSTRAINT [FK__ErrorLogs__UserI__5629CD9C] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[ErrorLogs] CHECK CONSTRAINT [FK__ErrorLogs__UserI__5629CD9C]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK__Projects__Create__403A8C7D] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK__Projects__Create__403A8C7D]
GO
ALTER TABLE [dbo].[TaskComments]  WITH CHECK ADD FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([TaskId])
GO
ALTER TABLE [dbo].[TaskComments]  WITH CHECK ADD  CONSTRAINT [FK__TaskComme__UserI__4BAC3F29] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[TaskComments] CHECK CONSTRAINT [FK__TaskComme__UserI__4BAC3F29]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK__Tasks__AssignedT__45F365D3] FOREIGN KEY([AssignedTo])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK__Tasks__AssignedT__45F365D3]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK__Tasks__CreatedBy__47DBAE45] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK__Tasks__CreatedBy__47DBAE45]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ProjectId])
GO
ALTER TABLE [dbo].[TaskStatusHistory]  WITH CHECK ADD  CONSTRAINT [FK__TaskStatu__Chang__52593CB8] FOREIGN KEY([ChangedBy])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[TaskStatusHistory] CHECK CONSTRAINT [FK__TaskStatu__Chang__52593CB8]
GO
ALTER TABLE [dbo].[TaskStatusHistory]  WITH CHECK ADD FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([TaskId])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK__Users__UserRoleI__3B75D760] FOREIGN KEY([UserRoleId])
REFERENCES [dbo].[UserRoles] ([UserRoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK__Users__UserRoleI__3B75D760]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD CHECK  (([Priority]='High' OR [Priority]='Medium' OR [Priority]='Low'))
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD CHECK  (([Status]='Completed' OR [Status]='In Progress' OR [Status]='To Do'))
GO
ALTER TABLE [dbo].[TaskStatusHistory]  WITH CHECK ADD CHECK  (([NewStatus]='Completed' OR [NewStatus]='In Progress' OR [NewStatus]='To Do'))
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD CHECK  (([Role]='Employee' OR [Role]='Manager' OR [Role]='Admin'))
GO
