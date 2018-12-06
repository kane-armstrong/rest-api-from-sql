// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("SpecialOfferProduct", Schema = "Sales")]
    public class SpecialOfferProduct
    {
		[Column("SpecialOfferID")]
		public int SpecialOfferID { get; set; }
		[Column("ProductID")]
		public int ProductID { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}