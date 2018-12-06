// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace HumanResources
{
    [Table("Employee", Schema = "HumanResources")]
    public class Employee
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
		[Column("SalariedFlag")]
		public bool SalariedFlag { get; set; }
		[Column("VacationHours")]
		public short VacationHours { get; set; }
		[Column("SickLeaveHours")]
		public short SickLeaveHours { get; set; }
		[Column("CurrentFlag")]
		public bool CurrentFlag { get; set; }
		[Column("rowguid")]
		public Guid rowguid { get; set; }
		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; set; }

	}
}