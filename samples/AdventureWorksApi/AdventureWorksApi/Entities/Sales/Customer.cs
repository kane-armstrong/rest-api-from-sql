// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("Customer", Schema = "Sales")]
    public class Customer
    {
		[Column("CustomerID")]
		public int CustomerID { get; set; }
		[Column("PersonID")]
		public int? PersonID { get; set; }
		[Column("StoreID")]
		public int? StoreID { get; set; }
		[Column("TerritoryID")]
		public int? TerritoryID { get; set; }
		[Column("AccountNumber")]
		public string AccountNumber { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}