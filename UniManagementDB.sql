USE [master]
GO
/****** Object:  Database [UniversityManagementDB]    Script Date: 9/3/2019 2:17:57 AM ******/
CREATE DATABASE [UniversityManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\UniversityManagementDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\UniversityManagementDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityManagementDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversityManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityManagementDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UniversityManagementDB]
GO
/****** Object:  Table [dbo].[AllocatedClassrooms]    Script Date: 9/3/2019 2:17:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AllocatedClassrooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[AllocatedDay] [varchar](15) NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClassRooms]    Script Date: 9/3/2019 2:17:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClassRooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 9/3/2019 2:17:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](80) NOT NULL,
	[CourseCode] [varchar](20) NOT NULL,
	[Credit] [decimal](18, 0) NOT NULL,
	[CourseDescription] [varchar](200) NULL,
	[DepartmentId] [int] NOT NULL,
	[Semester] [varchar](10) NOT NULL,
	[TeacherId] [int] NULL,
 CONSTRAINT [PK__Courses__C92D71A726A7234B] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 9/3/2019 2:17:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departments](
	[DeptId] [int] IDENTITY(1,1) NOT NULL,
	[DeptCode] [varchar](8) NOT NULL,
	[DeptName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DeptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designations]    Script Date: 9/3/2019 2:17:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designations](
	[DesignationId] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EnrolledCourses]    Script Date: 9/3/2019 2:17:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnrolledCourses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[RegDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Results]    Script Date: 9/3/2019 2:17:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Results](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Grade] [varchar](3) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Students]    Script Date: 9/3/2019 2:17:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](50) NOT NULL,
	[RegId] [varchar](16) NOT NULL,
	[Email] [varchar](80) NOT NULL,
	[ContactNo] [varchar](20) NULL,
	[RegDate] [datetime] NOT NULL,
	[Address] [varchar](200) NULL,
	[DepartmentId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 9/3/2019 2:17:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teachers](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [varchar](50) NOT NULL,
	[Email] [varchar](80) NOT NULL,
	[ContactNo] [varchar](20) NOT NULL,
	[Address] [varchar](200) NULL,
	[DesignationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CreditToBeTaken] [decimal](18, 2) NOT NULL,
	[CreditTaken] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK__Teachers__EDF259645CB16E73] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ClassRooms] ON 

INSERT [dbo].[ClassRooms] ([Id], [RoomNo]) VALUES (4, N'B-100')
INSERT [dbo].[ClassRooms] ([Id], [RoomNo]) VALUES (5, N'B-101')
INSERT [dbo].[ClassRooms] ([Id], [RoomNo]) VALUES (6, N'B-102')
INSERT [dbo].[ClassRooms] ([Id], [RoomNo]) VALUES (8, N'L-100')
INSERT [dbo].[ClassRooms] ([Id], [RoomNo]) VALUES (7, N'L-101')
INSERT [dbo].[ClassRooms] ([Id], [RoomNo]) VALUES (9, N'L-102')
INSERT [dbo].[ClassRooms] ([Id], [RoomNo]) VALUES (1, N'S-100')
INSERT [dbo].[ClassRooms] ([Id], [RoomNo]) VALUES (2, N'S-101')
INSERT [dbo].[ClassRooms] ([Id], [RoomNo]) VALUES (3, N'S-102')
SET IDENTITY_INSERT [dbo].[ClassRooms] OFF
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseId], [CourseName], [CourseCode], [Credit], [CourseDescription], [DepartmentId], [Semester], [TeacherId]) VALUES (2, N'Computer Graphics', N'CSE-4703', CAST(3 AS Decimal(18, 0)), N'This is Computer Graphics', 1, N'7th', NULL)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [CourseCode], [Credit], [CourseDescription], [DepartmentId], [Semester], [TeacherId]) VALUES (3, N'Computer Networking', N'CSE-4706', CAST(3 AS Decimal(18, 0)), N'This is computer networking', 1, N'7th', NULL)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [CourseCode], [Credit], [CourseDescription], [DepartmentId], [Semester], [TeacherId]) VALUES (4, N'Finance', N'BBA-2304', CAST(3 AS Decimal(18, 0)), N'This is finance', 4, N'3rd', NULL)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [CourseCode], [Credit], [CourseDescription], [DepartmentId], [Semester], [TeacherId]) VALUES (5, N'Structured Programming', N'CSE-1101', CAST(3 AS Decimal(18, 0)), N'This is structured programing', 1, N'1st', NULL)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [CourseCode], [Credit], [CourseDescription], [DepartmentId], [Semester], [TeacherId]) VALUES (6, N'Mathematics I', N'MATH-1101', CAST(3 AS Decimal(18, 0)), N'This is something', 1, N'1st', NULL)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [CourseCode], [Credit], [CourseDescription], [DepartmentId], [Semester], [TeacherId]) VALUES (7, N'Mathematics II', N'MATH-1201', CAST(3 AS Decimal(18, 0)), N'This is another thing', 1, N'2nd', NULL)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [CourseCode], [Credit], [CourseDescription], [DepartmentId], [Semester], [TeacherId]) VALUES (8, N'Mathematics III', N'MATH-2301', CAST(3 AS Decimal(18, 0)), N'This is a terrible thing', 1, N'3rd', NULL)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [CourseCode], [Credit], [CourseDescription], [DepartmentId], [Semester], [TeacherId]) VALUES (1006, N'Database', N'CSE-4705', CAST(3 AS Decimal(18, 0)), N'a course', 1, N'4th', NULL)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [CourseCode], [Credit], [CourseDescription], [DepartmentId], [Semester], [TeacherId]) VALUES (1007, N'Pulse Techniques', N'EEE-2402', CAST(3 AS Decimal(18, 0)), N'a course', 2, N'4th', NULL)
SET IDENTITY_INSERT [dbo].[Courses] OFF
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([DeptId], [DeptCode], [DeptName]) VALUES (1, N'CSE', N'Computer Science and Engineering')
INSERT [dbo].[Departments] ([DeptId], [DeptCode], [DeptName]) VALUES (2, N'EEE', N'Electrical & Electronics Engineering')
INSERT [dbo].[Departments] ([DeptId], [DeptCode], [DeptName]) VALUES (3, N'ETE', N'Electronic & Telecommunication Engineering')
INSERT [dbo].[Departments] ([DeptId], [DeptCode], [DeptName]) VALUES (4, N'BBA', N'Bachelor of Business Administration')
INSERT [dbo].[Departments] ([DeptId], [DeptCode], [DeptName]) VALUES (5, N'PHARM', N'Department of Pharmacy')
INSERT [dbo].[Departments] ([DeptId], [DeptCode], [DeptName]) VALUES (1002, N'LLB', N'Department of Law')
INSERT [dbo].[Departments] ([DeptId], [DeptCode], [DeptName]) VALUES (1003, N'AEI', N'Automobile Engineering')
INSERT [dbo].[Departments] ([DeptId], [DeptCode], [DeptName]) VALUES (1004, N'CE', N'Civil Engineering')
SET IDENTITY_INSERT [dbo].[Departments] OFF
SET IDENTITY_INSERT [dbo].[Designations] ON 

INSERT [dbo].[Designations] ([DesignationId], [DesignationName]) VALUES (1, N'Lecturer')
INSERT [dbo].[Designations] ([DesignationId], [DesignationName]) VALUES (2, N'Assistant Professor')
INSERT [dbo].[Designations] ([DesignationId], [DesignationName]) VALUES (3, N'Associate Professor')
INSERT [dbo].[Designations] ([DesignationId], [DesignationName]) VALUES (4, N'Professor')
SET IDENTITY_INSERT [dbo].[Designations] OFF
SET IDENTITY_INSERT [dbo].[EnrolledCourses] ON 

INSERT [dbo].[EnrolledCourses] ([Id], [StudentId], [CourseId], [RegDate]) VALUES (1, 1, 2, CAST(0x0000AAC500000000 AS DateTime))
INSERT [dbo].[EnrolledCourses] ([Id], [StudentId], [CourseId], [RegDate]) VALUES (2, 1, 3, CAST(0x0000AABC00000000 AS DateTime))
INSERT [dbo].[EnrolledCourses] ([Id], [StudentId], [CourseId], [RegDate]) VALUES (3, 1, 5, CAST(0x0000AABC00000000 AS DateTime))
INSERT [dbo].[EnrolledCourses] ([Id], [StudentId], [CourseId], [RegDate]) VALUES (1002, 1008, 5, CAST(0x0000AABC00000000 AS DateTime))
INSERT [dbo].[EnrolledCourses] ([Id], [StudentId], [CourseId], [RegDate]) VALUES (1003, 1008, 3, CAST(0x0000AABE00000000 AS DateTime))
INSERT [dbo].[EnrolledCourses] ([Id], [StudentId], [CourseId], [RegDate]) VALUES (1004, 1008, 6, CAST(0x0000AABB00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[EnrolledCourses] OFF
SET IDENTITY_INSERT [dbo].[Results] ON 

INSERT [dbo].[Results] ([Id], [StudentId], [CourseId], [Grade]) VALUES (1, 1, 2, N'B+')
INSERT [dbo].[Results] ([Id], [StudentId], [CourseId], [Grade]) VALUES (2, 1008, 5, N'A')
INSERT [dbo].[Results] ([Id], [StudentId], [CourseId], [Grade]) VALUES (3, 1008, 3, N'A+')
SET IDENTITY_INSERT [dbo].[Results] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentId], [StudentName], [RegId], [Email], [ContactNo], [RegDate], [Address], [DepartmentId]) VALUES (1, N'Athar Shihab Chowdhury', N'CSE-2019-001', N'shihab@gmail.com', N'01571771480', CAST(0x0000AAAF00000000 AS DateTime), N'Chittagong', 1)
INSERT [dbo].[Students] ([StudentId], [StudentName], [RegId], [Email], [ContactNo], [RegDate], [Address], [DepartmentId]) VALUES (1008, N'Nasihun ', N'CSE-2019-002', N'nasihun@gmail.com', N'01894563255', CAST(0x0000AAB100000000 AS DateTime), N'cg', 1)
INSERT [dbo].[Students] ([StudentId], [StudentName], [RegId], [Email], [ContactNo], [RegDate], [Address], [DepartmentId]) VALUES (1009, N'Amin', N'CSE-2012-001', N'amin@gmail.com', N'01894569985', CAST(0x0000A03000000000 AS DateTime), N'ctg', 1)
INSERT [dbo].[Students] ([StudentId], [StudentName], [RegId], [Email], [ContactNo], [RegDate], [Address], [DepartmentId]) VALUES (2002, N'Samiul Alam Chowdhury', N'CSE-2018-001', N'samiul@gmail.com', N'0186545523', CAST(0x0000A88000000000 AS DateTime), N'ctg', 1)
INSERT [dbo].[Students] ([StudentId], [StudentName], [RegId], [Email], [ContactNo], [RegDate], [Address], [DepartmentId]) VALUES (2003, N'Hasib', N'CSE-2019-003', N'hasibul@gmail.com', N'01579456654', CAST(0x0000AABD00000000 AS DateTime), N'ctg', 1)
SET IDENTITY_INSERT [dbo].[Students] OFF
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([TeacherId], [TeacherName], [Email], [ContactNo], [Address], [DesignationId], [DepartmentId], [CreditToBeTaken], [CreditTaken]) VALUES (1, N'Mr. Tanveer Ahsan', N'tanveerah@gmail.com', N'01845665544', N'Chittagong', 3, 1, CAST(12.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Teachers] ([TeacherId], [TeacherName], [Email], [ContactNo], [Address], [DesignationId], [DepartmentId], [CreditToBeTaken], [CreditTaken]) VALUES (2, N'MD. Mahmudur Rahman', N'mahmud@gmail.com', N'01866223355', N'Chittagong', 3, 1, CAST(9.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Teachers] ([TeacherId], [TeacherName], [Email], [ContactNo], [Address], [DesignationId], [DepartmentId], [CreditToBeTaken], [CreditTaken]) VALUES (3, N'Shaiful Alam ', N'shaiful@gmail.com', N'01899547789', N'Mirsharai', 1, 1, CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Teachers] ([TeacherId], [TeacherName], [Email], [ContactNo], [Address], [DesignationId], [DepartmentId], [CreditToBeTaken], [CreditTaken]) VALUES (4, N'Sabbir Mirja', N'mirja@gmail.com', N'01598446621', N'Cox''s Bazar', 1, 2, CAST(8.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Teachers] ([TeacherId], [TeacherName], [Email], [ContactNo], [Address], [DesignationId], [DepartmentId], [CreditToBeTaken], [CreditTaken]) VALUES (5, N'Sumon Borua', N'sumon@gmail.com', N'01645887744', N'Chittagong', 2, 4, CAST(4.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Teachers] ([TeacherId], [TeacherName], [Email], [ContactNo], [Address], [DesignationId], [DepartmentId], [CreditToBeTaken], [CreditTaken]) VALUES (6, N'Rifat Chowdhury', N'rifat@gmail.com', N'01562445888', N'Chittagong', 1, 1, CAST(6.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Teachers] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__ClassRoo__328651ABBE05B7DA]    Script Date: 9/3/2019 2:17:58 AM ******/
ALTER TABLE [dbo].[ClassRooms] ADD UNIQUE NONCLUSTERED 
(
	[RoomNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Courses__9526E2776568A147]    Script Date: 9/3/2019 2:17:58 AM ******/
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [UQ__Courses__9526E2776568A147] UNIQUE NONCLUSTERED 
(
	[CourseName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Courses__FC00E000FB54F6B2]    Script Date: 9/3/2019 2:17:58 AM ******/
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [UQ__Courses__FC00E000FB54F6B2] UNIQUE NONCLUSTERED 
(
	[CourseCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Departme__5E508265FBF9B44B]    Script Date: 9/3/2019 2:17:58 AM ******/
ALTER TABLE [dbo].[Departments] ADD UNIQUE NONCLUSTERED 
(
	[DeptName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Departme__BB9B9550A56D0D9A]    Script Date: 9/3/2019 2:17:58 AM ******/
ALTER TABLE [dbo].[Departments] ADD UNIQUE NONCLUSTERED 
(
	[DeptCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Students__2C6821198AC73EC0]    Script Date: 9/3/2019 2:17:58 AM ******/
ALTER TABLE [dbo].[Students] ADD UNIQUE NONCLUSTERED 
(
	[RegId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Students__A9D10534FFCE6812]    Script Date: 9/3/2019 2:17:58 AM ******/
ALTER TABLE [dbo].[Students] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Teachers__A9D10534D5F94E21]    Script Date: 9/3/2019 2:17:58 AM ******/
ALTER TABLE [dbo].[Teachers] ADD  CONSTRAINT [UQ__Teachers__A9D10534D5F94E21] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [DF__Courses__Teacher__1ED998B2]  DEFAULT (NULL) FOR [TeacherId]
GO
ALTER TABLE [dbo].[Teachers] ADD  CONSTRAINT [DF__Teachers__Credit__1920BF5C]  DEFAULT ((0)) FOR [CreditTaken]
GO
ALTER TABLE [dbo].[AllocatedClassrooms]  WITH CHECK ADD  CONSTRAINT [FK__Allocated__Cours__2B3F6F97] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[AllocatedClassrooms] CHECK CONSTRAINT [FK__Allocated__Cours__2B3F6F97]
GO
ALTER TABLE [dbo].[AllocatedClassrooms]  WITH CHECK ADD FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DeptId])
GO
ALTER TABLE [dbo].[AllocatedClassrooms]  WITH CHECK ADD FOREIGN KEY([RoomId])
REFERENCES [dbo].[ClassRooms] ([Id])
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK__Courses__DepartM__1DE57479] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DeptId])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK__Courses__DepartM__1DE57479]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK__Courses__Teacher__1FCDBCEB] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([TeacherId])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK__Courses__Teacher__1FCDBCEB]
GO
ALTER TABLE [dbo].[EnrolledCourses]  WITH CHECK ADD  CONSTRAINT [FK__EnrolledC__Cours__300424B4] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[EnrolledCourses] CHECK CONSTRAINT [FK__EnrolledC__Cours__300424B4]
GO
ALTER TABLE [dbo].[EnrolledCourses]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD  CONSTRAINT [FK__Results__CourseI__33D4B598] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[Results] CHECK CONSTRAINT [FK__Results__CourseI__33D4B598]
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DeptId])
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK__Teachers__Depart__182C9B23] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DeptId])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK__Teachers__Depart__182C9B23]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK__Teachers__Design__173876EA] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designations] ([DesignationId])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK__Teachers__Design__173876EA]
GO
USE [master]
GO
ALTER DATABASE [UniversityManagementDB] SET  READ_WRITE 
GO
