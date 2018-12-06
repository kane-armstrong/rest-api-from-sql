// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("Location", Schema = "Production")]
    public class Location
    {
		[Column("LocationID")]
		public short LocationID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("CostRate")]
		public decimal CostRate { get; set; }
		[Column("Availability")]
		public decimal Availability { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}