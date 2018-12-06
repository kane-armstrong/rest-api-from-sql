// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("TrackingEvent", Schema = "Sales")]
    public class TrackingEvent
    {
		[Column("TrackingEventID")]
		public int TrackingEventID { get; set; }
		[Column("EventName")]
		public string EventName { get; set; }

	}
}