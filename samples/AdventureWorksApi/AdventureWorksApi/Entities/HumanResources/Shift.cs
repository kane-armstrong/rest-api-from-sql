// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace HumanResources
{
    [Table("Shift", Schema = "HumanResources")]
    public class Shift
    {
		[Column("ShiftID")]
		public byte ShiftID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("StartTime")]
		public TimeSpan StartTime { get; set; }
		[Column("EndTime")]
		public TimeSpan EndTime { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}