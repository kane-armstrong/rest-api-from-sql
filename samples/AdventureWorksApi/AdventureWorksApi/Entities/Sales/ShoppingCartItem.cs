// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Sales
{
    [Table("ShoppingCartItem", Schema = "Sales")]
    public class ShoppingCartItem
    {
		[Column("ShoppingCartItemID")]
		public int ShoppingCartItemID { get; set; }
		[Column("ShoppingCartID")]
		public string ShoppingCartID { get; set; }
		[Column("Quantity")]
		public int Quantity { get; set; }
		[Column("ProductID")]
		public int ProductID { get; set; }
		[Column("DateCreated")]
		public DateTime DateCreated { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}