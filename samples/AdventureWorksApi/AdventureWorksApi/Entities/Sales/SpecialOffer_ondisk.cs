// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("SpecialOffer_ondisk", Schema = "Sales")]
    public class SpecialOffer_ondisk
    {
		[Column("SpecialOfferID")]
		public int SpecialOfferID { get; set; }
		[Column("Description")]
		public string Description { get; set; }
		[Column("DiscountPct")]
		public decimal DiscountPct { get; set; }
		[Column("Type")]
		public string Type { get; set; }
		[Column("Category")]
		public string Category { get; set; }
		[Column("StartDate")]
		public DateTime StartDate { get; set; }
		[Column("EndDate")]
		public DateTime EndDate { get; set; }
		[Column("MinQty")]
		public int MinQty { get; set; }
		[Column("MaxQty")]
		public int? MaxQty { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}