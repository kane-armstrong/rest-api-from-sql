CREATE TABLE dbo.WithTwoPrimaryKeys
(
	Id1 uniqueidentifier NOT NULL,
	Id2 uniqueidentifier NOT NULL,
	CONSTRAINT PK_WithCompositeKey_Id1_Id2 PRIMARY KEY CLUSTERED(Id1, Id2)
)