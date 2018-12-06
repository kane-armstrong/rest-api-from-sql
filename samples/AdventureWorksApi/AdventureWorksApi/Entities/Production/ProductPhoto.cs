// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("ProductPhoto", Schema = "Production")]
    public class ProductPhoto
    {
		[Column("ProductPhotoID")]
		public int ProductPhotoID { get; set; }
		[Column("ThumbNailPhoto")]
		public byte[] ThumbNailPhoto { get; set; }
		[Column("ThumbnailPhotoFileName")]
		public string ThumbnailPhotoFileName { get; set; }
		[Column("LargePhoto")]
		public byte[] LargePhoto { get; set; }
		[Column("LargePhotoFileName")]
		public string LargePhotoFileName { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}