// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("CreditCard", Schema = "Sales")]
    public class CreditCard
    {
		[Column("CreditCardID")]
		public int CreditCardID { get; set; }
		[Column("CardType")]
		public string CardType { get; set; }
		[Column("CardNumber")]
		public string CardNumber { get; set; }
		[Column("ExpMonth")]
		public byte ExpMonth { get; set; }
		[Column("ExpYear")]
		public short ExpYear { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}