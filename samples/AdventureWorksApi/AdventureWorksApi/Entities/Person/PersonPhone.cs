// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Person
{
    [Table("PersonPhone", Schema = "Person")]
    public class PersonPhone
    {
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; set; }
		[Column("PhoneNumber")]
		public string PhoneNumber { get; set; }
		[Column("PhoneNumberTypeID")]
		public int PhoneNumberTypeID { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}