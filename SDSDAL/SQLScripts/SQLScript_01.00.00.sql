IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Issues]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Issues](
		[IssueId] [int] IDENTITY(1,1) NOT NULL,
		[Subject] [nvarchar](150) NOT NULL,
		[Description] [nvarchar](max) NOT NULL,
		[CategoryId] [int] NULL,
		[PriorityId] [int] NULL,
		[DueDate] [date] NULL,
		[Status] [int] NULL,
		[AssignTo] [nvarchar](50) NULL,
		[SpentTime] [varchar](20) NULL,
		[CreatedBy] [nvarchar](50) NULL,
		[CreatedDate] [datetime] NULL,
		[UpdatedBy] [nvarchar](50) NULL,
		[UpdatedDate] [datetime] NULL,
	 CONSTRAINT [PK_Issues] PRIMARY KEY CLUSTERED 
	(
		[IssueId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	CREATE TABLE [dbo].[IssueAttachments](
		[AttachmentId] [int] IDENTITY(1,1) NOT NULL,
		[IssueId] [int] NOT NULL,
		[FileName] [nvarchar](200) NOT NULL,
		[FileUrl] [nvarchar](max) NOT NULL,
	 CONSTRAINT [PK_IssueAttachments] PRIMARY KEY CLUSTERED 
	(
		[AttachmentId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	CREATE UNIQUE NONCLUSTERED INDEX [IX_IssueAttachments] ON [dbo].[IssueAttachments]
	(
		[IssueId] ASC,
		[FileName] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	CREATE TABLE [dbo].[IssueEmails](
		[EmailId] [int] IDENTITY(1,1) NOT NULL,
		[IssueId] [int] NOT NULL,
		[EmailAddress] [nvarchar](100) NOT NULL,
		[UserName] [nvarchar](200) NULL,
	 CONSTRAINT [PK_IssueEmails] PRIMARY KEY CLUSTERED 
	(
		[EmailId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	CREATE UNIQUE NONCLUSTERED INDEX [IX_IssueEmails] ON [dbo].[IssueEmails]
	(
		[IssueId] ASC,
		[EmailAddress] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	CREATE TABLE [dbo].[IssueHistories](
		[HistoryId] [int] IDENTITY(1,1) NOT NULL,
		[IssueId] [int] NOT NULL,
		[Description] [nvarchar](max) NULL,
		[UpdatedBy] [nvarchar](50) NULL,
		[UpdatedDate] [datetime] NULL,
	 CONSTRAINT [PK_IssueHistories] PRIMARY KEY CLUSTERED 
	(
		[HistoryId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO