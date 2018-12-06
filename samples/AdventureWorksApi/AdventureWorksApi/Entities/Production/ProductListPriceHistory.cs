// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("ProductListPriceHistory", Schema = "Production")]
    public class ProductListPriceHistory
    {
		[Column("ProductID")]
		public int ProductID { get; set; }
		[Column("StartDate")]
		public DateTime StartDate { get; set; }
		[Column("EndDate")]
		public DateTime? EndDate { get; set; }
		[Column("ListPrice")]
		public decimal ListPrice { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}