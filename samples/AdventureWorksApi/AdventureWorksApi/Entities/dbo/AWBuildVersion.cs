// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace dbo
{
    [Table("AWBuildVersion", Schema = "dbo")]
    public class AWBuildVersion
    {
		[Column("SystemInformationID")]
		public byte SystemInformationID { get; set; }
		[Column("Database Version")]
		public string Database_Version { get; set; }
		[Column("VersionDate")]
		public DateTime VersionDate { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}