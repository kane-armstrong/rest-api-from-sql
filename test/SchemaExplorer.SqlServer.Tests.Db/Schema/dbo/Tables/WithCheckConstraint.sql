CREATE TABLE dbo.WithCheckConstraint
(
	Id uniqueidentifier NOT NULL,
	ImConstrained int,
	CONSTRAINT PK_WithCheckConstraint_Id PRIMARY KEY CLUSTERED(Id),
	CONSTRAINT CK_WithCheckConstraint_ImConstrained CHECK(ImConstrained > 20)
)