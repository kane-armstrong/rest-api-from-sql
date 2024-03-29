﻿CREATE TABLE [Demo].WithAllNotNullDataTypes
(
	Id uniqueidentifier,
	ThisIsBigInt bigint NOT NULL,
	ThisIsBinary binary NOT NULL,
	ThisIsBit bit NOT NULL,
	ThisIsChar char NOT NULL,
	ThisIsDate date NOT NULL,
	ThisIsDateTime datetime NOT NULL,
	ThisIsDateTime2 datetime2 NOT NULL,
	ThisIsDateTimeOffset datetimeoffset NOT NULL,
	ThisIsDecimal decimal NOT NULL,
	ThisIsFloat float NOT NULL,
	ThisIsImage image NOT NULL,
	ThisIsInt int NOT NULL,
	ThisIsMoney money NOT NULL,
	ThisIsNChar nchar NOT NULL,
	ThisIsNText ntext NOT NULL,
	ThisIsNumeric numeric NOT NULL,
	ThisIsNvarchar nvarchar NOT NULL,
	ThisIsReal real NOT NULL,
	ThisIsSmallDateTime smalldatetime NOT NULL,
	ThisIsSmallInt smallint NOT NULL,
	ThisIsSmallMoney smallmoney NOT NULL,
	ThisIsText text NOT NULL,
	ThisIsTime time NOT NULL,
	ThisIsTimestamp timestamp NOT NULL,
	ThisIsTinyInt tinyint NOT NULL,
	ThisIsUniqueIdentifier uniqueidentifier NOT NULL,
	ThisIsVarBinary varbinary NOT NULL,
	ThisIsVarchar varchar NOT NULL,
	ThisIsXml xml NOT NULL,
	ThisIsHierarchyId hierarchyid NOT NULL,
	ThisIsGeography geography NOT NULL,
	CONSTRAINT PK_WithAllNotNullDataTypes_Id PRIMARY KEY CLUSTERED(Id),
)