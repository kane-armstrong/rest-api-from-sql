// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("ProductReview", Schema = "Production")]
    public class ProductReview
    {
		[Column("ProductReviewID")]
		public int ProductReviewID { get; set; }
		[Column("ProductID")]
		public int ProductID { get; set; }
		[Column("ReviewerName")]
		public string ReviewerName { get; set; }
		[Column("ReviewDate")]
		public DateTime ReviewDate { get; set; }
		[Column("EmailAddress")]
		public string EmailAddress { get; set; }
		[Column("Rating")]
		public int Rating { get; set; }
		[Column("Comments")]
		public string Comments { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}