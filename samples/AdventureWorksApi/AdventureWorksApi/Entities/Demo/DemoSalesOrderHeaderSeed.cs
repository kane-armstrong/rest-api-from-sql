// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Demo
{
    [Table("DemoSalesOrderHeaderSeed", Schema = "Demo")]
    public class DemoSalesOrderHeaderSeed
    {
		[Column("DueDate")]
		public DateTime DueDate { get; set; }
		[Column("CustomerID")]
		public int CustomerID { get; set; }
		[Column("SalesPersonID")]
		public int SalesPersonID { get; set; }
		[Column("BillToAddressID")]
		public int BillToAddressID { get; set; }
		[Column("ShipToAddressID")]
		public int ShipToAddressID { get; set; }
		[Column("ShipMethodID")]
		public int ShipMethodID { get; set; }
		[Column("LocalID")]
		public int LocalID { get; set; }

	}
}