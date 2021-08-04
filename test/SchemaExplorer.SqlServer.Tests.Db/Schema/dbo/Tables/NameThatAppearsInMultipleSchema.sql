CREATE TABLE dbo.NameThatAppearsInMultipleSchema
(
	Id uniqueidentifier NOT NULL,
	ThisTableIsInDbo nvarchar,
	CONSTRAINT PK_NameThatAppearsInMultipleSchema_Id PRIMARY KEY CLUSTERED(Id)
)