// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Purchasing
{
    [Table("PurchaseOrderHeader", Schema = "Purchasing")]
    public class PurchaseOrderHeader
    {
		[Column("PurchaseOrderID")]
		public int PurchaseOrderID { get; set; }
		[Column("RevisionNumber")]
		public byte RevisionNumber { get; set; }
		[Column("Status")]
		public byte Status { get; set; }
		[Column("EmployeeID")]
		public int EmployeeID { get; set; }
		[Column("VendorID")]
		public int VendorID { get; set; }
		[Column("ShipMethodID")]
		public int ShipMethodID { get; set; }
		[Column("OrderDate")]
		public DateTime OrderDate { get; set; }
		[Column("ShipDate")]
		public DateTime? ShipDate { get; set; }
		[Column("SubTotal")]
		public decimal SubTotal { get; set; }
		[Column("TaxAmt")]
		public decimal TaxAmt { get; set; }
		[Column("Freight")]
		public decimal Freight { get; set; }
		[Column("TotalDue")]
		public decimal TotalDue { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}