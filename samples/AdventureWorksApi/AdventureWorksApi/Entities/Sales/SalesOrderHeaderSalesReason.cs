// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("SalesOrderHeaderSalesReason", Schema = "Sales")]
    public class SalesOrderHeaderSalesReason
    {
		[Column("SalesOrderID")]
		public int SalesOrderID { get; set; }
		[Column("SalesReasonID")]
		public int SalesReasonID { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}