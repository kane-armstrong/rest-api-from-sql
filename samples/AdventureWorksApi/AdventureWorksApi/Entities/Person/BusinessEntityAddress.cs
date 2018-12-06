// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Person
{
    [Table("BusinessEntityAddress", Schema = "Person")]
    public class BusinessEntityAddress
    {
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; set; }
		[Column("AddressID")]
		public int AddressID { get; set; }
		[Column("AddressTypeID")]
		public int AddressTypeID { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}