// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Purchasing
{
    [Table("Vendor", Schema = "Purchasing")]
    public class Vendor
    {
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; set; }
		[Column("AccountNumber")]
		public string AccountNumber { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("CreditRating")]
		public byte CreditRating { get; set; }
		[Column("PreferredVendorStatus")]
		public bool PreferredVendorStatus { get; set; }
		[Column("ActiveFlag")]
		public bool ActiveFlag { get; set; }
		[Column("PurchasingWebServiceURL")]
		public string PurchasingWebServiceURL { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}