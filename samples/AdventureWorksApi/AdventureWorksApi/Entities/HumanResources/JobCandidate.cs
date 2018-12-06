// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace HumanResources
{
    [Table("JobCandidate", Schema = "HumanResources")]
    public class JobCandidate
    {
		[Column("JobCandidateID")]
		public int JobCandidateID { get; set; }
		[Column("BusinessEntityID")]
		public int? BusinessEntityID { get; set; }
		[Column("Resume")]
		public string Resume { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}