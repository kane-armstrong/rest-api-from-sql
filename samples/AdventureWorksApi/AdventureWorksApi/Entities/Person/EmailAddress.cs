// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Person
{
    [Table("EmailAddress", Schema = "Person")]
    public class EmailAddress
    {
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; set; }
		[Column("EmailAddressID")]
		public int EmailAddressID { get; set; }
		[Column("EmailAddress")]
		public string EmailAddress1 { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}