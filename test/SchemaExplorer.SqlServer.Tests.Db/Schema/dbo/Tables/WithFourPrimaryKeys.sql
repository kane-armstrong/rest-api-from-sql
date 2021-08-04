CREATE TABLE dbo.WithFourPrimaryKeys
(
	Id1 uniqueidentifier NOT NULL,
	Id2 uniqueidentifier NOT NULL,
	Id3 uniqueidentifier NOT NULL,
	Id4 uniqueidentifier NOT NULL,
	CONSTRAINT PK_WithFourPrimaryKeys_Id1_Id2_Id3_Id4 PRIMARY KEY CLUSTERED(Id1, Id2, Id3, Id4)
)