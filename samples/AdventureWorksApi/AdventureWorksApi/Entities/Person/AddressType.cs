// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Person
{
    [Table("AddressType", Schema = "Person")]
    public class AddressType
    {
		[Column("AddressTypeID")]
		public int AddressTypeID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}