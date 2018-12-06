// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("Illustration", Schema = "Production")]
    public class Illustration
    {
		[Column("IllustrationID")]
		public int IllustrationID { get; set; }
		[Column("Diagram")]
		public string Diagram { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}