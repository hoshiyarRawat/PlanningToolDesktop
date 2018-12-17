USE [PlanningDataBase]
GO

/****** Object: Table [dbo].[Status] Script Date: 12/17/2018 3:07:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Status];


GO
CREATE TABLE [dbo].[Status] (
    [Id]     INT          NOT NULL,
    [Status] VARCHAR (30) NULL
);


