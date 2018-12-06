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
    [Route("api/Production/TransactionHistory")]
    [ApiController]
    public class Production_TransactionHistoryController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public Production_TransactionHistoryController(ApplicationDbContext db)
        {
            _db = db;
        }

		[HttpGet]
        [Route("", Name = "List_Production_TransactionHistory")]
        public async Task<ActionResult<IEnumerable<Production.TransactionHistory>>> ListTransactionHistory(int pageIndex, int pageSize)
        {
            return await _db.Production_TransactionHistory.OrderBy(x => x.TransactionID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }

		[HttpGet]
        [Route("{transactionID}", Name = "GetById_Production_TransactionHistory")]
        public async Task<ActionResult<Production.TransactionHistory>> GetTransactionHistory(int transactionID)
        {
            var result = await _db.Production_TransactionHistory.FirstOrDefaultAsync(x => x.TransactionID == transactionID);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

		[HttpPost]
        [Route("", Name = "Create_Production_TransactionHistory")]
        public async Task<IActionResult> CreateTransactionHistory([FromBody] Production.TransactionHistory value)
        {
            _db.Production_TransactionHistory.Add(value);
            await _db.SaveChangesAsync();
            return Ok(value);
        }

		[HttpPut("{transactionID}", Name = "Edit_Production_TransactionHistory")]
        public async Task<IActionResult> EditTransactionHistory(int transactionID, [FromBody] Production.TransactionHistory value)
        {
            var existing = await _db.Production_TransactionHistory.FirstOrDefaultAsync(x => x.TransactionID == transactionID);
            if (existing == null)
            {
                return NotFound();
            }

			existing.TransactionID = value.TransactionID;
			existing.ProductID = value.ProductID;
			existing.ReferenceOrderID = value.ReferenceOrderID;
			existing.ReferenceOrderLineID = value.ReferenceOrderLineID;
			existing.TransactionDate = value.TransactionDate;
			existing.TransactionType = value.TransactionType;
			existing.Quantity = value.Quantity;
			existing.ActualCost = value.ActualCost;
			existing.ModifiedDate = value.ModifiedDate;

            _db.Production_TransactionHistory.Update(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		[HttpDelete("", Name = "Delete_Production_TransactionHistory")]
        public async Task<IActionResult> DeleteTransactionHistory(int transactionID)
        {
            var existing = await _db.Production_TransactionHistory.FirstOrDefaultAsync(x => x.TransactionID == transactionID);
            if (existing == null)
            {
                return NotFound();
            }
            _db.Production_TransactionHistory.Remove(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		// No GetByUniqueKeyActions generated

		// No EditByUniqueKeyActions generated

		// No DeleteByUniqueKeyActions generated

	}
}