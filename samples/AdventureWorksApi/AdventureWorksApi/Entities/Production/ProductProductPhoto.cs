// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("ProductProductPhoto", Schema = "Production")]
    public class ProductProductPhoto
    {
		[Column("ProductID")]
		public int ProductID { get; set; }
		[Column("ProductPhotoID")]
		public int ProductPhotoID { get; set; }
		[Column("Primary")]
		public bool Primary { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}