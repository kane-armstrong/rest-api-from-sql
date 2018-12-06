// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("SalesTaxRate", Schema = "Sales")]
    public class SalesTaxRate
    {
		[Column("SalesTaxRateID")]
		public int SalesTaxRateID { get; set; }
		[Column("StateProvinceID")]
		public int StateProvinceID { get; set; }
		[Column("TaxType")]
		public byte TaxType { get; set; }
		[Column("TaxRate")]
		public decimal TaxRate { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}