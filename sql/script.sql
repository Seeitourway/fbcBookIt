USE [master]
GO
/****** Object:  Database [BookInventory]    Script Date: 3/27/2015 11:32:14 PM ******/
CREATE DATABASE [BookInventory]
 CONTAINMENT = NONE
 GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookInventory].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookInventory] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookInventory] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookInventory] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookInventory] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookInventory] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookInventory] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookInventory] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BookInventory] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookInventory] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookInventory] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookInventory] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookInventory] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookInventory] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookInventory] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookInventory] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookInventory] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookInventory] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookInventory] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookInventory] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookInventory] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookInventory] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookInventory] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookInventory] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookInventory] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookInventory] SET  MULTI_USER 
GO
ALTER DATABASE [BookInventory] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookInventory] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookInventory] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookInventory] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [BookInventory]
GO
/****** Object:  Table [dbo].[BookLoan]    Script Date: 3/27/2015 11:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookLoan](
	[ID] [uniqueidentifier] NOT NULL,
	[BookRequestID] [uniqueidentifier] NOT NULL,
	[OutDate] [date] NULL,
	[InDate] [date] NULL,
	[CopyID] [uniqueidentifier] NOT NULL,
	[StatusID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookRequest]    Script Date: 3/27/2015 11:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookRequest](
	[ID] [uniqueidentifier] NOT NULL,
	[STSID] [uniqueidentifier] NOT NULL,
	[RequestDate] [date] NULL,
	[TitleID] [uniqueidentifier] NOT NULL,
	[FormatID] [uniqueidentifier] NOT NULL,
	[StatusID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Copy]    Script Date: 3/27/2015 11:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Copy](
	[ID] [uniqueidentifier] NOT NULL,
	[TitleID] [uniqueidentifier] NOT NULL,
	[FormatID] [uniqueidentifier] NOT NULL,
	[Volume] [int] NOT NULL,
	[Pages] [int] NULL,
	[Hours] [int] NULL,
	[ProofRead] [bit] NULL,
	[Consumable] [bit] NULL,
	[CopyNumber] [int] NOT NULL,
	[StatusID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uc_TitleVolume] UNIQUE NONCLUSTERED 
(
	[TitleID] ASC,
	[CopyNumber] ASC,
	[Volume] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CopyStatus]    Script Date: 3/27/2015 11:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CopyStatus](
	[ID] [int] NOT NULL,
	[StatusDescription] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[District]    Script Date: 3/27/2015 11:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[District](
	[ID] [uniqueidentifier] NOT NULL,
	[DistrictName] [varchar](100) NOT NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FormatType]    Script Date: 3/27/2015 11:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FormatType](
	[ID] [uniqueidentifier] NOT NULL,
	[FormatDescription] [varchar](100) NOT NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoanStatus]    Script Date: 3/27/2015 11:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoanStatus](
	[ID] [int] NOT NULL,
	[StatusDescription] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RequestStatus]    Script Date: 3/27/2015 11:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RequestStatus](
	[ID] [int] NOT NULL,
	[StatusDescription] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[School]    Script Date: 3/27/2015 11:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[School](
	[ID] [uniqueidentifier] NOT NULL,
	[DistrictID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](500) NULL,
	[StreetAddress] [varchar](500) NULL,
	[City] [varchar](500) NULL,
	[State] [varchar](100) NULL,
	[ZipPlus4] [char](10) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [varchar](500) NULL,
	[ContactName] [varchar](100) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 3/27/2015 11:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [uniqueidentifier] NOT NULL,
	[LastName] [varchar](100) NULL,
	[FirstName] [varchar](100) NULL,
	[MiddleName] [varchar](100) NULL,
	[DateOfBirth] [date] NULL,
	[Grade] [varchar](10) NULL,
	[Gender] [char](1) NULL,
	[VisionDiagnosis] [varchar](8000) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentTeacherSchool]    Script Date: 3/27/2015 11:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTeacherSchool](
	[StudentID] [uniqueidentifier] NOT NULL,
	[TeacherID] [uniqueidentifier] NOT NULL,
	[SchoolID] [uniqueidentifier] NOT NULL,
	[ID] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 3/27/2015 11:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Title] [varchar](500) NULL,
	[StreetAddress] [varchar](500) NULL,
	[City] [varchar](500) NULL,
	[State] [varchar](100) NULL,
	[ZipPlus4] [char](10) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [varchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Title]    Script Date: 3/27/2015 11:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Title](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[ISBN] [varchar](500) NOT NULL,
	[Active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[BookLoan]  WITH CHECK ADD FOREIGN KEY([BookRequestID])
REFERENCES [dbo].[BookRequest] ([ID])
GO
ALTER TABLE [dbo].[BookLoan]  WITH CHECK ADD FOREIGN KEY([CopyID])
REFERENCES [dbo].[Copy] ([ID])
GO
ALTER TABLE [dbo].[BookLoan]  WITH CHECK ADD FOREIGN KEY([StatusID])
REFERENCES [dbo].[LoanStatus] ([ID])
GO
ALTER TABLE [dbo].[BookRequest]  WITH CHECK ADD FOREIGN KEY([FormatID])
REFERENCES [dbo].[FormatType] ([ID])
GO
ALTER TABLE [dbo].[BookRequest]  WITH CHECK ADD FOREIGN KEY([StatusID])
REFERENCES [dbo].[RequestStatus] ([ID])
GO
ALTER TABLE [dbo].[BookRequest]  WITH CHECK ADD FOREIGN KEY([STSID])
REFERENCES [dbo].[StudentTeacherSchool] ([ID])
GO
ALTER TABLE [dbo].[BookRequest]  WITH CHECK ADD FOREIGN KEY([TitleID])
REFERENCES [dbo].[Title] ([ID])
GO
ALTER TABLE [dbo].[Copy]  WITH CHECK ADD FOREIGN KEY([FormatID])
REFERENCES [dbo].[FormatType] ([ID])
GO
ALTER TABLE [dbo].[Copy]  WITH CHECK ADD FOREIGN KEY([StatusID])
REFERENCES [dbo].[CopyStatus] ([ID])
GO
ALTER TABLE [dbo].[Copy]  WITH CHECK ADD FOREIGN KEY([TitleID])
REFERENCES [dbo].[Title] ([ID])
GO
ALTER TABLE [dbo].[School]  WITH CHECK ADD  CONSTRAINT [fk_SchoolDistrict] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[District] ([ID])
GO
ALTER TABLE [dbo].[School] CHECK CONSTRAINT [fk_SchoolDistrict]
GO
ALTER TABLE [dbo].[StudentTeacherSchool]  WITH CHECK ADD FOREIGN KEY([SchoolID])
REFERENCES [dbo].[School] ([ID])
GO
ALTER TABLE [dbo].[StudentTeacherSchool]  WITH CHECK ADD FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[StudentTeacherSchool]  WITH CHECK ADD FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([ID])
GO
USE [master]
GO
ALTER DATABASE [BookInventory] SET  READ_WRITE 
GO
