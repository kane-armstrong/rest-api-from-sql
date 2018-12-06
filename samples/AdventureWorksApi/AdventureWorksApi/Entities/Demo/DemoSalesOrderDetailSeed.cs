// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Demo
{
    [Table("DemoSalesOrderDetailSeed", Schema = "Demo")]
    public class DemoSalesOrderDetailSeed
    {
		[Column("OrderQty")]
		public short OrderQty { get; set; }
		[Column("ProductID")]
		public int ProductID { get; set; }
		[Column("SpecialOfferID")]
		public int SpecialOfferID { get; set; }
		[Column("OrderID")]
		public int OrderID { get; set; }
		[Column("LocalID")]
		public int LocalID { get; set; }

	}
}