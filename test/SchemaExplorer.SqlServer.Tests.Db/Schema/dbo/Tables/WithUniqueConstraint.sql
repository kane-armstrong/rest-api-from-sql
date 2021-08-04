CREATE TABLE dbo.WithUniqueConstraint
(
	Id uniqueidentifier NOT NULL,
	ImConstrained uniqueidentifier,
	CONSTRAINT PK_WithUniqueConstraint_Id PRIMARY KEY CLUSTERED(Id),
	CONSTRAINT UQ_WithUniqueConstraint_ImConstrained UNIQUE(ImConstrained)
)