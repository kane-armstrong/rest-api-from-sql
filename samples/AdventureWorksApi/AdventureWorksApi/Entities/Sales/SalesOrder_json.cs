// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("SalesOrder_json", Schema = "Sales")]
    public class SalesOrder_json
    {
		[Column("SalesOrderID")]
		public int SalesOrderID { get; set; }
		[Column("RevisionNumber")]
		public byte RevisionNumber { get; set; }
		[Column("OrderDate")]
		public DateTime OrderDate { get; set; }
		[Column("DueDate")]
		public DateTime DueDate { get; set; }
		[Column("ShipDate")]
		public DateTime? ShipDate { get; set; }
		[Column("Status")]
		public byte Status { get; set; }
		[Column("OnlineOrderFlag")]
		public bool OnlineOrderFlag { get; set; }
		[Column("SalesOrderNumber")]
		public string SalesOrderNumber { get; set; }
		[Column("PurchaseOrderNumber")]
		public string PurchaseOrderNumber { get; set; }
		[Column("AccountNumber")]
		public string AccountNumber { get; set; }
		[Column("CustomerID")]
		public int CustomerID { get; set; }
		[Column("SalesPersonID")]
		public int? SalesPersonID { get; set; }
		[Column("TerritoryID")]
		public int? TerritoryID { get; set; }
		[Column("BillToAddressID")]
		public int? BillToAddressID { get; set; }
		[Column("ShipToAddressID")]
		public int? ShipToAddressID { get; set; }
		[Column("ShipMethodID")]
		public int? ShipMethodID { get; set; }
		[Column("CreditCardID")]
		public int? CreditCardID { get; set; }
		[Column("CreditCardApprovalCode")]
		public string CreditCardApprovalCode { get; set; }
		[Column("CurrencyRateID")]
		public int? CurrencyRateID { get; set; }
		[Column("SubTotal")]
		public decimal SubTotal { get; set; }
		[Column("TaxAmt")]
		public decimal TaxAmt { get; set; }
		[Column("Freight")]
		public decimal Freight { get; set; }
		[Column("TotalDue")]
		public decimal TotalDue { get; set; }
		[Column("Comment")]
		public string Comment { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}