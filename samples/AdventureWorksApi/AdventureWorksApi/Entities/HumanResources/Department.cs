// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace HumanResources
{
    [Table("Department", Schema = "HumanResources")]
    public class Department
    {
		[Column("DepartmentID")]
		public short DepartmentID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("GroupName")]
		public string GroupName { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}