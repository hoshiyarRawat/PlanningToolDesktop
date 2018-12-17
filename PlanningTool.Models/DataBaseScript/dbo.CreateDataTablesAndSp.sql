
/****** Object: Table [dbo].[Employee] Script Date: 12/17/2018 3:07:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--DROP TABLE [dbo].[Employee];


--GO
CREATE TABLE [dbo].[Employee] (
    [EmployeeId]   INT           NOT NULL,
    [EmployeeName] NVARCHAR (30) NULL,
    [EmailAdress]  NVARCHAR (50) NULL,
    [EmployeeCode] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC)
);





/****** Object: Table [dbo].[Status] Script Date: 12/17/2018 3:07:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--DROP TABLE [dbo].[Status];


--GO
CREATE TABLE [dbo].[Status] (
    [Id]     INT          NOT NULL,
    [Status] VARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);





/****** Object: Table [dbo].[Task] Script Date: 12/17/2018 3:08:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--DROP TABLE [dbo].[Task];


--GO
CREATE TABLE [dbo].[Task] (
    [TaskID]          INT            NOT NULL,
    [Title]           NVARCHAR (200) NULL,
    [Description]     NCHAR (10)     NULL,
    [Duration]        INT            NULL,
    [StartDate]       DATETIME       NULL,
    [PercentComplete] INT            NULL,
    [Status]          INT            NULL,
    [EmployeeId]      INT            NULL, 
    CONSTRAINT [FK_Task_ToTable] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee]([EmployeeId]), 
    CONSTRAINT [FK_Task_ToTable_1] FOREIGN KEY ([Status]) REFERENCES [dbo].[Status]([Id])
	
);





/****** Object: SqlProcedure [dbo].[CreateEmployee] Script Date: 12/17/2018 3:08:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[CreateEmployee];


GO
CREATE PROCEDURE [dbo].[CreateEmployee]
	@Employee_Id int,
	@Employee_Name NVARCHAR(30),
    @Email_Adress NVARCHAR(30),
	@Employee_Code VARCHAR(30)	
AS
BEGIN
   SET NOCOUNT ON;

	INSERT INTO Employee Values(@Employee_Id
	,@Employee_Name
	,@Email_Adress
	,@Employee_Code);

END

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


	
	
	/****** Object: SqlProcedure [dbo].[GetEmployees] Script Date: 12/17/2018 3:08:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[GetEmployees];


GO
CREATE PROCEDURE [dbo].[GetEmployees]
	
AS
BEGIN
   SET NOCOUNT ON;  
   BEGIN
     Select 
	   emp.EmployeeId,
	   emp.EmployeeName,
	   emp.EmployeeCode,
	   emp.EmailAdress
	   From Employee emp
     END  
   END

   
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


