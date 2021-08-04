CREATE TABLE dbo.WithDefaultConstraint
(
	Id uniqueidentifier NOT NULL,
	ImConstrained int CONSTRAINT DF_WithDefaultConstraint_ImConstrained DEFAULT(20),
	CONSTRAINT PK_WithDefaultConstraint_Id PRIMARY KEY CLUSTERED(Id)
)