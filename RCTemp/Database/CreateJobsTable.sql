CREATE TABLE [dbo].[Jobs](
    [JobId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Title] NVARCHAR(200) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    [Location] NVARCHAR(150) NULL,
    [EmploymentType] NVARCHAR(50) NULL,
    [PostedDate] DATETIME NOT NULL DEFAULT(GETDATE()),
    [IsActive] BIT NOT NULL DEFAULT(1)
);