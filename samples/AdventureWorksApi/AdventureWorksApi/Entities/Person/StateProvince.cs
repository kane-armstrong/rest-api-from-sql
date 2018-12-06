// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Person
{
    [Table("StateProvince", Schema = "Person")]
    public class StateProvince
    {
		[Column("StateProvinceID")]
		public int StateProvinceID { get; set; }
		[Column("StateProvinceCode")]
		public string StateProvinceCode { get; set; }
		[Column("CountryRegionCode")]
		public string CountryRegionCode { get; set; }
		[Column("IsOnlyStateProvinceFlag")]
		public bool IsOnlyStateProvinceFlag { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("TerritoryID")]
		public int TerritoryID { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}