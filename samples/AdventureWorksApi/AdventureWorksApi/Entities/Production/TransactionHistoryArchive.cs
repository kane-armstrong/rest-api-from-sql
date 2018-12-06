// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("TransactionHistoryArchive", Schema = "Production")]
    public class TransactionHistoryArchive
    {
		[Column("TransactionID")]
		public int TransactionID { get; set; }
		[Column("ProductID")]
		public int ProductID { get; set; }
		[Column("ReferenceOrderID")]
		public int ReferenceOrderID { get; set; }
		[Column("ReferenceOrderLineID")]
		public int ReferenceOrderLineID { get; set; }
		[Column("TransactionDate")]
		public DateTime TransactionDate { get; set; }
		[Column("TransactionType")]
		public string TransactionType { get; set; }
		[Column("Quantity")]
		public int Quantity { get; set; }
		[Column("ActualCost")]
		public decimal ActualCost { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}