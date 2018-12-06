// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("WorkOrder", Schema = "Production")]
    public class WorkOrder
    {
		[Column("WorkOrderID")]
		public int WorkOrderID { get; set; }
		[Column("ProductID")]
		public int ProductID { get; set; }
		[Column("OrderQty")]
		public int OrderQty { get; set; }
		[Column("StockedQty")]
		public int StockedQty { get; set; }
		[Column("ScrappedQty")]
		public short ScrappedQty { get; set; }
		[Column("StartDate")]
		public DateTime StartDate { get; set; }
		[Column("EndDate")]
		public DateTime? EndDate { get; set; }
		[Column("DueDate")]
		public DateTime DueDate { get; set; }
		[Column("ScrapReasonID")]
		public short? ScrapReasonID { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}