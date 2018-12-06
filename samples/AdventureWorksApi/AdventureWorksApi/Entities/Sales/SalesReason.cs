// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("SalesReason", Schema = "Sales")]
    public class SalesReason
    {
		[Column("SalesReasonID")]
		public int SalesReasonID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("ReasonType")]
		public string ReasonType { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}