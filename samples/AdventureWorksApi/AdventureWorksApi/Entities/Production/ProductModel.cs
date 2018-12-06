// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("ProductModel", Schema = "Production")]
    public class ProductModel
    {
		[Column("ProductModelID")]
		public int ProductModelID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("CatalogDescription")]
		public string CatalogDescription { get; set; }
		[Column("Instructions")]
		public string Instructions { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}