// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("CurrencyRate", Schema = "Sales")]
    public class CurrencyRate
    {
		[Column("CurrencyRateID")]
		public int CurrencyRateID { get; set; }
		[Column("CurrencyRateDate")]
		public DateTime CurrencyRateDate { get; set; }
		[Column("FromCurrencyCode")]
		public string FromCurrencyCode { get; set; }
		[Column("ToCurrencyCode")]
		public string ToCurrencyCode { get; set; }
		[Column("AverageRate")]
		public decimal AverageRate { get; set; }
		[Column("EndOfDayRate")]
		public decimal EndOfDayRate { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}