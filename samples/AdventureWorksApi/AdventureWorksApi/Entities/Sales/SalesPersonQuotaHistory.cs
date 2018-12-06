// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("SalesPersonQuotaHistory", Schema = "Sales")]
    public class SalesPersonQuotaHistory
    {
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; set; }
		[Column("QuotaDate")]
		public DateTime QuotaDate { get; set; }
		[Column("SalesQuota")]
		public decimal SalesQuota { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}