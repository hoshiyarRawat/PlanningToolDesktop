USE [PlanningDataBase]
GO

/****** Object: Table [dbo].[Employee] Script Date: 12/17/2018 3:07:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Employee];


GO
CREATE TABLE [dbo].[Employee] (
    [EmployeeId]   INT           NOT NULL,
    [EmployeeName] NVARCHAR (30) NULL,
    [EmailAdress]  NVARCHAR (50) NULL,
    [EmployeeCode] NVARCHAR (50) NULL
);


