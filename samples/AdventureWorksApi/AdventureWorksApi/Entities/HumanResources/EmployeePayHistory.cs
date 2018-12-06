// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace HumanResources
{
    [Table("EmployeePayHistory", Schema = "HumanResources")]
    public class EmployeePayHistory
    {
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; set; }
		[Column("RateChangeDate")]
		public DateTime RateChangeDate { get; set; }
		[Column("Rate")]
		public decimal Rate { get; set; }
		[Column("PayFrequency")]
		public byte PayFrequency { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}