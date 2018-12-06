// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("Document", Schema = "Production")]
    public class Document
    {
		[Column("DocumentNode")]
		public string DocumentNode { get; set; }
		[Column("DocumentLevel")]
		public short? DocumentLevel { get; set; }
		[Column("Title")]
		public string Title { get; set; }
		[Column("Owner")]
		public int Owner { get; set; }
		[Column("FolderFlag")]
		public bool FolderFlag { get; set; }
		[Column("FileName")]
		public string FileName { get; set; }
		[Column("FileExtension")]
		public string FileExtension { get; set; }
		[Column("Revision")]
		public string Revision { get; set; }
		[Column("ChangeNumber")]
		public int ChangeNumber { get; set; }
		[Column("Status")]
		public byte Status { get; set; }
		[Column("DocumentSummary")]
		public string DocumentSummary { get; set; }
		[Column("Document")]
		public byte[] Document1 { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}