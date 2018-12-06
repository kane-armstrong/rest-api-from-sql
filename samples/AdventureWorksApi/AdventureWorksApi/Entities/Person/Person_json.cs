// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Person
{
    [Table("Person_json", Schema = "Person")]
    public class Person_json
    {
		[Column("PersonID")]
		public int PersonID { get; set; }
		[Column("PersonType")]
		public string PersonType { get; set; }
		[Column("NameStyle")]
		public bool NameStyle { get; set; }
		[Column("Title")]
		public string Title { get; set; }
		[Column("FirstName")]
		public string FirstName { get; set; }
		[Column("MiddleName")]
		public string MiddleName { get; set; }
		[Column("LastName")]
		public string LastName { get; set; }
		[Column("Suffix")]
		public string Suffix { get; set; }
		[Column("EmailPromotion")]
		public int EmailPromotion { get; set; }
		[Column("AdditionalContactInfo")]
		public string AdditionalContactInfo { get; set; }
		[Column("Demographics")]
		public string Demographics { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}