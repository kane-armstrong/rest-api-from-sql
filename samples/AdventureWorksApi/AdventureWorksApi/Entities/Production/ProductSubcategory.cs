// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("ProductSubcategory", Schema = "Production")]
    public class ProductSubcategory
    {
		[Column("ProductSubcategoryID")]
		public int ProductSubcategoryID { get; set; }
		[Column("ProductCategoryID")]
		public int ProductCategoryID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}