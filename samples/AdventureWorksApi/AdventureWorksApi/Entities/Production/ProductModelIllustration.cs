// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("ProductModelIllustration", Schema = "Production")]
    public class ProductModelIllustration
    {
		[Column("ProductModelID")]
		public int ProductModelID { get; set; }
		[Column("IllustrationID")]
		public int IllustrationID { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}