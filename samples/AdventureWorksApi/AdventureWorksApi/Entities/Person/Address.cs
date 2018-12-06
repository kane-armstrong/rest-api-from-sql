// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Person
{
    [Table("Address", Schema = "Person")]
    public class Address
    {
		[Column("AddressID")]
		public int AddressID { get; set; }
		[Column("AddressLine1")]
		public string AddressLine1 { get; set; }
		[Column("AddressLine2")]
		public string AddressLine2 { get; set; }
		[Column("City")]
		public string City { get; set; }
		[Column("StateProvinceID")]
		public int StateProvinceID { get; set; }
		[Column("PostalCode")]
		public string PostalCode { get; set; }
		[Column("SpatialLocation")]
		public Point SpatialLocation { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}