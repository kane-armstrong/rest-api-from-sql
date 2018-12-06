// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace HumanResources
{
    [Table("Employee_Temporal", Schema = "HumanResources")]
    public class Employee_Temporal
    {
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; set; }
		[Column("NationalIDNumber")]
		public string NationalIDNumber { get; set; }
		[Column("LoginID")]
		public string LoginID { get; set; }
		[Column("OrganizationNode")]
		public string OrganizationNode { get; set; }
		[Column("OrganizationLevel")]
		public short? OrganizationLevel { get; set; }
		[Column("JobTitle")]
		public string JobTitle { get; set; }
		[Column("BirthDate")]
		public DateTime BirthDate { get; set; }
		[Column("MaritalStatus")]
		public string MaritalStatus { get; set; }
		[Column("Gender")]
		public string Gender { get; set; }
		[Column("HireDate")]
		public DateTime HireDate { get; set; }
		[Column("VacationHours")]
		public short VacationHours { get; set; }
		[Column("SickLeaveHours")]
		public short SickLeaveHours { get; set; }
		[Column("ValidFrom")]
		public DateTime ValidFrom { get; set; }
		[Column("ValidTo")]
		public DateTime ValidTo { get; set; }

	}
}