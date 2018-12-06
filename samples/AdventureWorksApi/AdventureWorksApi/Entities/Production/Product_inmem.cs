// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("Product_inmem", Schema = "Production")]
    public class Product_inmem
    {
		[Column("ProductID")]
		public int ProductID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("ProductNumber")]
		public string ProductNumber { get; set; }
		[Column("MakeFlag")]
		public bool MakeFlag { get; set; }
		[Column("FinishedGoodsFlag")]
		public bool FinishedGoodsFlag { get; set; }
		[Column("Color")]
		public string Color { get; set; }
		[Column("SafetyStockLevel")]
		public short SafetyStockLevel { get; set; }
		[Column("ReorderPoint")]
		public short ReorderPoint { get; set; }
		[Column("StandardCost")]
		public decimal StandardCost { get; set; }
		[Column("ListPrice")]
		public decimal ListPrice { get; set; }
		[Column("Size")]
		public string Size { get; set; }
		[Column("SizeUnitMeasureCode")]
		public string SizeUnitMeasureCode { get; set; }
		[Column("WeightUnitMeasureCode")]
		public string WeightUnitMeasureCode { get; set; }
		[Column("Weight")]
		public decimal? Weight { get; set; }
		[Column("DaysToManufacture")]
		public int DaysToManufacture { get; set; }
		[Column("ProductLine")]
		public string ProductLine { get; set; }
		[Column("Class")]
		public string Class { get; set; }
		[Column("Style")]
		public string Style { get; set; }
		[Column("ProductSubcategoryID")]
		public int? ProductSubcategoryID { get; set; }
		[Column("ProductModelID")]
		public int? ProductModelID { get; set; }
		[Column("SellStartDate")]
		public DateTime SellStartDate { get; set; }
		[Column("SellEndDate")]
		public DateTime? SellEndDate { get; set; }
		[Column("DiscontinuedDate")]
		public DateTime? DiscontinuedDate { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}