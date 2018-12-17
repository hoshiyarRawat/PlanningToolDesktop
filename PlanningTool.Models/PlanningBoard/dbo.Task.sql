USE [PlanningDataBase]
GO

/****** Object: Table [dbo].[Task] Script Date: 12/17/2018 3:08:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Task];


GO
CREATE TABLE [dbo].[Task] (
    [TaskID]          INT            NOT NULL,
    [Title]           NVARCHAR (200) NULL,
    [Description]     NCHAR (10)     NULL,
    [Duration]        INT            NULL,
    [StartDate]       DATETIME       NULL,
    [PercentComplete] INT            NULL,
    [Status]          INT            NULL,
    [EmployeeId]      INT            NULL
);


