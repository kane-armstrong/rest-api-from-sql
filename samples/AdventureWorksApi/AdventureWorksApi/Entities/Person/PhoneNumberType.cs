// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Person
{
    [Table("PhoneNumberType", Schema = "Person")]
    public class PhoneNumberType
    {
		[Column("PhoneNumberTypeID")]
		public int PhoneNumberTypeID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}