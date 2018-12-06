// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Person
{
    [Table("BusinessEntityContact", Schema = "Person")]
    public class BusinessEntityContact
    {
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; set; }
		[Column("PersonID")]
		public int PersonID { get; set; }
		[Column("ContactTypeID")]
		public int ContactTypeID { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}