// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace dbo
{
    [Table("ErrorLog", Schema = "dbo")]
    public class ErrorLog
    {
		[Column("ErrorLogID")]
		public int ErrorLogID { get; set; }
		[Column("ErrorTime")]
		public DateTime ErrorTime { get; set; }
		[Column("UserName")]
		public string UserName { get; set; }
		[Column("ErrorNumber")]
		public int ErrorNumber { get; set; }
		[Column("ErrorSeverity")]
		public int? ErrorSeverity { get; set; }
		[Column("ErrorState")]
		public int? ErrorState { get; set; }
		[Column("ErrorProcedure")]
		public string ErrorProcedure { get; set; }
		[Column("ErrorLine")]
		public int? ErrorLine { get; set; }
		[Column("ErrorMessage")]
		public string ErrorMessage { get; set; }

	}
}