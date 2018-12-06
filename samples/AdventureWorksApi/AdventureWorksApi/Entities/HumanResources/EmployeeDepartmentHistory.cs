// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace HumanResources
{
    [Table("EmployeeDepartmentHistory", Schema = "HumanResources")]
    public class EmployeeDepartmentHistory
    {
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; set; }
		[Column("DepartmentID")]
		public short DepartmentID { get; set; }
		[Column("ShiftID")]
		public byte ShiftID { get; set; }
		[Column("StartDate")]
		public DateTime StartDate { get; set; }
		[Column("EndDate")]
		public DateTime? EndDate { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}