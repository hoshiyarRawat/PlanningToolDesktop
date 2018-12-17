USE [PlanningDataBase]
GO


/****** Object: SqlProcedure [dbo].[CreateTask] Script Date: 12/17/2018 3:08:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[CreateTask];


GO
CREATE PROCEDURE [dbo].[CreateTask]
	@Task_Id int,	
	@Title NVARCHAR(100),
    @Task_Description NVARCHAR(100),
	@Task_Duration int,
	@Task_startDate datetime,	
	@Task_Percentage int,
	@Task_Status int,
	@Task_Assignee int		
AS
BEGIN
   SET NOCOUNT ON;

	INSERT INTO Task Values(
	@Task_Id	
	,@Title
	,@Task_Description
	,@Task_Duration
	,@Task_startDate	
	,@Task_Percentage
	,@Task_Status
	,@Task_Assignee)
	END
