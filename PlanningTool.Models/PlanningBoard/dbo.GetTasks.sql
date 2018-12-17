USE [PlanningDataBase]
GO

/****** Object: SqlProcedure [dbo].[GetTasks] Script Date: 12/17/2018 3:08:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[GetTasks];


GO
CREATE PROCEDURE [dbo].[GetTasks]
	
AS
BEGIN
   SET NOCOUNT ON;
     select
	   tsk.TaskID,	 
	   tsk.Title,
	   tsk.Description,
	   tsk.Duration,
	   tsk.StartDate,	  
	   tsk.PercentComplete,	  
	   tsk.Status,
	   tsk.EmployeeId
	   From Task tsk where tsk.Status = 1     
   END
