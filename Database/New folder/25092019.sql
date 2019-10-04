USE master
GO

IF EXISTS (
	SELECT name 
	FROM sys.databases 
	WHERE name = N'SaleMobileAssistant'
)
DROP DATABASE SaleMobileAssistant
GO

CREATE DATABASE SaleMobileAssistant
GO

USE SaleMobileAssistant
GO
-- 
CREATE TABLE Company(
	CompID nvarchar(8) primary key,
	CompName nvarchar(50),
	Address1 nvarchar(50),
	Address2 nvarchar(50),
	Address3 nvarchar(50),
	City nvarchar(50),
	Province nvarchar(50),
	PhoneNum nvarchar(20)
)

-- 
CREATE TABLE [Site](
	CompID nvarchar(8),
	SiteID nvarchar(8),
	SiteName nvarchar(50),
	Address1 nvarchar(50),
	Address2 nvarchar(50),
	Address3 nvarchar(50),
	City nvarchar(50),
	Province nvarchar(50),
	PhoneNum nvarchar(20),
	Primary Key (CompID, SiteID),
	FOREIGN KEY (CompID) REFERENCES Company (CompID)
)
--
CREATE TABLE EmployeeType(
	CompID nvarchar(8),
	ETypeID nvarchar(20),
	ETypeDescription nvarchar(30),
	Commissionable bit,
	Primary Key(CompID, ETypeID),
	FOREIGN KEY (CompID) REFERENCES Company (CompID)
)
--
CREATE TABLE Employee(
	CompID nvarchar(8),
	ETypeID nvarchar(20),
	EmplID nvarchar(8),
	EmplName nvarchar(30),
	Address1 nvarchar(50),
	Address2 nvarchar(50),
	Address3 nvarchar(50),
	PhoneNum nvarchar(20),
	DateIn date,
	DateOut date,
	PRIMARY KEY (CompID, EmplID),
	FOREIGN KEY (CompID, ETypeID) REFERENCES EmployeeType (CompID, ETypeID)
)
-- 
CREATE TABLE Customer(
	CompID nvarchar(8),
	EmplID nvarchar(8),
	CustID int,
	CustName nvarchar(50),
	Address1 nvarchar(50),
	Address2 nvarchar(50),
	Address3 nvarchar(50),
	City nvarchar(50),
	Country nvarchar(50),
	PhoneNum nvarchar(20),
	Discount decimal,
	PRIMARY KEY (CompID, CustID),
	FOREIGN KEY (CompID, EmplID) REFERENCES Employee (CompID, EmplID)
);
Go
-- 
CREATE TABLE ProductGroup(
	CompID nvarchar(8),
	PGroupID nvarchar(8),
	PGdescription nvarchar(30),
	PRIMARY KEY (CompID, PGroupID),
	FOREIGN KEY (CompID) REFERENCES Company (CompID)
)
-- 
CREATE TABLE Product(
	CompID nvarchar(8),
	PGroupID nvarchar(8),
	ProdID nvarchar(50),
	ProdName nvarchar(1000),
	UnitPrice FLOAT,
	UOM VARCHAR(6),
	DateUpdate date,
	PRIMARY KEY (CompID, ProdID),
	FOREIGN KEY (CompID, PGroupID) REFERENCES ProductGroup (CompID, PGroupID)
)
-- 
CREATE TABLE Account(
	CompID nvarchar(8),
	ID int identity,
	Username VARCHAR(50),
	[Password] VARCHAR(50),
	[Type] bit,
	EmplID nvarchar(8),
	Note nvarchar(100),
	Primary Key(CompID, ID),
	FOREIGN KEY (CompID, EmplID) REFERENCES Employee (CompID, EmplID)
)
--
CREATE TABLE ProductInSite(
	CompID nvarchar(8),
	SiteID nvarchar(8),
	ProdID nvarchar(50),
	Quatity FLOAT,
	UOM VARCHAR(6),--?
	PRIMARY KEY (CompID, SiteID, ProdID),
	FOREIGN KEY (CompID, SiteID) REFERENCES [Site] (CompID, SiteID),
	FOREIGN KEY (CompID, ProdID) REFERENCES Product (CompID, ProdID)
)
--
CREATE TABLE StatusType(
	STypeID int identity primary key,
	STypeName nvarchar(50)
)
-- 
CREATE TABLE Orders(
	CompID nvarchar(8),
	MyOrderID VARCHAR(20), -- id of mine
	OrdeID int, -- epicor increase auto
	CustID int,
	EmplID nvarchar(8),
	OrderDate Date,
	NeedByDate Date,
	RequestDate Date,
	OrderStatus int,
	Primary Key(CompID, MyOrderID),
	FOREIGN KEY (CompID, CustID) REFERENCES Customer (CompID, CustID),
	FOREIGN KEY (CompID, EmplID) REFERENCES Employee (CompID, EmplID),
	FOREIGN KEY (OrderStatus) REFERENCES StatusType (STypeID)
)
-- 
	-- Product lay tu Site ??
CREATE TABLE OrderDetail(
	CompID nvarchar(8),
	SiteID nvarchar(8),
	MyOrderID VARCHAR(20),
	OrderNum int,
	OrderLine int,
	LineType nvarchar(20),
	ProdID nvarchar(50),
	SellingQuantity decimal,
	UnitPrice FLOAT,
	PRIMARY KEY (CompID, SiteID, MyOrderID, ProdID),
	FOREIGN KEY (CompID, SiteID, ProdID) REFERENCES ProductInSite (CompID, SiteID, ProdID),
	FOREIGN KEY (CompID, MyOrderID) REFERENCES Orders (CompID, MyOrderID)
)


--
CREATE TABLE RoutePlan(
	CompID nvarchar(8),
	EmplID nvarchar(8),
	CustID int,
	DatePlan date,
	Prioritize int,
	Visited bit,-- 0 or 1
	Note nvarchar(100),
	PRIMARY KEY (CompID, EmplID, CustID, DatePlan),
	FOREIGN KEY (CompID, CustID) REFERENCES Customer (CompID, CustID),
	FOREIGN KEY (CompID, EmplID) REFERENCES Employee (CompID, EmplID)
)
SELECT * FROM dbo.RoutePlan
UPDATE dbo.RoutePlan SET EmplID = N'TYLER',CustID = 15 ,DatePlan = GETDATE(),CompID =N'EPIC06' WHERE Prioritize = 6
INSERT dbo.RoutePlan
(
    CompID,
    EmplID,
    CustID,
    DatePlan,
    Prioritize,
    Visited,
    Note
)
VALUES
(   N'EPIC06',       -- CompID - nvarchar(8)
    N'LANE',       -- EmplID - nvarchar(8)
    5,         -- CustID - int
    GETDATE(), -- DatePlan - date
    6,         -- Prioritize - int
    1,      -- Visited - bit
    N'lol'        -- Note - nvarchar(100)
    )

--
CREATE TABLE SaleTarget(
	CompID nvarchar(8),
	ID int identity primary key,
	EmplID nvarchar(8),
	PeriodTarget int,
	YearTarget int,
	TargetQty int,
	Note nvarchar(500),
	FOREIGN KEY (CompID, EmplID) REFERENCES Employee (CompID, EmplID)
)
--
CREATE TABLE ConnectionConfig(
	EpicorRestAPIpath nvarchar(200),
	EpicorUser nvarchar(50),
	EpicorPassword nvarchar(50),
	EpicorCompany nvarchar(8)
)

-- INSERT DATA
--company
INSERT INTO [dbo].[Company]
     VALUES('EPIC06', N'Vina Acecook', '180, Ly Chinh Thang street', 'Ward xx', 'District 3', 'Tp.HCM'
           ,'Tp.HCM', '19001560')
GO
--site
INSERT INTO [dbo].[Site]
     VALUES
           ('EPIC06', 'EPIC0601', 'Vina Acecook Chi nhánh Kinh doanh Hà Nội', '60 Hoang Kiem street'
           ,'Ward xx', 'District Dong Da', 'Ha Noi', 'Ha Noi', '19000000')
INSERT INTO [dbo].[Site]
     VALUES
           ('EPIC06', 'EPIC0602', 'Vina Acecook Chi Nhánh Đà Nẵng', '60 Hoang Kiem street'
           ,'Ward Lien Chieu', 'Da Nang city', 'Da Nang', 'Da Nang', '19000000')
GO
INSERT INTO [dbo].[Site]
     VALUES
           ('EPIC06', 'EPIC0603', 'Vina Acecook Hồ Chí Minh', '60 Hoang Kiem street'
           ,'Ward Lien Chieu', 'District Tan Phu', 'Tp.HCM', 'Tp.HCM', '19000000')
GO
--EmployeeType
INSERT INTO [dbo].[EmployeeType] VALUES('EPIC06', 'QTCT', N'Administration group', 1)
INSERT INTO [dbo].[EmployeeType] VALUES('EPIC06', 'QLNV', N'Sales manager', 1)
INSERT INTO [dbo].[EmployeeType] VALUES('EPIC06', 'NVBH', N'Sales', 1)
GO
--employee
INSERT INTO [dbo].[Employee]
     VALUES
           ('EPIC06','QTCT','QT01', N'Wayne Rooney','113 a-way street','Ward a-way'
		   ,'Liverpool city, England','123456789',convert(datetime,'12/03/2011',103), null)
INSERT INTO [dbo].[Employee]
     VALUES
           ('EPIC06','QLNV','QL01', N'Nguyen Quan Ly','113 a-way street','Ward a-way'
		   ,'Can Tho city','123456789',convert(datetime,'12/03/2011',103), null)
INSERT INTO [dbo].[Employee]
     VALUES
           ('EPIC06','QLNV','QL02', N'Ha Quan Ly','114 a-way street','Ward a-way'
		   ,'Da Nang city','123456789',convert(datetime,'12/03/2011',103), null)
INSERT INTO [dbo].[Employee]
     VALUES
           ('EPIC06','NVBH','NV01', N'Nhan Vien Mot','113 a-way street','Ward a-way'
		   ,'Manchester city, England','123456789',convert(datetime,'12/03/2011',103), null)
INSERT INTO [dbo].[Employee]
     VALUES
           ('EPIC06','NVBH','NV02', N'Nhan Vien Hai','113 a-way street','Ward a-way'
		   ,'Ho Chi Minh city','123456789',convert(datetime,'12/03/2011',103), null)
GO
--customer
INSERT INTO [dbo].[Customer]
     VALUES
           ('EPIC06','NV01',11111,'Nguyen Khach Hang Mot','123 Dong Khoi','Ward 2'
           ,'District Phu Nhuan','Ho Chi Minh city','Vietnam','928000000',0.8)
INSERT INTO [dbo].[Customer]
     VALUES
           ('EPIC06','NV01',11112,'Nguyen Khach Hang Hai','123 Dong Khoi','Ward 2'
           ,'District Go Vap','Ho Chi Minh city','Vietnam','928000000',0.6)
INSERT INTO [dbo].[Customer]
     VALUES
           ('EPIC06','NV02',11113,'Ha Khach Hang Mot','123 Dong Khoi','Ward 2'
           ,'District 3','Ho Chi Minh city','Vietnam','928000000',1.8)
INSERT INTO [dbo].[Customer]
     VALUES
           ('EPIC06','NV02',11114,'Ha Khach Hang Hai','123 Dong Khoi','Ward 2'
           ,'District Phu Nhuan','Ho Chi Minh city','Vietnam','928000000',0.8)
INSERT INTO [dbo].[Customer]
     VALUES
           ('EPIC06','NV02',11115,'Ha Khach Hang Ba','123 Dong Khoi','Ward 2'
           ,'District Binh Tan','Ho Chi Minh city','Vietnam','928000000',0.5)

GO
--productGroup
INSERT INTO [dbo].[ProductGroup] VALUES('EPIC06','PGMIGOI',N'Mì gói')
INSERT INTO [dbo].[ProductGroup] VALUES('EPIC06','PGMILYTO',N'Mì ly-tô-khay')
INSERT INTO [dbo].[ProductGroup] VALUES('EPIC06','PGBUNGOI',N'Phở - Hủ tiếu - Bún')
INSERT INTO [dbo].[ProductGroup] VALUES('EPIC06','PGMIEN',N'Miến')
GO
--product
INSERT INTO [dbo].[Product]
	VALUES('EPIC06','PGMIGOI','MIGOI01',N'Mì Hảo Hảo',83500,'Thùng',convert(datetime,'11/09/2019',103))
INSERT INTO [dbo].[Product]
	VALUES('EPIC06','PGMIGOI','MIGOI02',N'Mì Hảo 100',83000,'Thùng',convert(datetime,'11/09/2019',103))
INSERT INTO [dbo].[Product]
	VALUES('EPIC06','PGMIGOI','MIGOI03',N'Mì Lẫu Thái',126500,'Thùng',convert(datetime,'11/09/2019',103))
INSERT INTO [dbo].[Product]
	VALUES('EPIC06','PGMIGOI','MIGOI04',N'Mì Hít Hà',135500,'Thùng',convert(datetime,'11/09/2019',103))
GO

INSERT INTO [dbo].[Product]
	VALUES('EPIC06','PGMIGOI','MILY01',N'Khay Táo Quân',228500,'Thùng',convert(datetime,'11/09/2019',103))
INSERT INTO [dbo].[Product]
	VALUES('EPIC06','PGMIGOI','MILY02',N'Mì ly Handy Hảo Hảo',228500,'Thùng',convert(datetime,'11/09/2019',103))
INSERT INTO [dbo].[Product]
	VALUES('EPIC06','PGMIGOI','MILY03',N'Mì ly Modern',226500,'Thùng',convert(datetime,'11/09/2019',103))
INSERT INTO [dbo].[Product]
	VALUES('EPIC06','PGMIGOI','MILY04',N'Tô Nhớ Mãi Mãi',285500,'Thùng',convert(datetime,'11/09/2019',103))
GO

INSERT INTO [dbo].[Product]
	VALUES('EPIC06','PGMIGOI','MIEN01',N'Miến Trộn Phú Hương',188500,'Thùng',convert(datetime,'11/09/2019',103))
INSERT INTO [dbo].[Product]
	VALUES('EPIC06','PGMIGOI','MIEN02',N'Miến Phú Hương',188500,'Thùng',convert(datetime,'11/09/2019',103))
INSERT INTO [dbo].[Product]
	VALUES('EPIC06','PGMIGOI','MIEN03',N'Miến Phú Hương Yến Tiệc',186500,'Thùng',convert(datetime,'11/09/2019',103))
GO

INSERT INTO [dbo].[Product]
	VALUES('EPIC06','PGMIGOI','BUNGOI01',N'Phở Đệ Nhất',184500,'Thùng',convert(datetime,'11/09/2019',103))
INSERT INTO [dbo].[Product]
	VALUES('EPIC06','PGMIGOI','BUNGOI02',N'Bún Hằng Nga',188500,'Thùng',convert(datetime,'11/09/2019',103))
INSERT INTO [dbo].[Product]
	VALUES('EPIC06','PGMIGOI','BUNGOI03',N'Hủ tiếu Nhịp Sống',166500,'Thùng',convert(datetime,'11/09/2019',103))
INSERT INTO [dbo].[Product]
	VALUES('EPIC06','PGMIGOI','BUNGOI04',N'Phở Xưa & Nay',155500,'Thùng',convert(datetime,'11/09/2019',103))
GO

--account
INSERT INTO [dbo].[Account] VALUES('EPIC06','admin','123',1,'QL01','account center')
INSERT INTO [dbo].[Account] VALUES('EPIC06','host','123',1,'QL02','account center')
INSERT INTO [dbo].[Account] VALUES('EPIC06','sale01','123',1,'NV01','account sale')
INSERT INTO [dbo].[Account] VALUES('EPIC06','sale02','123',1,'NV02','account sale')
GO

--productinsite
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0601','MIGOI01',1000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0602','MIGOI01',5000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0603','MIGOI01',10000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0601','MIGOI02',1000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0601','MIGOI03',1000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0603','MIGOI03',1000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0602','MIGOI03',5000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0603','MIGOI02',10000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0602','MIGOI02',1000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0602','MIGOI04',1000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0601','MIGOI04',1000,N'Thùng')

INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0601','BUNGOI01',1000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0602','BUNGOI01',5000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0603','BUNGOI01',10000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0601','BUNGOI02',1000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0601','BUNGOI03',1000,N'Thùng')

INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0601','MILY01',1000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0602','MILY01',5000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0603','MILY01',10000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0601','MILY02',1000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0601','MILY03',1000,N'Thùng')

INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0601','MIEN01',1000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0602','MIEN01',5000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0603','MIEN01',10000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0601','MIEN02',1000,N'Thùng')
INSERT INTO [dbo].[ProductInSite] VALUES('EPIC06','EPIC0601','MIEN03',1000,N'Thùng')
GO

--StatusType
INSERT INTO [dbo].[StatusType] VALUES ('Pending')
INSERT INTO [dbo].[StatusType] VALUES ('Verifying')
INSERT INTO [dbo].[StatusType] VALUES ('Completed')
GO

--Orders
INSERT INTO [dbo].[Orders]
     VALUES
           ('EPIC06'
           ,'NV0100001'
           ,11111
           ,11111
           ,'NV01'
           ,convert(datetime,'11/09/2019',103)
           ,null
           ,null
           , 1)
INSERT INTO [dbo].[Orders]
     VALUES
           ('EPIC06'
           ,'NV0100002'
           ,11112
           ,11111
           ,'NV01'
           ,convert(datetime,'11/09/2019',103)
           ,null
           ,null
           ,1)
GO

--OrderDetail
INSERT INTO [dbo].[OrderDetail]
           ([CompID]
           ,[SiteID]
           ,[MyOrderID]
           ,[OrderNum]
           ,[OrderLine]
           ,[LineType]
           ,[ProdID]
           ,[SellingQuantity]
           ,[UnitPrice])
GO
INSERT INTO [dbo].OrderDetail VALUES('EPIC06','EPIC0601','NV0100001',11111,1,'MIGOI01',10,83500)
INSERT INTO [dbo].OrderDetail VALUES('EPIC06','EPIC0601','NV0100001',11111,2,'MIGOI03',10,126500)
INSERT INTO [dbo].OrderDetail VALUES('EPIC06','EPIC0601','NV0100001',11111,3,'MILY01',10,135500)
INSERT INTO [dbo].OrderDetail VALUES('EPIC06','EPIC0601','NV0100001',11111,4,'MIGOI04',10,228500)

INSERT INTO [dbo].OrderDetail VALUES('EPIC06','EPIC0601','NV0100002',11112,1'MILY01',10,135500)
INSERT INTO [dbo].OrderDetail VALUES('EPIC06','EPIC0601','NV0100002',11112,2'MIGOI04',10,228500)
GO

--RoutePlan
INSERT INTO [dbo].[RoutePlan]
     VALUES
           ('EPIC06'
           ,'NV01'
           ,11111
           ,convert(datetime,'11/09/2019',103)
           ,NULL
           ,1
           ,'sửa null khi add công việc')
GO

--messager

--SaleTargets
INSERT INTO [dbo].[SaleTarget]
     VALUES
           ('EPIC06'
           ,'NV01'	
           , 8, 2019
           ,null
           ,'giá trị target???')
INSERT INTO [dbo].[SaleTarget]
     VALUES
           ('EPIC06'
           ,'NV02'
           ,8, 2019
           ,null
           ,'giá trị target???')
GO

SELECT * FROM dbo.Employee
SELECT * FROM dbo.Customer

INSERT dbo.RoutePlan(CompID,EmplID,CustID,DatePlan,Prioritize,Visited,Note)
VALUES(N'EPIC06',N'',0,GETDATE(),0,0)

GO 




INSERT dbo.Orders(CompID,MyOrderID,OrdeID,CustID,EmplID,OrderDate,NeedByDate,RequestDate,OrderStatus)
VALUES(N'EPIC06','OD01',0,0,N'LANE',GETDATE(),GETDATE(),GETDATE(),1)

INSERT dbo.OrderDetail(CompID,SiteID,MyOrderID,OrderNum,OrderLine,LineType,ProdID,SellingQuantity,UnitPrice)
VALUES(N'',N'','',0,0,N'',N'',NULL,NULL)

SELECT * FROM dbo.StatusType
SELECT * FROM dbo.Customer
SELECT * FROM dbo.Employee
SELECT * FROM dbo.Orders
SELECT * FROM dbo.Product
SELECT * FROM dbo.Site
SELECT * FROM dbo.OrderDetail
SELECT * FROM dbo.ProductInSite

 -- OD0
INSERT dbo.OrderDetail(CompID,SiteID,MyOrderID,OrderNum,OrderLine,ProdID,SellingQuantity,UnitPrice)
VALUES( N'EPIC06',N'MfgSys','OD10',10,1,N'020-1223',3,19.203)

SELECT * FROM dbo.Product