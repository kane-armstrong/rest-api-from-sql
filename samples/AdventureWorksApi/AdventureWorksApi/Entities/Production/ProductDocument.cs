// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("ProductDocument", Schema = "Production")]
    public class ProductDocument
    {
		[Column("ProductID")]
		public int ProductID { get; set; }
		[Column("DocumentNode")]
		public string DocumentNode { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}