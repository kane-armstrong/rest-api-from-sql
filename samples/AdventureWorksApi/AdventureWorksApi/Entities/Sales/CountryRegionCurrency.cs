// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("CountryRegionCurrency", Schema = "Sales")]
    public class CountryRegionCurrency
    {
		[Column("CountryRegionCode")]
		public string CountryRegionCode { get; set; }
		[Column("CurrencyCode")]
		public string CurrencyCode { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}