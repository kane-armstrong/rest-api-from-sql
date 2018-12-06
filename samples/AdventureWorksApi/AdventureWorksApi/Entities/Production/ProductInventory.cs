// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("ProductInventory", Schema = "Production")]
    public class ProductInventory
    {
		[Column("ProductID")]
		public int ProductID { get; set; }
		[Column("LocationID")]
		public short LocationID { get; set; }
		[Column("Shelf")]
		public string Shelf { get; set; }
		[Column("Bin")]
		public byte Bin { get; set; }
		[Column("Quantity")]
		public short Quantity { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}