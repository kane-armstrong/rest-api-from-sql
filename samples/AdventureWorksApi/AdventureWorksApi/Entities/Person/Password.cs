// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Person
{
    [Table("Password", Schema = "Person")]
    public class Password
    {
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; set; }
		[Column("PasswordHash")]
		public string PasswordHash { get; set; }
		[Column("PasswordSalt")]
		public string PasswordSalt { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}