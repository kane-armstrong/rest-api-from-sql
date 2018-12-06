// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("SalesTerritory", Schema = "Sales")]
    public class SalesTerritory
    {
		[Column("TerritoryID")]
		public int TerritoryID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("CountryRegionCode")]
		public string CountryRegionCode { get; set; }
		[Column("Group")]
		public string Group { get; set; }
		[Column("SalesYTD")]
		public decimal SalesYTD { get; set; }
		[Column("SalesLastYear")]
		public decimal SalesLastYear { get; set; }
		[Column("CostYTD")]
		public decimal CostYTD { get; set; }
		[Column("CostLastYear")]
		public decimal CostLastYear { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}