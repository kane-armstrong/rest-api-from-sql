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
    [Route("api/Sales/SpecialOffer_ondisk")]
    [ApiController]
    public class Sales_SpecialOffer_ondiskController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public Sales_SpecialOffer_ondiskController(ApplicationDbContext db)
        {
            _db = db;
        }

		[HttpGet]
        [Route("", Name = "List_Sales_SpecialOffer_ondisk")]
        public async Task<ActionResult<IEnumerable<Sales.SpecialOffer_ondisk>>> ListSpecialOffer_ondisk(int pageIndex, int pageSize)
        {
            return await _db.Sales_SpecialOffer_ondisk.OrderBy(x => x.SpecialOfferID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }

		[HttpGet]
        [Route("{specialOfferID}", Name = "GetById_Sales_SpecialOffer_ondisk")]
        public async Task<ActionResult<Sales.SpecialOffer_ondisk>> GetSpecialOffer_ondisk(int specialOfferID)
        {
            var result = await _db.Sales_SpecialOffer_ondisk.FirstOrDefaultAsync(x => x.SpecialOfferID == specialOfferID);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

		[HttpPost]
        [Route("", Name = "Create_Sales_SpecialOffer_ondisk")]
        public async Task<IActionResult> CreateSpecialOffer_ondisk([FromBody] Sales.SpecialOffer_ondisk value)
        {
            _db.Sales_SpecialOffer_ondisk.Add(value);
            await _db.SaveChangesAsync();
            return Ok(value);
        }

		[HttpPut("{specialOfferID}", Name = "Edit_Sales_SpecialOffer_ondisk")]
        public async Task<IActionResult> EditSpecialOffer_ondisk(int specialOfferID, [FromBody] Sales.SpecialOffer_ondisk value)
        {
            var existing = await _db.Sales_SpecialOffer_ondisk.FirstOrDefaultAsync(x => x.SpecialOfferID == specialOfferID);
            if (existing == null)
            {
                return NotFound();
            }

			existing.SpecialOfferID = value.SpecialOfferID;
			existing.Description = value.Description;
			existing.DiscountPct = value.DiscountPct;
			existing.Type = value.Type;
			existing.Category = value.Category;
			existing.StartDate = value.StartDate;
			existing.EndDate = value.EndDate;
			existing.MinQty = value.MinQty;
			existing.MaxQty = value.MaxQty;
			existing.ModifiedDate = value.ModifiedDate;

            _db.Sales_SpecialOffer_ondisk.Update(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		[HttpDelete("", Name = "Delete_Sales_SpecialOffer_ondisk")]
        public async Task<IActionResult> DeleteSpecialOffer_ondisk(int specialOfferID)
        {
            var existing = await _db.Sales_SpecialOffer_ondisk.FirstOrDefaultAsync(x => x.SpecialOfferID == specialOfferID);
            if (existing == null)
            {
                return NotFound();
            }
            _db.Sales_SpecialOffer_ondisk.Remove(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		// No GetByUniqueKeyActions generated

		// No EditByUniqueKeyActions generated

		// No DeleteByUniqueKeyActions generated

	}
}