// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoGeneratedApi.Controllers
{
    [Route("api/Purchasing/Vendor")]
    [ApiController]
    public class Purchasing_VendorController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public Purchasing_VendorController(ApplicationDbContext db)
        {
            _db = db;
        }

		[HttpGet]
        [Route("", Name = "List_Purchasing_Vendor")]
        public async Task<ActionResult<IEnumerable<Purchasing.Vendor>>> ListVendor(int pageIndex, int pageSize)
        {
            return await _db.Purchasing_Vendor.OrderBy(x => x.BusinessEntityID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }

		[HttpGet]
        [Route("{businessEntityID}", Name = "GetById_Purchasing_Vendor")]
        public async Task<ActionResult<Purchasing.Vendor>> GetVendor(int businessEntityID)
        {
            var result = await _db.Purchasing_Vendor.FirstOrDefaultAsync(x => x.BusinessEntityID == businessEntityID);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

		[HttpPost]
        [Route("", Name = "Create_Purchasing_Vendor")]
        public async Task<IActionResult> CreateVendor([FromBody] Purchasing.Vendor value)
        {
            _db.Purchasing_Vendor.Add(value);
            await _db.SaveChangesAsync();
            return Ok(value);
        }

		[HttpPut("{businessEntityID}", Name = "Edit_Purchasing_Vendor")]
        public async Task<IActionResult> EditVendor(int businessEntityID, [FromBody] Purchasing.Vendor value)
        {
            var existing = await _db.Purchasing_Vendor.FirstOrDefaultAsync(x => x.BusinessEntityID == businessEntityID);
            if (existing == null)
            {
                return NotFound();
            }

			existing.BusinessEntityID = value.BusinessEntityID;
			existing.AccountNumber = value.AccountNumber;
			existing.Name = value.Name;
			existing.CreditRating = value.CreditRating;
			existing.PreferredVendorStatus = value.PreferredVendorStatus;
			existing.ActiveFlag = value.ActiveFlag;
			existing.PurchasingWebServiceURL = value.PurchasingWebServiceURL;
			existing.ModifiedDate = value.ModifiedDate;

            _db.Purchasing_Vendor.Update(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		[HttpDelete("", Name = "Delete_Purchasing_Vendor")]
        public async Task<IActionResult> DeleteVendor(int businessEntityID)
        {
            var existing = await _db.Purchasing_Vendor.FirstOrDefaultAsync(x => x.BusinessEntityID == businessEntityID);
            if (existing == null)
            {
                return NotFound();
            }
            _db.Purchasing_Vendor.Remove(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		// No GetByUniqueKeyActions generated

		// No EditByUniqueKeyActions generated

		// No DeleteByUniqueKeyActions generated

	}
}