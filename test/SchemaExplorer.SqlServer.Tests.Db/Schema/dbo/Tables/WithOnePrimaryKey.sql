CREATE TABLE dbo.WithOnePrimaryKey
(
	Id uniqueidentifier NOT NULL,
	CONSTRAINT PK_WithOnePrimaryKey_Id PRIMARY KEY CLUSTERED(Id)
)