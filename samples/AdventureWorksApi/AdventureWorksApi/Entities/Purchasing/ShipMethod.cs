// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Purchasing
{
    [Table("ShipMethod", Schema = "Purchasing")]
    public class ShipMethod
    {
		[Column("ShipMethodID")]
		public int ShipMethodID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("ShipBase")]
		public decimal ShipBase { get; set; }
		[Column("ShipRate")]
		public decimal ShipRate { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}