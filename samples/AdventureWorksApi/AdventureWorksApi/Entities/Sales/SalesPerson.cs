// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("SalesPerson", Schema = "Sales")]
    public class SalesPerson
    {
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; set; }
		[Column("TerritoryID")]
		public int? TerritoryID { get; set; }
		[Column("SalesQuota")]
		public decimal? SalesQuota { get; set; }
		[Column("Bonus")]
		public decimal Bonus { get; set; }
		[Column("CommissionPct")]
		public decimal CommissionPct { get; set; }
		[Column("SalesYTD")]
		public decimal SalesYTD { get; set; }
		[Column("SalesLastYear")]
		public decimal SalesLastYear { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}