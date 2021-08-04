CREATE TABLE Demo.NameThatAppearsInMultipleSchema
(
	Id uniqueidentifier NOT NULL,
	ThisTableNotInDbo nvarchar,
	CONSTRAINT PK_NameThatAppearsInMultipleSchema_Id PRIMARY KEY CLUSTERED(Id)
)