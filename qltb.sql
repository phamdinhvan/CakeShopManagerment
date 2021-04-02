use master
go
if DB_ID('QLTB') is not null
	drop database QLTB;
go
CREATE DATABASE QLTB
GO
USE [QLTB]
GO
--create table User
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USER_](
	[Username] [varchar](10) NOT NULL,
	[Password] [varchar](20) NULL,
CONSTRAINT [PK_USER_] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)ON [PRIMARY]
)ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[USER_] ([Username],[Password]) VALUES (N'manager', N'123');
--create table categories
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CATEGORIES](
	[CategoriesID] [char](4) NOT NULL,
	[Name] [nvarchar](100) NULL,
CONSTRAINT [PK_CATEGORIES] PRIMARY KEY CLUSTERED 
(
	[CategoriesID] ASC
)ON [PRIMARY]
)ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[CATEGORIES] ([CategoriesID],[Name]) VALUES (N'BM', N'Bánh mì');
INSERT [dbo].[CATEGORIES] ([CategoriesID],[Name]) VALUES (N'BN', N'Bánh ngọt');
INSERT [dbo].[CATEGORIES] ([CategoriesID],[Name]) VALUES (N'BKN', N'Bánh kem nhỏ');
INSERT [dbo].[CATEGORIES] ([CategoriesID],[Name]) VALUES (N'BK', N'Bánh kem');

--create table products
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PRODUCTS](
	[ProID] [char](4) NOT NULL,
	[CategoriesID] [char](4) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Price] [money] NULL,
CONSTRAINT [PK_PRODUCTS] PRIMARY KEY CLUSTERED 
(
	[ProID] ASC
)ON [PRIMARY]
)ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[PRODUCTS] ([ProID],[CategoriesID],[Name],[Price]) VALUES (N'BM01',N'BM', N'Bánh mì Salad',1000.0000);
INSERT [dbo].[PRODUCTS] ([ProID],[CategoriesID],[Name],[Price]) VALUES (N'BM02',N'BM', N'Bánh mì Châu Âu',1200.0000);
INSERT [dbo].[PRODUCTS] ([ProID],[CategoriesID],[Name],[Price]) VALUES (N'BM03',N'BM', N'Bánh mì sốt nắm',1300.0000);
INSERT [dbo].[PRODUCTS] ([ProID],[CategoriesID],[Name],[Price]) VALUES (N'BN01',N'BN', N'Đan Mạch Hạnh Nhân',1500.0000);
INSERT [dbo].[PRODUCTS] ([ProID],[CategoriesID],[Name],[Price]) VALUES (N'BN02',N'BN', N'Đậu Xanh Blueberry',2000.0000);
INSERT [dbo].[PRODUCTS] ([ProID],[CategoriesID],[Name],[Price]) VALUES (N'BN03',N'BN', N'Su Kem',1200.0000);
INSERT [dbo].[PRODUCTS] ([ProID],[CategoriesID],[Name],[Price]) VALUES (N'BKN1',N'BKN', N'Orange Vani',2000.0000);
INSERT [dbo].[PRODUCTS] ([ProID],[CategoriesID],[Name],[Price]) VALUES (N'BKN2',N'BKN', N'Strawberry Dome',2000.0000);
INSERT [dbo].[PRODUCTS] ([ProID],[CategoriesID],[Name],[Price]) VALUES (N'BKN3',N'BKN', N'Marble Cheesecake',2300.0000);
INSERT [dbo].[PRODUCTS] ([ProID],[CategoriesID],[Name],[Price]) VALUES (N'BK01',N'BK', N'Bánh kem sữa tươi hình khuôn mặt dễ thương',8000.0000);
INSERT [dbo].[PRODUCTS] ([ProID],[CategoriesID],[Name],[Price]) VALUES (N'BK02',N'BK', N'Bánh kem socola trang trí với mức, socola và trái cây',10000.0000);
INSERT [dbo].[PRODUCTS] ([ProID],[CategoriesID],[Name],[Price]) VALUES (N'BK03',N'BK', N'Bánh kem đặc biệt',8000.0000);

--create table order 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ORDER_](
	[OrderID] [char](4) NOT NULL,
	[Total_Amount] [money] NULL,
CONSTRAINT [PK_ORDER] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)ON [PRIMARY]
)ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ORDER_] ([OrderID],[Total_Amount]) VALUES (N'001',0);
INSERT [dbo].[ORDER_] ([OrderID],[Total_Amount]) VALUES (N'002',0);
INSERT [dbo].[ORDER_] ([OrderID],[Total_Amount]) VALUES (N'003',0);
--create table orderdetail
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ORDER_DETAIL](
	[ID] [char](4) NOT NULL,
	[ProductID] [char](4) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Amount] [int] NULL,
	[Price] [money] NULL,
CONSTRAINT [PK_ORDER_DETAIL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[ProductID] ASC
)ON [PRIMARY]
)ON [PRIMARY]
GO
DROP TRIGGER  trg_ORDER
GO
CREATE TRIGGER trg_ORDER ON ORDER_DETAIL AFTER INSERT, UPDATE AS 
BEGIN
	UPDATE ORDER_
	SET Total_Amount = (t.Amount*t.Price)
	FROM inserted AS t
	WHERE t.ID= ORDER_.OrderID
END
GO
INSERT [dbo].[ORDER_DETAIL] ([ID],[ProductID],[Name],[Price],[Amount]) VALUES (N'001',N'BM01',N'Bánh mì Salad',1000.0000,5);
INSERT [dbo].[ORDER_DETAIL] ([ID],[ProductID],[Name],[Price],[Amount]) VALUES (N'002',N'BKN2',N'Strawberry Dome',2000.0000,3);
INSERT [dbo].[ORDER_DETAIL] ([ID],[ProductID],[Name],[Price],[Amount]) VALUES (N'003',N'BK03',N'Bánh kem đặc biệt',8000.0000,2);



select * from CATEGORIES;
select * from PRODUCTS;
select * from ORDER_;
select * from ORDER_DETAIL;
select * from USER_;

