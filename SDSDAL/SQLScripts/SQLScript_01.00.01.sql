IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_IssueUpdate]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[usp_IssueUpdate]
GO
  
CREATE PROCEDURE [dbo].[usp_IssueUpdate]
	@issueId int,
	@subject nvarchar(150),
	@description nvarchar(max),
	@categoryId int,
	@priorityId int,
	@dueDate date,
	@status int,
	@assignTo nvarchar(50),
	@spentTime varchar(20),
	@updatedBy nvarchar(50)
AS
BEGIN
	IF NOT EXISTS (SELECT TOP 1 * FROM Issues WHERE IssueId = @issueId)
	BEGIN
		INSERT INTO Issues(Subject, Description, CategoryId, PriorityId, DueDate, Status, 
			AssignTo, SpentTime, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate)
		VALUES(@subject, @description, @categoryId, @priorityId, @dueDate, @status, 
			@assignTo, @spentTime, @updatedBy, GETDATE(), @updatedBy, GETDATE())

		SELECT @issueId = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		UPDATE Issues
		SET Subject = @subject,
			Description = @description,
			CategoryId = @categoryId,
			PriorityId = @priorityId,
			DueDate = @dueDate,
			Status = @status,
			AssignTo = @assignTo,
			SpentTime = @spentTime,
			UpdatedBy = @updatedBy,
			UpdatedDate = GETDATE()
		WHERE IssueId = @issueId
	END

	SELECT * FROM Issues WHERE IssueId = @issueId
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_IssueGet]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[usp_IssueGet]
GO

CREATE PROCEDURE [dbo].[usp_IssueGet]
	@issueId int = 0,
	@subject nvarchar(150) = '',
	@status int = 0,
	@priorityId int = 0,
	@assignTo nvarchar(50) = '',
	@dueDate datetime = NULL
AS
BEGIN
	SELECT * 
	FROM Issues
	WHERE (@issueId = 0 OR IssueId = @issueId) AND
		(@subject = '' OR Subject = @subject) AND
		(@status = 0 OR Status = @status) AND
		(@priorityId = 0 OR PriorityId = @priorityId) AND
		(@assignTo = '' OR AssignTo = @assignTo) AND
		(@dueDate IS NULL OR DueDate = @dueDate)
END
GO

