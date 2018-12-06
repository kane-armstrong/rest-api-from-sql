// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Purchasing
{
    [Table("ProductVendor", Schema = "Purchasing")]
    public class ProductVendor
    {
		[Column("ProductID")]
		public int ProductID { get; set; }
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; set; }
		[Column("AverageLeadTime")]
		public int AverageLeadTime { get; set; }
		[Column("StandardPrice")]
		public decimal StandardPrice { get; set; }
		[Column("LastReceiptCost")]
		public decimal? LastReceiptCost { get; set; }
		[Column("LastReceiptDate")]
		public DateTime? LastReceiptDate { get; set; }
		[Column("MinOrderQty")]
		public int MinOrderQty { get; set; }
		[Column("MaxOrderQty")]
		public int MaxOrderQty { get; set; }
		[Column("OnOrderQty")]
		public int? OnOrderQty { get; set; }
		[Column("UnitMeasureCode")]
		public string UnitMeasureCode { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}