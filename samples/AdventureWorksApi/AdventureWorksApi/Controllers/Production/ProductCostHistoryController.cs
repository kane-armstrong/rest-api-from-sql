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
    [Route("api/Production/ProductCostHistory")]
    [ApiController]
    public class Production_ProductCostHistoryController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public Production_ProductCostHistoryController(ApplicationDbContext db)
        {
            _db = db;
        }

		[HttpGet]
        [Route("", Name = "List_Production_ProductCostHistory")]
        public async Task<ActionResult<IEnumerable<Production.ProductCostHistory>>> ListProductCostHistory(int pageIndex, int pageSize)
        {
            return await _db.Production_ProductCostHistory.OrderBy(x => x.ProductID).ThenBy(x => x.StartDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }

		[HttpGet]
        [Route("productID/{productID}/startDate/{startDate}", Name = "GetById_Production_ProductCostHistory")]
        public async Task<ActionResult<Production.ProductCostHistory>> GetProductCostHistory(int productID, DateTime startDate)
        {
            var result = await _db.Production_ProductCostHistory.FirstOrDefaultAsync(x => x.ProductID == productID && x.StartDate == startDate);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

		[HttpPost]
        [Route("", Name = "Create_Production_ProductCostHistory")]
        public async Task<IActionResult> CreateProductCostHistory([FromBody] Production.ProductCostHistory value)
        {
            _db.Production_ProductCostHistory.Add(value);
            await _db.SaveChangesAsync();
            return Ok(value);
        }

		[HttpPut("productID/{productID}/startDate/{startDate}", Name = "Edit_Production_ProductCostHistory")]
        public async Task<IActionResult> EditProductCostHistory(int productID, DateTime startDate, [FromBody] Production.ProductCostHistory value)
        {
            var existing = await _db.Production_ProductCostHistory.FirstOrDefaultAsync(x => x.ProductID == productID && x.StartDate == startDate);
            if (existing == null)
            {
                return NotFound();
            }

			existing.ProductID = value.ProductID;
			existing.StartDate = value.StartDate;
			existing.EndDate = value.EndDate;
			existing.StandardCost = value.StandardCost;
			existing.ModifiedDate = value.ModifiedDate;

            _db.Production_ProductCostHistory.Update(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		[HttpDelete("", Name = "Delete_Production_ProductCostHistory")]
        public async Task<IActionResult> DeleteProductCostHistory(int productID, DateTime startDate)
        {
            var existing = await _db.Production_ProductCostHistory.FirstOrDefaultAsync(x => x.ProductID == productID && x.StartDate == startDate);
            if (existing == null)
            {
                return NotFound();
            }
            _db.Production_ProductCostHistory.Remove(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		// No GetByUniqueKeyActions generated

		// No EditByUniqueKeyActions generated

		// No DeleteByUniqueKeyActions generated

	}
}