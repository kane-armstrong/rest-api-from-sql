// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Production
{
    [Table("WorkOrderRouting", Schema = "Production")]
    public class WorkOrderRouting
    {
		[Column("WorkOrderID")]
		public int WorkOrderID { get; set; }
		[Column("ProductID")]
		public int ProductID { get; set; }
		[Column("OperationSequence")]
		public short OperationSequence { get; set; }
		[Column("LocationID")]
		public short LocationID { get; set; }
		[Column("ScheduledStartDate")]
		public DateTime ScheduledStartDate { get; set; }
		[Column("ScheduledEndDate")]
		public DateTime ScheduledEndDate { get; set; }
		[Column("ActualStartDate")]
		public DateTime? ActualStartDate { get; set; }
		[Column("ActualEndDate")]
		public DateTime? ActualEndDate { get; set; }
		[Column("ActualResourceHrs")]
		public decimal? ActualResourceHrs { get; set; }
		[Column("PlannedCost")]
		public decimal PlannedCost { get; set; }
		[Column("ActualCost")]
		public decimal? ActualCost { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}