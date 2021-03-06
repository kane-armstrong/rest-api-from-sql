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
    [Route("api/Sales/CreditCard")]
    [ApiController]
    public class Sales_CreditCardController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public Sales_CreditCardController(ApplicationDbContext db)
        {
            _db = db;
        }

		[HttpGet]
        [Route("", Name = "List_Sales_CreditCard")]
        public async Task<ActionResult<IEnumerable<Sales.CreditCard>>> ListCreditCard(int pageIndex, int pageSize)
        {
            return await _db.Sales_CreditCard.OrderBy(x => x.CreditCardID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }

		[HttpGet]
        [Route("{creditCardID}", Name = "GetById_Sales_CreditCard")]
        public async Task<ActionResult<Sales.CreditCard>> GetCreditCard(int creditCardID)
        {
            var result = await _db.Sales_CreditCard.FirstOrDefaultAsync(x => x.CreditCardID == creditCardID);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

		[HttpPost]
        [Route("", Name = "Create_Sales_CreditCard")]
        public async Task<IActionResult> CreateCreditCard([FromBody] Sales.CreditCard value)
        {
            _db.Sales_CreditCard.Add(value);
            await _db.SaveChangesAsync();
            return Ok(value);
        }

		[HttpPut("{creditCardID}", Name = "Edit_Sales_CreditCard")]
        public async Task<IActionResult> EditCreditCard(int creditCardID, [FromBody] Sales.CreditCard value)
        {
            var existing = await _db.Sales_CreditCard.FirstOrDefaultAsync(x => x.CreditCardID == creditCardID);
            if (existing == null)
            {
                return NotFound();
            }

			existing.CreditCardID = value.CreditCardID;
			existing.CardType = value.CardType;
			existing.CardNumber = value.CardNumber;
			existing.ExpMonth = value.ExpMonth;
			existing.ExpYear = value.ExpYear;
			existing.ModifiedDate = value.ModifiedDate;

            _db.Sales_CreditCard.Update(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		[HttpDelete("", Name = "Delete_Sales_CreditCard")]
        public async Task<IActionResult> DeleteCreditCard(int creditCardID)
        {
            var existing = await _db.Sales_CreditCard.FirstOrDefaultAsync(x => x.CreditCardID == creditCardID);
            if (existing == null)
            {
                return NotFound();
            }
            _db.Sales_CreditCard.Remove(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		// No GetByUniqueKeyActions generated

		// No EditByUniqueKeyActions generated

		// No DeleteByUniqueKeyActions generated

	}
}