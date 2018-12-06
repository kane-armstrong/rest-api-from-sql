// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("BillOfMaterials", Schema = "Production")]
    public class BillOfMaterials
    {
		[Column("BillOfMaterialsID")]
		public int BillOfMaterialsID { get; set; }
		[Column("ProductAssemblyID")]
		public int? ProductAssemblyID { get; set; }
		[Column("ComponentID")]
		public int ComponentID { get; set; }
		[Column("StartDate")]
		public DateTime StartDate { get; set; }
		[Column("EndDate")]
		public DateTime? EndDate { get; set; }
		[Column("UnitMeasureCode")]
		public string UnitMeasureCode { get; set; }
		[Column("BOMLevel")]
		public short BOMLevel { get; set; }
		[Column("PerAssemblyQty")]
		public decimal PerAssemblyQty { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}