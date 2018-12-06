// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("ProductModelProductDescriptionCulture", Schema = "Production")]
    public class ProductModelProductDescriptionCulture
    {
		[Column("ProductModelID")]
		public int ProductModelID { get; set; }
		[Column("ProductDescriptionID")]
		public int ProductDescriptionID { get; set; }
		[Column("CultureID")]
		public string CultureID { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}