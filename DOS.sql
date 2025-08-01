USE [master]
GO
/****** Object:  Database [DrinkOrderDB]    Script Date: 6/25/2025 5:46:30 PM ******/
CREATE DATABASE [DrinkOrderDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DrinkOrderDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DrinkOrderDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DrinkOrderDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DrinkOrderDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DrinkOrderDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DrinkOrderDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DrinkOrderDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DrinkOrderDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DrinkOrderDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DrinkOrderDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DrinkOrderDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET RECOVERY FULL 
GO
ALTER DATABASE [DrinkOrderDB] SET  MULTI_USER 
GO
ALTER DATABASE [DrinkOrderDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DrinkOrderDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DrinkOrderDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DrinkOrderDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DrinkOrderDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DrinkOrderDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DrinkOrderDB', N'ON'
GO
ALTER DATABASE [DrinkOrderDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [DrinkOrderDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DrinkOrderDB]
GO
/****** Object:  Table [dbo].[AdminActions]    Script Date: 6/25/2025 5:46:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminActions](
	[ActionID] [int] IDENTITY(1,1) NOT NULL,
	[AdminID] [int] NOT NULL,
	[ActionType] [nvarchar](50) NOT NULL,
	[ActionDetail] [nvarchar](255) NULL,
	[ActionTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ActionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartItems]    Script Date: 6/25/2025 5:46:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItems](
	[CartItemID] [int] IDENTITY(1,1) NOT NULL,
	[CartID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[AddedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CartItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 6/25/2025 5:46:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[CartID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6/25/2025 5:46:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 6/25/2025 5:46:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[OrderItemID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 6/25/2025 5:46:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[OrderStatus] [nvarchar](20) NULL,
	[OrderDate] [datetime] NULL,
	[TotalAmount] [decimal](10, 2) NULL,
	[PaymentStatus] [nvarchar](20) NULL,
	[CancelReason] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 6/25/2025 5:46:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[PaidAmount] [decimal](10, 2) NOT NULL,
	[PaymentMethod] [nvarchar](50) NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentStatus] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 6/25/2025 5:46:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Stock] [int] NULL,
	[CategoryID] [int] NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/25/2025 5:46:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[Role] [nvarchar](20) NOT NULL,
	[IsBanned] [bit] NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CartItems] ON 

INSERT [dbo].[CartItems] ([CartItemID], [CartID], [ProductID], [Quantity], [AddedAt]) VALUES (1, 1, 1, 2, CAST(N'2025-06-25T17:42:11.600' AS DateTime))
INSERT [dbo].[CartItems] ([CartItemID], [CartID], [ProductID], [Quantity], [AddedAt]) VALUES (2, 1, 3, 1, CAST(N'2025-06-25T17:42:11.600' AS DateTime))
INSERT [dbo].[CartItems] ([CartItemID], [CartID], [ProductID], [Quantity], [AddedAt]) VALUES (3, 2, 2, 1, CAST(N'2025-06-25T17:42:11.600' AS DateTime))
SET IDENTITY_INSERT [dbo].[CartItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Carts] ON 

INSERT [dbo].[Carts] ([CartID], [UserID], [CreatedAt]) VALUES (1, 1, CAST(N'2025-06-25T17:42:06.127' AS DateTime))
INSERT [dbo].[Carts] ([CartID], [UserID], [CreatedAt]) VALUES (2, 2, CAST(N'2025-06-25T17:42:06.127' AS DateTime))
SET IDENTITY_INSERT [dbo].[Carts] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description]) VALUES (1, N'Trà sữa', N'Các loại trà sữa đặc biệt')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description]) VALUES (2, N'Cà phê', N'Cà phê truyền thống và hiện đại')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description]) VALUES (3, N'Nước ép', N'Nước ép trái cây tươi')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderItems] ON 

INSERT [dbo].[OrderItems] ([OrderItemID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (1, 1, 1, 2, CAST(25000.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderItems] ([OrderItemID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (2, 1, 3, 1, CAST(20000.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderItems] ([OrderItemID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (3, 2, 2, 1, CAST(30000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[OrderItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderDate], [TotalAmount], [PaymentStatus], [CancelReason]) VALUES (1, 1, N'completed', CAST(N'2025-06-25T17:42:19.120' AS DateTime), CAST(70000.00 AS Decimal(10, 2)), N'paid', NULL)
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderDate], [TotalAmount], [PaymentStatus], [CancelReason]) VALUES (2, 2, N'pending', CAST(N'2025-06-25T17:42:19.120' AS DateTime), CAST(30000.00 AS Decimal(10, 2)), N'unpaid', NULL)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([PaymentID], [OrderID], [PaidAmount], [PaymentMethod], [PaymentDate], [PaymentStatus]) VALUES (1, 1, CAST(70000.00 AS Decimal(10, 2)), N'Momo', CAST(N'2025-06-25T17:42:28.007' AS DateTime), N'success')
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [PaidAmount], [PaymentMethod], [PaymentDate], [PaymentStatus]) VALUES (2, 2, CAST(0.00 AS Decimal(10, 2)), NULL, NULL, N'pending')
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [ProductName], [Description], [Price], [Stock], [CategoryID], [CreatedAt]) VALUES (1, N'Trà sữa truyền thống', N'Trà sữa vị truyền thống', CAST(25000.00 AS Decimal(10, 2)), 50, 1, CAST(N'2025-06-25T17:42:01.253' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Description], [Price], [Stock], [CategoryID], [CreatedAt]) VALUES (2, N'Trà sữa trân châu', N'Trà sữa kèm trân châu', CAST(30000.00 AS Decimal(10, 2)), 40, 1, CAST(N'2025-06-25T17:42:01.253' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Description], [Price], [Stock], [CategoryID], [CreatedAt]) VALUES (3, N'Cà phê sữa đá', N'Cà phê pha sữa đá', CAST(20000.00 AS Decimal(10, 2)), 60, 2, CAST(N'2025-06-25T17:42:01.253' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Description], [Price], [Stock], [CategoryID], [CreatedAt]) VALUES (4, N'Nước ép cam', N'Nước cam vắt nguyên chất', CAST(35000.00 AS Decimal(10, 2)), 30, 3, CAST(N'2025-06-25T17:42:01.253' AS DateTime))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Username], [PasswordHash], [FullName], [Email], [Phone], [Role], [IsBanned], [CreatedAt]) VALUES (1, N'user1', N'hashed_password1', N'Nguyễn Văn A', N'user1@email.com', N'0911111111', N'customer', 0, CAST(N'2025-06-25T17:41:47.787' AS DateTime))
INSERT [dbo].[Users] ([UserID], [Username], [PasswordHash], [FullName], [Email], [Phone], [Role], [IsBanned], [CreatedAt]) VALUES (2, N'user2', N'hashed_password2', N'Lê Thị B', N'user2@email.com', N'0922222222', N'customer', 0, CAST(N'2025-06-25T17:41:47.787' AS DateTime))
INSERT [dbo].[Users] ([UserID], [Username], [PasswordHash], [FullName], [Email], [Phone], [Role], [IsBanned], [CreatedAt]) VALUES (3, N'admin', N'hashed_admin', N'Admin User', N'admin@email.com', N'0933333333', N'admin', 0, CAST(N'2025-06-25T17:41:47.787' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [UQ__Carts__1788CCADEFE5A2BC]    Script Date: 6/25/2025 5:46:31 PM ******/
ALTER TABLE [dbo].[Carts] ADD UNIQUE NONCLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__536C85E48A205224]    Script Date: 6/25/2025 5:46:31 PM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D105346E94E9EC]    Script Date: 6/25/2025 5:46:31 PM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AdminActions] ADD  DEFAULT (getdate()) FOR [ActionTime]
GO
ALTER TABLE [dbo].[CartItems] ADD  DEFAULT (getdate()) FOR [AddedAt]
GO
ALTER TABLE [dbo].[Carts] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('pending') FOR [OrderStatus]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('unpaid') FOR [PaymentStatus]
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT (getdate()) FOR [PaymentDate]
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT ('pending') FOR [PaymentStatus]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [Stock]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [IsBanned]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[AdminActions]  WITH CHECK ADD FOREIGN KEY([AdminID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([CartID])
REFERENCES [dbo].[Carts] ([CartID])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
USE [master]
GO
ALTER DATABASE [DrinkOrderDB] SET  READ_WRITE 
GO
