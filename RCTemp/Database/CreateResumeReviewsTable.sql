CREATE TABLE dbo.ResumeReviews
(
    ReviewId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NULL, -- optional if user is authenticated
    ApplicantName NVARCHAR(200) NOT NULL,
    Email NVARCHAR(200) NOT NULL,
    Phone NVARCHAR(50) NULL,
    JobId INT NULL,
    FilePath NVARCHAR(500) NOT NULL,
    Status NVARCHAR(50) NOT NULL DEFAULT('Pending'), -- Pending, Reviewed, Rejected
    ReviewerComments NVARCHAR(MAX) NULL,
    SubmittedDate DATETIME NOT NULL DEFAULT(GETDATE())
);

CREATE INDEX IX_ResumeReviews_Status ON dbo.ResumeReviews(Status);