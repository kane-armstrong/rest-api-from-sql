// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("OrderTracking", Schema = "Sales")]
    public class OrderTracking
    {
		[Column("OrderTrackingID")]
		public int OrderTrackingID { get; set; }
		[Column("SalesOrderID")]
		public int SalesOrderID { get; set; }
		[Column("CarrierTrackingNumber")]
		public string CarrierTrackingNumber { get; set; }
		[Column("TrackingEventID")]
		public int TrackingEventID { get; set; }
		[Column("EventDetails")]
		public string EventDetails { get; set; }
		[Column("EventDateTime")]
		public DateTime EventDateTime { get; set; }

	}
}