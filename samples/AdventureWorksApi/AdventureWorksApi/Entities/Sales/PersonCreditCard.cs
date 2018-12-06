// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("PersonCreditCard", Schema = "Sales")]
    public class PersonCreditCard
    {
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; set; }
		[Column("CreditCardID")]
		public int CreditCardID { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}