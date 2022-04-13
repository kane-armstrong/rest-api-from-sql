using FluentAssertions;
using SchemaExplorer.SqlServer.Tests.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SchemaExplorer.SqlServer.Tests.Experimental.SqlServerSchemaExplorerSpec;

public class TableTests
{
    [Theory]
    [MemberData(nameof(ExpectedTableRepresentations))]
    public async Task Explorer_captures_table_columns_correctly(string schemaName, SchemaExplorer.Experimental.Table fixture)
    {
        var sut = new SqlServerSchemaExplorerBuilder().Build();
        var db = await sut.ExploreDatabase(CancellationToken.None);
        var table = db.Schema.First(x => x.Name == schemaName).Tables.First(x => x.Name == fixture.Name);
        table.Columns.Should().BeEquivalentTo(fixture.Columns);
    }

    public static IEnumerable<object[]> ExpectedTableRepresentations
    {
        get
        {
            yield return new object[]
            {
                "dbo",
                new SchemaExplorer.Experimental.Table
                {
                    Name = "JoinWithMe",
                    Columns = new []
                    {
                        new SchemaExplorer.Experimental.Column { Name = "Id", AllowsNulls = false, DataType = "uniqueidentifier", Order = 1, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "PK_JoinWithMe_Id", ConstraintType = ConstraintType.PrimaryKey, OrdinalPosition = 1 }
                        }},
                    }
                }
            };

            yield return new object[]
            {
                "Demo",
                new SchemaExplorer.Experimental.Table
                {
                    Name = "WithAllNotNullDataTypes",
                    Columns = new []
                    {
                        new SchemaExplorer.Experimental.Column { Name = "Id", AllowsNulls = false, DataType = "uniqueidentifier", Order = 1, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "PK_WithAllNotNullDataTypes_Id", ConstraintType = ConstraintType.PrimaryKey, OrdinalPosition = 1 }
                        }},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsBigInt", AllowsNulls = false, DataType = "bigint", Order = 2, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsBinary", AllowsNulls = false, DataType = "binary", Order = 3, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsBit", AllowsNulls = false, DataType = "bit", Order = 4, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsChar", AllowsNulls = false, DataType = "char", Order = 5, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsDate", AllowsNulls = false, DataType = "date", Order = 6, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsDateTime", AllowsNulls = false, DataType = "datetime", Order = 7, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsDateTime2", AllowsNulls = false, DataType = "datetime2", Order = 8, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsDateTimeOffset", AllowsNulls = false, DataType = "datetimeoffset", Order = 9, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsDecimal", AllowsNulls = false, DataType = "decimal", Order = 10, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsFloat", AllowsNulls = false, DataType = "float", Order = 11, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsImage", AllowsNulls = false, DataType = "image", Order = 12, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsInt", AllowsNulls = false, DataType = "int", Order = 13, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsMoney", AllowsNulls = false, DataType = "money", Order = 14, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsNChar", AllowsNulls = false, DataType = "nchar", Order = 15, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsNText", AllowsNulls = false, DataType = "ntext", Order = 16, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsNumeric", AllowsNulls = false, DataType = "numeric", Order = 17, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsNvarchar", AllowsNulls = false, DataType = "nvarchar", Order = 18, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsReal", AllowsNulls = false, DataType = "real", Order = 19, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsSmallDateTime", AllowsNulls = false, DataType = "smalldatetime", Order = 20, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsSmallInt", AllowsNulls = false, DataType = "smallint", Order = 21, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsSmallMoney", AllowsNulls = false, DataType = "smallmoney", Order = 22, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsText", AllowsNulls = false, DataType = "text", Order = 23, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsTime", AllowsNulls = false, DataType = "time", Order = 24, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsTimestamp", AllowsNulls = false, DataType = "timestamp", Order = 25, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsTinyInt", AllowsNulls = false, DataType = "tinyint", Order = 26, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsUniqueIdentifier", AllowsNulls = false, DataType = "uniqueidentifier", Order = 27, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsVarBinary", AllowsNulls = false, DataType = "varbinary", Order = 28, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsVarchar", AllowsNulls = false, DataType = "varchar", Order = 29, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsXml", AllowsNulls = false, DataType = "xml", Order = 30, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsHierarchyId", AllowsNulls = false, DataType = "hierarchyid", Order = 31, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsGeography", AllowsNulls = false, DataType = "geography", Order = 32, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                    }
                }
            };

            yield return new object[]
            {
                "Demo",
                new SchemaExplorer.Experimental.Table
                {
                    Name = "WithAllNullDataTypes",
                    Columns = new []
                    {
                        new SchemaExplorer.Experimental.Column { Name = "Id", AllowsNulls = false, DataType = "uniqueidentifier", Order = 1, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "PK_WithAllNullDataTypes_Id", ConstraintType = ConstraintType.PrimaryKey, OrdinalPosition = 1 }
                        }},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsBigInt", AllowsNulls = true, DataType = "bigint", Order = 2, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsBinary", AllowsNulls = true, DataType = "binary", Order = 3, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsBit", AllowsNulls = true, DataType = "bit", Order = 4, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsChar", AllowsNulls = true, DataType = "char", Order = 5, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsDate", AllowsNulls = true, DataType = "date", Order = 6, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsDateTime", AllowsNulls = true, DataType = "datetime", Order = 7, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsDateTime2", AllowsNulls = true, DataType = "datetime2", Order = 8, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsDateTimeOffset", AllowsNulls = true, DataType = "datetimeoffset", Order = 9, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsDecimal", AllowsNulls = true, DataType = "decimal", Order = 10, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsFloat", AllowsNulls = true, DataType = "float", Order = 11, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsImage", AllowsNulls = true, DataType = "image", Order = 12, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsInt", AllowsNulls = true, DataType = "int", Order = 13, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsMoney", AllowsNulls = true, DataType = "money", Order = 14, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsNChar", AllowsNulls = true, DataType = "nchar", Order = 15, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsNText", AllowsNulls = true, DataType = "ntext", Order = 16, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsNumeric", AllowsNulls = true, DataType = "numeric", Order = 17, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsNvarchar", AllowsNulls = true, DataType = "nvarchar", Order = 18, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsReal", AllowsNulls = true, DataType = "real", Order = 19, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsSmallDateTime", AllowsNulls = true, DataType = "smalldatetime", Order = 20, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsSmallInt", AllowsNulls = true, DataType = "smallint", Order = 21, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsSmallMoney", AllowsNulls = true, DataType = "smallmoney", Order = 22, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsText", AllowsNulls = true, DataType = "text", Order = 23, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsTime", AllowsNulls = true, DataType = "time", Order = 24, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsTimestamp", AllowsNulls = true, DataType = "timestamp", Order = 25, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsTinyInt", AllowsNulls = true, DataType = "tinyint", Order = 26, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsUniqueIdentifier", AllowsNulls = true, DataType = "uniqueidentifier", Order = 27, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsVarBinary", AllowsNulls = true, DataType = "varbinary", Order = 28, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsVarchar", AllowsNulls = true, DataType = "varchar", Order = 29, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsXml", AllowsNulls = true, DataType = "xml", Order = 30, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsHierarchyId", AllowsNulls = true, DataType = "hierarchyid", Order = 31, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                        new SchemaExplorer.Experimental.Column { Name = "ThisIsGeography", AllowsNulls = true, DataType = "geography", Order = 32, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                    }
                }
            };

            yield return new object[]
            {
                "dbo",
                new SchemaExplorer.Experimental.Table
                {
                    Name = "WithCheckConstraint",
                    Columns = new []
                    {
                        new SchemaExplorer.Experimental.Column { Name = "Id", AllowsNulls = false, DataType = "uniqueidentifier", Order = 1, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "PK_WithCheckConstraint_Id", ConstraintType = ConstraintType.PrimaryKey, OrdinalPosition = 1 }
                        }},
                        new SchemaExplorer.Experimental.Column { Name = "ImConstrained", AllowsNulls = true, DataType = "int", Order = 2, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                    }
                }
            };

            yield return new object[]
            {
                "dbo",
                new SchemaExplorer.Experimental.Table
                {
                    Name = "WithDefaultConstraint",
                    Columns = new []
                    {
                        new SchemaExplorer.Experimental.Column { Name = "Id", AllowsNulls = false, DataType = "uniqueidentifier", Order = 1, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "PK_WithDefaultConstraint_Id", ConstraintType = ConstraintType.PrimaryKey, OrdinalPosition = 1 }
                        }},
                        new SchemaExplorer.Experimental.Column { Name = "ImConstrained", AllowsNulls = true, DataType = "int", Order = 2, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                    }
                }
            };

            yield return new object[]
            {
                "dbo",
                new SchemaExplorer.Experimental.Table
                {
                    Name = "WithForeignKeyConstraint",
                    Columns = new []
                    {
                        new SchemaExplorer.Experimental.Column { Name = "Id", AllowsNulls = false, DataType = "uniqueidentifier", Order = 1, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "PK_WithForeignKeyConstraint_Id", ConstraintType = ConstraintType.PrimaryKey, OrdinalPosition = 1 }
                        }},
                        new SchemaExplorer.Experimental.Column { Name = "FriendlyId", AllowsNulls = true, DataType = "uniqueidentifier", Order = 2, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "FK_WithForeignKeyConstraint_FriendlyId", ConstraintType = ConstraintType.ForeignKey, OrdinalPosition = 1 }
                        }},
                    }
                }
            };

            yield return new object[]
            {
                "dbo",
                new SchemaExplorer.Experimental.Table
                {
                    Name = "WithFourPrimaryKeys",
                    Columns = new []
                    {
                        new SchemaExplorer.Experimental.Column { Name = "Id1", AllowsNulls = false, DataType = "uniqueidentifier", Order = 1, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "PK_WithFourPrimaryKeys_Id1_Id2_Id3_Id4", ConstraintType = ConstraintType.PrimaryKey, OrdinalPosition = 1 }
                        }},
                        new SchemaExplorer.Experimental.Column { Name = "Id2", AllowsNulls = false, DataType = "uniqueidentifier", Order = 2, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "PK_WithFourPrimaryKeys_Id1_Id2_Id3_Id4", ConstraintType = ConstraintType.PrimaryKey, OrdinalPosition = 2 }
                        }},
                        new SchemaExplorer.Experimental.Column { Name = "Id3", AllowsNulls = false, DataType = "uniqueidentifier", Order = 3, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "PK_WithFourPrimaryKeys_Id1_Id2_Id3_Id4", ConstraintType = ConstraintType.PrimaryKey, OrdinalPosition = 3 }
                        }},
                        new SchemaExplorer.Experimental.Column { Name = "Id4", AllowsNulls = false, DataType = "uniqueidentifier", Order = 4, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "PK_WithFourPrimaryKeys_Id1_Id2_Id3_Id4", ConstraintType = ConstraintType.PrimaryKey, OrdinalPosition = 4 }
                        }},
                    }
                }
            };

            yield return new object[]
            {
                "dbo",
                new SchemaExplorer.Experimental.Table
                {
                    Name = "WithNoPrimaryKey",
                    Columns = new []
                    {
                        new SchemaExplorer.Experimental.Column { Name = "NotAnId", AllowsNulls = false, DataType = "uniqueidentifier", Order = 1, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                    }
                }
            };

            yield return new object[]
            {
                "dbo",
                new SchemaExplorer.Experimental.Table
                {
                    Name = "WithOnePrimaryKey",
                    Columns = new []
                    {
                        new SchemaExplorer.Experimental.Column { Name = "Id", AllowsNulls = false, DataType = "uniqueidentifier", Order = 1, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "PK_WithOnePrimaryKey_Id", ConstraintType = ConstraintType.PrimaryKey, OrdinalPosition = 1 }
                        }},
                    }
                }
            };

            yield return new object[]
            {
                "dbo",
                new SchemaExplorer.Experimental.Table
                {
                    Name = "WithTwoPrimaryKeys",
                    Columns = new []
                    {
                        new SchemaExplorer.Experimental.Column { Name = "Id1", AllowsNulls = false, DataType = "uniqueidentifier", Order = 1, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "PK_WithCompositeKey_Id1_Id2", ConstraintType = ConstraintType.PrimaryKey, OrdinalPosition = 1 }
                        }},
                        new SchemaExplorer.Experimental.Column { Name = "Id2", AllowsNulls = false, DataType = "uniqueidentifier", Order = 2, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "PK_WithCompositeKey_Id1_Id2", ConstraintType = ConstraintType.PrimaryKey, OrdinalPosition = 2 }
                        }},
                    }
                }
            };

            yield return new object[]
            {
                "dbo",
                new SchemaExplorer.Experimental.Table
                {
                    Name = "WithUniqueConstraint",
                    Columns = new []
                    {
                        new SchemaExplorer.Experimental.Column { Name = "Id", AllowsNulls = false, DataType = "uniqueidentifier", Order = 1, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "PK_WithUniqueConstraint_Id", ConstraintType = ConstraintType.PrimaryKey, OrdinalPosition = 1 }
                        }},
                        new SchemaExplorer.Experimental.Column { Name = "ImConstrained", AllowsNulls = true, DataType = "uniqueidentifier", Order = 2, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "UQ_WithUniqueConstraint_ImConstrained", ConstraintType = ConstraintType.Unique, OrdinalPosition = 1 }
                        }},
                    }
                }
            };

            yield return new object[]
            {
                "dbo",
                new SchemaExplorer.Experimental.Table
                {
                    Name = "NameThatAppearsInMultipleSchema",
                    Columns = new []
                    {
                        new SchemaExplorer.Experimental.Column { Name = "Id", AllowsNulls = false, DataType = "uniqueidentifier", Order = 1, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "PK_NameThatAppearsInMultipleSchema_Id", ConstraintType = ConstraintType.PrimaryKey, OrdinalPosition = 1 }
                        }},
                        new SchemaExplorer.Experimental.Column { Name = "ThisTableIsInDbo", AllowsNulls = true, DataType = "nvarchar", Order = 2, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                    }
                }
            };

            yield return new object[]
            {
                "Demo",
                new SchemaExplorer.Experimental.Table
                {
                    Name = "NameThatAppearsInMultipleSchema",
                    Columns = new []
                    {
                        new SchemaExplorer.Experimental.Column { Name = "Id", AllowsNulls = false, DataType = "uniqueidentifier", Order = 1, Constraints = new List<SchemaExplorer.Experimental.Constraint>
                        {
                            new() { Name = "PK_NameThatAppearsInMultipleSchema_Id", ConstraintType = ConstraintType.PrimaryKey, OrdinalPosition = 1 }
                        }},
                        new SchemaExplorer.Experimental.Column { Name = "ThisTableNotInDbo", AllowsNulls = true, DataType = "nvarchar", Order = 2, Constraints = new List<SchemaExplorer.Experimental.Constraint>()},
                    }
                }
            };
        }
    }
}