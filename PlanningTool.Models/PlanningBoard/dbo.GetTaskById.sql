USE [PlanningDataBase]
GO

/****** Object: SqlProcedure [dbo].[GetTaskById] Script Date: 12/17/2018 3:08:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[GetTaskById];


GO
CREATE PROCEDURE [dbo].[GetTaskById]
	@Employee_Id int
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
	   From Task tsk where tsk.EmployeeId = @Employee_Id     
   END
