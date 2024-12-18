USE [master]
GO
/****** Object:  Database [ClientDB]    Script Date: 27-11-2024 5.02.34 PM ******/
CREATE DATABASE [ClientDB]
 
GO
ALTER DATABASE [ClientDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ClientDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ClientDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ClientDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ClientDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ClientDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ClientDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ClientDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ClientDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ClientDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ClientDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ClientDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ClientDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ClientDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ClientDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ClientDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ClientDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ClientDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ClientDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ClientDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ClientDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ClientDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ClientDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ClientDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ClientDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ClientDB] SET  MULTI_USER 
GO
ALTER DATABASE [ClientDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ClientDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ClientDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ClientDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ClientDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ClientDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ClientDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [ClientDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ClientDB]
GO
/****** Object:  Table [dbo].[TblCompany]    Script Date: 27-11-2024 5.02.34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblCompany](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](200) NULL,
	[Address1] [varchar](max) NULL,
	[Address2] [varchar](max) NULL,
	[ZipCode] [varchar](10) NULL,
	[PhoneNumber] [varchar](15) NULL,
	[CreatedDT] [datetime] NOT NULL,
	[ModifiedDT] [datetime] NULL,
 CONSTRAINT [PK_TblCompany] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblContact]    Script Date: 27-11-2024 5.02.34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblContact](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[PhoneNumber] [varchar](15) NULL,
	[EmailID] [nvarchar](100) NULL,
	[CompanyID] [int] NOT NULL,
	[CreatedDT] [datetime] NOT NULL,
	[ModifedDT] [datetime] NULL,
 CONSTRAINT [PK_TblContact] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TblCompany] ADD  CONSTRAINT [DF_TblCompany_CreatedDT]  DEFAULT (getdate()) FOR [CreatedDT]
GO
ALTER TABLE [dbo].[TblContact] ADD  CONSTRAINT [DF_TblContact_CreatedDT]  DEFAULT (getdate()) FOR [CreatedDT]
GO
ALTER TABLE [dbo].[TblContact]  WITH CHECK ADD  CONSTRAINT [FK_TblContact_TblContact] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[TblCompany] ([CompanyID])
GO
ALTER TABLE [dbo].[TblContact] CHECK CONSTRAINT [FK_TblContact_TblContact]
GO
/****** Object:  StoredProcedure [dbo].[GetCompanyList]    Script Date: 27-11-2024 5.02.34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nishant Agrawal	
-- Create date: 26-11-2024
-- Description:	Retrieve Company List
-- =============================================
CREATE PROCEDURE [dbo].[GetCompanyList] 

AS
BEGIN
	
	SELECT * from TblCompany;
END
GO
/****** Object:  StoredProcedure [dbo].[GetContactList]    Script Date: 27-11-2024 5.02.34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Nishant Agrawal	
-- Create date: 26-11-2024
-- Description:	Retrieve Company List
-- =============================================
CREATE PROCEDURE [dbo].[GetContactList] 
@CompanyID int=NULL
AS

BEGIN
IF @CompanyID > 0
  BEGIN
	SELECT  c.CompanyID,ContactID,FirstName,LastName,EmailID,c.PhoneNumber,tc.CompanyName from TblContact c
	Left Join TblCompany tc on c.CompanyID=tc.CompanyID where c.CompanyID=@CompanyID;
  END
	ELSE
   BEGIN
	SELECT c.CompanyID,ContactID,FirstName,LastName,EmailID,c.PhoneNumber,tc.CompanyName from TblContact c
	Left Join TblCompany tc on c.CompanyID=tc.CompanyID
   END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateCompany]    Script Date: 27-11-2024 5.02.34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================

-- Author:	Nishant Agrawal	

-- Create date: 26-11-2024

-- Description:	Insert Company

-- =============================================

CREATE PROCEDURE [dbo].[InsertUpdateCompany]

@CompanyName varchar(200) null,

@Address1 varchar(max) null,

@Address2 varchar(max) null,

@ZipCode varchar(10) null,

@PhoneNumber varchar(15) null,

@CompanyID INT OUTPUT
AS

BEGIN
    SET NOCOUNT ON
	 IF @CompanyID IS NULL OR @CompanyID = 0
	 BEGIN
	   INSERT INTO TblCompany (CompanyName, Address1,Address2, ZipCode,PhoneNumber) 
	   VALUES(@CompanyName, @Address1,@Address2,@ZipCode,@PhoneNumber)

	   SET @CompanyID = SCOPE_IDENTITY();
	 END
	 ELSE
	    BEGIN
        -- Update existing company
        UPDATE TblCompany
        SET CompanyName = @CompanyName,
            Address1 = @Address1,
            Address2 = @Address2,
            ZipCode = @ZipCode,
            PhoneNumber = @PhoneNumber,
			ModifiedDT=GetDate()
        WHERE CompanyID = @CompanyID;
    END

END

 
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateContact]    Script Date: 27-11-2024 5.02.34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Nishant Agrawal	
-- Create date: 26-11-2024
-- Description:	INSERT/UPDATE Contact
-- =============================================
CREATE PROCEDURE [dbo].[InsertUpdateContact]
    @ContactID INT = NULL OUTPUT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @PhoneNumber NVARCHAR(15),
    @EmailID NVARCHAR(100),
    @CompanyID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF @ContactID IS NULL OR @ContactID = 0
    BEGIN
        -- Insert Operation
        INSERT INTO [dbo].[TblContact] 
        (
            [FirstName],
            [LastName],
            [PhoneNumber],
            [EmailID],
            [CompanyID]
        )
        VALUES 
        (
            @FirstName,
            @LastName,
            @PhoneNumber,
            @EmailID,
            @CompanyID
        );

        -- Return the new ContactID (last inserted)
            SET @ContactID = SCOPE_IDENTITY();

    END
    ELSE
    BEGIN
        -- Update Operation
        UPDATE [dbo].[TblContact]
        SET
            [FirstName] = @FirstName,
            [LastName] = @LastName,
            [PhoneNumber] = @PhoneNumber,
            [EmailID] = @EmailID,
            [CompanyID] = @CompanyID,
            [ModifedDT] = GETDATE()
        WHERE [ContactID] = @ContactID;

    END
END
GO
/****** Object:  StoredProcedure [dbo].[IsCompanyExist]    Script Date: 27-11-2024 5.02.34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nishant Agrawal	
-- Create date: 27-11-2024
-- Description:	Check Company Name Exist
-- =============================================
CREATE PROCEDURE [dbo].[IsCompanyExist] 
@CompanyId INT,
@CompanyName varchar(max),
@IsExist bit=0 OUTPUT
AS
BEGIN
IF EXISTS (SELECT 1 from TblCompany where CompanyName= TRIM(@CompanyName) AND CompanyID <> @CompanyId)
BEGIN
SET @IsExist=1;
END
	
END
GO
USE [master]
GO
ALTER DATABASE [ClientDB] SET  READ_WRITE 
GO
