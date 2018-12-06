// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("Store", Schema = "Sales")]
    public class Store
    {
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("SalesPersonID")]
		public int? SalesPersonID { get; set; }
		[Column("Demographics")]
		public string Demographics { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}