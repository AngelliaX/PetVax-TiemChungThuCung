USE [master]
GO
/****** Object:  Database [TiemChungThuCung]    Script Date: 4/21/2023 2:28:35 PM ******/
CREATE DATABASE [TiemChungThuCung]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TiemChungThuCung', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.TIEMCHUNGTHUCUNG\MSSQL\DATA\TiemChungThuCung.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TiemChungThuCung_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.TIEMCHUNGTHUCUNG\MSSQL\DATA\TiemChungThuCung_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TiemChungThuCung] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TiemChungThuCung].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TiemChungThuCung] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET ARITHABORT OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TiemChungThuCung] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TiemChungThuCung] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TiemChungThuCung] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TiemChungThuCung] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TiemChungThuCung] SET  MULTI_USER 
GO
ALTER DATABASE [TiemChungThuCung] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TiemChungThuCung] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TiemChungThuCung] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TiemChungThuCung] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TiemChungThuCung] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TiemChungThuCung] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TiemChungThuCung] SET QUERY_STORE = OFF
GO
USE [TiemChungThuCung]
GO
/****** Object:  Table [dbo].[account]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[phone] [varchar](10) NULL,
	[email] [varchar](50) NULL,
	[address] [varchar](50) NULL,
	[birthday] [date] NULL,
	[account_init_day] [date] NULL,
	[isTerminated] [bit] NULL,
	[account_type] [int] NULL,
	[avatar] [varchar](max) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[username] [varchar](50) NOT NULL,
	[salary] [int] NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[appointment]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[appointment](
	[appointment_id] [varchar](10) NOT NULL,
	[pet_id] [varchar](10) NULL,
	[doctor_username] [varchar](50) NULL,
	[state] [int] NULL,
	[init_day] [datetime] NULL,
	[date] [datetime] NULL,
	[note] [nchar](200) NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[appointment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bill]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bill](
	[bill_id] [varchar](10) NOT NULL,
	[client_username] [varchar](50) NULL,
	[init_date] [date] NULL,
	[total_cost] [int] NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[bill_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bill_vaccine]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bill_vaccine](
    [bill_vaccine_key] [int] IDENTITY(1,1) NOT NULL,
    [bill_id] [varchar](10) NOT NULL,
    [vaccine_lot_number] [varchar](10) NULL,
    [amount] [int] NULL,
    [cost] [int] NULL,
    CONSTRAINT [PK_bill_vaccine] PRIMARY KEY CLUSTERED
    (
        [bill_vaccine_key] ASC
    )
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[breed]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[breed](
	[breed_id] [varchar](10) NOT NULL,
	[breed_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Species] PRIMARY KEY CLUSTERED 
(
	[breed_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cashier]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cashier](
	[username] [varchar](50) NOT NULL,
	[salary] [int] NULL,
 CONSTRAINT [PK_Cashier] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[client]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[client](
	[username] [varchar](50) NOT NULL,
	[total_pay] [int] NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[disease]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[disease](
	[disease_code] [varchar](10) NOT NULL,
	[disease_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Disease] PRIMARY KEY CLUSTERED 
(
	[disease_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[doctor]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doctor](
	[username] [varchar](50) NOT NULL,
	[breed_id] [varchar](10) NULL,
	[salary] [int] NULL,
	[experience] [nvarchar](max) NULL,
	[education] [nvarchar](max) NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[doctor_major]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doctor_major](
	[doctor_username] [varchar](50) NOT NULL,
	[breed_id] [varchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pet]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pet](
	[pet_id] [varchar](10) NOT NULL,
	[breed_id] [varchar](10) NULL,
	[client_username] [varchar](50) NULL,
	[pet_name] [nvarchar](50) NULL,
	[age] [int] NULL,
	[weight] [float] NULL,
 CONSTRAINT [PK_Pet] PRIMARY KEY CLUSTERED 
(
	[pet_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pet_disease]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pet_disease](
	[pet_id] [varchar](10) NOT NULL,
	[disease_code] [varchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pet_vaccine]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pet_vaccine](
    [record_id] [int] IDENTITY(1,1) NOT NULL,
    [pet_id] [varchar](10) NOT NULL,
    [vaccine_code] [varchar](10) NULL,
    [state] [bit] NULL,
    [dose_order] [int] NULL,
    [vaccine_date] [date] NULL,
    CONSTRAINT [PK_pet_vaccine] PRIMARY KEY CLUSTERED 
    (
        [record_id] ASC
    )
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pharmacist]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pharmacist](
	[username] [varchar](50) NOT NULL,
	[salary] [int] NULL,
 CONSTRAINT [PK_Pharmacist] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vaccine_compatible]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vaccine_compatible](
	[record_id] [int] IDENTITY(1,1) NOT NULL,
	[disease_code] [varchar](10) NOT NULL,
	[vaccine_code] [varchar](10) NULL
	CONSTRAINT [PK_vaccine_compatible] PRIMARY KEY CLUSTERED 
    (
        [record_id] ASC
    )
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vaccine_lot]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vaccine_lot](
	[lot_number] [varchar](10) NOT NULL,
	[vaccine_code] [varchar](10) NULL,
	[production_date] [date] NOT NULL,
	[expiration_date] [date] NOT NULL,
	[rival_date] [date] NOT NULL,
	[total_amount] [int] NOT NULL,
	[remain_amount] [int] NOT NULL,
	[dose_unit] [int] NULL,
	[import_price] [int] NULL,
	[sale_price] [int] NULL,
	[tax] [int] NULL,
	[publisher] [nvarchar](200) NULL,
	[note] [varchar](max) NULL,
 CONSTRAINT [PK_VaccineLot] PRIMARY KEY CLUSTERED 
(
	[lot_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vaccine_type]    Script Date: 4/21/2023 2:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vaccine_type](
	[vaccine_code] [varchar](10) NOT NULL,
	[vaccine_name] [nvarchar](50) NULL,
	[country_of_origin] [nvarchar](50) NULL,
	[note] [nvarchar](400) NULL,
 CONSTRAINT [PK_VaccineType] PRIMARY KEY CLUSTERED 
(
	[vaccine_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[admin]  WITH CHECK ADD  CONSTRAINT [FK_Admin_Account1] FOREIGN KEY([username])
REFERENCES [dbo].[account] ([username])
GO
ALTER TABLE [dbo].[admin] CHECK CONSTRAINT [FK_Admin_Account1]
GO
ALTER TABLE [dbo].[appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Doctor] FOREIGN KEY([doctor_username])
REFERENCES [dbo].[doctor] ([username])
GO
ALTER TABLE [dbo].[appointment] CHECK CONSTRAINT [FK_Appointment_Doctor]
GO
ALTER TABLE [dbo].[appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Pet] FOREIGN KEY([pet_id])
REFERENCES [dbo].[pet] ([pet_id])
GO
ALTER TABLE [dbo].[appointment] CHECK CONSTRAINT [FK_Appointment_Pet]
GO
ALTER TABLE [dbo].[bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Client] FOREIGN KEY([client_username])
REFERENCES [dbo].[client] ([username])
GO
ALTER TABLE [dbo].[bill] CHECK CONSTRAINT [FK_Bill_Client]
GO
ALTER TABLE [dbo].[bill_vaccine]  WITH CHECK ADD  CONSTRAINT [FK_bill_vaccine_vaccine_lot] FOREIGN KEY([vaccine_lot_number])
REFERENCES [dbo].[vaccine_lot] ([lot_number])
GO
ALTER TABLE [dbo].[bill_vaccine] CHECK CONSTRAINT [FK_bill_vaccine_vaccine_lot]
GO
ALTER TABLE [dbo].[bill_vaccine]  WITH CHECK ADD  CONSTRAINT [FK_BillVaccine_Bill] FOREIGN KEY([bill_id])
REFERENCES [dbo].[bill] ([bill_id])
GO
ALTER TABLE [dbo].[bill_vaccine] CHECK CONSTRAINT [FK_BillVaccine_Bill]
GO
ALTER TABLE [dbo].[cashier]  WITH CHECK ADD  CONSTRAINT [FK_Cashier_Account1] FOREIGN KEY([username])
REFERENCES [dbo].[account] ([username])
GO
ALTER TABLE [dbo].[cashier] CHECK CONSTRAINT [FK_Cashier_Account1]
GO
ALTER TABLE [dbo].[client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Account1] FOREIGN KEY([username])
REFERENCES [dbo].[account] ([username])
GO
ALTER TABLE [dbo].[client] CHECK CONSTRAINT [FK_Client_Account1]
GO
ALTER TABLE [dbo].[doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Account1] FOREIGN KEY([username])
REFERENCES [dbo].[account] ([username])
GO
ALTER TABLE [dbo].[doctor] CHECK CONSTRAINT [FK_Doctor_Account1]
GO
ALTER TABLE [dbo].[doctor_major]  WITH CHECK ADD  CONSTRAINT [FK_doctor_major_breed] FOREIGN KEY([breed_id])
REFERENCES [dbo].[breed] ([breed_id])
GO
ALTER TABLE [dbo].[doctor_major] CHECK CONSTRAINT [FK_doctor_major_breed]
GO
ALTER TABLE [dbo].[doctor_major]  WITH CHECK ADD  CONSTRAINT [FK_doctor_major_doctor] FOREIGN KEY([doctor_username])
REFERENCES [dbo].[doctor] ([username])
GO
ALTER TABLE [dbo].[doctor_major] CHECK CONSTRAINT [FK_doctor_major_doctor]
GO
ALTER TABLE [dbo].[pet]  WITH CHECK ADD  CONSTRAINT [FK_Pet_Client] FOREIGN KEY([client_username])
REFERENCES [dbo].[client] ([username])
GO
ALTER TABLE [dbo].[pet] CHECK CONSTRAINT [FK_Pet_Client]
GO
ALTER TABLE [dbo].[pet]  WITH CHECK ADD  CONSTRAINT [FK_Pet_Species] FOREIGN KEY([breed_id])
REFERENCES [dbo].[breed] ([breed_id])
GO
ALTER TABLE [dbo].[pet] CHECK CONSTRAINT [FK_Pet_Species]
GO
ALTER TABLE [dbo].[pet_disease]  WITH CHECK ADD  CONSTRAINT [FK_PetDisease_Disease] FOREIGN KEY([disease_code])
REFERENCES [dbo].[disease] ([disease_code])
GO
ALTER TABLE [dbo].[pet_disease] CHECK CONSTRAINT [FK_PetDisease_Disease]
GO
ALTER TABLE [dbo].[pet_disease]  WITH CHECK ADD  CONSTRAINT [FK_PetDisease_Pet] FOREIGN KEY([pet_id])
REFERENCES [dbo].[pet] ([pet_id])
GO
ALTER TABLE [dbo].[pet_disease] CHECK CONSTRAINT [FK_PetDisease_Pet]
GO
ALTER TABLE [dbo].[pet_vaccine]  WITH CHECK ADD  CONSTRAINT [FK_PetVaccine_Pet] FOREIGN KEY([pet_id])
REFERENCES [dbo].[pet] ([pet_id])
GO
ALTER TABLE [dbo].[pet_vaccine] CHECK CONSTRAINT [FK_PetVaccine_Pet]
GO
ALTER TABLE [dbo].[pet_vaccine]  WITH CHECK ADD  CONSTRAINT [FK_PetVaccine_VaccineType] FOREIGN KEY([vaccine_code])
REFERENCES [dbo].[vaccine_type] ([vaccine_code])
GO
ALTER TABLE [dbo].[pet_vaccine] CHECK CONSTRAINT [FK_PetVaccine_VaccineType]
GO
ALTER TABLE [dbo].[pharmacist]  WITH CHECK ADD  CONSTRAINT [FK_Pharmacist_Account] FOREIGN KEY([username])
REFERENCES [dbo].[account] ([username])
GO
ALTER TABLE [dbo].[pharmacist] CHECK CONSTRAINT [FK_Pharmacist_Account]
GO
ALTER TABLE [dbo].[vaccine_compatible]  WITH CHECK ADD  CONSTRAINT [FK_vaccine_compatible_disease] FOREIGN KEY([disease_code])
REFERENCES [dbo].[disease] ([disease_code])
GO
ALTER TABLE [dbo].[vaccine_compatible] CHECK CONSTRAINT [FK_vaccine_compatible_disease]
GO
ALTER TABLE [dbo].[vaccine_compatible]  WITH CHECK ADD  CONSTRAINT [FK_vaccine_compatible_vaccine_type] FOREIGN KEY([vaccine_code])
REFERENCES [dbo].[vaccine_type] ([vaccine_code])
GO
ALTER TABLE [dbo].[vaccine_compatible] CHECK CONSTRAINT [FK_vaccine_compatible_vaccine_type]
GO
ALTER TABLE [dbo].[vaccine_lot]  WITH CHECK ADD  CONSTRAINT [FK_VaccineLot_VaccineType] FOREIGN KEY([vaccine_code])
REFERENCES [dbo].[vaccine_type] ([vaccine_code])
GO
ALTER TABLE [dbo].[vaccine_lot] CHECK CONSTRAINT [FK_VaccineLot_VaccineType]
GO
USE [master]
GO
ALTER DATABASE [TiemChungThuCung] SET  READ_WRITE 
GO
