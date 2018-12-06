// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Purchasing
{
    [Table("PurchaseOrderDetail", Schema = "Purchasing")]
    public class PurchaseOrderDetail
    {
		[Column("PurchaseOrderID")]
		public int PurchaseOrderID { get; set; }
		[Column("PurchaseOrderDetailID")]
		public int PurchaseOrderDetailID { get; set; }
		[Column("DueDate")]
		public DateTime DueDate { get; set; }
		[Column("OrderQty")]
		public short OrderQty { get; set; }
		[Column("ProductID")]
		public int ProductID { get; set; }
		[Column("UnitPrice")]
		public decimal UnitPrice { get; set; }
		[Column("LineTotal")]
		public decimal LineTotal { get; set; }
		[Column("ReceivedQty")]
		public decimal ReceivedQty { get; set; }
		[Column("RejectedQty")]
		public decimal RejectedQty { get; set; }
		[Column("StockedQty")]
		public decimal StockedQty { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}