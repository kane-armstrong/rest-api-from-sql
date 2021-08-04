CREATE TABLE dbo.WithForeignKeyConstraint
(
	Id uniqueidentifier NOT NULL,
	FriendlyId uniqueidentifier,
	CONSTRAINT PK_WithForeignKeyConstraint_Id PRIMARY KEY CLUSTERED(Id),
	CONSTRAINT FK_WithForeignKeyConstraint_FriendlyId FOREIGN KEY(FriendlyId) REFERENCES dbo.JoinWithMe(Id)
)