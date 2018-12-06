// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace dbo
{
    [Table("DatabaseLog", Schema = "dbo")]
    public class DatabaseLog
    {
		[Column("DatabaseLogID")]
		public int DatabaseLogID { get; set; }
		[Column("PostTime")]
		public DateTime PostTime { get; set; }
		[Column("DatabaseUser")]
		public string DatabaseUser { get; set; }
		[Column("Event")]
		public string Event { get; set; }
		[Column("Schema")]
		public string Schema { get; set; }
		[Column("Object")]
		public string Object { get; set; }
		[Column("TSQL")]
		public string TSQL { get; set; }
		[Column("XmlEvent")]
		public string XmlEvent { get; set; }

	}
}